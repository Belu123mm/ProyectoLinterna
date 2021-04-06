using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    public FPSPlayer player;
    public BasicSensor groundSensor;
    public BasicSensor wallSensor;
    public float mouseXSensibility = 1;
    public float mouseYSensibility = 1;
    FSM<PlayerStates> _fsm;
    CameraController camContr;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camContr = GetComponent<CameraController>();
        SetFSM();
    }
    void SetFSM()
    {
        var idle = new BaseState<PlayerStates>();
        var walk = new BaseState<PlayerStates>();
        var jump = new BaseState<PlayerStates>();
        var wallJump = new BaseState<PlayerStates>();
        var switchlight = new BaseState<PlayerStates>();

        //behaviourz
        walk.Execute = Movement;
        jump.OnAwake = Jump;
        wallJump.OnAwake = Jump;
        switchlight.OnAwake = SwitchLight;

        idle.AddTransition(PlayerStates.walk, walk);
        idle.AddTransition(PlayerStates.jump, jump);
        idle.AddTransition(PlayerStates.wallJump, wallJump);
        idle.AddTransition(PlayerStates.switchlight, switchlight);
        walk.AddTransition(PlayerStates.idle, idle);
        walk.AddTransition(PlayerStates.jump, jump);
        walk.AddTransition(PlayerStates.wallJump, wallJump);
        walk.AddTransition(PlayerStates.switchlight, switchlight);
        jump.AddTransition(PlayerStates.idle, idle);
        jump.AddTransition(PlayerStates.walk, walk);
        jump.AddTransition(PlayerStates.wallJump, wallJump);
        jump.AddTransition(PlayerStates.switchlight, switchlight);
        wallJump.AddTransition(PlayerStates.idle, idle);
        wallJump.AddTransition(PlayerStates.walk, walk);
        wallJump.AddTransition(PlayerStates.switchlight, switchlight);
        switchlight.AddTransition(PlayerStates.idle, idle);
        switchlight.AddTransition(PlayerStates.jump, jump);
        switchlight.AddTransition(PlayerStates.walk, walk);
        switchlight.AddTransition(PlayerStates.wallJump, wallJump);

        _fsm = new FSM<PlayerStates>(idle);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wallSensor.CheckIsLayer() + "walll");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundSensor.CheckIsLayer())
            {
                if (_fsm.CanTransicion(PlayerStates.jump))
                {
                    _fsm.Transition(PlayerStates.jump);
                }
            }
            else if (wallSensor.CheckIsLayer())
            {
                if (_fsm.CanTransicion(PlayerStates.wallJump))
                    Debug.Log("SALTAALAPARED");
                {
                    _fsm.Transition(PlayerStates.wallJump);
                }
            }

        }
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (_fsm.CanTransicion(PlayerStates.walk))
            {
                _fsm.Transition(PlayerStates.walk);
            }
        }

        else
        {

            if (_fsm.CanTransicion(PlayerStates.idle))
            {
                _fsm.Transition(PlayerStates.idle);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("owo");
            if (_fsm.CanTransicion(PlayerStates.switchlight))
            {
                Debug.Log("owo2");
                _fsm.Transition(PlayerStates.switchlight);
            }
        }


    }
    void FixedUpdate()
    {
        if (!groundSensor.CheckIsLayer())
        {
            player.Gravity();
        }
        _fsm.OnUpdate();

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        player.Rotate(x);
        //Independientemente de la fsm la camara se tiene que mover
        camContr.MoveCamera(x * mouseXSensibility, y * mouseYSensibility);
        //gravedad?
    }
    void Movement()
    {
        Vector3 dir = camContr.cameraParent.forward * Input.GetAxis("Vertical") + camContr.cameraParent.right * Input.GetAxis("Horizontal");
        player.Movement(dir);
    }
    void Jump()
    {
        player.Jump(wallSensor.GetNormal());
    }
    void SwitchLight()
    {
        player.SwitchLamp();
    }
}

