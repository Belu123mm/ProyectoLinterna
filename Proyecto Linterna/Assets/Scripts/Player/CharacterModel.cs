using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel
{
    CharacterView _view;
    CameraController _cameraController;
    Character _character;
    BasicSensor _sensor;
    Lamp _lamp;
    bool isGrabbing;
    LayerMask _grabbedObject;
    GameObject _grabbedposition;
    public CharacterModel(Character ch, CharacterView view, CameraController cam, BasicSensor groundSensor, Lamp lamp, LayerMask grabbedObject, GameObject grabbedPosition)
    {
        _character = ch;
        _view = view;
        _cameraController = cam;
        _sensor = groundSensor;
        _lamp = lamp;
        _grabbedObject = grabbedObject;
        _grabbedposition = grabbedPosition;
    }
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Movement(float v, float h)
    {
        Vector3 dir = _cameraController.cameraParent.forward * v + _cameraController.cameraParent.right * h;
        dir.y = 0;
        Vector3 newPos = _character.transform.position;
        _character.rb.MovePosition(newPos + dir.normalized * _character.speed * Time.deltaTime);
    }
    public void Rotate(float x)
    {
        Vector3 rotateCameraVector3 = _character.transform.rotation.eulerAngles;

        rotateCameraVector3.x = x;

        _character.transform.Rotate(Vector3.up * x * 50 * Time.deltaTime);

    }
    public void MoveCamera(float x, float y)
    {
        _cameraController.MoveCamera(x * _character.mouseXSensibility, y * _character.mouseYSensibility);
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
                c.GetComponent<LightObject>().GiveLight();
                //_lamp.GetLight();
            }
            else
            {
                c.GetComponent<LightObject>().GetLight();
                //_lamp.GiveLight();
            }

        }
    }
    public void GrabSomething()
    {
        Debug.Log("trygrabbing");
        if (isGrabbing)
        {
            Release();
        }
        else
        {
            Grab();
        }

    }
    void Grab()
    {
        RaycastHit owo;
        if (Physics.Raycast(_cameraController.cameraTransform.position, _cameraController.cameraTransform.forward, out owo, Mathf.Infinity, _grabbedObject))
        {
            isGrabbing = true;
            //Poner este objeto como hijo del gameobject
            owo.transform.SetParent(_grabbedposition.transform);
            owo.collider.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void Release()
    {
        isGrabbing = false;
        _grabbedposition.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        _grabbedposition.transform.DetachChildren();
    }
}
