using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyCombat : MonoBehaviour
{
    [HideInInspector] public float AttackDamage;
    [HideInInspector] float BaseDamage;
    GameObject Player;
    [HideInInspector]public bool CanAttack;
    [HideInInspector] public float armour;
    [HideInInspector] private bool ArmourStatLowered;
    [HideInInspector] private bool PlayerHasArmour;
    
    // Start is called before the first frame update
    void Start()
    {
        AttackDamage = GetComponent<EnemyStates>().AttackDamage;
        Player = GameObject.Find("Player");
        CanAttack = true;
        armour = GameObject.Find("Player").GetComponent<PlayerStats>().armour;
        BaseDamage = AttackDamage;
        ArmourStatLowered = false;
        PlayerHasArmour = false;
    }

    private void Update()
    {
        //A check to make sure the player hasn't died
        if (Player != null)
        {
            if(Player.GetComponent<PlayerStats>().Health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //autoattack damage towards the player
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            //If the enemy can attack it'll check if the player's health is above 0
            if ((Player.GetComponent<PlayerStats>().Health != 0 && Player.GetComponent<PlayerStats>().Health > 0) && CanAttack == true)
            {
                InvokeRepeating("Attack", 0, 1f);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            //If the player dies then the gameover screen loads
            if (Player.GetComponent<PlayerStats>().Health <= 0)
            {
                GameObject.Find("InGameUI").SetActive(false);
                SceneManager.LoadScene("GameOver");
            }
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        //If the player leaves the enemy then the auto attack will stop
        if(other.gameObject.tag == "Player")
        {
            CancelInvoke("Attack");
        }
        //Empties the player variable to prevent errors in code
        Player = null;
    }

    void Attack()
    {
        if (CanAttack)
        {

            if (Player.GetComponent<PlayerStats>().armour > 0 && PlayerHasArmour == false)
            {
                armour = Player.GetComponent<PlayerStats>().armour;
                PlayerHasArmour = true;
            }
            else
            {
                PlayerHasArmour = false;
            }

            //Chance of player blocking the enemies attack
            if (Random.value < Player.GetComponent<PlayerStats>().BlockChance || Player.GetComponent<PlayerCombat>().CarefulApproachTurnedOn)
            {
                //Player doesn't lose health, maybe place some signal to player the attack was blocked here
                Player.GetComponent<PlayerCombat>().Audio.Block.Play();
                //Reflects damage back at the enemy if the player has the reflective trait
                if (Player.GetComponent<PlayerCombat>().ReflectiveActive)
                {
                    this.GetComponent<EnemyStates>().EnemyHealth -= BaseDamage;
                }
                //Player gets a guranteed crit if bulwarkparry is active
                if (Player.GetComponent<PlayerStats>().BulwarkParryActive)
                    Player.GetComponent<PlayerCombat>().GuranteedCrit = true;

                FloatingTextController.CreatFloatingText("BLOCKED", this.transform);
            }
            else
            {
                if ((Player.GetComponent<PlayerCombat>().CanCounter == true) && (Random.Range(0, 10) < Player.GetComponent<PlayerCombat>().CounterChance))
                {
                    this.GetComponent<EnemyStates>().EnemyHealth -= BaseDamage;
                }
                else
                {
                    if (ArmourStatLowered == false && PlayerHasArmour)
                    {
                        AttackDamage -= armour;
                        AttackDamage = Mathf.Clamp(AttackDamage, 0, int.MaxValue);
                        ArmourStatLowered = true;
                    }
                    else
                    {
                        AttackDamage = BaseDamage;
                        armour = 0;
                        ArmourStatLowered = false;
                    }
                    
                    //Lowers the player's health
                    Player.GetComponent<PlayerStats>().Health -= AttackDamage;
                    //If more gore is active activate the skill
                    if (Player.GetComponent<PlayerCombat>().MoreGoreActive)
                        StartCoroutine(Player.GetComponent<PlayerCombat>().MoreGore());
                }
            }

            //Reflects the enemies attack
            if (Player.GetComponent<PlayerCombat>().ReflectiveArmourActivated == true)
            {
                Player.GetComponent<PlayerCombat>().SendMessage("ReflectiveArmour");
            }
        }
    }
}
