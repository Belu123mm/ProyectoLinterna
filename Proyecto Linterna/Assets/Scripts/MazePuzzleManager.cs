using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePuzzleManager : ListPuzzleManager
{
    // Start is called before the first frame update

    public GameObject walls;


    void CheckDoor()    //Cada vez que prende o apaga checkea la puerta
    {
        int lighton = 1;
        foreach (LightObjectListed l in turnonlightobject)
        {

            if (l.hasLight)
            {
                lighton++;
            }

        }
        if (lighton == turnonlightobject.Count)
        {
            walls.SetActive(true);

        }
        else
        {
            walls.SetActive(false);
        }
    }
}
