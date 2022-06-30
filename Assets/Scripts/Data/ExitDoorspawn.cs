using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorspawn : MonoBehaviour
{

    public GameObject Exit;

   [HideInInspector] public GameObject ExitPoint;
    
   
    // ints used for the limit for the end point to spawn 
    int limitExitpoint = 1;
    int LeavePoint = 1;

    private void Update()
    {
        // finds all end hallways with ExitPoint
        ExitPoint = GameObject.FindWithTag("ExitPoint");

        if (LeavePoint <= limitExitpoint)
        {

            //spawns the Exit for the player and adds 1 to leave points 
            GameObject.Instantiate(Exit, ExitPoint.transform.position, ExitPoint.transform.rotation);
            LeavePoint++;
        }else if (LeavePoint >= limitExitpoint)
        {
            // Deletes all the objects with ExitPoint
            Destroy(GameObject.FindWithTag("ExitPoint"));
        }
        
    }
}
