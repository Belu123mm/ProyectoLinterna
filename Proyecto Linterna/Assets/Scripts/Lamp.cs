using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public bool hasLight;
    public float radius;
    public GameObject lightobject;
    public LayerMask objects;
    public void GiveLight()
    {
        lightobject.SetActive(false);
        hasLight = false;
    }
    public void GetLight()
    {
        lightobject.SetActive(true);
        hasLight = true;
    }

}
