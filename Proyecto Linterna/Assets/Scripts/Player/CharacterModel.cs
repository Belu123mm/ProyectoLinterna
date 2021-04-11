using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel
{
    CharacterView _view;
    CameraController cameraController;
    Character _character;
    BasicSensor _sensor;
    public CharacterModel(Character ch, CharacterView view, CameraController cam, BasicSensor groundSensor)
    {
        _character = ch;
        _view = view;
        cameraController = cam;
        _sensor = groundSensor;
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

}
