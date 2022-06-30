using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChooseSkills : MonoBehaviour
{
    //Stores the main menu scene
    private Scene scene;
    private GameObject Canvas;

    //Stores the names of the chosen skills
    [HideInInspector] public string Slot1Skill;
    [HideInInspector] public string Slot2Skill;
    [HideInInspector] public string Slot3Skill;
    [HideInInspector] public string Slot1Buff;
    [HideInInspector] public string Slot2Buff;
    [HideInInspector] public string Slot3Buff;
    [HideInInspector] public string UltimateSkill;
    [HideInInspector] public string UltimateBuff;

    //Stores the stamina usage
    [HideInInspector] public int Skill1StaminaUsage;
    [HideInInspector] public int Skill2StaminaUsage;
    [HideInInspector] public int Skill3StaminaUsage;
    [HideInInspector] public int Buff1StaminaUsage;
    [HideInInspector] public int Buff2StaminaUsage;
    [HideInInspector] public int Buff3StaminaUsage;
    [HideInInspector] public int UltimateSkillStaminaUsage;
    [HideInInspector] public int UltimateBuffStaminaUsage;

    //Stores the skills cooldowns
    [HideInInspector] public int Skill1Cooldown;
    [HideInInspector] public int Skill2Cooldown;
    [HideInInspector] public int Skill3Cooldown;
    [HideInInspector] public int Buff1Cooldown;
    [HideInInspector] public int Buff2Cooldown;
    [HideInInspector] public int Buff3Cooldown;
    [HideInInspector] public int UltimateSkillCooldown;
    [HideInInspector] public int UltimateBuffCooldown;

    //Stores player's speed
    [HideInInspector] public int SpeedRank;

    //Store Player's auto attack rate
    [HideInInspector] public int AutoAttackRank;

    //stores Player's health regen rank
    [HideInInspector] public int HealthRegenRank;

    //Stores the player to set skills
     public PlayerCombat Player;

    [HideInInspector]public bool PlayerIsFound;
    [HideInInspector] public List<string> UnlockedPassiveAbilities;
    [HideInInspector] public List<int> PassiveRanks;

    private void Start()
    {
        //SaveSystem data = SavePassiveBinary.LoadPassiveAbility();
        //UnlockedPassiveAbilities = data.UnlockedPassiveAbilities;

        //removes listeners
        SceneManager.sceneLoaded -= OnSceneLoaded;

        SceneManager.sceneLoaded += OnSceneLoaded;

        //Prevents this Game Object from being destroyed when the system loads a new scene
        DontDestroyOnLoad(this.gameObject);

        //Gets the main menu scene to prevent later code from activating on the main menu
        scene = SceneManager.GetActiveScene();

        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
        HealthRegenRank = Camera.GetComponent<SpawnDontDestroys>().SkillMenu.GetComponent<Skills>().HealthRegenRank;
    }

    public void CheckPassiveUnlocked()
    {
        for(int i = 0; i < UnlockedPassiveAbilities.Count; i++)
        {
            string UnlockedPassive = UnlockedPassiveAbilities[i];
            GameObject Skill = GameObject.Find(UnlockedPassive);
            Skill.GetComponent<SkillValue>().SkillUnlocked = true;
            Skill.GetComponent<SkillValue>().SkillLevel = PassiveRanks[i];

            if(Skill.GetComponent<SkillValue>().SkillLevel == 3)
            {
                Skill.GetComponent<Button>().interactable = false;
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //Empties player variable so it's free for the next use
        Player = null;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        //prevents the code from activating in main menu
        if (string.Equals(scene.path, this.scene.path) || SceneManager.GetActiveScene().name == "MainMenu") return;

        //Insert code that needs to be loaded at start of scene in here

        SetPlayerSkills();
    }

    void SetPlayerSkills()
    {
        //If the player is found this gets set to true, otherwise is used to check 
        PlayerIsFound = false;

        //sends the chosen skills to the player
        GameObject AnotherPlayer = GameObject.Find("Player");

        if (AnotherPlayer != null)
        {
            Player = AnotherPlayer.GetComponent<PlayerCombat>();
            //Sets skills and stats
            Player.Slot1Skill = Slot1Skill;
            Player.Slot2Skill = Slot2Skill;
            Player.Slot3Skill = Slot3Skill;
            Player.Slot1Buff = Slot1Buff;
            Player.Slot2Buff = Slot2Buff;
            Player.Slot3Buff = Slot3Buff;
            Player.UltimateSkill = UltimateSkill;
            Player.UltimateBuff = UltimateBuff;
            Player.UnlockedPassiveAbilities = UnlockedPassiveAbilities;
            Player.PassiveRank = PassiveRanks;
            Player.GetComponent<PlayerStats>().Movespeed = SpeedRank;
            Player.GetComponent<PlayerStats>().AttackSpeedRank = AutoAttackRank;
            Player.GetComponent<PlayerStats>().HealthRegenRank = HealthRegenRank;
            //Sets the cooldown for the skills
            Player.Skill1Cooldown = Skill1Cooldown;
            Player.Skill2Cooldown = Skill2Cooldown;
            Player.Skill3Cooldown = Skill3Cooldown;
            Player.Buff1Cooldown = Buff1Cooldown;
            Player.Buff2Cooldown = Buff2Cooldown;
            Player.Buff3Cooldown = Buff3Cooldown;
            Player.UltimateSkillCooldown = UltimateSkillCooldown;
            Player.UltimateBuffCooldown = UltimateBuffCooldown;
            //Sets stamina usage
            Player.Skill1Stamina = Skill1StaminaUsage;
            Player.Skill2Stamina = Skill2StaminaUsage;
            Player.Skill3Stamina = Skill3StaminaUsage;
            Player.Buff1Stamina = Buff1StaminaUsage;
            Player.Buff2Stamina = Buff2StaminaUsage;
            Player.Buff3Stamina = Buff3StaminaUsage;
            Player.UltimateSkillStamina = UltimateSkillStaminaUsage;
            Player.UltimateBuffStamina = UltimateBuffStaminaUsage;

            PlayerIsFound = true;
        }

    }

    //Safety net in case the player hasn't loaded when the skills are set, if the player variable has no data then the player spawn script will activate the code below
    public void PlayerNotFound()
    {
        //Finds player
        Player = GameObject.Find("Player").GetComponent<PlayerCombat>();
        //Sets skills and stats
        Player.Slot1Skill = Slot1Skill;
        Player.Slot2Skill = Slot2Skill;
        Player.Slot3Skill = Slot3Skill;
        Player.Slot1Buff = Slot1Buff;
        Player.Slot2Buff = Slot2Buff;
        Player.Slot3Buff = Slot3Buff;
        Player.UltimateSkill = UltimateSkill;
        Player.UltimateBuff = UltimateBuff;
        Player.UnlockedPassiveAbilities = UnlockedPassiveAbilities;
        Player.GetComponent<PlayerStats>().Movespeed = SpeedRank;
        Player.GetComponent<NavMeshAgent>().speed = SpeedRank;
        Player.GetComponent<NavMeshAgent>().acceleration = SpeedRank;
        Player.GetComponent<PlayerStats>().AttackSpeedRank = AutoAttackRank;
        Player.AttackSpeedRank = AutoAttackRank;
        Player.GetComponent<PlayerStats>().HealthRegenRank = HealthRegenRank;
        //Sets the cooldown for the skills
        Player.Skill1Cooldown = Skill1Cooldown;
        Player.Skill2Cooldown = Skill2Cooldown;
        Player.Skill3Cooldown = Skill3Cooldown;
        Player.Buff1Cooldown = Buff1Cooldown;
        Player.Buff2Cooldown = Buff2Cooldown;
        Player.Buff3Cooldown = Buff3Cooldown;
        Player.UltimateSkillCooldown = UltimateSkillCooldown;
        Player.UltimateBuffCooldown = UltimateBuffCooldown;
        //Sets stamina usage
        Player.Skill1Stamina = Skill1StaminaUsage;
        Player.Skill2Stamina = Skill2StaminaUsage;
        Player.Skill3Stamina = Skill3StaminaUsage;
        Player.Buff1Stamina = Buff1StaminaUsage;
        Player.Buff2Stamina = Buff2StaminaUsage;
        Player.Buff3Stamina = Buff3StaminaUsage;
        Player.UltimateSkillStamina = UltimateSkillStaminaUsage;
        Player.UltimateBuffStamina = UltimateBuffStaminaUsage;
        //Activates functions needed to set skills/stats
        Player.GetComponent<PlayerStats>().CancelInvoke("RegenHealth");
        Player.GetComponent<PlayerStats>().InvokeRepeating("RegenHealth", 0, HealthRegenRank);
        Player.SetSlot1();
        Player.SetSlot2();
        Player.SetSlot3();
        Player.SetBuff1();
        Player.SetBuff2();
        Player.SetBuff3();
        Player.SetUltimateSkill();
        Player.SetUltimateBuff();
        Player.SetPassiveSkills();
        PlayerIsFound = true;
        CancelInvoke("PlayerNotFound");
    }
}
