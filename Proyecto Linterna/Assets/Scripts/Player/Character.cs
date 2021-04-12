using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController _controller;
    public CharacterView view;
    public CameraController camController;
    public float speed;
    public Rigidbody rb;
    public float powerJump;
    public BasicSensor groundsensor;
    public float mouseXSensibility = 1;
    public float mouseYSensibility = 1;
    public Lamp lamp;
    public float gravity;
    void Start()
    {
        _controller = new CharacterController(new CharacterModel(this, view, camController, groundsensor, lamp));
    }

    // Update is called once per frame
    void Update()
    {
        _controller.OnUpdate();
    }
    void FixedUpdate()
    {
        _controller.OnFixedUpdate();
    }
}
