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
    public GameObject grabbedposition;
    public LayerMask grabbedobjects;
    public bool isPaused;
    public GameObject pausePanel;
    void Start()
    {
        _controller = new CharacterController(new CharacterModel(this, view, camController, groundsensor, lamp, grabbedobjects, grabbedposition));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }
        if (isPaused)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
        if (!isPaused)
            _controller.OnUpdate();
    }
    void FixedUpdate()
    {
        if (!isPaused)
            _controller.OnFixedUpdate();
    }
}
