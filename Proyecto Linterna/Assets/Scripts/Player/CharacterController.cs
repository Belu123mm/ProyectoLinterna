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
        
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            _model.SwitchLight();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            _model.MoveLight();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //agarrar y soltar objeto 
            _model.GrabSomething();
        }
    }
    public void OnFixedUpdate()
    {

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        _model.Rotate(x);
        //Independientemente de la fsm la camara se tiene que mover
        _model.MoveCamera(x, y);
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            _model.Movement(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
        if (Input.GetKeyDown(KeyCode.Space))
            _model.Jump();

        if(Input.GetButtonDown("Fire3")){
            if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){

            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
            _model.Dash(dir);
            }else{
                //_model.Dash(_model.transform.forward);
            }

        }
    }
}

