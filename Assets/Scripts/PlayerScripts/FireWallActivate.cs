using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallActivate : MonoBehaviour
{
    //Makes a list of the enemies effected by the barrier
    List<EnemyCombat> Enemies = new List<EnemyCombat>();
    //Stores the boss
    Boss1 Boss;

    private void OnTriggerEnter(Collider other)
    {
        //If the FireWall touches an enemy then the enemy will be unable to attack
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyCombat>().CanAttack = false;
            Enemies.Add(other.GetComponent<EnemyCombat>());
        }
        //If the FireWall touches a boss then the boss will be unable to attack
        if(other.tag == "Boss")
        {
            Boss = other.GetComponent<Boss1>();
            Boss.CanAttack = false;
        }
    }

    //Resets the enemy's ability to attack
    public void ResetAttacks()
    {
        //If there enemies are stored in the enemy list
        if (Enemies.Count != 0)
        {
            //The system will go through everything in the list and allow them to attack again
            foreach (EnemyCombat Enemy in Enemies)
            {
                Enemy.CanAttack = true;
            }
        }

        //Allows the boss to attack again
        if(Boss != null)
        {
            Boss.CanAttack = true;
        }
    }
}
