using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    public float screamTime;
    public AudioSource scream;
    public GameObject player;
    public GameObject screamCamera;
    private void OnTriggerEnter(Collider other)
    {
        scream.Play();
        player.SetActive(false);
        screamCamera.SetActive(true);
        StartCoroutine(EndScream());
    }
    IEnumerator EndScream()
    {
        yield return new WaitForSeconds(screamTime);
        player.SetActive(true);
        screamCamera.SetActive(false);
    }
}
