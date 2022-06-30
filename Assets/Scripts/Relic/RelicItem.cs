using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;

public class RelicItem : MonoBehaviour,Relictip
{
    [HideInInspector] public int ID;
    [HideInInspector] public string Relic;

 
    public string description;
    public Sprite icon;
    public bool PickedUp;
    public Relic Data;
    public string type;
   [HideInInspector] public bool Equipped;
    [HideInInspector] public GameObject relic;
    [HideInInspector] public GameObject RelicBeginner;
    [HideInInspector] public GameObject RelicBattleHarden;
    [HideInInspector] public GameObject RelicExpert;
    public bool RelicWeapon;

    [HideInInspector] public Image RelicTooltip;
    [HideInInspector] public Text RelicTooltipText;

    // int that are floats for bigger numbers
    [HideInInspector] public float HPBonus;
    [HideInInspector] public float MovementSpeedBonus;
    [HideInInspector] public float Damage;
    [HideInInspector] public float BlockChanceBonus;
    [HideInInspector] public float MultiAttackBonus;
    [HideInInspector] public float AbilityDamage;
    [HideInInspector] public float ArmourStats;
    //percentage
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float StaminaRegenBonus;
    [HideInInspector] public float CooldownReduction;
    [HideInInspector] public float AOEchanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float GoldBonus;
    [HideInInspector] public float Rareitydroprate;
    [HideInInspector] public float EXPbonus;
    [HideInInspector] public float HealthRegen;

   
    [HideInInspector] public bool FromSaveFile = false;

    public GameObject RelicManager;
    
    public string Maindescription;

    // Start is called before the first frame update
   public void Start()
    {
        if (Data != null)
        {
            ID = Data.ID;
            Relic = Data.relic;
            icon = Data.icon;
            description = Data.Description;
            HPBonus = Data.HPBonus;
            MovementSpeedBonus = Data.MovementSpeedBonus;
            Damage = Data.Damage;
            BlockChanceBonus = Data.BlockChanceBonus;
            MultiAttackBonus = Data.MultiAttackBonus;
            AbilityDamage = Data.AbilityDamage;
            ArmourStats = Data.ArmourStats;
            StunChanceBonus = Data.StunChanceBonus;
            DodgeBonus = Data.DodgeBonus;
            CritDamageBonus = Data.CritDamageBonus;
            StaminaRegenBonus = Data.StaminaRegenBonus;
            CooldownReduction = Data.CooldownReduction;
            AOEchanceBonus = Data.AOEchanceBonus;
            CritChance = Data.CritChance;
            GoldBonus = Data.GoldBonus;
            Rareitydroprate = Data.Rareitydroprate;
            EXPbonus = Data.EXPbonus;
            HealthRegen = Data.HealthRegen;
        }

        RelicManager = GameObject.FindGameObjectWithTag("RelicManager");
        RelicBeginner = GameObject.Find("Relicone");
        RelicBattleHarden = GameObject.Find("Relictwo");
        RelicExpert = GameObject.Find("Relicthree");
        SetRelicTtile();
       
    }

    public void RelicHolder()
    {
        int AllRelic = RelicManager.transform.childCount;
        for(int i=0; i < AllRelic; i++)
        {

            if (RelicManager.transform.GetChild(i).gameObject.GetComponent<Relic>().relic == Relic)
            {
                if(type== "Beginner")
                {
                    RelicBeginner = RelicManager.transform.GetChild(i).gameObject;
                }
                if(type== "BattleHarden")
                {
                    RelicBattleHarden = RelicManager.transform.GetChild(i).gameObject;
                }
                if (type == "Expert")
                {
                    RelicExpert = RelicManager.transform.GetChild(i).gameObject;
                }

            }
              

        }
    }

    public void Relicusage()
    {
        if(!relic)
            RelicHolder();

        GameObject EquippedRelicHolder = GameObject.Find("EquipedRelics");

        Equipped = true;
            if(type== "Beginner")
            {
                RelicBeginner.SetActive(true);
                PlayerStats Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

                if (HPBonus > 0)
                    Player.Health += HPBonus;
                if (MovementSpeedBonus > 0)
                    Player.Movespeed += MovementSpeedBonus;
                if (Damage > 0)
                    Player.BaseDamage += Damage;
                if (BlockChanceBonus > 0.00)
                    Player.BlockChance += BlockChanceBonus;
                if (MultiAttackBonus > 0.00)
                    Player.MultiattackChance += MultiAttackBonus;
                if (AbilityDamage > 0.00)
                    Player.AbilityDamage += AbilityDamage;
                if (ArmourStats > 0)
                    Player.armour += ArmourStats;
                if (StunChanceBonus > 0.00)
                    Player.StunChance += StunChanceBonus;
                if (DodgeBonus > 0.00)
                    Player.DodgeChance += DodgeBonus;
                if (CritDamageBonus > 0.00)
                    Player.CriticalDamage += CritDamageBonus;
                if (StaminaRegenBonus > 0)
                    Player.StaminaRegen += StaminaRegenBonus;
                if (CooldownReduction > 0)
                    Player.CooldownReduction += CooldownReduction;
                if (AOEchanceBonus > 0.00)
                    Player.AOEChance += AOEchanceBonus;
                if (CritChance > 0.00)
                    Player.CriticalChance += CritChance;
                if (GoldBonus > 0)
                    Player.GoldBonus += GoldBonus;
                if (Rareitydroprate > 0.00)
                    Player.RarityIncrease += Rareitydroprate;
                if (EXPbonus > 0)
                    Player.EXPBonus += EXPbonus;
                if (HealthRegen > 0)
                    Player.HealthRegen += HealthRegen;
              EquippedRelicHolder.transform.Find("Relicone").GetComponent<Image>().sprite = icon;
            }

            if(type== "BattleHarden")
            {
            RelicBattleHarden.SetActive(true);
            PlayerStats Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

            if (HPBonus > 0)
                Player.Health += HPBonus;
            if (MovementSpeedBonus > 0)
                Player.Movespeed += MovementSpeedBonus;
            if (Damage > 0)
                Player.BaseDamage += Damage;
            if (BlockChanceBonus > 0.00)
                Player.BlockChance += BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Player.MultiattackChance += MultiAttackBonus;
            if (AbilityDamage > 0.00)
                Player.AbilityDamage += AbilityDamage;
            if (ArmourStats > 0)
                Player.armour += ArmourStats;
            if (StunChanceBonus > 0.00)
                Player.StunChance += StunChanceBonus;
            if (DodgeBonus > 0.00)
                Player.DodgeChance += DodgeBonus;
            if (CritDamageBonus > 0.00)
                Player.CriticalDamage += CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Player.StaminaRegen += StaminaRegenBonus;
            if (CooldownReduction > 0)
                Player.CooldownReduction += CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Player.AOEChance += AOEchanceBonus;
            if (CritChance > 0.00)
                Player.CriticalChance += CritChance;
            if (GoldBonus > 0)
                Player.GoldBonus += GoldBonus;
            if (Rareitydroprate > 0.00)
                Player.RarityIncrease += Rareitydroprate;
            if (EXPbonus > 0)
                Player.EXPBonus += EXPbonus;
            if (HealthRegen > 0)
                Player.HealthRegen += HealthRegen;
            EquippedRelicHolder.transform.Find("Relictwo").GetComponent<Image>().sprite = icon;
            }

        if (type == "Expert")
        {
            RelicExpert.SetActive(true);
            PlayerStats Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

            if (HPBonus > 0)
                Player.Health += HPBonus;
            if (MovementSpeedBonus > 0)
                Player.Movespeed += MovementSpeedBonus;
            if (Damage > 0)
                Player.BaseDamage += Damage;
            if (BlockChanceBonus > 0.00)
                Player.BlockChance += BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Player.MultiattackChance += MultiAttackBonus;
            if (AbilityDamage > 0.00)
                Player.AbilityDamage += AbilityDamage;
            if (ArmourStats > 0)
                Player.armour += ArmourStats;
            if (StunChanceBonus > 0.00)
                Player.StunChance += StunChanceBonus;
            if (DodgeBonus > 0.00)
                Player.DodgeChance += DodgeBonus;
            if (CritDamageBonus > 0.00)
                Player.CriticalDamage += CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Player.StaminaRegen += StaminaRegenBonus;
            if (CooldownReduction > 0)
                Player.CooldownReduction += CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Player.AOEChance += AOEchanceBonus;
            if (CritChance > 0.00)
                Player.CriticalChance += CritChance;
            if (GoldBonus > 0)
                Player.GoldBonus += GoldBonus;
            if (Rareitydroprate > 0.00)
                Player.RarityIncrease += Rareitydroprate;
            if (EXPbonus > 0)
                Player.EXPBonus += EXPbonus;
            if (HealthRegen > 0)
                Player.HealthRegen += HealthRegen;
            EquippedRelicHolder.transform.Find("Relicthree").GetComponent<Image>().sprite = icon;
        }
    }


    public void RemoveRelic()
    {
        if (!relic)
            RelicHolder();

        GameObject EquippedRelicHolder = GameObject.Find("EquipedRelics");

        Equipped = false;

        if(type == "Beginner")
        {
            RelicBeginner.SetActive(false);
            PlayerStats Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

            if (HPBonus > 0)
                Player.Health -= HPBonus;
            if (MovementSpeedBonus > 0)
                Player.Movespeed -= MovementSpeedBonus;
            if (Damage > 0)
                Player.BaseDamage -= Damage;
            if (BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Player.MultiattackChance -= MultiAttackBonus;
            if (AbilityDamage > 0.00)
                Player.AbilityDamage -= AbilityDamage;
            if (ArmourStats > 0)
                Player.armour -= ArmourStats;
            if (StunChanceBonus > 0.00)
                Player.StunChance -= StunChanceBonus;
            if (DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if (CritDamageBonus > 0.00)
                Player.CriticalDamage -= CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Player.StaminaRegen -= StaminaRegenBonus;
            if (CooldownReduction > 0)
                Player.CooldownReduction -= CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Player.AOEChance -= AOEchanceBonus;
            if (CritChance > 0.00)
                Player.CriticalChance -= CritChance;
            if (GoldBonus > 0)
                Player.GoldBonus -= GoldBonus;
            if (Rareitydroprate > 0.00)
                Player.RarityIncrease -= Rareitydroprate;
            if (EXPbonus > 0)
                Player.EXPBonus -= EXPbonus;
            if (HealthRegen > 0)
                Player.HealthRegen -= HealthRegen;
            EquippedRelicHolder.transform.Find("Relicone").GetComponent<Image>().sprite = null;
        }
        if(type == "BattleHarden")
        {
            RelicBattleHarden.SetActive(false);
            PlayerStats Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

            if (HPBonus > 0)
                Player.Health -= HPBonus;
            if (MovementSpeedBonus > 0)
                Player.Movespeed -= MovementSpeedBonus;
            if (Damage > 0)
                Player.BaseDamage -= Damage;
            if (BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Player.MultiattackChance -= MultiAttackBonus;
            if (AbilityDamage > 0.00)
                Player.AbilityDamage -= AbilityDamage;
            if (ArmourStats > 0)
                Player.armour -= ArmourStats;
            if (StunChanceBonus > 0.00)
                Player.StunChance -= StunChanceBonus;
            if (DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if (CritDamageBonus > 0.00)
                Player.CriticalDamage -= CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Player.StaminaRegen -= StaminaRegenBonus;
            if (CooldownReduction > 0)
                Player.CooldownReduction -= CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Player.AOEChance -= AOEchanceBonus;
            if (CritChance > 0.00)
                Player.CriticalChance -= CritChance;
            if (GoldBonus > 0)
                Player.GoldBonus -= GoldBonus;
            if (Rareitydroprate > 0.00)
                Player.RarityIncrease -= Rareitydroprate;
            if (EXPbonus > 0)
                Player.EXPBonus -= EXPbonus;
            if (HealthRegen > 0)
                Player.HealthRegen -= HealthRegen;
            EquippedRelicHolder.transform.Find("Relictwo").GetComponent<Image>().sprite = null;
        }
        if (type == "Expert")
        {
            RelicExpert.SetActive(false);
            PlayerStats Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

            if (HPBonus > 0)
                Player.Health -= HPBonus;
            if (MovementSpeedBonus > 0)
                Player.Movespeed -= MovementSpeedBonus;
            if (Damage > 0)
                Player.BaseDamage -= Damage;
            if (BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Player.MultiattackChance -= MultiAttackBonus;
            if (AbilityDamage > 0.00)
                Player.AbilityDamage -= AbilityDamage;
            if (ArmourStats > 0)
                Player.armour -= ArmourStats;
            if (StunChanceBonus > 0.00)
                Player.StunChance -= StunChanceBonus;
            if (DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if (CritDamageBonus > 0.00)
                Player.CriticalDamage -= CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Player.StaminaRegen -= StaminaRegenBonus;
            if (CooldownReduction > 0)
                Player.CooldownReduction -= CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Player.AOEChance -= AOEchanceBonus;
            if (CritChance > 0.00)
                Player.CriticalChance -= CritChance;
            if (GoldBonus > 0)
                Player.GoldBonus -= GoldBonus;
            if (Rareitydroprate > 0.00)
                Player.RarityIncrease -= Rareitydroprate;
            if (EXPbonus > 0)
                Player.EXPBonus -= EXPbonus;
            if (HealthRegen > 0)
                Player.HealthRegen -= HealthRegen;
            EquippedRelicHolder.transform.Find("relicthree").GetComponent<Image>().sprite = null;
        }

    }

    public void EquipDifferentRelicBeginner()
    {
        RelicItem PreviousRelicBeginner = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<RelicInventory>().RelicBeginnerEquipped.GetComponent<RelicItem>();
        PreviousRelicBeginner.RemoveRelic();
        Relicusage();
    }

    public void EquipedDifferentBattlehardenRelic()
    {
        RelicItem PreviousRelicBattleharden = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<RelicInventory>().RelicBattleHardenEquipped.GetComponent<RelicItem>();
        PreviousRelicBattleharden.RemoveRelic();
        Relicusage();
    }

    public void EquipDifferentExpertRelic()
    {
        RelicItem PreviousRelicExpert = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<RelicInventory>().RelicExpertEquipped.GetComponent<RelicItem>();
        PreviousRelicExpert.RemoveRelic();
        Relicusage();
    }

    public void SetRelicTtile()
    {
        if (type == "Beginner")
        {
            Maindescription = description + "\n Relic " + Relic;
            if (Damage > 0)
                Maindescription += "\n Damage = " + Damage;
            if (HPBonus > 0)
                Maindescription += "\n Health Bonus = " + HPBonus;
            if (AbilityDamage > 0.00)
                Maindescription += "\n Ability Damage = " + AbilityDamage;
            if (MovementSpeedBonus > 0)
                Maindescription += "\n Movement speed = " + MovementSpeedBonus;
            if (BlockChanceBonus > 0.00)
                Maindescription += "\n Block chance = " + BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Maindescription += "\n Multi-attack = " + MultiAttackBonus;
            if (ArmourStats > 0)
                Maindescription += "\n Armour stat = " + ArmourStats;
            if (StunChanceBonus > 0.00)
                Maindescription += "\n Stun chance = " + StunChanceBonus;
            if (DodgeBonus > 0.00)
                Maindescription += "\n Dodge chance = " + DodgeBonus;
            if (CritDamageBonus > 0.00)
                Maindescription += "\n Critical Damage = " + CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Maindescription += "\n Stamina Regen = " + StaminaRegenBonus;
            if (CooldownReduction > 0)
                Maindescription += "\n Cooldown reduction = " + CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Maindescription += "\n AOE chance = " + AOEchanceBonus;
            if (CritChance > 0.00)
                Maindescription += "\n Critical chance = " + CritChance;
            if (GoldBonus > 0.00)
                Maindescription += "\n Gold bonus = " + GoldBonus;
            if (Rareitydroprate > 0.00)
                Maindescription += "\n Rarity drop rate = " + Rareitydroprate;
            if (EXPbonus > 0.00)
                Maindescription += "\n EXP bonus = " + EXPbonus;
            if (HealthRegen > 0)
                Maindescription += "\n Health regen = " + HealthRegen;

        }
        if (type == "BattleHarden")
        {
            Maindescription = description + "\n Relic " + Relic;
            if (Damage > 0)
                Maindescription += "\n Damage = " + Damage;
            if (HPBonus > 0)
                Maindescription += "\n Health Bonus = " + HPBonus;
            if (AbilityDamage > 0.00)
                Maindescription += "\n Ability Damage = " + AbilityDamage;
            if (MovementSpeedBonus > 0)
                Maindescription += "\n Movement speed = " + MovementSpeedBonus;
            if (BlockChanceBonus > 0.00)
                Maindescription += "\n Block chance = " + BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Maindescription += "\n Multi-attack = " + MultiAttackBonus;
            if (ArmourStats > 0)
                Maindescription += "\n Armour stat = " + ArmourStats;
            if (StunChanceBonus > 0.00)
                Maindescription += "\n Stun chance = " + StunChanceBonus;
            if (DodgeBonus > 0.00)
                Maindescription += "\n Dodge chance = " + DodgeBonus;
            if (CritDamageBonus > 0.00)
                Maindescription += "\n Critical Damage = " + CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Maindescription += "\n Stamina Regen = " + StaminaRegenBonus;
            if (CooldownReduction > 0)
                Maindescription += "\n Cooldown reduction = " + CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Maindescription += "\n AOE chance = " + AOEchanceBonus;
            if (CritChance > 0.00)
                Maindescription += "\n Critical chance = " + CritChance;
            if (GoldBonus > 0.00)
                Maindescription += "\n Gold bonus = " + GoldBonus;
            if (Rareitydroprate > 0.00)
                Maindescription += "\n Rarity drop rate = " + Rareitydroprate;
            if (EXPbonus > 0.00)
                Maindescription += "\n EXP bonus = " + EXPbonus;
            if (HealthRegen > 0)
                Maindescription += "\n Health regen = " + HealthRegen;
        }
        if (type == "Expert")
        {
            Maindescription = description + "\n Relic " + Relic;
            if (Damage > 0)
                Maindescription += "\n Damage = " + Damage;
            if (HPBonus > 0)
                Maindescription += "\n Health Bonus = " + HPBonus;
            if (AbilityDamage > 0.00)
                Maindescription += "\n Ability Damage = " + AbilityDamage;
            if (MovementSpeedBonus > 0)
                Maindescription += "\n Movement speed = " + MovementSpeedBonus;
            if (BlockChanceBonus > 0.00)
                Maindescription += "\n Block chance = " + BlockChanceBonus;
            if (MultiAttackBonus > 0.00)
                Maindescription += "\n Multi-attack = " + MultiAttackBonus;
            if (ArmourStats > 0)
                Maindescription += "\n Armour stat = " + ArmourStats;
            if (StunChanceBonus > 0.00)
                Maindescription += "\n Stun chance = " + StunChanceBonus;
            if (DodgeBonus > 0.00)
                Maindescription += "\n Dodge chance = " + DodgeBonus;
            if (CritDamageBonus > 0.00)
                Maindescription += "\n Critical Damage = " + CritDamageBonus;
            if (StaminaRegenBonus > 0)
                Maindescription += "\n Stamina Regen = " + StaminaRegenBonus;
            if (CooldownReduction > 0)
                Maindescription += "\n Cooldown reduction = " + CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Maindescription += "\n AOE chance = " + AOEchanceBonus;
            if (CritChance > 0.00)
                Maindescription += "\n Critical chance = " + CritChance;
            if (GoldBonus > 0.00)
                Maindescription += "\n Gold bonus = " + GoldBonus;
            if (Rareitydroprate > 0.00)
                Maindescription += "\n Rarity drop rate = " + Rareitydroprate;
            if (EXPbonus > 0.00)
                Maindescription += "\n EXP bonus = " + EXPbonus;
            if (HealthRegen > 0)
                Maindescription += "\n Health regen = " + HealthRegen;
        }
    }

    public string GetRelicDescription()
    {
        RelicTooltip = GameObject.Find("Relictooltip").GetComponent<Image>();
        RelicTooltipText = RelicTooltip.GetComponentInChildren<Text>();
        switch(type){
            case "Beginner":
                RelicTooltip.GetComponent<Image>().color = new Color32();
                RelicTooltipText.GetComponent<Text>().color = new Color();
                break;
            case "BattleHarden":
                RelicTooltip.GetComponent<Image>().color = new Color32();
                RelicTooltipText.GetComponent<Text>().color = new Color32();
                break;
            case "Expert":
                RelicTooltip.GetComponent<Image>().color = new Color32();
                RelicTooltipText.GetComponent<Text>().color = new Color();
                break;
        }
        
        return Maindescription;
    }
}
