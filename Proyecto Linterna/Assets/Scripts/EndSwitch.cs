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
    public GameObject particlePrefab1;
    public GameObject particlePrefab2;
    public Transform sparktransform;
    public Transform lighttransform;
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
        Instantiate(particlePrefab1, sparktransform.position, Quaternion.identity);
        Instantiate(particlePrefab2, lighttransform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
    }
}
