using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawn : MonoBehaviour
{
   public GameObject Chest;
    // ints used to spawn 2 chests in a level
   [HideInInspector] public int chestNumber = 0;
   [HideInInspector] public int MaxNumber = 1;

    public GameObject [] chestspawnpoints;


    public void Update()
    {

        if (chestNumber <= MaxNumber)
        {
            chestspawnpoints = GameObject.FindGameObjectsWithTag("ChestSpawn");
            int spawn = Random.Range(0, chestspawnpoints.Length);
            
            // Random is used to have 5% chance to spawn a chest in each floor
            if (Random.value < 0.05)
            {

                // spawns the chest into point from the templates for the level
                GameObject go = Instantiate(Chest, chestspawnpoints[spawn].transform.position,chestspawnpoints[spawn].transform.rotation);
                go.name = Chest.name;
                chestNumber++;
            }
            else
            {
                Debug.Log("No Chest");
                chestNumber++;
            }
        }else if (chestNumber >= MaxNumber)
        {
            // gets rid of the chest spawn tag from all the templates 
            Destroy(GameObject.FindWithTag("ChestSpawn"));
        }
    }




}
