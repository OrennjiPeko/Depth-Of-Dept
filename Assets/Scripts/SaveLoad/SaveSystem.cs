using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveSystem 
{
    //Stores the player's stats
    [HideInInspector] public float Level;
    [HideInInspector] public float mainexp;
    [HideInInspector] public float skillpoints;
    [HideInInspector] public float Gold;
    [HideInInspector] public float Health;
    [HideInInspector] public float baseDamage;
    [HideInInspector] public float AOEDamage;
    [HideInInspector] public float StaminaMax;
    [HideInInspector] public float MultiAttckX;
    [HideInInspector] public float HealthRegen;
    [HideInInspector] public float StaminaRegen;
    [HideInInspector] public float HealthRegenRank;
    [HideInInspector] public float CriticalDamage;
    [HideInInspector] public float AttackSpeedRank;
    [HideInInspector] public float StunChance;
    [HideInInspector] public float MultiattackChance;
    [HideInInspector] public float DodgeChance;
    [HideInInspector] public float AbilityDamage;
    [HideInInspector] public float AOEChance;
    [HideInInspector] public float HealthBonus;
    [HideInInspector] public float CriticalChance;
    [HideInInspector] public float BlockChance;
    [HideInInspector] public float CooldownReduction;
    [HideInInspector] public float GoldBonus;
    [HideInInspector] public float DamageBonus;
    [HideInInspector] public float SpeedRank;
    [HideInInspector] public float Movespeed;
    [HideInInspector] public float EXPBonus;
    [HideInInspector] public float DamageReflect;
    [HideInInspector] public float RarityIncrease;
    [HideInInspector] public int Floor;
    [HideInInspector] public float MaxHealth;
    [HideInInspector] public float EXPtoNext;
    [HideInInspector] public float Armour;

    //Saves a list of the ID of the items
    public List<int> WeaponsCollectedID = new List<int>();
    public List<int> HeadArmourCollectedID = new List<int>();
    public List<int> ChestArmourCollectedID = new List<int>();
    public List<int> GlovesCollectedId = new List<int>();
    public List<int> LegsArmourCollectedId = new List<int>();
    public List<int> BootsCollectedID = new List<int>();
    public List<int> WeaponCollectedRank = new List<int>();
    public List<int> HeadArmourCollectedRank = new List<int>();
    public List<int> ChestArmourCollectedRank = new List<int>();
    public List<int> GlovesCollectedRank = new List<int>();
    public List<int> LegsArmourCollectedRank = new List<int>();
    public List<int> BootsArmourCollectdRank = new List<int>();
    public List<string> WeaponsCollectedRarity = new List<string>();
    public List<string> HeadArmourCollectedRarity = new List<string>();
    public List<string> ChestArmourCollectedRarity = new List<string>();
    public List<string> GlovesCollectedRarity = new List<string>();
    public List<string> LegsArmourCollectedRarity = new List<string>();
    public List<string> BootsCollectedRarity = new List<string>();

    //Stores the Player's unlocked Passive Skills
    public List<string> UnlockedPassiveAbilities;
    public List<int> UnlockedPassiveRank;

    public List<int>BeginnerColltecID = new List<int>();
    public List<int> BattlehardenCollectedID = new List<int>();
    public List<int> ExpertCollectedID = new List<int>();
    // int that are floats for bigger numbers
    public List<float> BeginnerHPBonus = new List<float>();
    public List<float> BattleHardenHPBonus = new List<float>();
    public List<float> ExpertHPBonus = new List<float>();
    public List<float> BeginnerMovementSpeedBonus = new List<float>();
    public List<float> BattleHardenMovementSpeedBonus = new List<float>();
    public List<float> ExpertMovementSpeedBonus = new List<float>();
    public List<float> BeginnerDamage = new List<float>();
    public List<float> BattleHardenDamage = new List<float>();
    public List<float> ExpertDamage = new List<float>();
    public List<float> BeginnerBlockChanceBonus = new List<float>();
    public List<float> BattlehardenBlockChanceBonus = new List<float>();
    public List<float> ExpertBlockChanceBonus = new List<float>();
    public List<float> BeginnerMultiAttackBonus = new List<float>();
    public List<float> BattlehardenMultiAttackBonus = new List<float>();
    public List<float> ExpertMultiAttackBonus = new List<float>();
    public List<float> BeginnerAbilityDamage = new List<float>();
    public List<float> BattlehardenAbilityDamage = new List<float>();
    public List<float> ExpertAbilityDamage = new List<float>();
    public List<float> BeginnerArmourStats = new List<float>();
    public List<float> BattleHardenArmourStats = new List<float>();
    public List<float> ExpertArmourStats = new List<float>();
    //percentage
    public List<float> BeginnerStunChanceBonus = new List<float>();
    public List<float> BattlehardenStunChanceBonus = new List<float>();
    public List<float> ExpertStunChanceBonus = new List<float>();
    public List<float> BeginnerDodgeBonus = new List<float>();
    public List<float> BattlehardenDodgeBonus = new List<float>();
    public List<float> ExpertDodgeBonus = new List<float>();
    public List<float> BeginnerCritDamageBonus = new List<float>();
    public List<float> BattlehardenCritDamageBonus = new List<float>();
    public List<float> ExpertCritDamageBonus = new List<float>();
    public List<float> BeginnerStaminaRegenBonus = new List<float>();
    public List<float> BattlehardenStaminaRegenBonus = new List<float>();
    public List<float> ExpertStaminaRegenBonus = new List<float>();
    public List<float> BeginnerCooldownReduction = new List<float>();
    public List<float> BattlehardenCooldownReduction = new List<float>();
    public List<float> ExpertCooldownReduction = new List<float>();
    public List<float> BeginnerAOEchanceBonus = new List<float>();
    public List<float> BattlehardenAOEchanceBonus = new List<float>();
    public List<float> ExpertAOEchanceBonus = new List<float>();
    public List<float> BeginnerCritChance = new List<float>();
    public List<float> BattlehardenCritChance = new List<float>();
    public List<float> ExpertCritChance = new List<float>();
    public List<float> BeginnerGoldBonus = new List<float>();
    public List<float> BattlehardenGoldBonus = new List<float>();
    public List<float> ExpertGoldBonus = new List<float>();
    public List<float> BeginnerRareitydroprate = new List<float>();
    public List<float> BattlehardenRareitydroprate = new List<float>();
    public List<float> ExpertRareitydroprate = new List<float>();
    public List<float> BeginnerEXPbonus = new List<float>();
    public List<float> BattlehardenEXPbonus = new List<float>();
    public List<float> ExpertEXPbonus = new List<float>();
    public List<float> BeginnerHealthRegen = new List<float>();
    public List<float> BattlehardenHealthRegen = new List<float>();
    public List<float> ExpertHealthRegen = new List<float>();

    public List<string> BeginnerDescription = new List<string>();
    public List<string> BattlehardenDescription = new List<string>();
    public List<string> ExpertDescription = new List<string>();

    public List<string> Beginnertype = new List<string>();
    public List<string> Battlehardentype = new List<string>();
    public List<string> Experttype = new List<string>();
    public SaveSystem(PlayerData Player)
    {
        //Pulls the stat information from the player
        Level = Player.Level;
        mainexp = Player.mainexp;
        skillpoints = Player.skillpoints;
        Gold = Player.Gold;
        Health = Player.Health;
        baseDamage = Player.baseDamage;
        AOEDamage = Player.AOEDamage;
        StaminaMax = Player.StaminaMax;
        MultiAttckX = Player.MultiAttckX;
        HealthRegen = Player.HealthRegen;
        StaminaRegen = Player.StaminaRegen;
        HealthRegenRank = Player.HealthRegenRank;
        CriticalDamage = Player.CriticalDamage;
        AttackSpeedRank = Player.AttackSpeedRank;
        StunChance = Player.StunChance;
        MultiattackChance = Player.MultiattackChance;
        DodgeChance = Player.DodgeChance;
        AbilityDamage = Player.AbilityDamage;
        AOEChance = Player.AOEChance;
        HealthBonus = Player.HealthBonus;
        CriticalChance = Player.CriticalChance;
        BlockChance = Player.BlockChance;
        CooldownReduction = Player.CooldownReduction;
        GoldBonus = Player.GoldBonus;
        DamageBonus = Player.DamageBonus;
        SpeedRank = Player.MovesRank;
        Movespeed = Player.Movespeed;
        EXPBonus = Player.EXPBonus;
        DamageReflect = Player.DamageReflect;
        RarityIncrease = Player.RarityIncrease;
        Floor = Player.Floor;
        MaxHealth = Player.MaxHealth;
        EXPtoNext = Player.EXPtoNext;
        Armour = Player.Armour;
    }

    public SaveSystem(SaveplayerInventory inventory)
    {
        //Pulls the weapon IDs from the inventory
        WeaponsCollectedID = inventory.WeaponsCollectedID;
        HeadArmourCollectedID = inventory.HeadArmourCollectedID;
        ChestArmourCollectedID = inventory.ChestArmourCollectedID;
        GlovesCollectedId = inventory.GlovesCollectedId;
        LegsArmourCollectedId = inventory.LegsArmourCollectedId;
        BootsCollectedID = inventory.BootsCollectedID;
        //pulls the Rank from the inventory
        WeaponCollectedRank = inventory.WeaponCollectedRank;
        HeadArmourCollectedRank = inventory.HeadArmourCollectedRank;
        ChestArmourCollectedRank = inventory.HeadArmourCollectedRank;
        GlovesCollectedRank = inventory.GlovesCollectedRank;
        LegsArmourCollectedRank = inventory.LegsArmourCollectedRank;
        BootsArmourCollectdRank = inventory.BootsArmourCollectdRank;
        //Saves the items rarity
        WeaponsCollectedRarity = inventory.WeaponsCollectedRarity;
        HeadArmourCollectedRarity = inventory.HeadArmourCollectedRarity;
        ChestArmourCollectedRarity = inventory.ChestArmourCollectedRarity;
        GlovesCollectedRarity = inventory.GlovesCollectedRarity;
        LegsArmourCollectedRarity = inventory.LegsArmourCollectedRarity;
        BootsCollectedRarity = inventory.BootsCollectedRarity;
    }

    public SaveSystem(PlayerCombat PassiveSkills)
    {
        UnlockedPassiveAbilities = PassiveSkills.UnlockedPassiveAbilities;
        UnlockedPassiveRank = PassiveSkills.PassiveRank;
        foreach(string ability in UnlockedPassiveAbilities)
        {
            Debug.Log(ability + " Rank:" + UnlockedPassiveRank[UnlockedPassiveAbilities.IndexOf(ability)]);
        }

    }

    public SaveSystem(SaveInventoryRelic RelicInventory)
    {
        BeginnerColltecID = RelicInventory.CollectedBeginnerID;
        BattlehardenCollectedID = RelicInventory.CollectedBattleHardenID;
        ExpertCollectedID = RelicInventory.CollectedExpertID;
        
        BeginnerHPBonus = RelicInventory.BeginnerHPBonus;
        BeginnerMovementSpeedBonus = RelicInventory.BeginnerMovementSpeedBonus;
        BeginnerDamage = RelicInventory.BeginnerDamage;
        BeginnerBlockChanceBonus = RelicInventory.BeginnerBlockChanceBonus;
        BeginnerMultiAttackBonus = RelicInventory.BeginnerMultiAttackBonus;
        BeginnerAbilityDamage = RelicInventory.BeginnerAbilityDamage;
        BeginnerArmourStats = RelicInventory.BeginnerArmourStats;
        BeginnerStunChanceBonus = RelicInventory.BeginnerStunChanceBonus;
        BeginnerDodgeBonus = RelicInventory.BeginnerDodgeBonus;
        BeginnerCritDamageBonus = RelicInventory.BeginnerCritDamageBonus;
        BeginnerStaminaRegenBonus = RelicInventory.BeginnerStaminaRegenBonus;
        BeginnerCooldownReduction = RelicInventory.BeginnerCooldownReduction;
        BeginnerAOEchanceBonus = RelicInventory.BeginnerAOEchanceBonus;
        BeginnerCritChance = RelicInventory.BeginnerCritChance;
        BeginnerGoldBonus = RelicInventory.BeginnerGoldBonus;
        BeginnerRareitydroprate = RelicInventory.BeginnerRareitydroprate;
        BeginnerEXPbonus = RelicInventory.BeginnerEXPbonus;
        BeginnerHealthRegen = RelicInventory.BeginnerHealthRegen;
        BeginnerDescription = RelicInventory.BeginnerDescription;
        Beginnertype = RelicInventory.Beginnertype;

        BattleHardenHPBonus = RelicInventory.BattleHardenHPBonus;
        BattleHardenMovementSpeedBonus = RelicInventory.BattleHardenMovementSpeedBonus;
        BattleHardenDamage = RelicInventory.BattleHardenDamage;
        BattlehardenBlockChanceBonus = RelicInventory.BattlehardenBlockChanceBonus;
        BattlehardenMultiAttackBonus = RelicInventory.BattlehardenMultiAttackBonus;
        BattlehardenAbilityDamage = RelicInventory.BattlehardenAbilityDamage;
        BattleHardenArmourStats = RelicInventory.BattleHardenArmourStats;
        BattlehardenStunChanceBonus = RelicInventory.BattlehardenStunChanceBonus;
        BattlehardenDodgeBonus = RelicInventory.BattlehardenDodgeBonus;
        BattlehardenCritDamageBonus = RelicInventory.BattlehardenCritDamageBonus;
        BattlehardenStaminaRegenBonus = RelicInventory.BattlehardenStaminaRegenBonus;
        BattlehardenCooldownReduction = RelicInventory.BattlehardenCooldownReduction;
        BattlehardenAOEchanceBonus = RelicInventory.BattlehardenAOEchanceBonus;
        BattlehardenCritChance = RelicInventory.BattlehardenCritChance;
        BattlehardenGoldBonus = RelicInventory.BattlehardenGoldBonus;
        BattlehardenRareitydroprate = RelicInventory.BattlehardenRareitydroprate;
        BattlehardenEXPbonus = RelicInventory.BattlehardenEXPbonus;
        BattlehardenHealthRegen = RelicInventory.BattlehardenHealthRegen;
        BattlehardenDescription = RelicInventory.BattlehardenDescription;
        Battlehardentype = RelicInventory.Battlehardentype;

        ExpertHPBonus = RelicInventory.ExpertHPBonus;
        ExpertMovementSpeedBonus = RelicInventory.ExpertMovementSpeedBonus;
        ExpertDamage = RelicInventory.ExpertDamage;
        ExpertBlockChanceBonus = RelicInventory.ExpertBlockChanceBonus;
        ExpertMultiAttackBonus = RelicInventory.ExpertMultiAttackBonus;
        ExpertAbilityDamage = RelicInventory.ExpertAbilityDamage;
        ExpertArmourStats = RelicInventory.ExpertArmourStats;
        ExpertStunChanceBonus = RelicInventory.ExpertStunChanceBonus;
        ExpertDodgeBonus = RelicInventory.ExpertDodgeBonus;
        ExpertCritDamageBonus = RelicInventory.ExpertCritDamageBonus;
        ExpertStaminaRegenBonus = RelicInventory.ExpertStaminaRegenBonus;
        ExpertCooldownReduction = RelicInventory.ExpertCooldownReduction;
        ExpertAOEchanceBonus = RelicInventory.ExpertAOEchanceBonus;
        ExpertCritChance = RelicInventory.ExpertCritChance;
        ExpertGoldBonus = RelicInventory.ExpertGoldBonus;
        ExpertRareitydroprate = RelicInventory.ExpertRareitydroprate;
        ExpertEXPbonus = RelicInventory.ExpertEXPbonus;
        ExpertHealthRegen = RelicInventory.ExpertHealthRegen;
        ExpertDescription = RelicInventory.ExpertDescription;
        Experttype = RelicInventory.Experttype;
    }
}
