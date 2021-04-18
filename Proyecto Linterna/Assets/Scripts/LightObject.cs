using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    public bool hasLight;
    public GameObject lightobject;
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
