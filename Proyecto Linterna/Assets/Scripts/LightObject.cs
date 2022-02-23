using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    public bool hasLight;
    public GameObject lightobject;
    Character ch;
    public GameObject ui;
    private void Start()
    {
        ch = FindObjectOfType<Character>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position,ch.transform.position) < 4)
        {
            ui.SetActive(true);
            //ui.transform.LookAt(Camera.main.transform);
        }
        else
        {
            ui.SetActive(false);
        }
    }
    public virtual void GiveLight()
    {
        if (hasLight)
        {

            hasLight = false;

            lightobject.SetActive(false);
        }

    }
    public virtual void GetLight()
    {
        if (!hasLight)
        {
            hasLight = true;

            lightobject.SetActive(true);
        }
    }
}
