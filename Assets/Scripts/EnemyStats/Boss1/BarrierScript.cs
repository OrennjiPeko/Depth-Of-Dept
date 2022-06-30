using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BarrierScript : MonoBehaviour
{
    public float Health;
    private PlayerCombat Player;
    public int Floor;

    public GameObject Boss;

    private void Awake()
    {
        Boss = this.transform.parent.gameObject;
    }

    public void Start()
    {
        Floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;

        if (Floor > 10)
        {
            UpdateStats();
        }else if (Floor > 200)
        {
            Health += 10;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            string name = this.name;

            //Depending on the name of the barrier the script will change the corresponding boolean
            switch (name)
            {
                case "Barrier1":
                    {
                        Boss.GetComponentInParent<Boss1>().Barrier1Destroyed = true;
                        break;
                    }
                case "Barrier2":
                    {
                        Boss.GetComponentInParent<Boss1>().Barrier2Destroyed = true;
                        break;
                    }
                case "Barrier3":
                    {
                        Boss.GetComponentInParent<Boss1>().Barrier3Destroyed = true;
                        break;
                    }
                case "Barrier4":
                    {
                        Boss.GetComponentInParent<Boss1>().Barrier4Destroyed = true;
                        break;
                    }
            }

            //Allows the player to move again
            Player.GetComponent<NavMeshAgent>().isStopped = false;
            //Makes the player look for a new target after the barrier has destroyed itself
            Player.GetComponent<PlayerNavi>().Invoke("FindNextTarget", 0.0001f);

            if (GameObject.FindGameObjectsWithTag("Minion").Length != 0)
            {
                //Goes through every minion
                foreach (GameObject Minion in GameObject.FindGameObjectsWithTag("Minion"))
                {
                    //Minion can move again
                    Minion.GetComponent<NavMeshAgent>().isStopped = false;
                    Minion.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    //Will make minion follow the player
                    Minion.GetComponent<MinionAI>().Invoke("SearchForBoss", 0.00001f);
                    Minion.GetComponent<NavMeshAgent>().stoppingDistance = 5;
                }
            }
            //Destroys the barrier game object
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Gets the player's infromation
            Player = other.GetComponent<PlayerCombat>();
            //stops the player from moving
            Player.GetComponent<NavMeshAgent>().isStopped = true;
            //Makes the player look at the barrier
            other.transform.LookAt(this.transform.position);
            //Activates the script that makes the barrier take damage
            StartCoroutine(TakeDamage(Player.AttackDamage, Player.AttackSpeedRank));
        }

        if(other.tag == "Minion")
        {
            other.GetComponent<NavMeshAgent>().isStopped = true;
            other.transform.LookAt(this.transform.position);
            StartCoroutine(TakeDamage(other.GetComponent<MinionAI>().AttackDamage, 5));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //Stops the barrier from taking damage
            StopCoroutine(TakeDamage(0, 0));
            Player = null;
        }

        if(other.tag == "Minion")
        {
            StopCoroutine(TakeDamage(0, 0));
        }
    }

    public IEnumerator TakeDamage(float Damage, float WaitTime)
    {
        //the barrier takes damage
        Health -= Damage;

        //Wait time until auto attack repeats
        yield return new WaitForSeconds(WaitTime);
    }

    public void UpdateStats()
    {
        switch (Floor)
        {
            case 20:
                Health += 5;
                break;
            case 30:
                Health += 5;
                break;
            case 40:
                Health += 5;
                break;
            case 50:
                Health += 5;
                break;
            case 60:
                Health += 5;
                break;
            case 70:
                Health += 5;
                break;
            case 80:
                Health += 5;
                break;
            case 90:
                Health += 5;
                break;
            case 100:
                Health += 5;
                break;
            case 110:
                Health += 5;
                break;
            case 120:
                Health += 5;
                break;
            case 130:
                Health += 5;
                break;
            case 140:
                Health += 5;
                break;
            case 150:
                Health += 5;
                break;
            case 160:
                Health += 5;
                break;
            case 170:
                Health += 5;
                break;
            case 180:
                Health += 5;
                break;
            case 190:
                Health += 5;
                break;
            case 200:
                Health += 5;
                break;

            
                    
        }
    }
}
