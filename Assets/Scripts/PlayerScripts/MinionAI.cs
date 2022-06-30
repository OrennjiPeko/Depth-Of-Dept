using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MinionAI : MonoBehaviour
{
    //Stores minions health
    public float MinionHealth;
    //Stores navmeshagent
    private NavMeshAgent MinionTarget;
    //stores player
    [HideInInspector]public GameObject Player;
    //stores all the enemies
    private GameObject[] Enemies;
    //Stores the target enemy
    private GameObject TargetedEnemy;
    //stores enemy postion
    private Vector3 EnemyPosition;
    //Bool used to check if an enemy is found
    private bool EnemyFound;
    //Stores minion's attack
    public float AttackDamage;
    //Stores gold prefab
    public GameObject GoldPrefab;
    //Stores Test item prefab
    public GameObject[] Item;
    //Stored minion's rigibody
    private Rigidbody RB;

    //Damage Gift Giver will do if activated
    public float GiftGiverDamage;

    //Used when a minion is in a boss room
    bool InBossRoom;
    private GameObject[] Barriers;
    private GameObject Boss;
   [HideInInspector] public float Itemdroprate;
    // Start is called before the first frame update
    void Start()
    {
        //Sets player variable as the player
        Player = GameObject.FindGameObjectWithTag("Player");
        //Tells the player there is a minion on the scene
        Player.GetComponent<PlayerCombat>().MinionOnScene = true;
        //Stores all enemies in the enemy array
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Sets RB to the minion's rigibody
        RB = GetComponent<Rigidbody>();
        //gets minion's navmeshagent
        MinionTarget = GetComponent<NavMeshAgent>();
        //sets the player as the minion's destination
        MinionTarget.SetDestination(Player.transform.position);
        //Makes the enemy stop before touching the player
        MinionTarget.stoppingDistance = 3;
        //Enemy isn't found at the start
        EnemyFound = false;
        Item = Player.GetComponent<PlayerCombat>().Item;
        Itemdroprate = Player.GetComponent<PlayerStats>().ItemDroprate;
        if(SceneManager.GetActiveScene().name == "BossRoom")
        {
            InBossRoom = true;
            Barriers = GameObject.FindGameObjectsWithTag("Barrier");
            Boss = GameObject.FindGameObjectWithTag("Boss");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Only activates if the enemy hasn't been found
        if (EnemyFound == false)
        {
            MinionTarget.stoppingDistance = 3;
            if (!InBossRoom)
            {
                this.GetComponent<NavMeshAgent>().isStopped = false;
                //Sets the minion's destination to the player
                MinionTarget.destination = Player.transform.position;
                //A for each loop to check through every enemy in the scene
                foreach (GameObject Enemy in Enemies)
                {
                    //Returns if the enemy has been destroyed
                    if (Enemy != null)
                    {
                        //Checks the distance between itself and the enemies, if it's close code activates
                        if (Vector3.Distance(this.transform.position, Enemy.transform.position) < 19)
                        {
                            //Sets the enemy that is close enough to the target
                            TargetedEnemy = Enemy;
                            //Sets the minion's destination to the targeted enemy
                            MinionTarget.destination = TargetedEnemy.transform.position;
                            //resets stopping distance
                            MinionTarget.stoppingDistance = 0;
                            //Sets enemy found to true to stop this code from activating while targeted
                            EnemyFound = true;
                            Debug.Log(this.name + " found enemy");
                        }
                    }
                }
                //if the minion is too close to the player it will move away from the player to prevent it from blocking the player's path
                if (Vector3.Distance(this.transform.position, Player.transform.position) < 5)
                {
                    Debug.Log("Move back " + this.name + MinionTarget.isStopped);
                    //Calculates the distance between the minion and the player as a vector 3
                    Vector3 Distance = new Vector3(Player.transform.position.x - this.transform.position.x, Player.transform.position.y - this.transform.position.y, Player.transform.position.z - this.transform.position.z);
                    //Sets the minions to move away from the player
                    MinionTarget.destination = transform.forward - (Distance);
                }

                //Don't continue function if neither item is there
                if (GameObject.FindGameObjectsWithTag("Item").Length == 0 && GameObject.FindGameObjectsWithTag("Gold").Length == 0) return;

                //Check if there is more then 0 items on scene
                if (GameObject.FindGameObjectsWithTag("Item").Length > 0)
                {
                    //Stores all the items on a scene
                    GameObject[] Items = GameObject.FindGameObjectsWithTag("Item");
                    //Checks the distance between the minion and each item
                    foreach(GameObject Item in Items)
                    {
                        if (Vector3.Distance(this.transform.position, Item.transform.position) < 5)
                        {
                            //Sets the item that is close enough to the target
                            TargetedEnemy = Item;
                            //Sets the minion's destination to the targeted item
                            MinionTarget.destination = TargetedEnemy.transform.position;
                            //Sets enemy found to true to stop this code from activating while targeted
                            EnemyFound = true;
                            //resets stopping distance
                            MinionTarget.stoppingDistance = 0;
                        }
                    }
                }

                if(GameObject.FindGameObjectsWithTag("Gold").Length > 0)
                {
                    //Stores all the items on a scene
                    GameObject[] Gold = GameObject.FindGameObjectsWithTag("Item");
                    //Checks the distance between the minion and each item
                    foreach (GameObject GoldPiece in Gold)
                    {
                        if (Vector3.Distance(this.transform.position, GoldPiece.transform.position) < 5)
                        {
                            //Sets the gold piece that is close enough to the target
                            TargetedEnemy = GoldPiece;
                            //Sets the minion's destination to the targeted gold piece
                            MinionTarget.destination = TargetedEnemy.transform.position;
                            //Sets enemy found to true to stop this code from activating while targeted
                            EnemyFound = true;
                            //resets stopping distance
                            MinionTarget.stoppingDistance = 0;
                        }
                    }
                }
            }
            else
            {
                SearchForBoss();
            }
        }

        //only activates if the enemy has been found, updates minion on enemy's postion
        if(EnemyFound == true)
        {
            //a check if the targeted enemy is still on the scene
            if(TargetedEnemy.gameObject != null)
            {
                MinionTarget.destination = TargetedEnemy.transform.position;
            }
            else
            {
                EnemyFound = false;
            }
    
        }
    }


    public void SearchForBoss()
    {
        //Follow the player
        MinionTarget.destination = Player.transform.position;

        //Checks if there is any barriers on the scene
        if (GameObject.FindGameObjectsWithTag("Barrier").Length != 0)
        {
            //Go through each barrier
            foreach(GameObject Barrier in Barriers)
            {
                //Do nothing if the barrier has been destroyed
                if (Barrier == null) return;

                //Check the distance between the minion and the barrier
                if(Vector3.Distance(this.transform.position, Barrier.transform.position) < 10)
                {
                    //Barrier is the target
                    TargetedEnemy = Barrier;
                    //Sets the minion's target to the barrier
                    MinionTarget.destination = TargetedEnemy.transform.position;
                    //Stopping distance set to 0
                    MinionTarget.stoppingDistance = 0;
                    //Minion has a target now
                    EnemyFound = true;
                }
            }
        }
        else
        {
            if (Boss)
            {
                //Checks if the minion is close enough to the boss
                if (Vector3.Distance(this.transform.position, Boss.transform.position) < 10)
                {
                    //Boss is the target
                    TargetedEnemy = Boss;
                    //Sets the minion's target to the barrier
                    MinionTarget.destination = TargetedEnemy.transform.position;
                    //Stopping distance set to 0
                    MinionTarget.stoppingDistance = 0;
                    //Minion has a target now
                    EnemyFound = true;
                }
            }
            else
            {
                InBossRoom = false;
            }
        }
    }

    //Lower's enemy's and minion's health
    void Attack()
    {
        if (!InBossRoom)
        {
            //Checks if enemy is still on scene
            if (TargetedEnemy)
            {
                //Check to see if the enemy is ranged or not and actiavtes appropriate code
                if (TargetedEnemy.GetComponent<EnemyAI>() != null)
                {
                    //Deals double damage if the enemy is frozen
                    if (TargetedEnemy.GetComponent<EnemyAI>().IsFrozen == true)
                    {
                        TargetedEnemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage * 2;
                    }
                    //deals normal damage if enemy isn't frozen
                    else
                    {
                        TargetedEnemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage;
                    }

                    if(TargetedEnemy.GetComponent<EnemyCombat>().CanAttack == true)
                    {
                        MinionHealth -= TargetedEnemy.GetComponent<EnemyCombat>().AttackDamage;
                    }
                }
                else
                {
                    //Deals double if the enemy is frozen
                    if (TargetedEnemy.GetComponent<RangedEnemyAI>().IsFrozen == true)
                    {
                        TargetedEnemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage * 2;
                    }
                    //Deals normal damage
                    else
                    {
                        TargetedEnemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage;
                    }
                }
            }
            else
            {
                EnemyFound = false;
            }

            //Check if the enemy is dead
            EnemyDeathCheck();
            //checks if the minion is dead
            MinionDeathCheck();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the enemy collides with the minion
        if (other.tag == "Enemy")
        {
            //sets the enemy to targeted enemy (should already be the there but if just a safety net in case it touches a different enemy then what was originally targeted)
            TargetedEnemy = other.gameObject;
            //Stops the minion from sliding away and prevents it from moving
            this.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            this.GetComponent<NavMeshAgent>().isStopped = true;
            //Freezes the minion's position and roation
            RB.constraints = RigidbodyConstraints.FreezePosition;
            RB.constraints = RigidbodyConstraints.FreezeRotation;
            //Perfroms all the previous action but for the enemy instead of the enemy
            TargetedEnemy.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            TargetedEnemy.GetComponent<NavMeshAgent>().isStopped = true;
            TargetedEnemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //Starts attack function
            InvokeRepeating("Attack", 0, 5);
        }

        if (other.tag == "Item")
        {
            Inventory Inventory = GameObject.Find("PlayerData").GetComponent<Inventory>();

            Item item = other.GetComponent<Item>();

            Inventory.AddItem(other.gameObject, item, item.ID, item.type, item.description, item.icon);

            EnemyFound = false;
        }

        if(other.tag == "Gold")
        {
            EnemyFound = false;
        }
    }

    //checks if the minion dies
    void MinionDeathCheck()
    {
        //If the minion's health is 0 or below
        if(MinionHealth <= 0)
        {
            //resets the enemy back to normal
            TargetedEnemy.GetComponent<NavMeshAgent>().isStopped = false;
            TargetedEnemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //cancels the attack function
            CancelInvoke("Attack");
            Player.GetComponent<PlayerCombat>().MinionCount -= 1;
            //Checks if there are any minions left on the scene, set to activate after 1 frame so the minion that activated it isn't included
            Player.GetComponent<PlayerCombat>().Invoke("MinionCheck", 0.0001f);
            //Minion death sound
            
            Player.GetComponentInChildren<PlayerAudio>().MinionDeath.Play();
            //destroys itself
            Destroy(this.gameObject);
        }
    }

    //Makes minion go boom if activated
    public void GiftGiverActivated()
    {
        //gets all nearby objects and stores them in array
        Collider[] NearByEnemies = Physics.OverlapSphere(GetComponent<Transform>().position, 10);
        foreach(Collider Hit in NearByEnemies)
        {
            //checks if the game object has the tag Enemy and will only continue if that's the case
            if(Hit.tag == "Enemy")
            {
                //checks if the enemy is ranged or not and activates the correct code
                if(Hit.GetComponent<EnemyAI>() != null)
                {
                    //Lowers the enemy's health
                    Hit.GetComponent<EnemyAI>().EnemyHealth -= GiftGiverDamage;
                }
                else
                {
                    //Lowers the enemy's health
                    Hit.GetComponent<RangedEnemyAI>().EnemyHealth -= GiftGiverDamage;
                }
                //Set's target enemy to hit so the enemy death check works
                TargetedEnemy = Hit.gameObject;
                //checks if the enemy got killed
                EnemyDeathCheck();
            }

            //Lowers Boss' health
            if(Hit.tag == "Boss")
            {
                Hit.GetComponent<Boss1>().Health -= GiftGiverDamage;
            }
        }
        Player.GetComponent<PlayerCombat>().MinionCount -= 1;
        //Checks if there are any minions left on the scene, set to activate after 1 frame so the minion that activated it isn't included
        Player.GetComponent<PlayerCombat>().Invoke("MinionCheck", 0.0001f);
        //Minion destroys itself
        Destroy(this.gameObject);
    }

    void EnemyDeathCheck()
    {
        //Checks if the enemy is still stored
        if (TargetedEnemy)
        {
            //Check to see if the enemy is ranged or not and actiavtes appropriate code
            if (TargetedEnemy.GetComponent<EnemyAI>() != null)
            {
                //check that is the enemy health goes under 0 through methods other then the auto attack
                if (TargetedEnemy.GetComponent<EnemyAI>().EnemyHealth <= 0)
                {
                    //Reactivates the navmesh for the minion to start moving
                    GetComponent<NavMeshAgent>().isStopped = false;
                    MinionTarget.destination = Player.transform.position;
                    MinionTarget.stoppingDistance = 3;
                    EnemyFound = false;
                    //Spawn Gold
                    EnemyPosition = TargetedEnemy.GetComponent<Transform>().position;
                    Instantiate(GoldPrefab, EnemyPosition, Quaternion.identity);
                    //Unlocks the minion's postion
                    RB.constraints = RigidbodyConstraints.None;
                    //Adds experiance to player
                    Player.GetComponent<PlayerStats>().exp += TargetedEnemy.GetComponent<EnemyStates>().EXPGiven * Player.GetComponent<PlayerStats>().EXPBonus;
                    //Delete enemy
                    Destroy(TargetedEnemy.gameObject);
                    Player.GetComponentInChildren<PlayerAudio>().EnemyDeath.Play();
                    //Makes player look for next target
                    Player.GetComponent<PlayerNavi>().FindNextTarget();
                    //Stops Invoke from activating
                    CancelInvoke("Attack");
                    //Spanws a item 40% of the time
                    if (Random.value > Itemdroprate)
                    {
                        Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                        if (Player.GetComponent<PlayerCombat>().HoardSpotterActive)
                        {
                            if (Random.value <= 0.05)
                            {
                                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                            }
                        }
                    }
                }
            }
            else
            {
                //check that is the enemy health goes under 0 through methods other then the auto attack
                if (TargetedEnemy.GetComponent<RangedEnemyAI>().EnemyHealth <= 0)
                {
                    //Reactivates the navmesh for the minion to start moving
                    GetComponent<NavMeshAgent>().isStopped = false;
                    MinionTarget.destination = Player.transform.position;
                    MinionTarget.stoppingDistance = 3;
                    EnemyFound = false;
                    //Spawn Gold
                    EnemyPosition = TargetedEnemy.GetComponent<Transform>().position;
                    Instantiate(GoldPrefab, EnemyPosition, Quaternion.identity);
                    //Unlocks the minion's postion
                    RB.constraints = RigidbodyConstraints.None;
                    //Adds experiance to the player
                    Player.GetComponent<PlayerStats>().exp += TargetedEnemy.GetComponent<EnemyStates>().EXPGiven * Player.GetComponent<PlayerStats>().EXPBonus;
                    //Delete enemy
                    Destroy(TargetedEnemy.gameObject);
                    Player.GetComponentInChildren<PlayerAudio>().EnemyDeath.Play();
                    //Makes player look for next target
                    Player.GetComponent<PlayerNavi>().FindNextTarget();
                    //Stops Invoke from activating
                    CancelInvoke("Attack");
                    //Spanws a item 40% of the time
                    if (Random.value > 0.4)
                    {
                        Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                    }
                }
            }
        }
        else
        {
            EnemyFound = false;
        }
    }
}
