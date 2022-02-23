using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowEnemy : MonoBehaviour
{
    FSM<ShadowStates> _fsm;
    public Transform followed;
    public float distanceToFollow;
    public float distanceToAttack;
    public float speed;
    public bool isPaused;
    public Animator anim;
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
        attack.Execute = () => SceneManager.LoadScene(1);
        idle.Execute = Idle;


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
        transform.position += dir.normalized / 10 * speed * Time.deltaTime;
        transform.forward = dir.normalized;
        anim.SetBool("walking",true);
    }
    void Idle(){
anim.SetBool("walking",false);
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
        if (Vector3.Distance(followed.transform.position, transform.position) < distanceToFollow)
        {
            if (_fsm.CanTransicion(ShadowStates.walk))
                {
                    _fsm.Transition(ShadowStates.walk);
                }
            if (Vector3.Distance(followed.transform.position, transform.position) < distanceToAttack)
            {
                if (_fsm.CanTransicion(ShadowStates.attack))
                {
                    _fsm.Transition(ShadowStates.attack);
                }
                 
            }
        } else
        {
            if(_fsm.CanTransicion(ShadowStates.idle)){
                _fsm.Transition(ShadowStates.idle);
            }
        }
        if (!isPaused)
            _fsm.OnUpdate();
    }
void OnDrawGizmos(){
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position,distanceToFollow);
Gizmos.color = Color.red;
Gizmos.DrawWireSphere(transform.position,distanceToAttack);
}
}
public enum ShadowStates
{
    idle,
    walk,
    attack
}
