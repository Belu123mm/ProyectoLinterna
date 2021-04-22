using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<LightObjectListed> turnonlightobject;

    public List<LightObject> playerobjects;
    public GameObject door;
    public void Start()
    {
        foreach (var l in turnonlightobject)
        {
            l.SetGet(CheckDoor);
            l.SetGive(CheckDoor);
        }
    }

    void CheckDoor()    //Cada vez que prende o apaga checkea la puerta
    {
        int lighton = 0;
        foreach (LightObjectListed l in turnonlightobject)
        {

            if (l.hasLight)
            {
                lighton++;
            }

        }
        if (lighton == turnonlightobject.Count)
        {
            door.SetActive(false);

        }
        else
        {
            door.SetActive(true);
        }
    }
}
