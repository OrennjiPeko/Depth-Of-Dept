using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // GameObject that links to the range and close combat enemies, the array used for the all the spawn points the enemies can use to spawn
    public GameObject[] EnemyspawnPoints;
    public GameObject Enemy;
    public GameObject RangeEnemy;
    
    // int used for spawning the enemy and max number to spawn in room
    int MaxEnemyNumber = 1;
    int EnemyNumber = 1;
    
   

    private void Update()
    {
        if (EnemyNumber <= MaxEnemyNumber)
        {
            int spawn = Random.Range(0, EnemyspawnPoints.Length);
            // 50% to spawn a range enemy into spawn point
            if (Random.value<0.5)
            {
                // go used to spawn range enemy into a room.
                GameObject go= Instantiate(RangeEnemy, EnemyspawnPoints[spawn].transform.position, Quaternion.identity);
                // sets go name into RangeEnemy name
                go.name = RangeEnemy.name;
                EnemyNumber++;
                if (GameObject.Find("EnemyData").GetComponent<EnemyData>().NoRangedEnemyFound == false){
                    GameObject.Find("EnemyData").GetComponent<EnemyData>().Invoke("NoRangedEnemiesFound", 0);
                }
            }
            else
            {
                GameObject.Instantiate(Enemy, EnemyspawnPoints[spawn].transform.position, Quaternion.identity);
                EnemyNumber++;
                if (GameObject.Find("EnemyData").GetComponent<EnemyData>().NoEnemyFound == false)
                {
                    GameObject.Find("EnemyData").GetComponent<EnemyData>().Invoke("NoEnemiesFound", 0);
                }
            }
            
            
        }
        else if (EnemyNumber >= MaxEnemyNumber)
        {
            //end
        }
    }
}
