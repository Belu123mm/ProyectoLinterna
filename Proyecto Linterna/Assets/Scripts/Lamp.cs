using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public bool hasLight;
    public GameObject lightobject;
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
