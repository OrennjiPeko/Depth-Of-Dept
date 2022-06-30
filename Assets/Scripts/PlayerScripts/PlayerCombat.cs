using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
   //Stores the enemy
    public GameObject Enemy;
    public GameObject DeadEnemy;
    //tracks the player's experiance
    float exp;
    //stores the player's rigibody
    Rigidbody RB;

    //sets variables for the stats to be used later
   [HideInInspector]  public float stamina;
   [HideInInspector] public float StaminaRegen;
   [HideInInspector]  public float Health;
   [HideInInspector] public float HealthRegen;
   [HideInInspector] public float AttackDamage;
   [HideInInspector] public float AOEDamage;
   [HideInInspector] public float AttackSpeedRank;
   [HideInInspector] public float DodgeChance;
   [HideInInspector]  public float Damage;
   [HideInInspector] public float AbilityDamage;
   [HideInInspector] public float DamageReflect;
   [HideInInspector] public float CriticalChance;
   [HideInInspector] public float CriticalDamage;
   [HideInInspector]  public float BonusDamage;
   [HideInInspector] public float BlockChance;
   [HideInInspector] public float CooldownReduction;
   [HideInInspector] public float AOEChance;
   [HideInInspector] public float MultiAttackChance;
   [HideInInspector] public float EXPBonus;
   [HideInInspector] public float GoldBonus;
   [HideInInspector] public float StunChance;
   [HideInInspector] public float MultiAttackDamage;
   [HideInInspector] public float Armour;
   [HideInInspector] public float droprate;
    float EnemyHealth;
    float StartingHealth;

    public float BurnDamage;

    //Stores the minion that some skills can summon
    public GameObject Minion;
    
    //Setting the game objects that will spawn on enemy death
    public GameObject GoldPrefab;
    public GameObject[] Item;

    //controls how long effects last for
    int EffectDuration;

    //Game objects that acts as AOE
    public GameObject AOEAttack;
    public GameObject AOECone;
    public GameObject AOELine;

    //AOE's actual damage, different stat used to store base AOE Damage
    [HideInInspector]public float AOEAttackDamage;

    Vector3 EnemyPosition;
    //buttons that get used later
    Button MultiAttack;
    Button SkillSlot;
    Button Slot1;
    Button Slot2;
    public Button Slot3;
    Button Buff1;
    Button Buff2;
    Button Buff3;
    Button UltimateSkillSlot;
    Button UltimateBuffSlot;

    //Used to have I'm Angry effects happen
    bool ImAngryActivated;
    private bool ActivateImAngry;
    //Counter for elemental overload
    int counter;
    //Used to have effects of LimbHarvest activate
  [HideInInspector]  public bool LimbHarvestActivated;
    //Used to have the projectiles reflect of the player
   [HideInInspector] public bool CanReflect;

    //Checks if heavy landing has been activated
    private bool HeavyLandingActivated;

   //used to check if reflective armour is activated
   [HideInInspector] public bool ReflectiveArmourActivated;

    //Stores the slot skills
    private string CurrentSlotSkill;
   [HideInInspector] public string Slot1Skill;
   [HideInInspector] public string Slot2Skill;
   [HideInInspector] public string Slot3Skill;
   [HideInInspector] public string Slot1Buff;
   [HideInInspector] public string Slot2Buff;
   [HideInInspector] public string Slot3Buff;
   [HideInInspector] public string UltimateSkill;
   [HideInInspector] public string UltimateBuff;

    //Stores the skill cooldown
    [HideInInspector] public int Skill1Cooldown;
    [HideInInspector] public int Skill2Cooldown;
    [HideInInspector] public int Skill3Cooldown;
    [HideInInspector] public int Buff1Cooldown;
    [HideInInspector] public int Buff2Cooldown;
    [HideInInspector] public int Buff3Cooldown;
    [HideInInspector] public int UltimateSkillCooldown;
    [HideInInspector] public int UltimateBuffCooldown;

    //Tracks the passive skills the player has unlocked
    [HideInInspector] public List<string> UnlockedPassiveAbilities;
    //Tracks passive ranks for use in saving
    [HideInInspector] public List<int> PassiveRank;

    //Tracks if the player has a minion
    [HideInInspector] public bool MinionOnScene = false;

    //Stores stamina useage for every slot skill
    public int Skill1Stamina;
    public int Skill2Stamina;
    public int Skill3Stamina;
    public int Buff1Stamina;
    public int Buff2Stamina;
    public int Buff3Stamina;
    public int UltimateSkillStamina;
    public int UltimateBuffStamina;

    //stores functions for elemental overload
    delegate void ChosenSkillMethod();
    List<ChosenSkillMethod> ChosenSkills = new List<ChosenSkillMethod>();

    //Variables used to change player's colour
    public Material CharacterFlash;
    public Material DefaultColour;
    private Renderer PlayerColour;

    private UpgradeSkills SkillLevelTracker;

    //tracks the boss information
    [HideInInspector] public bool FightingBoss;
    [HideInInspector] public Boss1 Boss;

    //Information used for Flurry of attacks
    [HideInInspector]public bool FlurryOfAttacksUnlock;
    [HideInInspector]public bool FlurryOfAttacksActivated;
    int FlurryOfAttacksBuff;

    //Counter info
    [HideInInspector]public bool CanCounter;
    public int CounterChance;

    //Stores Firewall's shield
    public GameObject FireShield;

    public bool MoreGoreActive;

    //Minion information
    private GameObject[] MinionSpawnPoints;
    public Button SummonMinionButton;
    public int MinionCost;
    public int MinionCount;
    public int MaxNumOfMinions;

    //Stores player's audio
    public PlayerAudio Audio;

    //Camera shake functions
    public CameraShake cameraShake;
    public float CamShakeDuration;
    public float CamShakeMagnitude;

    //Player is Guranteed a critical hit
    public bool GuranteedCrit;

    //Legendary traits booleans
    [HideInInspector] public bool MulticastActive;
    [HideInInspector] public bool HoardSpotterActive;
    [HideInInspector] public bool ReflectiveActive;
    [HideInInspector] public bool ExplosiveFluryActive;
    [HideInInspector] public bool CarefulApproachActive;
    [HideInInspector] public bool CarefulApproachTurnedOn;
    [HideInInspector] public bool QuickLearnerActive;
    [HideInInspector] public bool RecklessAbandonActive;
    [HideInInspector] public bool FlurriedActive;
    [HideInInspector] public bool ShadowMergeActive;

    private void Awake()
    {
        CanCounter = false;
        MoreGoreActive = false;
        //gets the multiattack button to set it later
        MultiAttack = GameObject.Find("MultiAttack").GetComponent<Button>();
        //Gets the buttons that the skills will be put on
        Slot1 = GameObject.Find("Slot1").GetComponent<Button>();
        Slot2 = GameObject.Find("Slot2").GetComponent<Button>();
        Slot3 = GameObject.Find("Slot3").GetComponent<Button>();
        Buff1 = GameObject.Find("Buff1").GetComponent<Button>();
        Buff2 = GameObject.Find("Buff2").GetComponent<Button>();
        Buff3 = GameObject.Find("Buff3").GetComponent<Button>();
        UltimateSkillSlot = GameObject.Find("UltimateAttack").GetComponent<Button>();
        UltimateBuffSlot = GameObject.Find("UltimateBuff").GetComponent<Button>();
        //Gets the player's renderer to change colour
        PlayerColour = GetComponent<Renderer>();
        //Gets the script that stores information about the skills the player has and the skill level
        SkillLevelTracker = GameObject.Find("GlobalData").GetComponent<UpgradeSkills>();
        //Player isn't fighting a boss at start
        FightingBoss = false;
    }

    private void Start()
    {
        //Stores the player's stats to get called throughout start
        PlayerStats PlayerStats = this.GetComponent<PlayerStats>();

        //Sets the stats to the stats store in the player stat script
        AttackDamage = Mathf.CeilToInt(PlayerStats.BaseDamage * PlayerStats.DamageBonus);
        AttackSpeedRank = PlayerStats.AttackSpeedRank;
        exp = PlayerStats.exp;
        RB = GetComponent<Rigidbody>();
        Enemy = null;


        CanReflect = false;

        //sets the function for the buttons
        MultiAttack.onClick.AddListener(delegate { MultiAttackActivate(); }) ;
        SetSlot1();
        SetSlot2();
        SetSlot3();
        SetBuff1();
        SetBuff2();
        SetBuff3();
        SetUltimateSkill();
        SetUltimateBuff();
        SetPassiveSkills();

        //50/50 chance of stunning enemies when level loads
        if (Random.value < 0.5 && HeavyLandingActivated == true)
        {
            HeavyLanding();
        }

        //Setting stats
        stamina = PlayerStats.StaminaMax;
        StaminaRegen = PlayerStats.StaminaRegen;
        Health = PlayerStats.Health;
        StartingHealth = Health;
        HealthRegen = PlayerStats.HealthRegen;
        Damage = PlayerStats.BaseDamage;
        BonusDamage = PlayerStats.DamageBonus;
        DodgeChance = PlayerStats.DodgeChance;
        CriticalChance = PlayerStats.CriticalChance;
        CriticalDamage = Mathf.CeilToInt(PlayerStats.CriticalDamage * PlayerStats.DamageBonus);
        MultiAttackDamage = PlayerStats.MultiAttckX;
        AbilityDamage = PlayerStats.AbilityDamage;
        DamageReflect = PlayerStats.DamageReflect;
        BlockChance = PlayerStats.BlockChance;
        CooldownReduction = PlayerStats.CooldownReduction;
        AOEChance = PlayerStats.AOEChance;
        MultiAttackChance = PlayerStats.MultiattackChance;
        EXPBonus = PlayerStats.EXPBonus;
        GoldBonus = PlayerStats.GoldBonus;
        StunChance = PlayerStats.StunChance;
        Armour = PlayerStats.armour;
        droprate = PlayerStats.ItemDroprate;

        //Finds the minion's spawn point
        MinionSpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        //Finds the button that spawns minions when pressed
        SummonMinionButton = GameObject.Find("SummonMinion").GetComponent<Button>();
        //Sets the buttons function to the SummonMinion function
        SummonMinionButton.onClick.AddListener(delegate { SummonMinion(false); }) ;

        //Gets the number of minions the player has already spawned
        MinionCount = GameObject.Find("PlayerData").GetComponent<PlayerData>().MinionCount;

        //Spawn minions if the player had any in the previous room
        if(MinionCount > 0)
        {
            Invoke("StartSummon", 0.0001f);
        }

        //Player can't summon minion if the player spawns with too little gold
        if(PlayerStats.Gold < MinionCost)
        {
            SummonMinionButton.interactable = false;
        }

        //stores script with all the player's audio
        Audio = GetComponentInChildren<PlayerAudio>();

        //Gets camera shake function
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        //Has the floating text controller set itself up
        FloatingTextController.Initialise();


        Item = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g => g.tag == "Item").ToArray();
    }

    private void StartSummon()
    {
        for (int i = 0; i < MinionCount; i++)
        {
            SummonMinion(true);
        }
    }

    private void Update()
    {

        //cancels elemental overload once it's used 5 spells
        if(counter == 5)
        {
            CancelInvoke("ElementalOverload");
            counter = 0;
        }

        //Activates I'm Angry at 30% percent health
        if((ImAngryActivated == false) && (Health < (StartingHealth/30 * 10)) && ActivateImAngry == true)
        {
            ImAngry();
        }

        if(Slot3.GetComponentInChildren<Text>().text == "Gift Giver" && MinionOnScene == true)
        {
            Slot3.interactable = true;
        }
    }

    public void SetSlot1()
    {
        //Sets the skill slot that is used when skill setting to slot 1
        SkillSlot = Slot1;
        //Sets the name of the skill the system will be looking for in SetSkill()
        CurrentSlotSkill = Slot1Skill;

        Slot1.GetComponentInChildren<Text>().text = Slot1Skill;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetSlot2()
    {
        //Sets the skill slot that is used when skill setting to slot 2
        SkillSlot = Slot2;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = Slot2Skill;

        Slot2.GetComponentInChildren<Text>().text = Slot2Skill;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetSlot3()
    {
        //Sets the skill slot that is used when skill setting to slot 3
        SkillSlot = Slot3;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = Slot3Skill;

        Slot3.GetComponentInChildren<Text>().text = Slot3Skill;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetBuff1()
    {
        //Sets the skill slot that is used when skill setting to slot 3
        SkillSlot = Buff1;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = Slot1Buff;

        Buff1.GetComponentInChildren<Text>().text = Slot1Buff;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetBuff2()
    {
        //Sets the skill slot that is used when skill setting to slot 3
        SkillSlot = Buff2;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = Slot2Buff;

        Buff2.GetComponentInChildren<Text>().text = Slot2Buff;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetBuff3()
    {
        //Sets the skill slot that is used when skill setting to slot 3
        SkillSlot = Buff3;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = Slot3Buff;

        Buff3.GetComponentInChildren<Text>().text = Slot3Buff;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetUltimateSkill()
    {
        //Sets the skill slot that is used when skill setting to slot 3
        SkillSlot = UltimateSkillSlot;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = UltimateSkill;

        UltimateSkillSlot.GetComponentInChildren<Text>().text = UltimateSkill;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetUltimateBuff()
    {
        //Sets the skill slot that is used when skill setting to slot 3
        SkillSlot = UltimateBuffSlot;
        //Sets the name of the skill the system will be looking for in SkillSet()
        CurrentSlotSkill = UltimateBuff;

        UltimateBuffSlot.GetComponentInChildren<Text>().text = UltimateBuff;
        //Calls the function that sets the skill's action to the button
        SetSkill();
    }

    public void SetPassiveSkills()
    {
        foreach(string PassiveAbility in UnlockedPassiveAbilities)
        {
            CurrentSlotSkill = PassiveAbility;
            SetSkill();
        }
    }

    private void SetSkill()
    {
        //Checks the name of the skill and sets the appropriate action to the appropriate button, also adds the skill chosen to a list for elemental overload to use
        switch (CurrentSlotSkill)
        {
            case "Burn Baby":
                {
                    SkillSlot.onClick.AddListener(delegate { BurnBaby(Skill2Cooldown); });
                    ChosenSkills.Add(delegate { BurnBaby(0); });
                    break;
                }
            case "Ghostly Time":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(GhostlyTime(Buff2Cooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(GhostlyTime(0)); });
                    break;
                }
            case "Mirror Of Ice":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(MirrorOfIce(Buff3Cooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(MirrorOfIce(0)); });
                    break;
                }
            case "Breath Of Life":
                {
                    SkillSlot.onClick.AddListener(delegate { BreathOfLife(Buff1Cooldown); });
                    ChosenSkills.Add(delegate { BreathOfLife(0); });
                    break;
                }
            case "Rage":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(Rage(Skill1Cooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(Rage(0)); });
                    break;
                }
            case "Survival Instinct":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(SurvivalInstinct(Buff1Cooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(SurvivalInstinct(0)); });
                    break;
                }
            case "Hunting Instinct":
                {
                    SkillSlot.onClick.AddListener(delegate { HuntingInstinct(Skill1Cooldown); });
                    ChosenSkills.Add(delegate { HuntingInstinct(0); });
                    break;
                }
            case "Petrifying Presence":
                {
                    SkillSlot.onClick.AddListener(delegate { PetrifyingPresence(Buff1Cooldown); });
                    ChosenSkills.Add(delegate { PetrifyingPresence(0); });
                    break;
                }
            case "Presence Of Pain":
                {
                    SkillSlot.onClick.AddListener(delegate { PresenceOfPain(Buff1Cooldown); });
                    ChosenSkills.Add(delegate { PresenceOfPain(0); });
                    break;
                }
            case "BobAndWeave":
                {
                    BobAndWeave();
                    break;
                }
            case "BiggerArms":
                {
                    BiggerArms();
                    break;
                }
            case "TargetPractice":
                {
                    TargetPractice();
                    break;
                }
            case "ForceofWill":
                {
                    ForceOfWill();
                    break;
                }
            case "ThornSkin":
                {
                    ThornSkin();
                    break;
                }
            case "Riposte":
                {
                    Riposte();
                    break;
                }
            case "ImprovedMemory":
                {
                    ImprovedMemory();
                    break;
                }
            case "Cleave":
                {
                    Cleave();
                    break;
                }
            case "MultipleHands":
                {
                    MultipleHands();
                    break;
                }
            case "QuickRecharge":
                {
                    QuickRecharge();
                    break;
                }
            case "Cone Of Tundra":
                {
                    SkillSlot.onClick.AddListener(delegate { ConeOfTundra(Buff2Cooldown); });
                    ChosenSkills.Add(delegate { ConeOfTundra(0); });
                    break;
                }
            case "Limb Harvest":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(LimbHarvest(Skill2Cooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(LimbHarvest(0)); });
                    break;
                }
            case "Cone Of Unlife":
                {
                    SkillSlot.onClick.AddListener(delegate { ConeOfUnlife(Skill2Cooldown); });
                    ChosenSkills.Add(delegate { ConeOfUnlife(0); });
                    break;
                }
            case "ArtOfTraining":
                {
                    ArtOfTraining();
                    break;
                }
            case "Pennies":
                {
                    Pennies();
                    break;
                }
            case "RollTheDice":
                {
                    RollTheDice();
                    break;
                }
            case "FlurryOfAttacks":
                {
                    FlurryOfAttacks();
                    break;
                }
            case "Frostbite":
                {
                    Frostbite();
                    break;
                }
            case "ReflectiveArmour":
                {
                    ReflectiveArmour();
                    break;
                }
            case "BackAtYou":
                {
                    BackAtYou();
                    break;
                }
            case "Echo":
                {
                    Echo();
                    break;
                }
            case "HeavyLanding":
                {
                    HeavyLandingActivated = true;
                    break;
                }
            case "Death Grip":
                {
                    SkillSlot.onClick.AddListener(delegate { DeathGrip(Skill3Cooldown); });
                    ChosenSkills.Add(delegate { DeathGrip(0); });
                    break;
                }
            case "Burst Of Gore":
                {
                    SkillSlot.onClick.AddListener(delegate { BurstOfGore(Skill3Cooldown); });
                    ChosenSkills.Add(delegate { BurstOfGore(0); });
                    break;
                }
            case "DiamondBody":
                {
                    DiamondBody();
                    break;
                }
            case "MasterOfPennies":
                {
                    MasterOfPennies();
                    break;
                }
            case "SoulCollector":
                {
                    SoulCollector();
                    break;
                }
            case "MoreGore":
                {
                    MoreGoreActive = true;
                    break;
                }
            case "StealthCut":
                {
                    StealthCut();
                    break;
                }
            case "WhyAreYouRunning":
                {
                    WhyAreYouRunning();
                    break;
                }
            case "ImAngry":
                {
                    ActivateImAngry = true;
                    SkillSlot.interactable = false;
                    break;
                }
            case "ThrowThings":
                {
                    ThrowThings();
                    break;
                }
            case "Blind Rage":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(BlindRage(UltimateBuffCooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(BlindRage(0)); });
                    break;
                }
            case "I'm Calm":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(ImCalm(UltimateBuffCooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(ImCalm(0)); });
                    break;
                }
            case "Soul Eater":
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(SoulEater(UltimateBuffCooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(SoulEater(0)); });
                    break;
                }
            case "Rampage":
                {
                    SkillSlot.onClick.AddListener(delegate { Rampage(UltimateSkillCooldown); });
                    ChosenSkills.Add(delegate { Rampage(0); });
                    break;
                }
            case "Wall Of Spears":
                {
                    SkillSlot.onClick.AddListener(delegate { WallOfSpears(UltimateSkillCooldown); });
                    ChosenSkills.Add(delegate { WallOfSpears(0); });
                    break;
                }
            case "Elemental Overload":
                {
                    SkillSlot.onClick.AddListener(delegate { InvokeRepeating("ElementalOverload", 0, 1); });
                    break;
                }
            case "GateOfChaos":
                {
                    GateOfChaos();
                    break;
                }
            case "Shield Storm":
                {
                    SkillSlot.onClick.AddListener(delegate { ShieldStorm(Buff3Cooldown); });
                    ChosenSkills.Add(delegate { ShieldStorm(0); });
                    break;
                }
            case ("FireWall"):
                {
                    SkillSlot.onClick.AddListener(delegate { StartCoroutine(FireWall(Buff3Cooldown)); });
                    ChosenSkills.Add(delegate { StartCoroutine(FireWall(0)); });
                    break;
                }
            case "Gift Giver":
                {
                    SkillSlot.onClick.AddListener(delegate { GiftGiver(Skill3Cooldown); });
                    break;
                }
            case "Stunning Quake":
                {
                    SkillSlot.onClick.AddListener(delegate { StunningQuake(Buff2Cooldown); });
                    ChosenSkills.Add(delegate { StunningQuake(0); });
                    break;
                }
        }
    }

    //Places all the stats in the pause menu
    public void SetStats()
    {
        //Gets the gameobject that stores all of the text that displays stat information
        GameObject StatHolder = GameObject.Find("Canvas").transform.Find("Inventory").transform.Find("BackGround2").Find("PlayerStats").gameObject;
        //Gets player stats that aren't stored in player combat
        PlayerStats PlayerInfo = this.GetComponent<PlayerStats>();

        //Sets the stat information for all the text boxes
        StatHolder.transform.Find("Level").GetComponent<Text>().text = "Level: " + PlayerInfo.Level;
        StatHolder.transform.Find("EXP").GetComponent<Text>().text = "EXP: " + PlayerInfo.exp;
        StatHolder.transform.Find("Skill Points").GetComponent<Text>().text = "Skill Points: " + PlayerInfo.skillpoints;
        StatHolder.transform.Find("Gold").GetComponent<Text>().text = "Gold: " + PlayerInfo.Gold;
        StatHolder.transform.Find("Damage").GetComponent<Text>().text = "Damage: " + AttackDamage;
        StatHolder.transform.Find("HealthRegen").GetComponent<Text>().text = "Health Regen: " + PlayerInfo.HealthRegenRank;
        StatHolder.transform.Find("Critical Damage").GetComponent<Text>().text = "Critical Damage: " + CriticalDamage;
        StatHolder.transform.Find("Critical Chance").GetComponent<Text>().text = "Critical Chance: " + PlayerInfo.CriticalChance;
        StatHolder.transform.Find("Attack Speed").GetComponent<Text>().text = "Attack Speed: " + AttackSpeedRank;
        StatHolder.transform.Find("Stun Chance").GetComponent<Text>().text = "Stun Chance: " + StunChance;
        StatHolder.transform.Find("MultiAttackChance").GetComponent<Text>().text = "Multi-Attack Chance: " + MultiAttackChance;
        StatHolder.transform.Find("MultiAttackDamage").GetComponent<Text>().text = "Multi-Attack Damage: " + MultiAttackDamage;
        StatHolder.transform.Find("AbilityDamage").GetComponent<Text>().text = "Ability Damage: " + AbilityDamage;
        StatHolder.transform.Find("AOEChance").GetComponent<Text>().text = "AOE Chance: " + AOEChance;
        StatHolder.transform.Find("BlockChance").GetComponent<Text>().text = "Block Chance: " + BlockChance;
        StatHolder.transform.Find("CooldownReduction").GetComponent<Text>().text = "Cooldown Reduction: " + CooldownReduction;
        StatHolder.transform.Find("GoldBonus").GetComponent<Text>().text = "Gold Bonus: " + GoldBonus;
        StatHolder.transform.Find("DamageBonus").GetComponent<Text>().text = "Damage Bonus: " + BonusDamage;
        StatHolder.transform.Find("EXPBonus").GetComponent<Text>().text = "EXP Bonus: " + EXPBonus;
        StatHolder.transform.Find("HealthBonus").GetComponent<Text>().text = "Health Bonus: " + PlayerInfo.HealthBonus;
        StatHolder.transform.Find("DodgeChance").GetComponent<Text>().text = "Dodge Chance: " + PlayerInfo.DodgeChance;
        StatHolder.transform.Find("StaminaRegen").GetComponent<Text>().text = "Stamina Regen Bonus: " + PlayerInfo.StaminaRegen;
        StatHolder.transform.Find("AOEDamage").GetComponent<Text>().text = "AOE Damage: " + PlayerInfo.AOEDamage;
        StatHolder.transform.Find("ArmourStats").GetComponent<Text>().text = "Armour protection" + PlayerInfo.armour;
    }

    public void CheckSkillStamina()
    {
        //checks the button variable to check if it has been set
        if(Slot1 != null)
        {
            //Checks if the skill 1 stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (Skill1Stamina > stamina || (Enemy == null && FightingBoss == false) || Slot1.GetComponentInChildren<Text>().text == "" || Slot1.GetComponent<Cooldown>().OnCooldown == true)
            {
                Slot1.interactable = false;
            }
            else
            {
                Slot1.interactable = true;
            }
        }
        //checks the button variable to check if it has been set
        if (Slot2 != null)
        {
            //Checks if the skill 2 stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (Skill2Stamina > stamina || (Enemy == null && FightingBoss == false) || Slot2.GetComponentInChildren<Text>().text == "" || Slot2.GetComponent<Cooldown>().OnCooldown == true)
            {
                Slot2.interactable = false;
            }
            else
            {
                Slot2.interactable = true;
            }
        }
        //checks the button variable to check if it has been set
        if (Slot3 != null)
        {
            //Checks if the skill 3 stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (Skill3Stamina > stamina || (Enemy == null && FightingBoss == false) || Slot3.GetComponentInChildren<Text>().text == "" || Slot3.GetComponent<Cooldown>().OnCooldown == true)
            {
                Slot3.interactable = false;
            }
            else
            {
                Slot3.interactable = true;
            }
        }
        //checks the button variable to check if it has been set
        if (Buff1 != null)
        {
            //Checks if the buff 1 stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (Buff1Stamina > stamina || (Enemy == null && FightingBoss == false) || Buff1.GetComponentInChildren<Text>().text == "" || Buff1.GetComponent<Cooldown>().OnCooldown == true)
            {
                Buff1.interactable = false;
            }
            else
            {
                Buff1.interactable = true;
            }
        }
        //checks the button variable to check if it has been set
        if (Buff2 != null)
        {
            //Checks if the buff 2 stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (Buff2Stamina > stamina || (Enemy == null && FightingBoss == false) || Buff2.GetComponentInChildren<Text>().text == "" || Buff2.GetComponent<Cooldown>().OnCooldown == true)
            {
                Buff2.interactable = false;
            }
            else
            {
                Buff2.interactable = true;
            }
        }
        //checks the button variable to check if it has been set
        if (Buff3 != null)
        {
            //Checks if the buff 3 stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (Buff3Stamina > stamina || (Enemy == null && FightingBoss == false) || Buff3.GetComponentInChildren<Text>().text == "" || Buff3.GetComponent<Cooldown>().OnCooldown == true)
            {
                Buff3.interactable = false;
            }
            else
            {
                Buff3.interactable = true;
            }
        }
        //checks the button variable to check if it has been set
        if (UltimateSkillSlot != null)
        {
            //Checks if the ultimate skill stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (UltimateSkillStamina > stamina || (Enemy == null && FightingBoss == false) || UltimateSkillSlot.GetComponentInChildren<Text>().text == "" || UltimateSkillSlot.GetComponent<Cooldown>().OnCooldown == true)
            {
                UltimateSkillSlot.interactable = false;
            }
            else
            {
                UltimateSkillSlot.interactable = true;
            }
        }
                //checks the button variable to check if it has been set
        if (UltimateBuffSlot != null)
        {
            //Checks if the ultimate buff stamina value is higher then the player's stamina and if too low the button becomes uninteractable
            if (UltimateBuffStamina > stamina || (Enemy == null && FightingBoss == false) || UltimateBuffSlot.GetComponentInChildren<Text>().text == "" || UltimateBuffSlot.GetComponent<Cooldown>().OnCooldown == true)
            {
                UltimateBuffSlot.interactable = false;
            }
            else
            {
                UltimateBuffSlot.interactable = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Autoattck, continusly does damage to the enemy
        if (other.gameObject.tag == "Enemy")
        {
            Enemy = other.gameObject;
            if(Enemy.GetComponent<EnemyAI>() == null)
            {
                if (Enemy.GetComponent<RangedEnemyAI>().EnemyHealth != 0)
                {

                    //First attack hit immediatly then frequency of attack rate depends on the attack speed rank
                    StartCoroutine(Attack(Enemy));
                }
            }
            else
            {
                if (Enemy.GetComponent<EnemyAI>().EnemyHealth != 0)
                {
                    //First attack hit immediatly then frequency of attack rate depends on the attack speed rank
                    StartCoroutine(Attack(Enemy));
                }
            }
        }

        if (other.transform.tag == "Boss")
        {
            Boss = other.GetComponent<Boss1>();
            FightingBoss = true;
        }
    }

    IEnumerator Attack(GameObject FightingEnemy)
    {
        if (FightingEnemy)
        {
            //Changes script slightly if enemy is ranged or normal
            if (FightingEnemy.GetComponent<EnemyAI>() == null)
            {
                while (FightingEnemy && FightingEnemy.GetComponent<RangedEnemyAI>().EnemyHealth > 0)
                {
                    //checks if the enemy is frozen and if it is doubles the damage done
                    if (FightingEnemy.GetComponent<RangedEnemyAI>().IsFrozen == true)
                    {
                        //Critical hit calculations
                        if (Random.value < CriticalChance || GuranteedCrit)
                        {
                            //Critical hit when frozen deals even more damage
                            FightingEnemy.GetComponent<RangedEnemyAI>().EnemyHealth -= CriticalDamage * 2;
                            //Critical sound effect playes
                            Audio.CriticalHit.Play();
                            //Activates camera shake
                            StartCoroutine(cameraShake.Shake(CamShakeDuration, CamShakeMagnitude));
                            //Displays floating text
                            FloatingTextController.CreatFloatingText((CriticalDamage * 2).ToString(), FightingEnemy.transform);
                            //Guranteed critical set to false
                            GuranteedCrit = false;
                        }
                        else
                        {
                            //Deals double damage
                            FightingEnemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage * 2;
                            //Displays floating text
                            FloatingTextController.CreatFloatingText((AttackDamage * 2).ToString(), FightingEnemy.transform);
                        }
                    }
                    else
                    {
                        //Critical hit chance
                        if (Random.value < CriticalChance || GuranteedCrit)
                        {
                            //Deals critical damage
                            FightingEnemy.GetComponent<RangedEnemyAI>().EnemyHealth -= CriticalDamage;
                            //Critical sound effect playes
                            Audio.CriticalHit.Play();
                            //Activates camera shake
                            StartCoroutine(cameraShake.Shake(CamShakeDuration, CamShakeMagnitude));
                            //Displays floating text
                            FloatingTextController.CreatFloatingText(CriticalDamage.ToString(), FightingEnemy.transform);
                            //Guranteed critical set to false
                            GuranteedCrit = false;
                        }
                        else
                        {
                            //Deals regular damage
                            FightingEnemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage;
                            //Displays floating text
                            FloatingTextController.CreatFloatingText(AttackDamage.ToString(), FightingEnemy.transform);
                        }
                    }

                    //Calculates stun chance
                    if (Random.value < StunChance)
                    {
                        FightingEnemy.GetComponent<RangedEnemyAI>().IsStunned = true;
                        EffectDuration = 5;
                        FightingEnemy.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
                    }
                    yield return new WaitForSeconds(AttackSpeedRank);
                }
            }
            else
            {
                while (FightingEnemy && FightingEnemy.GetComponent<EnemyAI>().EnemyHealth > 0)
                {
                    //checks if the enemy is frozen and if it is doubles the damage done
                    if (FightingEnemy.GetComponent<EnemyAI>().IsFrozen == true)
                    {
                        //Critical hit calculations
                        if (Random.value < CriticalChance || GuranteedCrit)
                        {
                            //Critical hit when frozen deals even more damage
                            FightingEnemy.GetComponent<EnemyAI>().EnemyHealth -= CriticalDamage * 2;
                            //Critical sound effect playes
                            Audio.CriticalHit.Play();
                            //Activates camera shake
                            StartCoroutine(cameraShake.Shake(CamShakeDuration, CamShakeMagnitude));
                            //Displays floating text
                            FloatingTextController.CreatFloatingText((CriticalDamage * 2).ToString(), FightingEnemy.transform);
                            //Guranteed critical set to false
                            GuranteedCrit = false;
                        }
                        else
                        {
                            //Deals double damage
                            FightingEnemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage * 2;
                            //Displays floating text
                            FloatingTextController.CreatFloatingText((AttackDamage * 2).ToString(), FightingEnemy.transform);
                        }

                    }
                    else
                    {
                        //Critical hit chance
                        if (Random.value < CriticalChance)
                        {
                            //Deals critical damage
                            FightingEnemy.GetComponent<EnemyAI>().EnemyHealth -= CriticalDamage;
                            //Displays floating text
                            FloatingTextController.CreatFloatingText(CriticalDamage.ToString(), FightingEnemy.transform);
                            //Guranteed critical set to false
                            GuranteedCrit = false;
                        }
                        else
                        {
                            //Deals regular damage
                            FightingEnemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage;
                            //Displays floating text
                            FloatingTextController.CreatFloatingText(AttackDamage.ToString(), FightingEnemy.transform);
                        }
                    }

                    //Calculates stun chance
                    if (Random.value < StunChance)
                    {
                        FightingEnemy.GetComponent<EnemyAI>().IsStunned = true;
                        EffectDuration = 5;
                        FightingEnemy.GetComponent<EnemyAI>().StunDuration = EffectDuration;
                    }
                    yield return new WaitForSeconds(AttackSpeedRank);
                }
            }

            if (FightingEnemy)
            {
                DeadEnemy = FightingEnemy;
                EnemyDeathCheck();
            }
        }
    }

    public void EnemyDeathCheck()
    {
        if(DeadEnemy.GetComponent<EnemyAI>() != null)
        {
            //check that is the enemy health goes under 0 through methods other then the auto attack
            if (DeadEnemy.GetComponent<EnemyAI>().EnemyHealth <= 0)
            {
                //Reactivates the navmesh for the player to start moving
                GetComponent<NavMeshAgent>().isStopped = false;
                //Spawn Gold
                EnemyPosition = DeadEnemy.GetComponent<Transform>().position;
                Instantiate(GoldPrefab, EnemyPosition, Quaternion.identity);
                //Unlocks the player's postion
                RB.constraints = RigidbodyConstraints.None;
                if (!this.GetComponent<PlayerStats>().MaxLevel)
                {
                    if (QuickLearnerActive)
                    {
                        //5% chance of getting double exp
                        if (Random.value <= 0.05)
                        {
                            //Adds experiance
                            GetComponent<PlayerStats>().exp += (DeadEnemy.GetComponent<EnemyStates>().EXPGiven * EXPBonus) * 2;
                        }

                        //Adds experiance
                        GetComponent<PlayerStats>().exp += (DeadEnemy.GetComponent<EnemyStates>().EXPGiven * EXPBonus);
                    }
                    else
                    {
                        //Adds experiance
                        GetComponent<PlayerStats>().exp += (DeadEnemy.GetComponent<EnemyStates>().EXPGiven * EXPBonus);
                    }
                }
                if (DeadEnemy.GetComponent<EnemyAI>() != null)
                {
                    DeadEnemy.GetComponent<EnemyAI>().Player = null;
                }
                else
                {
                    DeadEnemy.GetComponent<RangedEnemyAI>().Player = null;
                }
                //Spanws a item droprate % of the time
                if (Random.value > droprate)
                {
                    Instantiate(Item[Random.Range(0, Item.Length)],transform.position,Quaternion.identity);
                    if (HoardSpotterActive)
                    {
                        if(Random.value <= 0.05)
                        {
                            Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                            Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                        }
                    }
                } 
                //Delete enemy
                Destroy(DeadEnemy.gameObject);
                //Plays enemy death sound
                
                Audio.EnemyDeath.Play();
                //Empty the enemy variable
                DeadEnemy = null;
                //Allows player to start regening health and stamina
                GetComponent<PlayerStats>().Rest = true;
                if (LimbHarvestActivated == true)
                {
                    AttackDamage += 5;
                }
                GetComponent<PlayerNavi>().LookForNextTarget = true;
                if (ExplosiveFluryActive)
                {
                    StartCoroutine(ExplosiveFlury());
                }
                if (CarefulApproachActive)
                {
                    StartCoroutine(CarefulApproach());
                }
            }
        }
        else
        {
            //check that is the enemy health goes under 0 through methods other then the auto attack
            if (DeadEnemy.GetComponent<RangedEnemyAI>().EnemyHealth <= 0)
            {
                //Reactivates the navmesh for the player to start moving
                GetComponent<NavMeshAgent>().isStopped = false;
                //Spawn Gold
                EnemyPosition = DeadEnemy.GetComponent<Transform>().position;
                Instantiate(GoldPrefab, EnemyPosition, Quaternion.identity);
                //Unlocks the player's postion
                RB.constraints = RigidbodyConstraints.None;
                if (!this.GetComponent<PlayerStats>().MaxLevel)
                {
                    if (QuickLearnerActive)
                    {
                        //5% chance of getting double exp
                        if (Random.value <= 0.05)
                        {
                            //Adds experiance
                            GetComponent<PlayerStats>().exp += (DeadEnemy.GetComponent<EnemyStates>().EXPGiven * EXPBonus) * 2;
                        }

                        //Adds experiance
                        GetComponent<PlayerStats>().exp += (DeadEnemy.GetComponent<EnemyStates>().EXPGiven * EXPBonus);
                    }
                    else
                    {
                        //Adds experiance
                        GetComponent<PlayerStats>().exp += DeadEnemy.GetComponent<EnemyStates>().EXPGiven * EXPBonus;
                    }
                }
                //Spanws a item 40% of the time
                if (Random.value < 0.4)
                {
                    Instantiate(Item[Random.Range(0, Item.Length)],transform.position,Quaternion.identity);
                    if (HoardSpotterActive)
                    {
                        if (Random.value <= 0.05)
                        {
                            Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                            Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
                        }
                    }
                }
                //Delete enemy
                Destroy(DeadEnemy.gameObject);
                //Plays enemy death sound
                Audio.EnemyDeath.Play();
                //Empty the enemy variable
                DeadEnemy = null;
                //Allows player to start regening health and stamina
                GetComponent<PlayerStats>().Rest = true;
                if (LimbHarvestActivated == true)
                {
                    AttackDamage += 5;
                }
                GetComponent<PlayerNavi>().LookForNextTarget = true;
                if (ExplosiveFluryActive)
                {
                    StartCoroutine(ExplosiveFlury());
                }
                if (CarefulApproachActive)
                {
                    StartCoroutine(CarefulApproach());
                }
            }
        }
        if (ShadowMergeActive)
        {
            if (Random.value <= 0.05)
            {
                StartCoroutine(ShadowMerge());
            }
        }
    }

    private IEnumerator ShadowMerge()
    {
        EnemyCombat[] Enemies = FindObjectsOfType<EnemyCombat>();
        foreach (EnemyCombat Baddies in Enemies)
        {
            Baddies.CanAttack = false;
        }
        yield return new WaitForSeconds(5);
        foreach (EnemyCombat Baddies in Enemies)
        {
            Baddies.CanAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            CancelInvoke("Attack");
        }
    }

 

    public void SavePassiveAbilities()
    {
        SavePassiveBinary.SavePassiveAbilities(this);
    }

    public void LoadPassiveAbilities()
    {
        //Checks if the save file has anything in it
        FileStream stream = new FileStream(Application.persistentDataPath + "/PlayerPassiveAbilities.data", FileMode.Open, FileAccess.Read);
        if (stream.Length != 0)
        {
            //Closes stream used to check iformation
            stream.Close();
            SaveSystem data = SavePassiveBinary.LoadPassiveAbility();

            UnlockedPassiveAbilities = data.UnlockedPassiveAbilities;
            PassiveRank = data.UnlockedPassiveRank;

            
            GameObject[] PassiveStorage = GameObject.FindGameObjectsWithTag("PassiveAbilitiesButtons");

            foreach(GameObject Passive in PassiveStorage)
            {
                if (UnlockedPassiveAbilities.Contains(Passive.name))
                {
                    int Index = UnlockedPassiveAbilities.IndexOf(Passive.name);
                    int rank = PassiveRank[Index];
                    Passive.GetComponent<SkillValue>().SkillLevel = rank;
                    Debug.Log(Passive.name + " " + Passive.GetComponent<SkillValue>().SkillLevel);
                }
            }

            GameObject.FindGameObjectWithTag("Canvas").GetComponent<ReChooseSkills>().SkillMenu.GetComponent<Skills>().CheckSkillPoints(); 
        }
    }

    //Function to stop the player from autoattacking
    public void StopInvoke()
    {
        CancelInvoke("Attack");
    }

    private IEnumerator ExplosiveFlury()
    {
        AOEChance *= 2;
        yield return new WaitForSeconds(10);
        AOEChance /= 2;
    }

    private IEnumerator CarefulApproach()
    {
        CarefulApproachTurnedOn = true;
        yield return new WaitForSeconds(5);
        CarefulApproachTurnedOn = false;
    }

    public void SummonMinion(bool Start)
    {
        //Only lose money when not on start
        if (!Start)
        {
            this.GetComponent<PlayerStats>().Gold -= MinionCost;
        }
        //Button un-interactable if the player has max number of minions or can't afford one
        if (this.GetComponent<PlayerStats>().Gold < MinionCost || MinionCount == MaxNumOfMinions)
            SummonMinionButton.interactable = false;
        
        Vector3 MinionSpawnPoint;

        //Variables used to calculate the distance between the player and the Minion Spawn point
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject SpawnPoint in MinionSpawnPoints)
        {
            //Calculates the difference between the player and the Minion Spawn point
            Vector3 diff = SpawnPoint.transform.position - position;
            //Turns that number into a float that can be compared to each other
            float curDistance = diff.sqrMagnitude;
            //Checks if the current distance is smaller then the previously saved distance
            if (curDistance < distance)
            {
                //Stores the spawn point as the closest spawn point
                closest = SpawnPoint;
                //sets curDistance as the new smallest distance
                distance = curDistance;
            }
        }

        //Sets the spawn point
        MinionSpawnPoint = closest.transform.position;

        //Doesn't activate when the function is spawned on start
        if (!Start)
        {
            //Adds to the minion count
            MinionCount += 1;
            //Sound effect for summon a minion
           
            Audio.SummonMinion.Play();
        }
        //Spawns the Minion
        GameObject MyIntantiate = Instantiate(Minion, MinionSpawnPoint, Quaternion.identity);
        //Sets the minion's speed to 90% of the player's
        MyIntantiate.GetComponent<NavMeshAgent>().speed = this.GetComponent<NavMeshAgent>().speed * 0.9f;
        MyIntantiate.GetComponent<NavMeshAgent>().angularSpeed = this.GetComponent<NavMeshAgent>().angularSpeed;

        //Allows for Gift Giver skill to activate
        MinionCheck();
    }

    public void MinionCheck()
    {
        //checks if there any other minion on scene, if not then the minion on scene is set to false
        if (GameObject.FindWithTag("Minion") == null)
        {
            MinionOnScene = false;
            //Checks if the player's 3rd skill is Gift Giver and if it is make the button uninteractable
            if (Slot3.GetComponentInChildren<Text>().text == "Gift Giver")
            {
                Slot3.interactable = false;
            }
        }

        //If the player has less then 3 minions and enough gold the player can summon a minion
        if(MinionCount < 3 && this.GetComponent<PlayerStats>().Gold > MinionCost)
        {
            SummonMinionButton.interactable = true;
            Debug.Log("Summon Minion active");
        }
        //If the player has too many minions or doesn't have enough money then the player can't summon a minion
        else
        {
            SummonMinionButton.interactable = false;
            Debug.Log("Summon Minion not active");
        }
    }

    private void SkillOffCooldown()
    {
        List<Button> ButtonsCooldown = new List<Button>();

        //checks if the skill are on cooldown and adds them to the list
        if (Slot1.GetComponent<Cooldown>().OnCooldown == true)
            ButtonsCooldown.Add(Slot1);

        if (Slot2.GetComponent<Cooldown>().OnCooldown == true)
            ButtonsCooldown.Add(Slot2);

        if (Slot3.GetComponent<Cooldown>().OnCooldown == true)
            ButtonsCooldown.Add(Slot3);

        if (Buff1.GetComponent<Cooldown>().OnCooldown == true)
            ButtonsCooldown.Add(Buff1);

        if (Buff2.GetComponent<Cooldown>().OnCooldown == true)
            ButtonsCooldown.Add(Buff2);

        if (Buff3.GetComponent<Cooldown>().OnCooldown == true)
            ButtonsCooldown.Add(Buff3);

        if (UltimateSkillSlot.GetComponent<Cooldown>().OnCooldown)
            ButtonsCooldown.Add(UltimateSkillSlot);

        if (UltimateBuffSlot.GetComponent<Cooldown>().OnCooldown)
            ButtonsCooldown.Add(UltimateBuffSlot);

        //Chooses a random button from the list
        Button OffCooldown = ButtonsCooldown[Random.Range(0, ButtonsCooldown.Count)];
        //Puts the skill of cooldown
        OffCooldown.interactable = true;
        OffCooldown.GetComponent<Cooldown>().OnCooldown = false;
    }

    public void MultiAttackActivate()
    {

        if (stamina <= 0)
        {
            MultiAttack.interactable = false;
        }
        else
        {
            if (!FightingBoss)
            {
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    //Lower Enemy health
                    Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage;
                    //Lower Stamina
                    stamina -= 5;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                else
                {
                    //Lower Enemy health
                    Enemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage;
                    //Lower Stamina
                    stamina -= 5;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
            }
            else
            {
                Boss.Health -= AttackDamage;
            }
        }
    }

    public void BreathOfLife(int cooldown)
    {
        if (stamina <= 0)
        {
            Buff1.interactable = false;
        }
        else if(stamina>=5)
        {
            //heals player
            GetComponent<PlayerStats>().Health += 5;
            if (FlurryOfAttacksActivated == false)
                stamina -= Buff1Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff1.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        BreathOfLife(cooldown);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            //Play healing sound effect
            Audio.HealingSpell.Play();

            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if(Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public IEnumerator Rage(int cooldown)
    {
        if (stamina <= 0)
        {
            Slot1.interactable = false;
        }
        else if(stamina>=5)
        {
            if (FlurryOfAttacksActivated == false)
                //Lower Stamina
                stamina -= Skill1Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            //Changes player colour
            PlayerColour.material = CharacterFlash;
            //Increases player's damage
            AttackDamage += 5;
            //Timer
            EffectDuration = 10;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot1.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
            //Plays upgrade audio
            Audio.UpgradeSound.Play();
            yield return new WaitForSeconds(EffectDuration);
            //resets damage
            AttackDamage = Damage;
            //changes player's colour back to default
            PlayerColour.material = DefaultColour;
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        StartCoroutine(Rage(cooldown));
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
        }
    }

    public IEnumerator SurvivalInstinct(int cooldown)
    {
        if (stamina <= 0)
        {
            Buff1.interactable = false;
        }
        else if(stamina>=5)
        {
            //Increases dodge chance, needs to be changed to add a percentage of the state instead of a flat number
            GetComponent<PlayerStats>().DodgeChance = DodgeChance += Mathf.CeilToInt(((float)DodgeChance) / 5);
            if (FlurryOfAttacksActivated == false)
                //Lower Stamina
                stamina -= Buff1Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            //Changes player's colour
            PlayerColour.material = CharacterFlash;
            //Timer
            EffectDuration = 5;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff1.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
            //Plays upgrade audio
            Audio.UpgradeSound.Play();
            yield return new WaitForSeconds(EffectDuration);
            //resets the dodge chance
            GetComponent<PlayerStats>().DodgeChance = DodgeChance;
            //changes player's colour back to default
            PlayerColour.material = DefaultColour;
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        StartCoroutine(SurvivalInstinct(cooldown));
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
        }
    }

    public void HuntingInstinct(int cooldown)
    {
        if (stamina <= 0)
        {
            Slot1.interactable = false;
        }
        else if (stamina >= 5)
        {
            if (!FightingBoss)
            {
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    //Lower Enemy health
                    Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= (int)AbilityDamage;
                    if (FlurryOfAttacksActivated == false)
                        //Lower Stamina
                        stamina -= Skill1Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                else
                {
                    //Lower Enemy health
                    Enemy.GetComponent<EnemyAI>().EnemyHealth -= (int)AbilityDamage;
                    if (FlurryOfAttacksActivated == false)
                        //Lower Stamina
                        stamina -= Skill1Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                FloatingTextController.CreatFloatingText(AbilityDamage.ToString(), Enemy.transform);
            }
            else
            {
                Boss.Health -= (int)AbilityDamage; ;
                if (FlurryOfAttacksActivated == false)
                    stamina -= Skill1Stamina;
                FloatingTextController.CreatFloatingText(AbilityDamage.ToString(), Enemy.transform);
            }
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot1.GetComponent<Cooldown>().ActivateCooldown(cooldown));

            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        HuntingInstinct(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            Audio.Slice1.Play();
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public void PetrifyingPresence(int cooldown)
    {
        if (stamina <= 0)
        {
            Buff1.interactable = false;
        }
        else if (stamina >= 5)
        {
            if (!FightingBoss)
            {
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    //Lower Enemy health
                    Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= (int)AbilityDamage;
                    if (FlurryOfAttacksActivated == false)
                        //Lower Stamina
                        stamina -= Buff1Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                else
                {
                    //Lower Enemy health
                    Enemy.GetComponent<EnemyAI>().EnemyHealth -= (int)AbilityDamage;
                    if (FlurryOfAttacksActivated == false)
                        //Lower Stamina
                        stamina -= Buff1Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                //Adds floating text to the attack
                FloatingTextController.CreatFloatingText(AbilityDamage.ToString(), Enemy.transform);
            }
            else
            {
                Boss.Health -= (int)AbilityDamage;
                if (FlurryOfAttacksActivated == false)
                    stamina -= Buff1Stamina;
                FloatingTextController.CreatFloatingText(AbilityDamage.ToString(), Enemy.transform);
            }

            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff1.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        PetrifyingPresence(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            Audio.PetrifyingPresence.Play();
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public void PresenceOfPain(int cooldown)
    {
        if (stamina <= 0)
        {
            Slot1.interactable = false;
        }
        else if (stamina >= 5)
        {
            if (!FightingBoss)
            {
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    //Lower Enemy health
                    Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= (int)AbilityDamage;
                    if (FlurryOfAttacksActivated == false)
                        //Lower Stamina
                        stamina -= Skill1Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                else
                {
                    //Lower Enemy health
                    Enemy.GetComponent<EnemyAI>().EnemyHealth -= (int)AbilityDamage;
                    if (FlurryOfAttacksActivated == false)
                        //Lower Stamina
                        stamina -= Skill1Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    DeadEnemy = Enemy;
                    EnemyDeathCheck();
                }
                FloatingTextController.CreatFloatingText(AbilityDamage.ToString(), Enemy.transform);
            }
            else
            {
                Boss.Health -= (int)AbilityDamage;
                if (FlurryOfAttacksActivated == false)
                    stamina -= Skill1Stamina;
                FloatingTextController.CreatFloatingText(AbilityDamage.ToString(), Enemy.transform);
            }
            if (FlurryOfAttacksActivated == false)
                Slot1.GetComponent<Cooldown>().ActivateCooldown(cooldown);
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        PresenceOfPain(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public void SteelBody()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to be uninteractable
        }
        else if(stamina>=5)
       
        {
            //Increase armour
            //Add ability to increase armour here
            //Lower Stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
    }

    public void BobAndWeave()
    {
        int Buff = SkillLevelTracker.BobAndWeaveBuff;
        //Increases dodge chance            
        GetComponent<PlayerStats>().DodgeChance = DodgeChance += Mathf.CeilToInt(((float)DodgeChance) / Buff); ;
    }

    public void MageArmour()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to make it uninteractable
        }
        else if (stamina >= 5)
        {
            //Stack armour, I have no idea what it means by that (Kieran Clements)
            //Lower stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
    }

    public void BiggerArms()
    {
        int buff = SkillLevelTracker.BiggerArmsBuff;
        //Increases bonus damage
        GetComponent<PlayerStats>().DamageBonus = (BonusDamage += Mathf.CeilToInt((float)BonusDamage) / buff);
    }

    public void TargetPractice()
    {
        int buff = SkillLevelTracker.TargetPracticeBuff;
        //Increases crit chance
        GetComponent<PlayerStats>().CriticalChance = (CriticalChance += Mathf.CeilToInt((float)CriticalChance) / buff);
    }

    public void ForceOfWill()
    {
        int buff = SkillLevelTracker.ForceOfWillBuff;
        //Increase ability damage
        GetComponent<PlayerStats>().AbilityDamage = (AbilityDamage += buff);
    }

    public void ThornSkin()
    {
        int buff = SkillLevelTracker.ThornSkinBuff;
        //Increase damage reflect
        GetComponent<PlayerStats>().DamageReflect = (DamageReflect += Mathf.CeilToInt((float)DamageReflect) / buff);
    }

    public void Riposte()
    {
        int Buff = SkillLevelTracker.RiposteBuff;
        //Increase block chance
        GetComponent<PlayerStats>().BlockChance = (BlockChance += Mathf.CeilToInt((float)BlockChance) / Buff);
    }

    public void ImprovedMemory()
    {
        int buff = SkillLevelTracker.ImprovedMemoryBuff;
        //Increase cooldown reduction
        GetComponent<PlayerStats>().CooldownReduction = (CooldownReduction += Mathf.CeilToInt((float)CooldownReduction) / buff);
    }

    public void Cleave()
    {
        int buff = SkillLevelTracker.CleaveBuff;
        //Increase AOE chance
        GetComponent<PlayerStats>().AOEChance = (AOEChance += Mathf.CeilToInt((float)AOEChance) / buff);
    }

    public void MultipleHands()
    {
        int buff = SkillLevelTracker.MultipleHandsBuff;
        //Increase Multi-Attack chance
        GetComponent<PlayerStats>().MultiattackChance = (MultiAttackChance += Mathf.CeilToInt((float)MultiAttackChance) / buff);
    }

    public void QuickRecharge()
    {
        int buff = SkillLevelTracker.QuickRechargeBuff;
        //Increase health regen
        GetComponent<PlayerStats>().StaminaRegen = (StaminaRegen += buff);
    }

    public void StunningQuake(int cooldown)
    {
        if(stamina <= 0)
        {
            Buff2.interactable = false;
        }
        else
        {
            //Needs to activate a AOE stun that pulls enemies closer
            Collider[] NearByEnemies = Physics.OverlapSphere(GetComponent<Transform>().position, 10);
            foreach (Collider hit in NearByEnemies)
            {
                //checks each gameobject to see if it has the tag enemy, if it does the stun code activates
                if (hit.gameObject.tag == "Enemy")
                {
                    //Calculates the difference between the enemy and the player
                    float distance = Vector3.Distance(hit.transform.position, transform.position);
                    //Moves enemies closer to the player
                    hit.GetComponent<Transform>().position = Vector3.MoveTowards(hit.transform.position, this.transform.position, distance - 2);
                    //Sets how long the stun will last
                    EffectDuration = 5;
                    //Stuns ranged enemies
                    if (hit.GetComponent<EnemyAI>() == null)
                    {
                        hit.GetComponent<RangedEnemyAI>().IsStunned = true;
                        hit.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
                    }
                    //Stuns normal enmemies
                    else
                    {
                        hit.GetComponent<EnemyAI>().IsStunned = true;
                        hit.GetComponent<EnemyAI>().StunDuration = EffectDuration;
                    }
                    //Displays stun message when the enemy is stunned
                    FloatingTextController.CreatFloatingText("Stunned", hit.transform);
                }
            }
            //Empties erray
            NearByEnemies = null;
            if (FlurryOfAttacksActivated == false)
                //Lowers stamina
                stamina -= Buff2Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff2.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        StunningQuake(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            Audio.StunningQuake.Play();
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public IEnumerator GhostlyTime(int cooldown)
    {
        if(stamina <= 0)
        {
            Buff2.interactable = false;
        }
        else
        {
            if (!FightingBoss)
            {
                if (Enemy.GetComponent<EnemyCombat>() == null)
                {
                    //Enemies can't damage player for 5-10 seconds
                    Enemy.GetComponent<RangedEnemyAI>().CanAttack = false;
                    if (FlurryOfAttacksActivated == false)
                        //Lower stamina 
                        stamina -= Buff2Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    //Randomly turns a skill off cooldown if multicast is active
                    if (MulticastActive)
                    {
                        if (Random.value <= 0.10)
                        {
                            SkillOffCooldown();
                        }
                    }
                    CheckSkillStamina();
                    //change player colour
                    PlayerColour.material = CharacterFlash;
                    //Sets effect duration
                    EffectDuration = 1;
                    //Play upgrade audio
                    Audio.UpgradeSound.Play();
                    //Waits for the effect duration length to pass
                    yield return new WaitForSeconds(EffectDuration);
                    //Lets the enemy attack again
                    Enemy.GetComponent<RangedEnemyAI>().CanAttack = true;
                    //Sets the effect duration back to 0
                    EffectDuration = 0;
                    //Set player colour back to default
                    PlayerColour.material = DefaultColour;
                }
                else
                {
                    //Enemies can't damage player for 5-10 seconds
                    Enemy.GetComponent<EnemyCombat>().CanAttack = false;
                    if (FlurryOfAttacksActivated == false)
                        //Lower stamina 
                        stamina -= Buff2Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                    //Randomly turns a skill off cooldown if multicast is active
                    if (MulticastActive)
                    {
                        if (Random.value <= 0.10)
                        {
                            SkillOffCooldown();
                        }
                    }
                    CheckSkillStamina();
                    //change player colour
                    PlayerColour.material = CharacterFlash;
                    //Sets effect duration
                    EffectDuration = 1;
                    //Play upgrade audio
                    Audio.UpgradeSound.Play();
                    //Waits for the effect duration length to pass
                    yield return new WaitForSeconds(EffectDuration);
                    //Lets the enemy attack again
                    Enemy.GetComponent<EnemyCombat>().CanAttack = true;
                    //Sets the effect duration back to 0
                    EffectDuration = 0;
                    //Set player colour back to default
                    PlayerColour.material = DefaultColour;
                }
            }
            else
            {
                //Enemies can't damage player for 5-10 seconds
                Boss.CanAttack = false;
                if (FlurryOfAttacksActivated == false)
                    //Lower stamina 
                    stamina -= Buff2Stamina;
                GetComponent<PlayerStats>().currentstanima = stamina;
                //Randomly turns a skill off cooldown if multicast is active
                if (MulticastActive)
                {
                    if (Random.value <= 0.10)
                    {
                        SkillOffCooldown();
                    }
                }
                CheckSkillStamina();
                //change player colour
                PlayerColour.material = CharacterFlash;
                //Sets effect duration
                EffectDuration = 1;
                //Play upgrade audio
                Audio.UpgradeSound.Play();
                //Waits for the effect duration length to pass
                yield return new WaitForSeconds(EffectDuration);
                //Lets the enemy attack again
                Boss.CanAttack = true;
                //Sets the effect duration back to 0
                EffectDuration = 0;
                //Set player colour back to default
                PlayerColour.material = DefaultColour;
            }
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff2.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        StartCoroutine(GhostlyTime(0));
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
        }
    }

    public void ConeOfTundra(int cooldown)
    {
        if(stamina <= 0)
        {
            Buff2.interactable = false;
        }
        else
        {
            if (!FightingBoss)
            {
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    //Freeze enemy, takes more damage when frozen
                    Enemy.GetComponent<RangedEnemyAI>().IsStunned = true;
                    EffectDuration = 5;
                    Enemy.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
                    //Sets the enemy to frozen state
                    Enemy.GetComponent<RangedEnemyAI>().IsFrozen = true;
                    if (FlurryOfAttacksActivated == false)
                        //Lower stamina
                        stamina -= Buff2Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                }
                else
                {
                    //Freeze enemy, takes more damage when frozen
                    Enemy.GetComponent<EnemyAI>().IsStunned = true;
                    EffectDuration = 5;
                    Enemy.GetComponent<EnemyAI>().StunDuration = EffectDuration;
                    //Sets the enemy to frozen state
                    Enemy.GetComponent<EnemyAI>().IsFrozen = true;
                    if (FlurryOfAttacksActivated == false)
                        //Lower stamina
                        stamina -= Buff2Stamina;
                    GetComponent<PlayerStats>().currentstanima = stamina;
                }
            }
            else
            {
                EffectDuration = 5;
                if (FlurryOfAttacksActivated == false)
                    stamina -= Buff2Stamina;
                StartCoroutine(Boss.IsStunned(EffectDuration));

            }
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff2.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        ConeOfTundra(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            //Plays ice sound effect
            Audio.Ice.Play();
            CheckSkillStamina();
        }
    }

    public IEnumerator LimbHarvest(int cooldown)
    {
        if(stamina <= 0)
        {
            Slot2.interactable = false;
        }
        else
        {
            if (FlurryOfAttacksActivated == false)
                //Lower stamina
                stamina -= Skill2Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Increase damage with each kill for duration of the skill
            LimbHarvestActivated = true;
            //Displays text when Limb Harvest activates
            FloatingTextController.CreatFloatingText("Limb Harvest Activated", this.transform);
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            //changes player's colour
            PlayerColour.material = CharacterFlash;
            EffectDuration = 30;
            //Play upgrade audio
            Audio.UpgradeSound.Play();
            yield return new WaitForSeconds(EffectDuration);
            //Resets the attack damage
            AttackDamage = Damage;
            //Deactivates Limb Harvest
            LimbHarvestActivated = false;
            PlayerColour.material = DefaultColour;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot2.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        StartCoroutine(LimbHarvest(0));
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
        }
    }

    public void BurnBaby(int cooldown)
    {
        if(stamina < 10)
        {
            //Do nothing, alter button to make it uninteractable
            Slot2.interactable = false;
        }
        else
        {
            //buring damage in a line around 2-4 feet, can burn enemies
            GameObject MyInstantiate = Instantiate(AOELine, transform.position + (transform.forward * 5), transform.rotation);
            MyInstantiate.GetComponent<AOEAttack>().AttackDamage = AOEAttackDamage;
            MyInstantiate.GetComponent<AOEAttack>().AttackTime = 5;
            MyInstantiate.GetComponent<AOEAttack>().DotActivate = true;
            MyInstantiate.GetComponent<AOEAttack>().DotDamage = 5;
            if (FlurryOfAttacksActivated == false)
                //Lower stamina 
                stamina -= Skill2Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot2.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        BurnBaby(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            //Plays fire sound effect
            Audio.Fire.Play();
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public void ConeOfUnlife(int cooldown)
    {
        if(stamina <= 0)
        {
            Slot2.interactable = false;
        }
        else
        {
            //cone of damage and makes enemies minions
            GameObject MyInstantiate = Instantiate(AOECone, transform.position + (transform.forward * 2), Quaternion.identity);
            MyInstantiate.GetComponent<AOEAttack>().AttackDamage = AOEAttackDamage;
            MyInstantiate.GetComponent<AOEAttack>().AttackTime = 3;
            MyInstantiate.GetComponent<AOEAttack>().DotActivate = false;
            MyInstantiate.GetComponent<AOEAttack>().DotDamage = 5;
            MyInstantiate.GetComponent<AOEAttack>().CreatesMinion = true;
            if (FlurryOfAttacksActivated == false)
                //Lower stamina
                stamina -= Skill2Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot2.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        ConeOfUnlife(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            //Play dark magic sound
            Audio.DarkMagic.Play();
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public void ArtOfTraining()
    {
        int buff = SkillLevelTracker.ArtOfTrainingBuff;
        //Increases exp bonus
        GetComponent<PlayerStats>().EXPBonus = (EXPBonus += Mathf.CeilToInt((float)EXPBonus) / buff);
    }

    public void Pennies()
    {
        int Buff = SkillLevelTracker.PenniesBuff;
        //Increases gold bonus
        GetComponent<PlayerStats>().GoldBonus = (GoldBonus += Mathf.CeilToInt((float)GoldBonus) / Buff);
    }

    public void RollTheDice()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to make it uninteractable
        }
        else
        {
            //Randomly takes skill of cooldown
            SkillOffCooldown();
            //Lower stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
    }

    public void FlurryOfAttacks()
    {
        FlurryOfAttacksUnlock = true;
        FlurryOfAttacksBuff = SkillLevelTracker.FlurryOfAttacksBuff;
    }

    public void Frostbite()
    {
        int buff = SkillLevelTracker.FrostbiteBuff;
        if (!FightingBoss)
        {
            if (Enemy.GetComponent<EnemyAI>() == null)
            {
                //Chance of freezing enemy for 10 seconds
                Enemy.GetComponent<RangedEnemyAI>().IsStunned = true;
                Enemy.GetComponent<RangedEnemyAI>().IsFrozen = true;
                EffectDuration = buff;
                //Sets the length of the stun
                Enemy.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
            }
            else
            {
                //Chance of freezing enemy for 10 seconds
                Enemy.GetComponent<EnemyAI>().IsStunned = true;
                Enemy.GetComponent<EnemyAI>().IsFrozen = true;
                EffectDuration = buff;
                //Sets the length of the stun
                Enemy.GetComponent<EnemyAI>().StunDuration = EffectDuration;
            }
            FloatingTextController.CreatFloatingText("Enemy Frozen", Enemy.transform);
        }
        else
        {
            EffectDuration = buff;
            StartCoroutine(Boss.IsStunned(EffectDuration));
        }
        Audio.Ice.Play();
    }

    public void ReflectiveArmour()
    {
        int buff = SkillLevelTracker.ReflectiveArmourBuff;
        if(Random.value < 0.6)
        {
            if (!FightingBoss)
            {
                EffectDuration = buff;
                Enemy.GetComponent<EnemyAI>().IsStunned = true;
                Enemy.GetComponent<EnemyAI>().StunDuration = EffectDuration;
            }
            else
            {
                EffectDuration = buff;
                StartCoroutine(Boss.IsStunned(EffectDuration));
            }
        }
    }

    public void BackAtYou()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to make it uninteractable
        }
        else
        {
            //chance to counter attack when hit
            CanCounter = true;
        }
    }

    public void GateOfChaos()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to make it uninteractable
        }
        else
        {
            //chance of teleporting to random destination
            if (GameObject.FindGameObjectsWithTag("Destination") != null)
            {
                GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Destination");
                //GameObject TeleportDestination = Destinations[Random.Range(0, Destinations.Length)];
                this.transform.position = Destinations[Random.Range(0, Destinations.Length)].transform.position;
            }
            else
            {
                this.transform.position = GameObject.FindGameObjectWithTag("FinalDestination").transform.position;
            }
            Audio.DarkMagic.Play();
            //Lower stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
    }

    public void Massacre()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to make it uninterctable
        }
        else
        {
            //chance of triggering effects twice
            //Lower stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
    }

    public void Echo()
    {
        if(stamina <= 0)
        {
            //Do nothing, alter button to make it uninteractable
        }
        else
        {
            //chance to trigger spell twice
            //Lower stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
    }

    public void HeavyLanding()
    {
        int buff = SkillLevelTracker.HeavyLandingBuff;
        //Heavy landing sound effect plays
        Audio.HeavyLanding.Play();
        if (!FightingBoss)
        {
            //Gets every GameObject with the tag enemy
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //Sets length of stun
            EffectDuration = buff;
            //chance to stun enemy when level starts
            foreach (GameObject Enemy in Enemies)
            {
                //checks to see if the enemy has an enemy AI script as ranged enemies work of a different script
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    Enemy.GetComponent<RangedEnemyAI>().IsStunned = true;
                    //Sets how long the stun will last
                    Enemy.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
                }
                else
                {
                    Enemy.GetComponent<EnemyAI>().IsStunned = true;
                    //Sets how long the stun will last for
                    Enemy.GetComponent<EnemyAI>().StunDuration = EffectDuration;
                }
            }
        }
        else
        {
            Boss1 Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss1>();
            EffectDuration = buff;
            StartCoroutine(Boss.IsStunned(EffectDuration));
        }
        FloatingTextController.CreatFloatingText("Heavy Landing", this.transform);
    }

    public void DisarmingPresence(int cooldown)
    {
        if(stamina <= 0)
        {
            Buff3.interactable = false;
        }
        else
        {
            //Nearby enemies drop weapons, lowers their damage
            //Lower stamina
            stamina -= 5;
            GetComponent<PlayerStats>().currentstanima = stamina;
            CheckSkillStamina();
            StartCoroutine(Buff3.GetComponent<Cooldown>().ActivateCooldown(cooldown));
        }
    }

    public void ShieldStorm(int cooldown)
    {
        if(stamina <= 0)
        {
            Buff3.interactable = false;
        }
        else
        {
            if (!FightingBoss)
            {
                //If enemy hits player after activation the enemy will be stun, effect lasts 20-30 seconds
                if (Enemy.GetComponent<EnemyAI>() == null)
                {
                    Enemy.GetComponent<RangedEnemyAI>().StunDuration = Random.Range(20, 30);
                    Enemy.GetComponent<RangedEnemyAI>().IsStunned = true;
                }
                else
                {
                    Enemy.GetComponent<EnemyAI>().StunDuration = Random.Range(20, 30);
                    Enemy.GetComponent<EnemyAI>().IsStunned = true;
                }
            }
            else
            {
                EffectDuration = Random.Range(20, 30);
                Boss.IsStunned(EffectDuration);
            }

            if (FlurryOfAttacksActivated == false)
                //Lower stamina
                stamina -= Buff3Stamina;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff3.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //If enemy hits player in first 5 seconds of activation player takes no damage

            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        ShieldStorm(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            GetComponent<PlayerStats>().currentstanima = stamina;
        }
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
    }

    public IEnumerator MirrorOfIce(int cooldown)
    {
        if(stamina <= 0)
        {
            Buff3.interactable = false;
        }
        else
        {
            //Reflects damage done back to enemy
            CanReflect = true;
            if (FlurryOfAttacksActivated == false)
                //Lower stamina
                stamina -= Buff3Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            //Changes player colour
            PlayerColour.material = CharacterFlash;
            //Timer
            EffectDuration = 5;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Buff3.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
            //Play upgrade audio
            Audio.Ice.Play();
            yield return new WaitForSeconds(EffectDuration);
            //Turns the reflect status off
            CanReflect = false;
            //Changes player colour back to default
            PlayerColour.material = CharacterFlash;
        }
        //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
        if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
        {
            if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
            {
                if (Random.value < FlurryOfAttacksBuff)
                {
                    FlurryOfAttacksActivated = true;
                    StartCoroutine(MirrorOfIce(0));
                }
            }
        }
        else
        {
            FlurryOfAttacksActivated = false;
        }
    }

    public void DeathGrip(int cooldown)
    {
        if(stamina <= 0)
        {
            Slot3.interactable = false;
        }
        else
        {
            if (!FightingBoss)
            {
                Collider[] NearByEnemies = Physics.OverlapSphere(GetComponent<Transform>().position, 10);
                foreach (Collider hit in NearByEnemies)
                {
                    //checks each gameobject to see if it has the tag enemy, if it does the DOT code activates
                    if (hit.gameObject.tag == "Enemy")
                    {
                        //Calculates the difference between the enemy and the player
                        float distance = Vector3.Distance(hit.transform.position, transform.position);
                        //Moves enemies closer to the player
                        hit.GetComponent<Transform>().position = Vector3.MoveTowards(hit.transform.position, this.transform.position, distance - 2);
                        //Sets how long the stun will last
                        EffectDuration = 5;
                        //Deals DOT damage on ranged enemies
                        if (hit.GetComponent<EnemyAI>() == null)
                        {
                            hit.GetComponent<RangedEnemyAI>().IsBurning = true;
                            hit.GetComponent<RangedEnemyAI>().BurningDamage = 5;
                            hit.GetComponent<RangedEnemyAI>().BurningDuration = EffectDuration;
                        }
                        //Deals DOT damage on normal enmemies
                        else
                        {
                            hit.GetComponent<EnemyAI>().IsBurning = true;
                            hit.GetComponent<EnemyAI>().BurningDamage = 5;
                            hit.GetComponent<EnemyAI>().BurningDuration = EffectDuration;
                        }
                        FloatingTextController.CreatFloatingText("Burned", Enemy.transform);
                    }
                }
            }
            else
            {
                EffectDuration = 5;
                int BurningDamage = 5;
                StartCoroutine(Boss.IsBurned(EffectDuration, BurningDamage));
                FloatingTextController.CreatFloatingText("Burned", Boss.transform);
            }
            if (FlurryOfAttacksActivated == false)
                //Lower stamina
                stamina -= Skill3Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot3.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        DeathGrip(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
            //Dark magic sound effect
            Audio.DarkMagic.Play();
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
        }
    }

    public void BurstOfGore(int cooldown)
    {
        if(stamina <= 0)
        {
            Slot3.interactable = false;
        }
        else
        {
            //changes code slightly for ranged and normal enemies
            bool PerformDeathCheck;
            if(Enemy.GetComponent<EnemyAI>() == null)
            {
                //Lower Enemy health
                Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= (int)AbilityDamage;
                PerformDeathCheck = false;
            }
            else
            {
                //Lower Enemy health
                Enemy.GetComponent<EnemyAI>().EnemyHealth -= (int)AbilityDamage;
                PerformDeathCheck = true;
            }
            Audio.DarkMagic.Play();

            if(EnemyHealth <= 0)
            {
                //Perform AOE attack
                GameObject MyInstantiate = Instantiate(AOEAttack, Enemy.transform.position, Quaternion.identity);
                MyInstantiate.GetComponent<AOEAttack>().AttackDamage = AOEAttackDamage;
                MyInstantiate.GetComponent<AOEAttack>().AttackTime = 3;
                MyInstantiate.GetComponent<AOEAttack>().DotActivate = false;
                MyInstantiate.GetComponent<AOEAttack>().DotDamage = 5;
            }
            if (FlurryOfAttacksActivated == false)
                //Lower stamina
                stamina -= Skill3Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(Slot3.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            if (PerformDeathCheck == true)
            {
                DeadEnemy = Enemy;
                EnemyDeathCheck();
            }
            //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
            if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
            {
                if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
                {
                    if (Random.value < FlurryOfAttacksBuff)
                    {
                        FlurryOfAttacksActivated = true;
                        BurstOfGore(0);
                    }
                }
            }
            else
            {
                FlurryOfAttacksActivated = false;
            }
        }
    }

    public void GiftGiver(int cooldown)
    {
        if(stamina <= 0)
        {
            Slot3.interactable = false;
        }
        else
        {
            //Turns minion into bomb that will blow up doing AOE damage, kills minion
            GameObject.FindWithTag("Minion").GetComponent<MinionAI>().GiftGiverActivated();
            //Lower stamina
            stamina -= Skill3Stamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            StartCoroutine(Slot3.GetComponent<Cooldown>().ActivateCooldown(cooldown));
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            Audio.Explosion.Play();
        }
    }

    public void DiamondBody()
    {
        int buff = SkillLevelTracker.DiamondBodyBuff;
        //Increases block chance
        GetComponent<PlayerStats>().BlockChance = (BlockChance += Mathf.CeilToInt((float)BlockChance) / buff);
    }

    public void MasterOfPennies()
    {
        int buff = SkillLevelTracker.MasterOfPenniesBuff;
        //Increases gold bonus
        GetComponent<PlayerStats>().GoldBonus = (GoldBonus += Mathf.CeilToInt((float)GoldBonus) / buff);
    }

    public void SoulCollector()
    {
        int buff = SkillLevelTracker.SoulCollectorBuff;
        //Increases exp bonus
        GetComponent<PlayerStats>().EXPBonus = (EXPBonus += Mathf.CeilToInt((float)EXPBonus) / buff);
    }

    public IEnumerator MoreGore()
    {
        double buff = SkillLevelTracker.MoreGoreBuff;
        //include check for taking damage here
        if (Random.value <= buff)
        {
            AttackDamage = AttackDamage * 2;

            yield return new WaitForSeconds(10);

            AttackDamage = AttackDamage / 2;
        }
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
    }

    public void StealthCut()
    {
        int buff = SkillLevelTracker.StealthCutBuff;
        EffectDuration = buff;
        if (!FightingBoss)
        {
            //code changes slightly depending on if enemy is ranged or not
            if (Enemy.GetComponent<EnemyAI>() == null)
            {
                //Chance of stunning enemy for 15 seconds
                if (Random.value < 0.5)
                {
                    Enemy.GetComponent<RangedEnemyAI>().IsStunned = true;
                    Enemy.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
                }
                Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= AttackDamage;
            }
            else
            {
                //Chance of stunning enemy for 15 seconds
                if (Random.value < 0.5)
                {
                    Enemy.GetComponent<EnemyAI>().IsStunned = true;
                    Enemy.GetComponent<EnemyAI>().StunDuration = EffectDuration;
                }
                Enemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage;
            }
            FloatingTextController.CreatFloatingText("Enemy Stunned", Enemy.transform);
        }
        else
        {
            StartCoroutine(Boss.IsStunned(EffectDuration));
            Boss.Health -= AttackDamage;
            FloatingTextController.CreatFloatingText("Boss Stunned", Boss.transform);
        }
        Audio.Slice1.Play();
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
    }

    public IEnumerator FireWall(int cooldown)
    {
        //Spawns the fire wall at the same location of the player
        GameObject MyInstantiate = Instantiate(FireShield, this.transform.position, Quaternion.identity);
        //Sets the fire wall to be a child of the player
        MyInstantiate.transform.SetParent(this.transform);
        //Changes the firewall's rotation to match the player's
        MyInstantiate.transform.rotation = this.transform.rotation;
        //Lower stamina
        stamina -= Buff3Stamina;
        GetComponent<PlayerStats>().currentstanima = stamina;
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
        //Activate cooldown
        StartCoroutine(Buff3.GetComponent<Cooldown>().ActivateCooldown(cooldown));
        //Play fire sound effect
        Audio.Fire.Play();
        //System waits for pre-determined number of seconds before the code continues
        yield return new WaitForSeconds(5);
        //Makes the system allow the enemy to attack again
        MyInstantiate.GetComponentInChildren<FireWallActivate>().ResetAttacks();
        //Destroys the fire wall once the attack has been used up
        Destroy(MyInstantiate);
    }

    public void WhyAreYouRunning()
    {
        int buff = SkillLevelTracker.WhyAreYouRunningBuff;
        //chance to stun ranged enemies when hit
        if(Random.value <= 0.5)
        {
            if (!FightingBoss)
            {
                //Gets the collider of all the nearby objects and stores them in an array
                Collider[] NearByEnemies = Physics.OverlapSphere(GetComponent<Transform>().position, buff);
                foreach (Collider hit in NearByEnemies)
                {
                    //checks each gameobject to see if it has the tag enemy, if it does the stun code activates
                    if (hit.gameObject.tag == "Enemy")
                    {
                        EffectDuration = 5;
                        if (hit.GetComponent<EnemyAI>() == null)
                        {
                            hit.GetComponent<RangedEnemyAI>().IsStunned = true;
                            hit.GetComponent<RangedEnemyAI>().StunDuration = EffectDuration;
                            FloatingTextController.CreatFloatingText("Enemy Stunned", hit.transform);
                        }
                    }
                }
                //Empties erray
                NearByEnemies = null;
            }
            else
            {
                StartCoroutine(Boss.IsStunned(EffectDuration));
            }
            Audio.WhyAreYouRunning.Play();
        }
    }

    public void FreeGoods()
    {
        //chance to get better armour
        if(Random.value <= 5)
        {
            //increase odds of better armour
        }
    }

    public void BangWeapon()
    {
        //chance to get better weapon
        if(Random.value <= 5)
        {
            //increase odds to get better weapon
        }
    }

    public void ImAngry()
    {
        double buff = SkillLevelTracker.ImAngryBuff;
        //if the player is lower then 30% health there's a chance of increase multiattack damage
        if (Random.value <= buff)
        {
            //increases multiattack damage
            MultiAttackDamage += 5;
            ImAngryActivated = true;
        }
        else
        {
            ImAngryActivated = true;
        }
   
    }

    public void ThrowThings()
    {
        int buff = SkillLevelTracker.ThrowThingsBuff;
        //chance to throw things at enemies, increase basic damage
        if(Random.value <= 0.5)
        {
            //Increases attack damage
            AttackDamage = (Damage += Mathf.CeilToInt((float)Damage) / buff);
            //Add the ability to throw items here
        }
    }

    public void HumanShields()
    {
        //Create check for range attack
        if(Random.value <= 0.5)
        {
            //Block range attack
            //Timer here
        }
    }

    public IEnumerator BlindRage(int cooldown)
    {
        //Increases damage and defense
        AttackDamage = (Damage += Mathf.CeilToInt((float)Damage) / 20);
        if (FlurryOfAttacksActivated == false)
            //reduce damage
            stamina -= UltimateBuffStamina;
        GetComponent<PlayerStats>().currentstanima = stamina;
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
        //changes player's colour
        PlayerColour.material = CharacterFlash;
        //Timer
        EffectDuration = 10;
        //Lowers enemies damage
        Enemy.GetComponent<EnemyCombat>().AttackDamage -= 5;
        if (FlurryOfAttacksActivated == false)
            //Makes the code wait for the effect duration before setting everything back
            StartCoroutine(UltimateBuffSlot.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
        //Play upgrade audio
        Audio.UpgradeSound.Play();
        //Displays floating text
        FloatingTextController.CreatFloatingText("BLIND RAGE", this.transform);
        yield return new WaitForSeconds(EffectDuration);
        //Resets damage
        AttackDamage = Damage;
        //changes player's colour back to default
        PlayerColour.material = DefaultColour;
        //Resets the enemies damage
        Enemy.GetComponent<EnemyCombat>().AttackDamage += 5;
        //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
        if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
        {
            if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
            {
                if (Random.value < FlurryOfAttacksBuff)
                {
                    FlurryOfAttacksActivated = true;
                    StartCoroutine(BlindRage(0));
                }
            }
        }
        else
        {
            FlurryOfAttacksActivated = false;
        }
    }

    public IEnumerator ImCalm(int cooldown)
    {
        //Increases the dodge and crit chance of the player
        GetComponent<PlayerStats>().DodgeChance = (DodgeChance += Mathf.CeilToInt((float)DodgeChance) / 20);
        GetComponent<PlayerStats>().CriticalChance = (CriticalChance += Mathf.CeilToInt((float)CriticalChance) / 20);
        if (FlurryOfAttacksActivated == false)
            stamina -= UltimateBuffStamina;
        GetComponent<PlayerStats>().currentstanima = stamina;
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        //Checks the player's stamina and deactivates skills that have too high a cost
        CheckSkillStamina();
        //Changes player's colour
        PlayerColour.material = CharacterFlash;
        //Timer
        EffectDuration = 5;
        if (FlurryOfAttacksActivated == false)
            StartCoroutine(UltimateBuffSlot.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
        //Play upgrade audio
        Audio.UpgradeSound.Play();
        //Displays floating text
        FloatingTextController.CreatFloatingText("I'm Calm", this.transform);
        yield return new WaitForSeconds(EffectDuration);
        //Reset the dodge and crit chance of the player
        GetComponent<PlayerStats>().DodgeChance = DodgeChance;
        GetComponent<PlayerStats>().CriticalChance = CriticalChance;
        //changes player's colour back to default
        PlayerColour.material = DefaultColour;
        //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
        if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
        {
            if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
            {
                if (Random.value < FlurryOfAttacksBuff)
                {
                    FlurryOfAttacksActivated = true;
                    StartCoroutine(ImCalm(0));
                }
            }
        }
        else
        {
            FlurryOfAttacksActivated = false;
        }
    }

    public IEnumerator SoulEater(int cooldown)
    {
        if (!FightingBoss)
        {
            //Enemy takes damage
            Enemy.GetComponent<EnemyAI>().EnemyHealth -= AttackDamage;
            //Player gains health based on the amount of damage done
            GetComponent<PlayerStats>().Health += AttackDamage;
            //increase Aoe damage
            AOEAttackDamage = AOEDamage + 5;
            if (FlurryOfAttacksActivated == false)
                stamina -= UltimateBuffStamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            //Changes player's colour
            PlayerColour.material = CharacterFlash;
            //timer here
            EffectDuration = 5;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(UltimateBuffSlot.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
            //Soul eater sound effect plays
            Audio.SoulEater.Play();
            //Displays floating text
            FloatingTextController.CreatFloatingText("SOUL EATER", this.transform);
            //Makes the system wait for the effect duration before reseting information
            yield return new WaitForSeconds(EffectDuration);
            //lower AOE attack here
            AOEAttackDamage = AOEDamage;
            //Restores player's default colour
            PlayerColour.material = DefaultColour;
        }
        else
        {
            //Boss takes damage
            Boss.Health -= AttackDamage;
            //Player gains health based on the amount of damage done
            GetComponent<PlayerStats>().Health += AttackDamage;
            //increase Aoe damage
            AOEAttackDamage = AOEDamage + 5;
            if (FlurryOfAttacksActivated == false)
                stamina -= UltimateBuffStamina;
            GetComponent<PlayerStats>().currentstanima = stamina;
            //Randomly turns a skill off cooldown if multicast is active
            if (MulticastActive)
            {
                if (Random.value <= 0.10)
                {
                    SkillOffCooldown();
                }
            }
            CheckSkillStamina();
            //Changes player's colour
            PlayerColour.material = CharacterFlash;
            //timer here
            EffectDuration = 5;
            if (FlurryOfAttacksActivated == false)
                StartCoroutine(UltimateBuffSlot.GetComponent<Cooldown>().ActivateCooldown(EffectDuration + cooldown));
            //Sound Effect sound effect plays
            Audio.SoulEater.Play();
            //Displays floating text
            FloatingTextController.CreatFloatingText("SOUL EATER", this.transform);
            //Makes the system wait for the effect duration before reseting information
            yield return new WaitForSeconds(EffectDuration);
            //lower AOE attack here
            AOEAttackDamage = AOEDamage;
            //Restores player's default colour
            PlayerColour.material = DefaultColour;
        }
        //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
        if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
        {
            if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
            {
                if (Random.value < FlurryOfAttacksBuff)
                {
                    FlurryOfAttacksActivated = true;
                    StartCoroutine(SoulEater(0));
                }
            }
        }
        else
        {
            FlurryOfAttacksActivated = false;
        }
    }

    public void Rampage(int cooldown)
    {
        //AOE attack that range reduces with every hit
        GameObject MyInstantiate = Instantiate(AOEAttack, transform.position + (transform.forward * 2), Quaternion.identity);
        MyInstantiate.GetComponent<AOEAttack>().AttackDamage = AOEAttackDamage;
        MyInstantiate.GetComponent<AOEAttack>().AttackTime = 100;
        MyInstantiate.GetComponent<AOEAttack>().DotActivate = false;
        MyInstantiate.GetComponent<AOEAttack>().DotDamage = 0;
        MyInstantiate.GetComponent<AOEAttack>().AOEBecomesSmaller = true;
        if (FlurryOfAttacksActivated == false)
            stamina -= UltimateSkillStamina;
        GetComponent<PlayerStats>().currentstanima = stamina;
        if (FlurryOfAttacksActivated == false)
            StartCoroutine(UltimateSkillSlot.GetComponent<Cooldown>().ActivateCooldown(cooldown));
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
        //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
        if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
        {
            if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
            {
                if (Random.value < FlurryOfAttacksBuff)
                {
                    FlurryOfAttacksActivated = true;
                    Rampage(0);
                }
            }
        }
        else
        {
            FlurryOfAttacksActivated = false;
        }
        //Play sound effect
        Audio.Rampage.Play();
    }

    public void WallOfSpears(int cooldown)
    {
        //AOE cone in front of player that reduces after every hit
        GameObject MyInstantiate = Instantiate(AOECone, transform.position + (transform.forward), Quaternion.identity);
        MyInstantiate.transform.Rotate(new Vector3(90, 90, 0));
        MyInstantiate.GetComponent<AOEAttack>().AttackDamage = AOEAttackDamage;
        MyInstantiate.GetComponent<AOEAttack>().AttackTime = 20;
        MyInstantiate.GetComponent<AOEAttack>().DotActivate = false;
        MyInstantiate.GetComponent<AOEAttack>().DotDamage = 0;
        MyInstantiate.GetComponent<AOEAttack>().AOEBecomesSmaller = true;
        if (FlurryOfAttacksActivated == false)
            stamina -= UltimateSkillStamina;
        GetComponent<PlayerStats>().currentstanima = stamina;
        if (FlurryOfAttacksActivated == false)
            StartCoroutine(UltimateSkillSlot.GetComponent<Cooldown>().ActivateCooldown(cooldown));
        //Play stab sound
        Audio.Stab1.Play();
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
        //Player has a chance of activating the skill twice if they have unlocked Flurry Of Blows
        if (FlurryOfAttacksUnlock == true && FlurryOfAttacksActivated == false || FlurriedActive && FlurryOfAttacksActivated == false)
        {
            if (FlurryOfAttacksUnlock || (Random.value <= 0.1 && FlurriedActive))
            {
                if (Random.value < FlurryOfAttacksBuff)
                {
                    FlurryOfAttacksActivated = true;
                    WallOfSpears(0);
                }
            }
        }
        else
        {
            FlurryOfAttacksActivated = false;
        }
    }

    public void ElementalOverload()
    {
        //Cast random spells for 5 seconds
        int RandomNumber = Random.Range(0, ChosenSkills.Count);
        //Chooses a random skill to activate
        ChosenSkills[RandomNumber]();
        //Only play sound effect and displays floating text during first activation
        if (counter == 0)
        {
            //Plays elemental overload audio
            Audio.ElementalOverload.Play();
            //Creates floating text
            FloatingTextController.CreatFloatingText("ELEMENTAL OVERLOAD", this.transform);
        }
        stamina -= UltimateSkillStamina;
        //Tracks how many times the skill has activates
        counter += 1;
        //Activates cooldown
        StartCoroutine(UltimateSkillSlot.GetComponent<Cooldown>().ActivateCooldown(UltimateSkillCooldown));
        //Randomly turns a skill off cooldown if multicast is active
        if (MulticastActive)
        {
            if (Random.value <= 0.10)
            {
                SkillOffCooldown();
            }
        }
        CheckSkillStamina();
    }
}
