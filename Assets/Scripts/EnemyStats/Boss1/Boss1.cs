using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    //Stores barriers that the player must destory before they can damage the boss
    [HideInInspector] public GameObject Barrier1;
    [HideInInspector] public GameObject Barrier2;
    [HideInInspector] public GameObject Barrier3;
    [HideInInspector] public GameObject Barrier4;
    [HideInInspector] public GameObject[] Item;
    [HideInInspector] public GameObject GoldPrefab;
    [HideInInspector] public float Armour;
    //stores the floor number to change stats
    [HideInInspector] public int floor;

    //Boss stats
    public float Health;
    public float Damage;
    public float EXPGiveOut;
    [HideInInspector] public bool ArmourStatLowered;
    [HideInInspector] public bool HasArmour;
    [HideInInspector] public float BaseDamage;

    //Stores the projectile the enemy will fire
    public Rigidbody Projectile;
    public int ProjectileDamage;
    public int ProjectileImpulse;

    //Tracks if the boss can use ranged attacks
    private bool CanShoot;

    //Tracks if the barrier is destoryed
    [HideInInspector] public bool Barrier1Destroyed;
    [HideInInspector] public bool Barrier2Destroyed;
    [HideInInspector] public bool Barrier3Destroyed;
    [HideInInspector] public bool Barrier4Destroyed;

    public BoxCollider ActiveHitbox;

    //Tracks if the boss is vulnerable
    [HideInInspector] public bool Vulnerable;

    //Stores player so the boss can track their position
    [HideInInspector]public GameObject Player;

    [HideInInspector] public bool CanAttack;
    [HideInInspector] public bool IsFrozen;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the player on the scene
        Player = GameObject.FindGameObjectWithTag("Player");

        //Boss starts off not being able to take damage
        Vulnerable = false;

        //Sets all the barriers
        Barrier1 = this.transform.GetChild(0).gameObject;
        Barrier2 = this.transform.GetChild(1).gameObject;
        Barrier3 = this.transform.GetChild(2).gameObject;
        Barrier4 = this.transform.GetChild(3).gameObject;

        //Changes the name of the barriers
        Barrier1.name = "Barrier1";
        Barrier2.name = "Barrier2";
        Barrier3.name = "Barrier3";
        Barrier4.name = "Barrier4";

        //barriers are no longer child of the boss
        Barrier1.transform.parent = null;
        Barrier2.transform.parent = null;
        Barrier3.transform.parent = null;
        Barrier4.transform.parent = null;
        BaseDamage = Damage;
        //Boss can shoot at the start of the scene
        CanShoot = true;

        //Allows the boss to attack at the start of the scene
        CanAttack = true;
        HasArmour = false;
        ArmourStatLowered = false;

        //Activates shooting function
        InvokeRepeating("ShootProjectile", 0, 2);
        //gets an item from the player that will spawn
        Item = Player.GetComponent<PlayerCombat>().Item;
        floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;
       
        if (floor >= 11)
        {
            StatUpgrades();
        }else if (floor > 200)
        {
            Health *=2;
            Damage *=2;
            EXPGiveOut *=2;
            ProjectileDamage *=2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the boss look at the player
        this.transform.LookAt(Player.transform);


        //Checks if all the barriers are destoryed
        if (Barrier1Destroyed && Barrier2Destroyed && Barrier3Destroyed && Barrier4Destroyed)
            Vulnerable = true;
        

        //checks if the boss has lost all it's health
        if(Health <= 0)
        {
            //Stops the player from moving
            Player.GetComponent<NavMeshAgent>().isStopped = false;
            //Spawns the gold
            Instantiate(Player.GetComponent<PlayerCombat>().GoldPrefab, this.transform.position, Quaternion.identity);
            //Removes the constraints from the player's rigibody
            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //Adds exp to the player
            Player.GetComponent<PlayerStats>().exp += Mathf.CeilToInt(EXPGiveOut * Player.GetComponent<PlayerStats>().EXPBonus);
            Instantiate(GoldPrefab, transform.position, Quaternion.identity);
            //Increases player's attack damage if limb harvest is activated
            if (Player.GetComponent<PlayerCombat>().LimbHarvestActivated == true)
            {
                Player.GetComponent<PlayerCombat>().AttackDamage *=2;
            }
            if (Random.value > 0.9)
            {
                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
            }
            
            //checks if there are any minions left
            if(GameObject.FindGameObjectsWithTag("Minion").Length != 0)
            {
                //Goes through every minion
                foreach(GameObject Minion in GameObject.FindGameObjectsWithTag("Minion"))
                {
                    //Minion can move again
                    Minion.GetComponent<NavMeshAgent>().isStopped = false;
                    Minion.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    
                    //Will make minion follow the player
                    Minion.GetComponent<MinionAI>().Invoke("SearchForBoss", 0.00001f);
                    Minion.GetComponent<NavMeshAgent>().stoppingDistance = 5;
                }
            }

            //Activates the player's rest state
            Player.GetComponent<PlayerStats>().Rest = true;
            //Makes the player look for the next target
            Player.GetComponent<PlayerNavi>().Invoke("SearchForBoss", 0.0001f);
            //Boss death sound effect
            Player.GetComponentInChildren<PlayerAudio>().BossDeath.Play();
            //Destroys the boss
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the boss collides with the player
        if(other.tag == "Player")
        {
            //Checks if the boss can be damage
            if (Vulnerable)
            {
                //Stops the boss from using projectiles when the player is attacking the boss
                CanShoot = false;
                //Stops the player from moving
                Player.GetComponent<NavMeshAgent>().isStopped = true;
                Player.transform.LookAt(this.gameObject.transform.position);
                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Player.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                //Increases boss' hitbox to ensure the player doesn't fall out
                ActiveHitbox.size = new Vector3(2, 2, 2);
                //Stops boss from rotating
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //Activates function that deals damage to the player and the boss itself
                InvokeRepeating("TakeDealDamage", 0, Player.GetComponent<PlayerCombat>().AttackSpeedRank);

                //Activates the player's buttons
                if (Player.GetComponent<PlayerStats>().currentstanima != 0)
                {
                    PlayerNavi Buttons = Player.GetComponent<PlayerNavi>();
                    //checks auto activation skills/buttons with no skills attached to them and prevents those buttons from being interactable
                    Buttons.MultiAttack.interactable = true;
                    if (Buttons.Slot1.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.Slot1.interactable = false;
                    }
                    else
                    {
                        Buttons.Slot1.interactable = true;
                    }

                    if (Buttons.Slot2.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.Slot2.interactable = false;
                    }
                    else
                    {
                        Buttons.Slot2.interactable = true;
                    }

                    if (Buttons.Slot3.GetComponentInChildren<Text>().text == "" || (Buttons.Slot3.GetComponentInChildren<Text>().text == "Gift Giver" && Buttons.GetComponent<PlayerCombat>().MinionOnScene == false))
                    {
                        Buttons.Slot3.interactable = false;
                    }
                    else
                    {
                        Buttons.Slot3.interactable = true;
                    }

                    if (Buttons.Buff1.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.Buff1.interactable = false;
                    }
                    else
                    {
                        Buttons.Buff1.interactable = true;
                    }

                    if (Buttons.Buff2.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.Buff2.interactable = false;
                    }
                    else
                    {
                        Buttons.Buff2.interactable = true;
                    }

                    if (Buttons.Buff3.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.Buff3.interactable = false;
                    }
                    else
                    {
                        Buttons.Buff3.interactable = true;
                    }

                    if (Buttons.UltimateAttack.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.UltimateAttack.interactable = false;
                    }
                    else
                    {
                        Buttons.UltimateAttack.interactable = true;
                    }

                    if (Buttons.UltimateBuff.GetComponentInChildren<Text>().text == "")
                    {
                        Buttons.UltimateBuff.interactable = false;
                    }
                    else
                    {
                        Buttons.UltimateBuff.interactable = true;
                    }
                }
            }

            //Moves the player away if they try to touch the boss before it's vulnerable
            if (!Vulnerable)
            {
                Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * -1f, ForceMode.Impulse);
            }
        }

        //Checks if the boss has collided with a minion
        if(other.tag == "Minion")
        {
            if (Vulnerable)
            {
                CanShoot = false;
                StartCoroutine(FightMinion(other.GetComponent<MinionAI>()));
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce(other.transform.forward * -1f, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the player leaves the boss the take/deal damage function cancels
        if (other.tag == "Player")
        {
            CancelInvoke("TakeDealDamage");
            //Lets the boss fire projectile again
            CanShoot = true;
            //Lets the player move again
            Player.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    IEnumerator FightMinion(MinionAI Minion)
    {
        //Stops the minion from moving and forces it to look at the boss
        Minion.GetComponent<NavMeshAgent>().isStopped = true;
        Minion.transform.LookAt(this.transform.position);
        Minion.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Minion.GetComponent<NavMeshAgent>().velocity = Vector3.zero;

        //Keeps looping as long as the boss or the minion has enough health
        while (Minion.MinionHealth < 0 || Health < 0)
        {
            //Lowers the Minion's health
            Minion.MinionHealth -= Damage;

            if (IsFrozen)
            {
                //Lowers Boss' health more when boss if frozen
                Health -= Minion.AttackDamage * 2;
            }
            else
            {
                //Lowers Boss' health
                Health -= Minion.AttackDamage;
            }

            //Makes the system wait for a few seconds
            yield return new WaitForSeconds(5);
        }

        //Destroys minion if the minion has lost all it's health
        if (Minion.MinionHealth <= 0)
        {
            Destroy(Minion.gameObject);
            Player.GetComponent<PlayerCombat>().MinionCount -= 1;
            Player.GetComponent<PlayerCombat>().MinionCheck();
        }
    }

    void TakeDealDamage()
    {
        if (CanAttack)
        {
            if (Player.GetComponent<PlayerStats>().armour > 0 && HasArmour == false)
            {
                Armour = Player.GetComponent<PlayerStats>().armour;
                HasArmour = true;  
            }
            else
            {
                HasArmour = false;
            }
            //Chance of player blocking the enemies attack
            if (Random.value < Player.GetComponent<PlayerStats>().BlockChance)
            {
                //Player doesn't lose health, maybe place some signal to player the attack was blocked here
                Player.GetComponentInChildren<PlayerAudio>().Block.Play();
            }
            else
            {
                if (ArmourStatLowered == false && HasArmour)
                {
                    Damage -= Armour;
                    Damage = Mathf.Clamp(Damage, 0, int.MinValue);
                    ArmourStatLowered = true;
                }
                else
                {
                    Damage = BaseDamage;
                    Armour = 0;
                    ArmourStatLowered = false;
                }
               
                //Lowers the player's health
                Player.GetComponent<PlayerStats>().Health -= Damage;
            }
        }

        //Damage delt to the boss
        if (IsFrozen)
        {
            if (Random.value < Player.GetComponent<PlayerStats>().CriticalChance || Player.GetComponent<PlayerCombat>().GuranteedCrit)
            {
                //Doubles damage if boss is forzen
                Health -= Player.GetComponent<PlayerCombat>().CriticalDamage * 2;
                //Displays floating text
                FloatingTextController.CreatFloatingText((Player.GetComponent<PlayerCombat>().CriticalDamage * 2).ToString(), this.transform);
            }
            else
            {
                //Doubles damage if boss is forzen
                Health -= Player.GetComponent<PlayerCombat>().AttackDamage * 2;
                //Displays floating text
                FloatingTextController.CreatFloatingText((Player.GetComponent<PlayerCombat>().AttackDamage * 2).ToString(), this.transform);
            }
        }
        else
        {
            if (Random.value < Player.GetComponent<PlayerStats>().CriticalChance || Player.GetComponent<PlayerCombat>().GuranteedCrit)
            {
                //Normal damage
                Health -= Player.GetComponent<PlayerCombat>().CriticalDamage;
                //Displays floating text
                FloatingTextController.CreatFloatingText(Player.GetComponent<PlayerCombat>().CriticalDamage.ToString(), this.transform);
            }
            else
            {
                //Normal damage
                Health -= Player.GetComponent<PlayerCombat>().AttackDamage;
                //Displays floating text
                FloatingTextController.CreatFloatingText(Player.GetComponent<PlayerCombat>().AttackDamage.ToString(), this.transform);
            }
        }
    }

    void ShootProjectile()
    {
        //Only shoots if the boss isn't being attacked by the player
        if (CanShoot)
        {
            //Spawns the projectile in front of the enemy
            Rigidbody Bullet = (Rigidbody)Instantiate(Projectile, transform.position + transform.forward, transform.rotation);
            //Sets the damage the projectile will do
            Bullet.GetComponent<Projectile>().Damage = ProjectileDamage;
            //Sets how fast the projectile will go
            Bullet.GetComponent<Projectile>().ProjectileImpulse = ProjectileImpulse;
            //Destroys the bullet after 10 seconds
            Destroy(Bullet.gameObject, 10);
        }
    }

    public IEnumerator IsStunned(int EffectDuration)
    {
        //Allows the boss to be stunned for a set period of time
        CanAttack = false;
        yield return new WaitForSeconds(EffectDuration);
        CanAttack = true;
    }

    public IEnumerator IsBurned(int EffectDuration, int Burning)
    {
        //Activates burning effect for a set amount of loops
        for(int i = 0; i < EffectDuration; i++)
        {
            Health -= Burning;
            //Makes the system wait for a few seconds before looping again
            yield return new WaitForSeconds(2);
        }
    }


    public void StatUpgrades()
    {
        switch (floor)
        {
            case 20:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 30:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2 ;
                break;
            case 40:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 50:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 60:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 70:
                Health *=2;
                Damage += 10;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 80:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 90:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 100:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 110:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 120:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 130:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;

                break;
            case 140:
                Health +=50;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 150:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2; 
                EXPGiveOut *=2;
                break;
            case 170:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 180:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 190:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
            case 200:
                Health *=2;
                Damage *=2;
                ProjectileDamage *=2;
                EXPGiveOut *=2;
                break;
               
        }
    }
}
