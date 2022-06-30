using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AOEAttack : MonoBehaviour
{
    //Variables that will be for death such as leveling up, drop items etc
    GameObject Player;
    Vector3 EnemyPosition;
    float exp;
    public GameObject GoldPrefab;
    public GameObject[] Item;
    public GameObject Minion;
    
    //Used to get the enemy to perform various tasks
    GameObject Enemy;
    
    //Variables to set the attack damage and the duration of the attack
    [HideInInspector]public float AttackDamage;
    [HideInInspector]public float AttackTime;
    
    //Used if AOE performs dot damage
    [HideInInspector]public bool DotActivate;
    [HideInInspector]public int DotDamage;

    //Used if the AOE becomes smaller with every hit
    [HideInInspector]public bool AOEBecomesSmaller;
    int Counter;

    //Creates the minion
    [HideInInspector] public bool CreatesMinion;

    //Stores boss
    private Boss1 Boss;

    //Checks to make sure the enemy is fighting
    private bool IsFighting;

    private void Start()
    {
        //Destroys the AOE after the set amount of time in Attack Time
        Invoke("DestroyMe", AttackTime);
        //Finds player
        Player = GameObject.Find("Player");
        //Sets enemy to null to avoid logic errors when not being used
        Enemy = null;
        Item = Player.GetComponent<PlayerCombat>().Item;
    }

    private void Update()
    {
        //cancels the attack if enemy isn't touching the AOE
        if(Enemy == null)
        {
            CancelInvoke("Attack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If an enemy touches the AOE
        if(other.tag == "Enemy")
        {
            //Sets the enemy variable to the enemy it's collided with
            Enemy = other.gameObject;
            //changes code if the enemy is ranged
            if(Enemy.GetComponent<EnemyAI>() == null)
            {
                //checks the enemy isn't dead
                if (Enemy.GetComponent<RangedEnemyAI>().EnemyHealth != 0)
                {
                    //Activates Dot damage if effect is set to true
                    if (DotActivate == true)
                    {
                        //Sets burning to activate on the enemy
                        Enemy.GetComponent<RangedEnemyAI>().IsBurning = true;
                        //Sets the amount of damage that will be dealt
                        Enemy.GetComponent<RangedEnemyAI>().BurningDamage = DotDamage;

                        Enemy.GetComponent<RangedEnemyAI>().BurningDuration = 5;
                    }
                    //Activates attack
                    IsFighting = true;
                    StartCoroutine(Attack(false));
                }
            }
            else
            {
                //checks the enemy isn't dead
                if (Enemy.GetComponent<EnemyAI>().EnemyHealth != 0)
                {
                    //Activates Dot damage if effect is set to true
                    if (DotActivate == true)
                    {
                        //Sets burning to activate on the enemy
                        Enemy.GetComponent<EnemyAI>().IsBurning = true;
                        //Sets the amount of damage that will be dealt
                        Enemy.GetComponent<EnemyAI>().BurningDamage = DotDamage;

                        Enemy.GetComponent<EnemyAI>().BurningDuration = 5;
                    }
                    //Activates attack
                    IsFighting = true;
                    StartCoroutine(Attack(false));
                }
            }
        }

        //if a boss touches the AOE
        if(other.tag == "Boss")
        {
            //Gets the script that stores the boss' information
            Boss = other.GetComponent<Boss1>();

            //Boss only takes damage if it is vulnerable
            if (Boss.Vulnerable && DotActivate)
            {
                //Starts the coroutine that has the boss take burning damage
                StartCoroutine(Boss.IsBurned(5, DotDamage));
            }
            //Deals damage to the boss if it is vulnerable
            else if (Boss.Vulnerable)
            {
                if (!IsFighting)
                {
                    IsFighting = true;
                    StartCoroutine(Attack(true));
                }
            }
        }

        if(other.tag == "Barrier")
        {
            other.GetComponent<BarrierScript>().Health -= AttackDamage;
        }
    }

    void DestroyMe()
    {
        //Destorys AOE
        Destroy(transform.gameObject);
    }

    IEnumerator Attack(bool InBossRoom)
    {
        while (IsFighting)
        {
            //Checks if the enemy is a boss or not
            if (!InBossRoom)
            {
                //Stops the AOE from activating if the enemy is destroyed by something else
                if (Enemy)
                {
                    //Code changes slighly for ranged enemies
                    if (Enemy.GetComponent<EnemyAI>() == null)
                    {
                        //Lowers enemy's attack
                        Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage;
                        //Displays floating text of damage being delt
                        FloatingTextController.CreatFloatingText(AttackDamage.ToString(), Enemy.transform);
                        //check that is the enemy health goes under 0 through methods other then the auto attack
                        if (Enemy.GetComponent<RangedEnemyAI>().EnemyHealth <= 0)
                        {
                            //Reactivates the navmesh for the player to start moving
                            Player.GetComponent<NavMeshAgent>().isStopped = false;
                            //Spawn Gold
                            EnemyPosition = Enemy.GetComponent<Transform>().position;
                            Instantiate(GoldPrefab, EnemyPosition, Quaternion.identity);
                            //Unlocks the player's postion
                            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            //makes enemy into enemy into minion
                            if (CreatesMinion == true && (Player.GetComponent<PlayerCombat>().MaxNumOfMinions > Player.GetComponent<PlayerCombat>().MinionCount))
                            {
                                Instantiate(Minion, Enemy.transform.position, Quaternion.identity);
                                Player.GetComponentInChildren<PlayerAudio>().SummonMinion.Play();
                                Player.GetComponent<PlayerCombat>().MinionCount += 1;
                            }
                            //Adds experiance
                            exp = Player.GetComponent<PlayerStats>().exp;
                            exp += Enemy.GetComponent<EnemyStates>().EXPGiven;
                            Player.GetComponent<PlayerStats>().exp = exp;
                            //Delete enemy
                            Destroy(Enemy.gameObject);
                            //Empty the enemy variable
                            Enemy = null;
                            Player.GetComponent<PlayerCombat>().Enemy = null;
                            //Allows player to start regening health and stamina
                            Player.GetComponent<PlayerStats>().Rest = true;
                            //Stops Invoke from activating
                            Player.GetComponent<PlayerCombat>().SendMessage("StopInvoke");
                            StopCoroutine(Attack(false));
                            IsFighting = false;
                            //Spanws a item 40% of the time
                            if (Random.value > 0.6)
                            {
                                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                            }

                        }
                    }
                    else
                    {
                        //Lowers enemy's attack
                        Enemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage;
                        //Displays floating text of damage being delt
                        FloatingTextController.CreatFloatingText(AttackDamage.ToString(), Enemy.transform);
                        //check that is the enemy health goes under 0 through methods other then the auto attack
                        if (Enemy.GetComponent<EnemyAI>().EnemyHealth <= 0)
                        {
                            //Reactivates the navmesh for the player to start moving
                            Player.GetComponent<NavMeshAgent>().isStopped = false;
                            //Spawn Gold
                            EnemyPosition = Enemy.GetComponent<Transform>().position;
                            Instantiate(GoldPrefab, EnemyPosition, Quaternion.identity);
                            //Unlocks the player's postion
                            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            //makes enemy into enemy into minion
                            if (CreatesMinion == true && (Player.GetComponent<PlayerCombat>().MaxNumOfMinions > Player.GetComponent<PlayerCombat>().MinionCount))
                            {
                                Instantiate(Minion, Enemy.transform.position, Quaternion.identity);
                                Player.GetComponentInChildren<PlayerAudio>().SummonMinion.Play();
                                Player.GetComponent<PlayerCombat>().MinionCount += 1;
                            }
                            //Adds experiance
                            exp = Player.GetComponent<PlayerStats>().exp;
                            exp += Enemy.GetComponent<EnemyStates>().EXPGiven;
                            Player.GetComponent<PlayerStats>().exp = exp;
                            //Delete enemy
                            Destroy(Enemy.gameObject);
                            //Empty the enemy variable
                            Enemy = null;
                            Player.GetComponent<PlayerCombat>().Enemy = null;
                            //Allows player to start regening health and stamina
                            Player.GetComponent<PlayerStats>().Rest = true;
                            //Stops Invoke from activating
                            Player.GetComponent<PlayerCombat>().SendMessage("StopInvoke");
                            StopCoroutine(Attack(false));
                            IsFighting = false;
                            //Spanws a item 40% of the time
                            if (Random.value > 0.6)
                            {
                                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                            }
                        }
                    }
                }
                else
                {
                    StopCoroutine(Attack(false));
                    IsFighting = false;
                }
            }
            else
            {
                //Lowers the boss' health
                Boss.Health -= AttackDamage;
                //Displays floating text of damage being delt
                FloatingTextController.CreatFloatingText(AttackDamage.ToString(), Boss.transform);
            }

            //If the AOE needs to become smaller after every hit the MakeMeSmaller function will activate
            if (AOEBecomesSmaller == true)
            {
                MakeMeSmaller();
            }

            //Wait for a few seconds before peforming next loop
            yield return new WaitForSeconds(3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Cancels attack if the enemy leaves collider
        if (other.gameObject.tag == "Enemy")
        {
            Enemy = null;
            IsFighting = false;
            StopCoroutine(Attack(false));
        }
    }

    void MakeMeSmaller()
    {
        //The AOE can only get so small so a counter is used to both make the enemy smaller and delete it if it becomes too small
        switch (Counter)
        {
            case 0:
                {
                    // Adds to the counter
                    Counter += 1;
                    //Lowers the AOE's size by 2
                    transform.localScale = new Vector3(18f, 18f, 2f);
                    break;
                }
            case 1:
                {
                    // Adds to the counter
                    Counter += 1;
                    //Lowers the AOE's size by 2
                    transform.localScale = new Vector3(16f, 16f, 2f);
                    break;
                }
            case 2:
                {
                    // Adds to the counter
                    Counter += 1;
                    //Lowers the AOE's size by 2
                    transform.localScale = new Vector3(14f, 14f, 1.4f);
                    break;
                }
            case 3:
                {
                    // Adds to the counter
                    Counter += 1;
                    //Lowers the AOE's size by 1
                    transform.localScale = new Vector3(12f, 12f, 1.0f);
                    break;
                }
            case 4:
                {
                    //resets the counter
                    Counter = 0;
                    //Destorys the AOE
                    Destroy(this.gameObject);
                    break;
                }
        }
    }
}
