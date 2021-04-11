using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController
{
    CharacterModel _model;
    public CharacterController(CharacterModel model)
    {
        _model = model;
    }
    public void OnUpdate()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            _model.Movement(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
        if (Input.GetKeyDown(KeyCode.Space))
            _model.Jump();

    }
    public void OnFixedUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        _model.Rotate(x);
        //Independientemente de la fsm la camara se tiene que mover
        _model.MoveCamera(x, y);
    }
}

