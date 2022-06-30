using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GlovesDetails : ScriptableObject
{
  [HideInInspector]public string Gloves = "Gloves";
    public string GloveNames;
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

    public float Damage;
    public float HPBonus;
    public float CritDamageBonus;
    public float AbilityDamage;
   [HideInInspector] public int Gloveslevel;
   [HideInInspector] public string Class;
   [HideInInspector] public float GlovesGoldNeeded;
   [HideInInspector] public bool GlovesMaxGearLevel = false;

    //Random stats
    private int NumOfRandomStats;
    // percentages 
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float MovementSpeedBonus;
    [HideInInspector] public float MultiAttackBonus;
    [HideInInspector] public float BlockChanceBonus;
    [HideInInspector] public float StaminaRegenBonus;
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

        GearLevel();
        RartiyStats();
    }

    public void MaxUpgradeMode()
    {
        switch (ItemLevel)
        {
            case ItemRarity.Common:
                GlovesGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    Damage += 15;
                    HPBonus += 10;
                }
                if (Class == "Assassin")
                {
                    Damage += 5;
                    CritDamageBonus += 4;
                }
                if (Class == "Cultist")
                {
                    Damage += 3;
                    AbilityDamage += 0.01f;
                }
                break;
            case ItemRarity.Uncommon:
                GlovesGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    Damage += 20;
                    HPBonus += 15;
                }
                if (Class == "Assassin")
                {
                    Damage += 10;
                    CritDamageBonus += 8;
                }
                if (Class == "Cultist")
                {
                    Damage += 6;
                    AbilityDamage += 0.02f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
                GlovesGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    Damage += 25;
                    HPBonus += 20;
                }
                if (Class == "Assassin")
                {
                    Damage += 15;
                    CritDamageBonus += 12;
                }
                if (Class == "Cultist")
                {
                    Damage += 9;
                    AbilityDamage += 0.03f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
                GlovesGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    Damage += 30;
                    HPBonus += 25;
                }
                if (Class == "Assassin")
                {
                    Damage += 20;
                    CritDamageBonus += 16;
                }
                if (Class == "Cultist")
                {
                    Damage += 12;
                    AbilityDamage += 0.04f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
                GlovesGoldNeeded += 12000;
                if (Class == "Bruiser")
                {
                    Damage += 35;
                    HPBonus += 30;
                }
                if (Class == "Assassin")
                {
                    Damage += 25;
                    CritDamageBonus += 20;
                }
                if (Class == "Cultist")
                {
                    Damage += 15;
                    AbilityDamage += 0.05f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
                GlovesGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    Damage += 40;
                    HPBonus += 35;
                }
                if (Class == "Assassin")
                {
                    Damage += 30;
                    CritDamageBonus += 24;
                }
                if (Class == "Cultist")
                {
                    Damage += 18;
                    AbilityDamage += 0.06f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
                GlovesGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    Damage += 45;
                    HPBonus += 40;
                }
                if (Class == "Assassin")
                {
                    Damage += 35;
                    CritDamageBonus += 28;
                }
                if (Class == "Cultist")
                {
                    Damage += 21;
                    AbilityDamage += 0.07f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
                GlovesGoldNeeded += 20000;
                if (Class == "Bruiser")
                {
                    Damage += 50;
                    HPBonus += 45;
                }
                if (Class == "Assassin")
                {
                    Damage += 40;
                    CritDamageBonus += 32;
                }
                if (Class == "Cultist")
                {
                    Damage += 24;
                    AbilityDamage += 0.08f;
                }
                if (StunChanceBonus > 0)
                {
                    StunChanceBonus += 3;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (MovementSpeedBonus > 0)
                {
                    MovementSpeedBonus += 3;
                }
                if (MultiAttackBonus > 0.00)
                {
                    MultiAttackBonus += 0.03f;
                }
                if (BlockChanceBonus > 0.00)
                {
                    BlockChanceBonus += 0.03f;
                }
                if (StaminaRegenBonus > 0)
                {
                    StaminaRegenBonus += 3;
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
        switch (Gloveslevel)
        {
            case 0:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        GlovesGoldNeeded = 4000;
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded = 8000;
                        break;
                    case ItemRarity.Enchanted:
                        GlovesGoldNeeded = 12000;
                        break;
                    case ItemRarity.Rare:
                        GlovesGoldNeeded = 16000;
                        break;
                    case ItemRarity.Mystical:
                        GlovesGoldNeeded = 20000;
                        break;
                    case ItemRarity.Legendary:
                        GlovesGoldNeeded = 24000;
                        break;
                    case ItemRarity.Ancient:
                        GlovesGoldNeeded = 28000;
                        break;
                    case ItemRarity.Godly:
                        GlovesGoldNeeded = 32000;
                        break;
                }
                break;
            case 1:
            
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }

                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
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
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            HPBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 5;
                            CritDamageBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 3;
                            AbilityDamage += 0.01f;
                        }
                        GlovesMaxGearLevel = true;
                        break;
                    case ItemRarity.Uncommon:
                        GlovesGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            HPBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            CritDamageBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 6;
                            AbilityDamage += 0.02f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
                        break;
                    case ItemRarity.Enchanted:
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            HPBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            CritDamageBonus += 12;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 9;
                            AbilityDamage += 0.03f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
                        break;
                    case ItemRarity.Rare:
                        GlovesGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            HPBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            CritDamageBonus += 16;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 12;
                            AbilityDamage += 0.04f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
                        break;
                    case ItemRarity.Mystical:
                        GlovesGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            HPBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            CritDamageBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.05f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
                        break;
                    case ItemRarity.Legendary:
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            HPBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            CritDamageBonus += 24;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 18;
                            AbilityDamage += 0.06f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
                        break;
                    case ItemRarity.Ancient:
                        GlovesGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            HPBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            CritDamageBonus += 28;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 21;
                            AbilityDamage += 0.07f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
                        break;

                    case ItemRarity.Godly:
                        GlovesGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            HPBonus += 45;
                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            CritDamageBonus += 32;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 24;
                            AbilityDamage += 0.08f;
                        }
                        if (StunChanceBonus > 0)
                        {
                            StunChanceBonus += 3;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (MovementSpeedBonus > 0)
                        {
                            MovementSpeedBonus += 3;
                        }
                        if (MultiAttackBonus > 0.00)
                        {
                            MultiAttackBonus += 0.03f;
                        }
                        if (BlockChanceBonus > 0.00)
                        {
                            BlockChanceBonus += 0.03f;
                        }
                        if (StaminaRegenBonus > 0)
                        {
                            StaminaRegenBonus += 3;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        if (AOEchanceBonus > 0.00)
                        {
                            AOEchanceBonus += 0.02f;
                        }
                        GlovesMaxGearLevel = true;
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
                    //Adds random stat
                    switch (Random.Range(0, 9))
                    {
                        case 0:
                            {
                                StunChanceBonus = 3;
                                break;
                            }
                        case 1:
                            {
                                CritChance = 0.02f;
                                break;
                            }
                        case 2:
                            {
                                DodgeBonus = 0.02f;
                                break;
                            }
                        case 3:
                            {
                                MovementSpeedBonus = 3;
                                break;
                            }
                        case 4:
                            {
                                MultiAttackBonus = 0.02f;
                                break;
                            }
                        case 5:
                            {
                                BlockChanceBonus = 0.02f;
                                break;
                            }
                        case 6:
                            {
                                StaminaRegenBonus = 3;
                                break;
                            }
                        case 7:
                            {
                                CooldownReduction = 0.02f;
                                break;
                            }
                        case 8:
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
                    for (int i = 0; i < NumOfRandomStats; i++)
                    {
                        //Adds random stat
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                {
                                    StunChanceBonus = 6;
                                    break;
                                }
                            case 1:
                                {
                                    CritChance = 0.4f;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.04f;
                                    break;
                                }
                            case 3:
                                {
                                    MovementSpeedBonus = 6;
                                    break;
                                }
                            case 4:
                                {
                                    MultiAttackBonus = 0.04f;
                                    break;
                                }
                            case 5:
                                {
                                    BlockChanceBonus = 0.04f;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus += 6;
                                    break;
                                }
                            case 7:
                                {
                                    CooldownReduction = 0.04f;
                                    break;
                                }
                            case 8:
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
                        //Adds random stat
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                {
                                    StunChanceBonus = 9;
                                    break;
                                }
                            case 1:
                                {
                                    CritChance = 0.06f;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.06f;
                                    break;
                                }
                            case 3:
                                {
                                    MovementSpeedBonus = 9;
                                    break;
                                }
                            case 4:
                                {
                                    MultiAttackBonus = 0.06f;
                                    break;
                                }
                            case 5:
                                {
                                    BlockChanceBonus = 0.06f;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 9;
                                    break;
                                }
                            case 7:
                                {
                                    CooldownReduction = 0.06f;
                                    break;
                                }
                            case 8:
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
                        //Adds random stat
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                {
                                    StunChanceBonus = 12;
                                    break;
                                }
                            case 1:
                                {
                                    CritChance = 0.08f;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.08f;
                                    break;
                                }
                            case 3:
                                {
                                    MovementSpeedBonus = 12;
                                    break;
                                }
                            case 4:
                                {
                                    MultiAttackBonus = 0.08f;
                                    break;
                                }
                            case 5:
                                {
                                    BlockChanceBonus = 0.08f;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 12;
                                    break;
                                }
                            case 7:
                                {
                                    CooldownReduction = 0.08f;
                                    break;
                                }
                            case 8:
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
                        //Adds random stat
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                {
                                    StunChanceBonus = 15;
                                    break;
                                }
                            case 1:
                                {
                                    CritChance = 0.10f;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.10f;
                                    break;
                                }
                            case 3:
                                {
                                    MovementSpeedBonus = 15;
                                    break;
                                }
                            case 4:
                                {
                                    MultiAttackBonus = 0.10f;
                                    break;
                                }
                            case 5:
                                {
                                    BlockChanceBonus = 0.10f;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 15;
                                    break;
                                }
                            case 7:
                                {
                                    CooldownReduction = 0.10f;
                                    break;
                                }
                            case 8:
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
                        //Adds random stat
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                {
                                    StunChanceBonus = 18;
                                    break;
                                }
                            case 1:
                                {
                                    CritChance = 0.12f;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.12f;
                                    break;
                                }
                            case 3:
                                {
                                    MovementSpeedBonus = 18;
                                    break;
                                }
                            case 4:
                                {
                                    MultiAttackBonus = 0.12f;
                                    break;
                                }
                            case 5:
                                {
                                    BlockChanceBonus = 0.12f;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 18;
                                    break;
                                }
                            case 7:
                                {
                                    CooldownReduction = 0.12f;
                                    break;
                                }
                            case 8:
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
                        //Adds random stat
                        switch (Random.Range(0, 9))
                        {
                            case 0:
                                {
                                    StunChanceBonus = 21;
                                    break;
                                }
                            case 1:
                                {
                                    CritChance = 0.14f;
                                    break;
                                }
                            case 2:
                                {
                                    DodgeBonus = 0.14f;
                                    break;
                                }
                            case 3:
                                {
                                    MovementSpeedBonus = 21;
                                    break;
                                }
                            case 4:
                                {
                                    MultiAttackBonus = 0.14f;
                                    break;
                                }
                            case 5:
                                {
                                    BlockChanceBonus = 0.14f;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 21;
                                    break;
                                }
                            case 7:
                                {
                                    CooldownReduction = 0.14f;
                                    break;
                                }
                            case 8:
                                {
                                    AOEchanceBonus = 0.14f;
                                    break;
                                }
                        }
                    }
                    //Add 2 legendary traits
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
