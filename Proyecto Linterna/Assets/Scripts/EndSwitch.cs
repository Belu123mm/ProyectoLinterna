using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float distance;
public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)){

    if( Vector3.Distance(player.position,transform.position)< distance)
    {
        StartCoroutine("ActivateSwitch");
        Debug.Log("TryingToenter");
    }
        }
    }
    IEnumerator ActivateSwitch(){
        anim.SetBool("isOn",true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
    }
}
