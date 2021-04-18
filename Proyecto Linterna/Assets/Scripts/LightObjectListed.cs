using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LightObjectListed : LightObject
{
    Action OnGet;
    Action OnGive;
    public override void GetLight()
    {
        base.GetLight();
    }
    public override void GiveLight()
    {
        base.GiveLight();
    }
    public void SetGet(Action a)
    {
        OnGet = a;
    }
    public void SetGive(Action a)
    {
        OnGive = a;
    }

}
