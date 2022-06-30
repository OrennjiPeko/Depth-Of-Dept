using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    // uses array to pull GoHere gameobjects into single place
    public GameObject[] GoHere;
    public GameObject MoveHere;
   
    int MaxDesticationnumber = 1;
    int Destication = 0;

    private void Update()
    {
        if (Destication <= MaxDesticationnumber)
        {
            int spawn = Random.Range(0, GoHere.Length);
            if (Random.value < 0.5)
            {
                GameObject.Instantiate(MoveHere, GoHere[spawn].transform.position, Quaternion.identity);
                Destication++;
            }
            else
            {
                GameObject.Instantiate(MoveHere, GoHere[spawn].transform.position, Quaternion.identity);
                Destication++;
            } 
        }
        else if (Destication >= MaxDesticationnumber)
        {
            //end
        }
    }
}
