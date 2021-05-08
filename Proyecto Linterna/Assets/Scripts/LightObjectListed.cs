using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LightObjectListed : LightObject
{
    Action OnGet;
    Action OnGive;
    public ListPuzzleManager puzzleManager;
    public override void GetLight()
    {
        base.GetLight();
        Debug.Log("Lighted");
        OnGet();
    }
    public override void GiveLight()
    {
        base.GiveLight();
        OnGive();
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
