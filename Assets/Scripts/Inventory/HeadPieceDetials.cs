using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HeadPieceDetials : ScriptableObject
{
   [HideInInspector] public string HeadArmour = "HeadArmour";
    public string HeadName;
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

    public int HPBonus;
    public float CritChance;
    public float CooldownReduction;
    public int ArmourStats;
   [HideInInspector] public string Class;
   [HideInInspector] public int Headlevel;
   [HideInInspector] public float HeadGoldNeeded;
   [HideInInspector] public bool HeadMaxGearLevel = false;

    //Random stats
    private int NumOfRandomStats;
    //really ints but floats due the limit of ints for upgrade
    [HideInInspector] public float Damage;
    [HideInInspector] public float MultiAttackBonus;
    [HideInInspector] public float StaminaRegenBonus;
    
    // percentages    
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float MovementSpeedBonus;
    [HideInInspector] public float BlockChanceBonus;
    [HideInInspector] public float AbilityDamage;
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

    public void Awake()
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

        gearLevel();
        RartiyStats();
    }


    //needs changes to upgrade items with gold

    public void MaxUpgradeMode()
    {
        switch (ItemLevel)
        {
            case ItemRarity.Common:
                HeadGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    HPBonus += 20;
                    ArmourStats += 10;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 15;
                    CritChance += 0.01f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 10;
                    CooldownReduction += 0.01f;
                }
                break;
            case ItemRarity.Uncommon:
                HeadGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    HPBonus += 25;
                    ArmourStats += 10;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 20;
                    CritChance += 0.02f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 10;
                    CooldownReduction += 0.02f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Enchanted:
                HeadGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    HPBonus += 30;
                    ArmourStats += 15;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 25;
                    CritChance += 0.03f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 20;
                    CooldownReduction += 0.03f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Rare:
                HeadGoldNeeded = 12000;
                if (Class == "Bruiser")
                {
                    HPBonus = 35;
                    ArmourStats += 20;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 30;
                    CritChance += 0.04f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 25;
                    CooldownReduction += 0.04f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Mystical:
                HeadGoldNeeded = 12000;
                if (Class == "Bruiser")
                {
                    HPBonus += 40;
                    ArmourStats += 25;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 35;
                    CritChance += 0.05f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 30;
                    CooldownReduction += 0.05f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Legendary:
                HeadGoldNeeded = 16000;
                if (Class == "Bruiser")
                {
                    HPBonus += 45;
                    ArmourStats += 30;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 40;
                    CritChance += 0.06f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 35;
                    CooldownReduction += 0.06f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Ancient:
                HeadGoldNeeded = 16000;
                if (Class == "Bruiser")
                {
                    HPBonus += 50;
                    ArmourStats += 35;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 45;
                    CritChance += 0.07f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 40;
                    CooldownReduction += 0.07f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;
            case ItemRarity.Godly:
                HeadGoldNeeded += 20000;
                if (Class == "Bruiser")
                {
                    HPBonus += 55;
                    ArmourStats += 35;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 50;
                    CritChance += 0.08f;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 45;
                    CooldownReduction += 0.08f;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
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
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
                }
                if (AbilityDamage > 0.00)
                {
                    AbilityDamage += 3;
                }
                if (AOEchanceBonus > 0.00)
                {
                    AOEchanceBonus += 0.02f;
                }
                break;


        }
    }
    public void gearLevel()
    {
        switch (Headlevel)
        {
            case 0:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        HeadGoldNeeded = 4000;
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded = 8000;
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded = 12000;
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 16000;
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 20000;
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 24000;
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 28000;
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded = 32000;
                        break;
                }
                break;
            case 1:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus +=30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus +=30 ;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus +=25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus +=45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus +=55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus +=45 ;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                       
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
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
                        HeadGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            CritChance += 0.01f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.01f;
                        }
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Uncommon:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            ArmourStats += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            CritChance += 0.02f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            CooldownReduction += 0.02f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                       
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Enchanted:
                        HeadGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            ArmourStats += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            CritChance += 0.03f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            CooldownReduction += 0.03f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus +=0.02f;
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
                            DodgeBonus +=0.02f;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus +=0.02f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus += 0.02f;
                        }
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Rare:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus = 35;
                            ArmourStats += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            CritChance += 0.04f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            CooldownReduction += 0.04f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus +=0.02f;
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
                            DodgeBonus +=0.02f;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus +=0.02f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus += 0.02f;
                        }
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Mystical:
                        HeadGoldNeeded = 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            CritChance += 0.05f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            CooldownReduction += 0.05f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus +=0.02f;
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
                            DodgeBonus +=0.02f;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus +=0.02f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus += 0.02f;
                        }
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Legendary:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            CritChance += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            CooldownReduction += 0.06f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus +=0.02f;
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
                            DodgeBonus +=0.02f;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus +=0.02f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus += 0.02f;
                        }
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Ancient:
                        HeadGoldNeeded = 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            CritChance += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            CooldownReduction += 0.07f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus +=0.02f;
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
                            DodgeBonus +=0.02f;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus +=0.02f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if ( BlockChanceBonus > 0.00)
                        {
                             BlockChanceBonus += 0.02f;
                        }
                        HeadMaxGearLevel = true;
                        break;
                    case ItemRarity.Godly:
                        HeadGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 50;
                            CritChance += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 45;
                            CooldownReduction += 0.08f;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
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
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (AbilityDamage > 0.00)
                        {
                            AbilityDamage += 3;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                      
                        HeadMaxGearLevel = true;
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
                    //Needs stuff added

                    //Adds random stats
                    switch (Random.Range(0, 10))
                    {
                        case 0:
                            {
                                Damage = 3;
                                break;
                            }
                        case 1:
                            {
                                StunChanceBonus = 3;
                                break;
                            }
                        case 2:
                            {
                                DodgeBonus =0.02f;
                                break;
                            }
                        case 3:
                            {
                                CritDamageBonus = 3;
                                break;
                            }
                        case 4:
                            {
                                MovementSpeedBonus = 3;
                                break;
                            }
                        case 5:
                            {
                                MultiAttackBonus = 6;
                                break;
                            }
                        case 6:
                            {
                                 BlockChanceBonus =0.02f;
                                break;
                            }
                        case 7:
                            {
                                StaminaRegenBonus = 3;
                                break;
                            }
                        case 8:
                            {
                                AbilityDamage = 3;
                                break;
                            }
                        case 9:
                            {
                                AOEchanceBonus = 0.04f;
                                break;
                            }
                    }
                    break;
                }
            case ItemRarity.Enchanted:
                {
                    //Add stuff
                    NumOfRandomStats = Random.Range(1, 3);
                    for(int i = 0; i < NumOfRandomStats; i++)
                    {
                        //Adds random stats
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 6;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 6;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.04f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 6;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 6;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 6;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 6;
                                    break;
                                }
                            case 7:
                                {
                                    StaminaRegenBonus = 6;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.04f;
                                    break;
                                }
                            case 9:
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
                        //Adds random stats
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 9;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 9;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.06f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 9;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 9;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 9;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 9;
                                    break;
                                }
                            case 7:
                                {
                                    StaminaRegenBonus = 9;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.06f;
                                    break;
                                }
                            case 9:
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
                        //Adds random stats
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 12;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 12;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.08f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 12;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 12;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 12;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 12;
                                    break;
                                }
                            case 7:
                                {
                                    StaminaRegenBonus = 12;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.08f;
                                    break;
                                }
                            case 9:
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
                        //Adds random stats
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 14;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 14;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.10f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 14;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 14;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 14;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 14;
                                    break;
                                }
                            case 7:
                                {
                                    StaminaRegenBonus = 14;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.10f;
                                    break;
                                }
                            case 9:
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
                        //Adds random stats
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 16;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 16;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.12f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 16;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 16;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 16;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 16;
                                    break;
                                }
                            case 7:
                                {
                                    StaminaRegenBonus = 16;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.12f;
                                    break;
                                }
                            case 9:
                                {
                                    AOEchanceBonus = 0.12f;
                                    break;
                                }
                        }
                    }

                    //Add legendary trait
                    RandomLegendryTrait(LegendaryTrait);
                    break;
                }
            case ItemRarity.Godly:
                {
                    NumOfRandomStats = 6;
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        //Adds random stats
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 18;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 18;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.14f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 18;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 18;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 18;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 18;
                                    break;
                                }
                            case 7:
                                {
                                    StaminaRegenBonus = 18;
                                    break;
                                }
                            case 8:
                                {
                                    AbilityDamage = 0.14f;
                                    break;
                                }
                            case 9:
                                {
                                    AOEchanceBonus = 0.14f;
                                    break;
                                }
                        }
                    }

                    //Add legendary  trait
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
