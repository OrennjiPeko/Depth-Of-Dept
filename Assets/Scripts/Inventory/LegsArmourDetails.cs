using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LegsArmourDetails : ScriptableObject
{
   [HideInInspector] public string LegsArmour = "LegsArmour";
    public string LegsName;
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

    public float HPBonus;
    public float DodgeBonus;
    public float StaminaRegenBonus;
    public float ArmourStats;
  [HideInInspector]public int Legslevel;

  [HideInInspector]public string Class;
  [HideInInspector] public float LegsGoldNeeded;
  [HideInInspector] public bool LegsMaxGearLevel=false;

    //Random stats
    private int NumOfRandomStats;
    [HideInInspector] public float Damage;
    [HideInInspector] public float MovementSpeedBonus;
    // percentages 
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float MultiAttackBonus;
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

    public void MaxxUpgradeMode()
    {

        switch (ItemLevel)
        {
            case ItemRarity.Common:
                LegsGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    HPBonus += 15;
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
                    StaminaRegenBonus += 4;
                }
                break;
            case ItemRarity.Uncommon:
                LegsGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    HPBonus += 20;
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
                    StaminaRegenBonus += 8;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
            case ItemRarity.Enchanted:
                LegsGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    HPBonus += 25;
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
                    StaminaRegenBonus += 12;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
            case ItemRarity.Rare:
                LegsGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    HPBonus += 30;
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
                    StaminaRegenBonus += 16;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
            case ItemRarity.Mystical:
                LegsGoldNeeded += 12000;
                if (Class == "Bruiser")
                {
                    HPBonus += 35;
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
                    StaminaRegenBonus += 20;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
            case ItemRarity.Legendary:
                LegsGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    HPBonus += 40;
                    ArmourStats += 35;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 30;
                    DodgeBonus += 0.06f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 18;
                    StaminaRegenBonus += 24;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
            case ItemRarity.Ancient:
                LegsGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    HPBonus += 45;
                    ArmourStats += 40;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 35;
                    DodgeBonus += 0.07f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 22;
                    StaminaRegenBonus += 28;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
            case ItemRarity.Godly:
                LegsGoldNeeded += 20000;
                if (Class == "Bruiser")
                {
                    HPBonus += 50;
                    ArmourStats += 45;
                }
                if (Class == "Assassin")
                {
                    ArmourStats += 40;
                    DodgeBonus += 0.08f;
                }
                if (Class == "Cultist")
                {
                    ArmourStats += 26;
                    StaminaRegenBonus += 32;
                }
                if (Damage > 0)
                {
                    Damage += 3;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02F;
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
                break;
        }

      
    }

   public void GearLevel()
    {
        switch (Legslevel)
        {
            case 0:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded = 4000;
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded = 8000;
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded = 12000;
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded = 16000;
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded = 20000;
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded = 24000;
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded = 28000;
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded = 32000;
                        break;
                }
                break;
            case 1:
       
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus +=12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats +=35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 2:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 3:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 4:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 5:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 6:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 7:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 8:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 9:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;
            case 10:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        break;
                }

                break;

            case 11:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 15;
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
                            StaminaRegenBonus += 4;
                        }
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Uncommon:
                        LegsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
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
                            StaminaRegenBonus += 8;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Enchanted:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
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
                            StaminaRegenBonus += 12;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Rare:
                        LegsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
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
                            StaminaRegenBonus += 16;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Mystical:
                        LegsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
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
                            StaminaRegenBonus += 20;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Legendary:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            ArmourStats += 35;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 30;
                            DodgeBonus += 0.06f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 18;
                            StaminaRegenBonus += 24;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Ancient:
                        LegsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            ArmourStats += 40;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 35;
                            DodgeBonus += 0.07f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 22;
                            StaminaRegenBonus += 28;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
                        break;
                    case ItemRarity.Godly:
                        LegsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            ArmourStats += 45;
                        }
                        if (Class == "Assassin")
                        {
                            ArmourStats += 40;
                            DodgeBonus += 0.08f;
                        }
                        if (Class == "Cultist")
                        {
                            ArmourStats += 26;
                            StaminaRegenBonus += 32;
                        }
                        if (Damage > 0)
                        {
                            Damage += 3;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02F;
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
                        LegsMaxGearLevel = true;
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
                                CritChance = 0.02f;
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
                                MultiAttackBonus = 0.02f;
                                break;
                            }
                        case 6:
                            {
                                BlockChanceBonus = 0.02f;
                                break;
                            }
                        case 7:
                            {
                                AbilityDamage = 0.02f;
                                break;
                            }
                        case 8:
                            {
                                CooldownReduction = 0.02f;
                                break;
                            }
                        case 9:
                            {
                                AOEchanceBonus = 0.02f;
                                break;
                            }
                    }
      
                    break;
                }
            case ItemRarity.Enchanted:
                {
                    //Add stuff
                    NumOfRandomStats = Random.Range(1, 3);
                    for(int i = 0; i< NumOfRandomStats; i++)
                    {
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
                                    CritChance = 0.04f;
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
                                    MultiAttackBonus = 0.04f;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 0.04f;
                                    break;
                                }
                            case 7:
                                {
                                    AbilityDamage = 0.04f;
                                    break;
                                }
                            case 8:
                                {
                                    CooldownReduction = 0.04f;
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
                                    CritChance = 0.06f;
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
                                    MultiAttackBonus = 0.06f;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 0.06f;
                                    break;
                                }
                            case 7:
                                {
                                    AbilityDamage = 0.06f;
                                    break;
                                }
                            case 8:
                                {
                                    CooldownReduction = 0.06f;
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
                                    CritChance = 0.08f;
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
                                    MultiAttackBonus = 0.08f;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 0.08f;
                                    break;
                                }
                            case 7:
                                {
                                    AbilityDamage = 0.08f;
                                    break;
                                }
                            case 8:
                                {
                                    CooldownReduction = 0.08f;
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
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 16;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 15;
                                    break;
                                }
                            case 2:
                                {
                                    CritChance = 0.10f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 15;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 15;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 0.10f;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 0.10f;
                                    break;
                                }
                            case 7:
                                {
                                    AbilityDamage = 0.10f;
                                    break;
                                }
                            case 8:
                                {
                                    CooldownReduction = 0.10f;
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
                                    CritChance = 0.12f;
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
                                    MultiAttackBonus = 0.12f;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 0.12f;
                                    break;
                                }
                            case 7:
                                {
                                    AbilityDamage = 0.12f;
                                    break;
                                }
                            case 8:
                                {
                                    CooldownReduction = 0.12f;
                                    break;
                                }
                            case 9:
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
                        switch (Random.Range(0, 10))
                        {
                            case 0:
                                {
                                    Damage = 21;
                                    break;
                                }
                            case 1:
                                {
                                    StunChanceBonus = 21;
                                    break;
                                }
                            case 2:
                                {
                                    CritChance += 0.14f;
                                    break;
                                }
                            case 3:
                                {
                                    CritDamageBonus = 21;
                                    break;
                                }
                            case 4:
                                {
                                    MovementSpeedBonus = 21;
                                    break;
                                }
                            case 5:
                                {
                                    MultiAttackBonus = 0.14f;
                                    break;
                                }
                            case 6:
                                {
                                    BlockChanceBonus = 0.14f;
                                    break;
                                }
                            case 7:
                                {
                                    AbilityDamage = 0.14f;
                                    break;
                                }
                            case 8:
                                {
                                    CooldownReduction = 0.14f;
                                    break;
                                }
                            case 9:
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
