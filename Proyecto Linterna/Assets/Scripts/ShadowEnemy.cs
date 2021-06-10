using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEnemy : MonoBehaviour
{
    FSM<ShadowStates> _fsm;
    public Transform followed;
    public float distance;
    public float speed;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        SetStates();
    }
    void SetStates()
    {
        var idle = new IdleState<ShadowStates>();
        var walk = new WalkState<ShadowStates>();
        var attack = new AttackState<ShadowStates>();

        walk.Execute = Walking;


        idle.AddTransition(ShadowStates.walk, walk);
        idle.AddTransition(ShadowStates.attack, attack);

        walk.AddTransition(ShadowStates.idle, idle);
        walk.AddTransition(ShadowStates.attack, attack);

        attack.AddTransition(ShadowStates.idle, idle);
        attack.AddTransition(ShadowStates.walk, walk);

        _fsm = new FSM<ShadowStates>();
        _fsm.SetInit(idle);

    }
    // Update is called once per frame
    void Walking()
    {
        var dir = followed.position - transform.position;
        transform.position += dir.normalized / 10 * speed;
    }
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
        if (Vector3.Distance(followed.transform.position, transform.position) < distance)
        {
            if (_fsm.CanTransicion(ShadowStates.walk))
            {
                _fsm.Transition(ShadowStates.walk);
            }
        }
        if (!isPaused)
            _fsm.OnUpdate();
    }
}
public enum ShadowStates
{
    idle,
    walk,
    attack
}
