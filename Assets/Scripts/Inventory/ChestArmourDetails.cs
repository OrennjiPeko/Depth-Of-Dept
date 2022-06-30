using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChestArmourDetails : ScriptableObject
{
   [HideInInspector] public string ChestArmour = "ChestArmour";
    public string ChestName;
    public enum ClassType
    {
        Bruiser,
        Assassin,
        Cultist
    }

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Enchanted,
        Rare,
        Mystical,
        Legendary,
        Ancient,
        Godly
    }

    public ClassType ArmourClass;
    public ItemRarity ItemLevel;
    public int ID;
    public string Description = "";
    public Sprite icon;

    public float DodgeBonus;
    public float StaminaRegenBonus;
    public float ArmourStats;
   [HideInInspector] public string Class;
   [HideInInspector] public int ChestLevel;
  [HideInInspector] public float ChestGoldNeeded;
   [HideInInspector] public bool ChestMaxGearLevel =false;

    //Random stats
    private int NumOfRandomStats;
    [HideInInspector] public float Damage;
    [HideInInspector] public float HPBonus;
    [HideInInspector] public float MultiAttackBonus;
    [HideInInspector] public float MovementSpeedBonus;
    // percentages 
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float BlockChanceBonus;
    [HideInInspector] public float AbilityDamage;
    [HideInInspector] public float CooldownReduction;
    [HideInInspector] public float AOEchanceBonus;

    //Checks if legendary trait has been activated
    [HideInInspector] public bool GoldRushActive;
    [HideInInspector] public bool BulwarkParryActive;
    [HideInInspector] public bool BerserkActive;
    [HideInInspector] public bool MultiCasterActive;
    [HideInInspector] public bool LuckyLooterActive;
    [HideInInspector] public bool SwiftActivated;

    //Legendary traits an item may have
    [HideInInspector] public string LegendaryTrait;
    [HideInInspector] public string SecondLegendaryTrait;

    //Variables to check if the item was loaded in and it's rarity
    [HideInInspector] public string ItemLoadedRarity;

    private void Awake()
    {
        Class = ArmourClass.ToString();
    }

    public void SetRarity(bool ItemLoadedIn)
    {
        if (!ItemLoadedIn)
        {
            ItemLevel = (ItemRarity)Random.Range(0, 8);
        }
        else
        {
            switch (ItemLoadedRarity)
            {
                case "Common":
                    {
                        ItemLevel = ItemRarity.Common;
                        break;
                    }
                case "Uncommon":
                    {
                        ItemLevel = ItemRarity.Uncommon;
                        break;
                    }
                case "Enchanted":
                    {
                        ItemLevel = ItemRarity.Enchanted;
                        break;
                    }
                case "Rare":
                    {
                        ItemLevel = ItemRarity.Rare;
                        break;
                    }
                case "Mystical":
                    {
                        ItemLevel = ItemRarity.Mystical;
                        break;
                    }
                case "Legendary":
                    {
                        ItemLevel = ItemRarity.Legendary;
                        break;
                    }
                case "Ancient":
                    {
                        ItemLevel = ItemRarity.Ancient;
                        break;
                    }
                case "Godly":
                    {
                        ItemLevel = ItemRarity.Godly;
                        break;
                    }
            }
        }

        GearLevel();
        RartiyStats();
    }

    public void MaxUpgradeMode()
    {
        switch (ItemLevel)
        {
            case ItemRarity.Common:
                ChestGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 10;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 5;
                    DodgeBonus += 0.01f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 3;
                    StaminaRegenBonus += 2;
                }
                break;
            case ItemRarity.Uncommon:
                ChestGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 15;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 10;
                    DodgeBonus += 0.02f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 6;
                    StaminaRegenBonus += 4;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Enchanted:
                ChestGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 20;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 15;
                    DodgeBonus += 0.03f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 9;
                    StaminaRegenBonus += 6;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Rare:
                ChestGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 25;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 20;
                    DodgeBonus += 0.04f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 12;
                    StaminaRegenBonus += 8;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Mystical:
                ChestGoldNeeded += 120000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 30;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 25;
                    DodgeBonus += 0.05f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 15;
                    StaminaRegenBonus += 10;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Legendary:
                ChestGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 35;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 30;
                    DodgeBonus += 0.06f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 20;
                    StaminaRegenBonus += 12;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Ancient:
                ChestGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 40;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 35;
                    DodgeBonus += 0.07f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 25;
                    StaminaRegenBonus += 14;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Godly:
                ChestGoldNeeded += 20000;
                if (Class == "Bruiser")
                {
                    ArmourStats += 45;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 40;
                    DodgeBonus += 0.07f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 30;
                    StaminaRegenBonus += 16;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.02f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.02f;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
        }
    }
   public void GearLevel()
    {
        switch (ChestLevel)
        {
            case 0:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded = 4000;
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded = 8000;
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded = 12000;
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded = 16000;
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded = 20000;
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded = 24000;
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded = 28000;
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded = 32000;
                        break;
                }
               
                break;
            case 1:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if(AbilityDamage> 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

             
              
                
                break;
            case 2:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
              case 3:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 4:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 5:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 6:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 7:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 8:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 9:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;
            case 10:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                }

                break;

            case 11:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 5;
                            DodgeBonus += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 3;
                            StaminaRegenBonus += 2;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Uncommon:
                        ChestGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 10;
                            DodgeBonus += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 6;
                            StaminaRegenBonus += 4;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Enchanted:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 15;
                            DodgeBonus += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 9;
                            StaminaRegenBonus += 6;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Rare:
                        ChestGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 20;
                            DodgeBonus += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 12;
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Mystical:
                        ChestGoldNeeded += 120000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 25;
                            DodgeBonus += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 15;
                            StaminaRegenBonus += 10;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Legendary:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 20;
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Ancient:
                        ChestGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 25;
                            StaminaRegenBonus += 14;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                    case ItemRarity.Godly:
                        ChestGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 30;
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.02f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.02f;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        ChestMaxGearLevel = true;
                        break;
                }
                break;

        }
    }

    public void RartiyStats()
    {
        switch (ItemLevel)
        {
            case ItemRarity.Common:
                break;
            case ItemRarity.Uncommon:
                {
                    switch (Random.Range(0, 11))
                    {
                        case 0:
                            {
                                Damage = 3;
                                break;
                            }
                        case 1:
                            {
                                HPBonus = 3;
                                break;
                            }
                        case 2:
                            {
                                StunChanceBonus = 3;
                                break;
                            }
                        case 3:
                            {
                                CritChance = 0.02f;
                                break;
                            }
                        case 4:
                            {
                                CritDamageBonus = 3;
                                break;
                            }
                        case 5:
                            {
                                MovementSpeedBonus = 3;
                                break;
                            }
                        case 6:
                            {
                                MultiAttackBonus = 0.02f;
                                break;
                            }
                        case 7:
                            {
                                BlockChanceBonus = 0.02f;
                                break;
                            }
                        case 8:
                            {
                                AbilityDamage = 0.02f;
                                break;
                            }
                        case 9:
                            {
                                CooldownReduction = 0.02f;
                                break;
                            }
                        case 10:
                            {
                                AOEchanceBonus = 0.02f;
                                break;
                            }
                    }
               
                    break;
                }
            case ItemRarity.Enchanted:
                {
                    NumOfRandomStats = Random.Range(1, 3);
                    for(int i = 0; i < NumOfRandomStats; i++)
                    {
                        switch (Random.Range(0, 11))
                        {
                            case 0:
                                {
                                    Damage = 6;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 6;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 6;
                                    break;
                                }
                            case 3:
                                {
                                    CritChance = 0.04f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 6;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 6;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.04f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus = 0.04f;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.04f;
                                    break;
                                }
                            case 9:
                                {
                                    CooldownReduction = 0.04f;
                                    break;
                                }
                            case 10:
                                {
                                    AOEchanceBonus = 0.04f;
                                    break;
                                }
                        }
                    }
                    break;
                }
            case ItemRarity.Rare:
                {
                    NumOfRandomStats = Random.Range(2, 5);
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        switch (Random.Range(0, 11))
                        {
                            case 0:
                                {
                                    Damage = 9;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 9;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 9;
                                    break;
                                }
                            case 3:
                                {
                                    CritChance = 0.06f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 9;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 9;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.06f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus = 0.06f;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.06f;
                                    break;
                                }
                            case 9:
                                {
                                    CooldownReduction = 0.06f;
                                    break;
                                }
                            case 10:
                                {
                                    AOEchanceBonus = 0.06f;
                                    break;
                                }
                        }
                    }
                    break;
                }
            case ItemRarity.Mystical:
                {
                    NumOfRandomStats = Random.Range(3, 6);
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        switch (Random.Range(0, 11))
                        {
                            case 0:
                                {
                                    Damage = 12;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 12;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 12;
                                    break;
                                }
                            case 3:
                                {
                                    CritChance = 0.08f; 
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 12;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 12;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.08f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus = 0.08f;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.08f;
                                    break;
                                }
                            case 9:
                                {
                                    CooldownReduction = 0.08f;
                                    break;
                                }
                            case 10:
                                {
                                    AOEchanceBonus = 0.08f;
                                    break;
                                }
                        }
                    }
                    break;
                }
            case ItemRarity.Legendary:
                {
                    NumOfRandomStats = Random.Range(3, 6) + 1;
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        switch (Random.Range(0, 11))
                        {
                            case 0:
                                {
                                    Damage = 15;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 15;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 15;
                                    break;
                                }
                            case 3:
                                {
                                    CritChance = 0.10f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 15;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 15;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.10f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus = 0.10f;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.10f;
                                    break;
                                }
                            case 9:
                                {
                                    CooldownReduction = 0.10f;
                                    break;
                                }
                            case 10:
                                {
                                    AOEchanceBonus = 0.10f;
                                    break;
                                }
                        }
                    }
                    RandomLegendryTrait(LegendaryTrait);
                    break;
                }
            case ItemRarity.Ancient:
                {
                    NumOfRandomStats = 6;
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        switch (Random.Range(0, 11))
                        {
                            case 0:
                                {
                                    Damage = 18;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 18;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 18;
                                    break;
                                }
                            case 3:
                                {
                                    CritChance = 0.12f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 18;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 18;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.12f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus = 0.12f;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.12f;
                                    break;
                                }
                            case 9:
                                {
                                    CooldownReduction = 0.12f;
                                    break;
                                }
                            case 10:
                                {
                                    AOEchanceBonus = 0.12f;
                                    break;
                                }
                        }
                    }
                    RandomLegendryTrait(LegendaryTrait);
                    break;
                }
            case ItemRarity.Godly:
                {
                    NumOfRandomStats = 6;
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        switch (Random.Range(0, 11))
                        {
                            case 0:
                                {
                                    Damage = 21;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 21;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 21;
                                    break;
                                }
                            case 3:
                                {
                                    CritChance = 0.14f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 21;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 21;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.14f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus = 0.14f;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.14f;
                                    break;
                                }
                            case 9:
                                {
                                    CooldownReduction = 0.14f;
                                    break;
                                }
                            case 10:
                                {
                                    AOEchanceBonus = 0.14f;
                                    break;
                                }
                        }
                    }
                    RandomLegendryTrait(LegendaryTrait);
                    RandomLegendryTrait(SecondLegendaryTrait);
                    break;
                }
        }
    }

    void RandomLegendryTrait(string Trait)
    {
        int RandomNumber = Random.Range(0, 30);

        switch (RandomNumber)
        {
            case 0:
                {
                    Trait = "GoldRush";
                    break;
                }
            case 1:
                {
                    Trait = "CriticalThinker";
                    break;
                }
            case 2:
                {
                    Trait = "BulwarkParry";
                    break;
                }
            case 3:
                {
                    Trait = "MultiCaster";
                    break;
                }
            case 4:
                {
                    Trait = "LuckyLooter";
                    break;
                }
            case 5:
                {
                    Trait = "HoardSpotter";
                    break;
                }
            case 6:
                {
                    Trait = "Swift";
                    break;
                }
            case 7:
                {
                    Trait = "Reflect";
                    break;
                }
            case 8:
                {
                    Trait = "ExplosiveFury";
                    break;
                }
            case 9:
                {
                    Trait = "DeathDealer";
                    break;
                }
            case 10:
                {
                    Trait = "CarefulApproach";
                    break;
                }
            case 11:
                {
                    Trait = "QuickLearner";
                    break;
                }
            case 12:
                {
                    Trait = "RecklessAbandon";
                    break;
                }
            case 13:
                {
                    Trait = "Flurried";
                    break;
                }
            case 14:
                {
                    Trait = "Drainer";
                    break;
                }
            case 15:
                {
                    Trait = "ShadowMerge";
                    break;
                }
            case 16:
                {
                    Trait = "EverlastingFlame";
                    break;
                }
        }
    }
}
