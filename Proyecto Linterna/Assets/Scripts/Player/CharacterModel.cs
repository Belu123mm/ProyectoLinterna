using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel
{
    CharacterView _view;
    CameraController cameraController;
    Character _character;
    BasicSensor _sensor;
    Lamp _lamp;
    public CharacterModel(Character ch, CharacterView view, CameraController cam, BasicSensor groundSensor, Lamp lamp)
    {
        _character = ch;
        _view = view;
        cameraController = cam;
        _sensor = groundSensor;
        _lamp = lamp;
    }
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Movement(float v, float h)
    {
        Vector3 dir = cameraController.cameraParent.forward * v + cameraController.cameraParent.right * h;
        dir.y = 0;
        Vector3 newPos = _character.transform.position;
        _character.rb.MovePosition(newPos + dir.normalized * _character.speed * Time.deltaTime);
    }
    public void Rotate(float x)
    {
        Vector3 rotateCameraVector3 = _character.transform.rotation.eulerAngles;

        rotateCameraVector3.y += x;

    }
    public void MoveCamera(float x, float y)
    {
        cameraController.MoveCamera(x * _character.mouseXSensibility, y * _character.mouseYSensibility);
    }
    public void Jump()
    {
        if (_sensor.CheckIsLayer())
        {
            _character.rb.velocity = new Vector3(_character.rb.velocity.x, 0, _character.rb.velocity.z);
            _character.rb.AddForce((Vector3.up + _sensor.GetNormal()).normalized * _character.powerJump, ForceMode.Force);
            Debug.Log("jumpp");

        }
    }
    public void Gravity()
    {
        if (!_sensor.CheckIsLayer())
        {
            _character.rb.AddForce(Vector3.down * _character.gravity, ForceMode.VelocityChange);
        }
    }
    public void SwitchLight()
    {
        if (_lamp.hasLight)
        {
            _lamp.GiveLight();
        }
        else
        {
            _lamp.GetLight();
        }
    }
    public void MoveLight()
    {

        var owo = Physics.OverlapSphere(_lamp.transform.position, _lamp.radius, _lamp.objects);
        if (owo.Length > 0)
        {
            Debug.Log("jsdfjsdf");
            float d = 10000000;
            Collider c = owo[0];
            foreach (var l in owo)
            {
                if (Vector3.Distance(l.transform.position, _lamp.transform.position) < d)
                {
                    d = Vector3.Distance(l.transform.position, _lamp.transform.position);
                    c = l;
                }
            }
            if (c.GetComponent<LightObject>().hasLight)
            {
                Debug.Log(c.GetComponent<LightObject>());
                c.GetComponent<LightObject>().hasLight = false;
                _lamp.GetLight();
                c.GetComponent<LightObject>().lightobject.SetActive(false);
            }
            else
            {
                c.GetComponent<LightObject>().hasLight = true;
                _lamp.GiveLight();
                c.GetComponent<LightObject>().lightobject.SetActive(true);
            }

        }
    }
}
