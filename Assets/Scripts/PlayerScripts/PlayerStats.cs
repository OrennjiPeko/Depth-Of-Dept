using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //Player stats using whole numbers
    public float Health;
    public float BaseDamage;
    public float AOEDamage;
    public float StaminaMax;
    public float MultiAttckX;
    public float HealthRegen;
    public float StaminaRegen;
    public float exp;
   [HideInInspector]public float Level;
   [HideInInspector]public float EXPToNext;
    public float skillpoints;
    public float HealthRegenRank;
    public float CriticalDamage;
    [HideInInspector]public float AttackSpeedRank;
    public float BurnDamage;

    // Player stats using Percentages
    public float StunChance;
    public float MultiattackChance;
    public float DodgeChance;
    public float AbilityDamage;
    public float AOEChance;
    public float HealthBonus;
    public float CriticalChance;
    public float BlockChance;
    public float CooldownReduction;
    public float GoldBonus;
    public float DamageBonus;
    public float Movespeed;
    public float EXPBonus;
    public float DamageReflect;
    public float RarityIncrease;
    public float ItemDroprate;
    public float armour;

    //Used for Calculations/stanima regen/health regen
    [HideInInspector] public float StartingHealth;
   [HideInInspector] public float currentstanima;
   [HideInInspector] public bool Rest;
    private bool RegenHealthPossible = false;

    Button MultiAttack;

    //displays fo UI
   [HideInInspector] public Text StaminaDisplay;
   [HideInInspector] public Text HealthDisplay;
   [HideInInspector] public Text LevelDisplay;
   [HideInInspector] public Text GoldDisplay;

    //Item display
   [HideInInspector] public float Gold;

    //Variables to store UI elements
   [HideInInspector] public GameObject InGameUI;
    public PlayerData PlayerData;

    [HideInInspector]public bool MaxLevel = false;

    Skills SkillManager;

    public int MaxGold;
    [HideInInspector] public bool MaxGoldReached;

    [HideInInspector]public bool GoldRushActive;
    [HideInInspector]public bool BulwarkParryActive;

    private PlayerCombat PlayerCom;

    private void Awake()
    {
        //Finds the gameobjects where the UI elements are stored
        InGameUI = GameObject.Find("InGameUI");
        PlayerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        SkillManager = GameObject.Find("Canvas").transform.Find("SkillMenu").GetComponent<Skills>();
        skillpoints = SkillManager.SkillPoints;
        PlayerCom = this.GetComponent<PlayerCombat>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Gets the UI text elements that will be changed
        StaminaDisplay = InGameUI.transform.Find("Stamina").GetComponent<Text>();
        HealthDisplay = InGameUI.transform.Find("Health").GetComponent<Text>();
        LevelDisplay = InGameUI.transform.Find("Level").GetComponent<Text>();
        GoldDisplay = InGameUI.transform.Find("GoldDisplay").GetComponent<Text>();

        //Sets the max health and stamina
        if(StartingHealth == 0 || StartingHealth == null)
        {
            StartingHealth = Health;
        }
        currentstanima = StaminaMax;
        Rest = false;
        MultiAttack = GetComponent<PlayerNavi>().MultiAttack;

        if(Health < StartingHealth)
        {
            RegenHealthPossible = true;
        }

        //activates function that manages health regen
        InvokeRepeating("RegenHealth", 0, HealthRegenRank);
        //activates function that manages stamina regen
        InvokeRepeating("RegenStamina", 0, 2);

        //Sets the speed of the NavMesh to the speed in the player's stats
        if(Movespeed != 0)
        {
            GetComponent<NavMeshAgent>().speed = Movespeed;
            GetComponent<NavMeshAgent>().acceleration = Movespeed;
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = 1;
            GetComponent<NavMeshAgent>().acceleration = 1;
        }
        if (Level == 50)
        {
            MaxLevel = true;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        //If the player isn't in combat health with regen until it reachs max health
        if ((GetComponent<NavMeshAgent>().isStopped == false) && (Health < StartingHealth))
        {
            RegenHealthPossible = true;
        }
        else
        {
            RegenHealthPossible = false;
        }

        if (currentstanima < StaminaMax)
        {
            Rest = true;
        }

        if(Health >= StartingHealth)
        {
            Health = StartingHealth;
        }

        if (Rest == true)
        {
            if(currentstanima >= StaminaMax)
            {
                Rest = false;
                PlayerCom.stamina = currentstanima;
            }

        }

        //show the current health,stamina and level to the player
        StaminaDisplay.text = currentstanima.ToString();
        HealthDisplay.text = Health.ToString();
        LevelDisplay.text = Level.ToString();
        GoldDisplay.text = Gold.ToString();
              
        //if the player's experiance equals the same as the exp to next level the player will level up and the LevelUpManager will be called
        if (exp >= EXPToNext && MaxLevel == false)
        {
            Level += 1;
            LevelUpManager();
        }
    }

    //changes the exp for next level based on the current level and adds stat upgrades
    void LevelUpManager()
    {
        switch (Level)
        {
            case 1:
                {
                    EXPToNext = 100;
                    ItemDroprate= 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 2:
                {
                    EXPToNext = 300;
                    BaseDamage += 5;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 3:
                {
                    EXPToNext = 500;
                    BaseDamage += 5;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 4:
                {
                    EXPToNext = 700;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 5:
                {
                    EXPToNext = 900;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 6:
                {
                    EXPToNext = 1100;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 7:
                {
                    EXPToNext = 1300;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 8:
                {
                    EXPToNext = 1500;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 9:
                {
                    EXPToNext = 1700;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 10:
                {
                    EXPToNext = 1900;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 11:
                {
                    EXPToNext = 2200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 12:
                {
                    EXPToNext = 2400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 13:
                {
                    EXPToNext = 2600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 14:
                {
                    EXPToNext = 2800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 15:
                {
                    EXPToNext = 3000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 16:
                {
                    EXPToNext = 3200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 17:
                {
                    EXPToNext = 3400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 18:
                {
                    EXPToNext = 3600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 19:
                {
                    EXPToNext = 3800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 20:
                {
                    EXPToNext = 4000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 21:
                {
                    EXPToNext = 4200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 22:
                {
                    EXPToNext = 4400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 23:
                {
                    EXPToNext = 4600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 24:
                {
                    EXPToNext = 4800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 25:
                {
                    EXPToNext = 5000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 26:
                {
                    EXPToNext = 5200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 27:
                {
                    EXPToNext = 5400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 28:
                {
                    EXPToNext = 5600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 29:
                {
                    EXPToNext = 5800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 30:
                {
                    EXPToNext = 6000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 31:
                {
                    EXPToNext = 6200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 32:
                {
                    EXPToNext = 6400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 33:
                {
                    EXPToNext = 6600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 34:
                {
                    EXPToNext = 6800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 35:
                {
                    EXPToNext = 7000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 36:
                {
                    EXPToNext = 7200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 37:
                {
                    EXPToNext = 7400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 38:
                {
                    EXPToNext = 7600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 39:
                {
                    EXPToNext = 7800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 40:
                {
                    EXPToNext = 8000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 41:
                {
                    EXPToNext = 8200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 42:
                {
                    EXPToNext = 8400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 43:
                {
                    EXPToNext = 8600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 44:
                {
                    EXPToNext = 8800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 45:
                {
                    EXPToNext = 9000;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 46:
                {
                    EXPToNext = 9200;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 47:
                {
                    EXPToNext = 9400;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 48:
                {
                    EXPToNext = 9600;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 49:
                {
                    EXPToNext = 9800;
                    ItemDroprate = 0.01f;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }
            case 50:
                {
                    EXPToNext = 10000;
                    exp = EXPToNext;
                    ItemDroprate = 0.01f;
                    MaxLevel = true;
                    SkillManager.SkillPoints += 2;
                    SkillManager.PlayerLevel = Level;
                    break;
                }

        }
        skillpoints = SkillManager.SkillPoints;
    }

   //Regens health
    private void RegenHealth()
    {
        //Only activates if the player isn't in combat/had lower health then max
        if(RegenHealthPossible == true)
        {
            Health += HealthRegen;
        }
    }

    //regens stamina
    private void RegenStamina()
    {
        //Only activates when the player isn't in combat
        if(Rest == true)
        {
            currentstanima += StaminaRegen;
            PlayerCom.stamina = currentstanima;
            PlayerCom.CheckSkillStamina();
        }
    }

    //Checks if the player can afford a minion after picking up a piece of gold
    public void CanPlayerSummonMinion()
    {
        if(Gold >= PlayerCom.MinionCost && (PlayerCom.MinionCount < PlayerCom.MaxNumOfMinions))
        {
            this.GetComponent<PlayerCombat>().SummonMinionButton.interactable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinalDestination")
        {
            //send the player's stats to player data to be used in the next scene
            PlayerData.Health = Health;
            PlayerData.baseDamage = BaseDamage;
            PlayerData.AOEDamage = AOEDamage;
            PlayerData.StaminaMax = StaminaMax;
            PlayerData.MultiAttckX = MultiAttckX;
            PlayerData.HealthRegen = HealthRegen;
            PlayerData.StaminaRegen = StaminaRegen;
            PlayerData.mainexp = exp;
            PlayerData.Level = Level;
            PlayerData.skillpoints = SkillManager.SkillPoints;
            PlayerData.HealthRegenRank = HealthRegenRank;
            PlayerData.CriticalDamage = CriticalDamage;
            PlayerData.AttackSpeedRank = AttackSpeedRank;
            PlayerData.StunChance = StunChance;
            PlayerData.MultiattackChance = MultiattackChance;
            PlayerData.DodgeChance = DodgeChance;
            PlayerData.AbilityDamage = AbilityDamage;
            PlayerData.AOEChance = AOEChance;
            PlayerData.HealthBonus = HealthBonus;
            PlayerData.CriticalChance = CriticalChance;
            PlayerData.BlockChance = BlockChance;
            PlayerData.CooldownReduction = CooldownReduction;
            PlayerData.GoldBonus = GoldBonus;
            PlayerData.DamageBonus = DamageBonus;
            PlayerData.MovesRank = SkillManager.SpeedRank;
            PlayerData.Movespeed = Movespeed;
            PlayerData.EXPBonus = EXPBonus;
            PlayerData.DamageReflect = DamageReflect;
            PlayerData.RarityIncrease = RarityIncrease;
            PlayerData.Gold = Gold;
            PlayerData.MaxHealth = StartingHealth;
            PlayerData.ChasingEnemy = this.GetComponent<PlayerNavi>().ChasingEnemy;
            PlayerData.RarityIncrease =RarityIncrease;
            PlayerData.EXPtoNext = EXPToNext;
            PlayerData.Armour = armour;
            PlayerData.MinionCount = PlayerCom.MinionCount;
        }
    }


    //Legendary Traits

    public IEnumerator GoldRush(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //5% chance of getting x3 gold
        if (Activate)
        {
            GoldRushActive = true;
        }
        else
        {
            GoldRushActive = false; 
        }
    }

    public IEnumerator CriticalThinker(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //Doubles critical chance but lowers critical damage to 75%
        if (Activate)
        {
            PlayerCom.CriticalChance *= 2;
            PlayerCom.CriticalDamage *= 0.75f;
        }
        else
        {
            PlayerCom.CriticalChance /= 2;
            PlayerCom.CriticalDamage = (PlayerCom.CriticalDamage/75) * 100;
        }
    }

    public IEnumerator BluwarkParry(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //Critical hit after every block
        if (Activate)
        {
            BulwarkParryActive = true;
        }
        else
        {
            BulwarkParryActive = false;
        }
    }

    public IEnumerator Berserk(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //Gain double attack speed for successful multiattack
        if (Activate)
        {
            PlayerCom.AttackSpeedRank /= 2;
        }
        else
        {
            PlayerCom.AttackSpeedRank *= 2;
        }
    }

    public IEnumerator Multicaster(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //10% of resetting cooldown on a skill
        if (Activate)
        {
            PlayerCom.MulticastActive = true;
        }
        else
        {
            PlayerCom.MulticastActive = false;
        }
    }

    public IEnumerator LuckyLooter(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //10% chance of enemy dropping a rarer item
        if (Activate)
        {

        }
        else
        {

        }
    }

    public IEnumerator HoardSpotter(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //5% chance of dropping 3 items
        if (Activate)
        {
            PlayerCom.HoardSpotterActive = true;
        }
        else
        {
            PlayerCom.HoardSpotterActive = false;
        }
    }

    public IEnumerator Swift(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //On successfull Critical Strike gain double movement speed for 10 seconds
        if (Activate)
        {
            this.GetComponent<NavMeshAgent>().speed *= 2;
        }
        else
        {
            this.GetComponent<NavMeshAgent>().speed /= 2;
        }
    }

    public IEnumerator Reflective(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //On successful block all damaged reflected
        if (Activate)
        {
            PlayerCom.ReflectiveActive = true;
        }
        else
        {
            PlayerCom.ReflectiveActive = false;
        }
    }

    public IEnumerator ExplosiveFlury(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //On kill gain double the AOE chance for 10s
        if (Activate)
        {
            PlayerCom.ExplosiveFluryActive = true;
        }
        else
        {
            PlayerCom.ExplosiveFluryActive = false;
        }
    }

    public IEnumerator DeathDealer(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //On kill guaranteed multiattack on next attack
        if (Activate)
        {

        }
        else
        {

        }
    }

    public IEnumerator CarefulApproach(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //On kill gain guaranteed blocks for 5s
        if (Activate)
        {
            PlayerCom.CarefulApproachActive = true;
        }
        else
        {
            PlayerCom.CarefulApproachActive = false;
        }
    }

    public IEnumerator QuickLearner(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //5% chance of double the EXP
        if (Activate)
        {
            PlayerCom.QuickLearnerActive = true;
        }
        else
        {
            PlayerCom.QuickLearnerActive = false;
        }
    }

    public IEnumerator RecklessAbandon(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //Take 30% more damage, deal 50% more
        if (Activate)
        {
            PlayerCom.Damage *= 1.5f;
            PlayerCom.RecklessAbandonActive = true;
        }
        else
        {
            PlayerCom.Damage = PlayerCom.Damage / 1.5f;
            PlayerCom.RecklessAbandonActive = false;
        }
    }

    public IEnumerator Flurried(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //10% chance of activating Flurry of blows for no cost even when not equipped
        if (Activate)
        {
            PlayerCom.FlurriedActive = true;
        }
        else
        {
            PlayerCom.FlurriedActive = false;
        }
    }

    public IEnumerator Drainer(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //Life steal regains 50% of health regen instead
        if (Activate)
        {

        }
        else
        {

        }
    }

    public IEnumerator ShadowMerge(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //5% chance of gaining invinsibility for 5 seconds after kill
        if (Activate)
        {
            PlayerCom.ShadowMergeActive = true;
        }
        else
        {
            PlayerCom.ShadowMergeActive = false;
        }
    }

    public IEnumerator EverlastingFlames(bool Activate)
    {
        yield return new WaitForSeconds(0);
        //Applies 10 of your damage as burn damage
        if (Activate)
        {
            PlayerCom.BurnDamage = BaseDamage * 0.1f;
        }
        else
        {
            PlayerCom.BurnDamage = BurnDamage;
        }
    }
}
