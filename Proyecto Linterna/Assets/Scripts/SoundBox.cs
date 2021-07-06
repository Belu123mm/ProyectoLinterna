using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource source;
    public AudioClip clip;
public LayerMask layer;
public bool played;


    public void OnTriggerEnter(Collider c){
        if(c.gameObject.tag == "Player" ){
            Debug.Log("Etered");
            if (!played){
                source.PlayOneShot(clip);
                played = true;

            }
        }
    }
}
