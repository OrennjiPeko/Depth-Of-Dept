using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BootsDetails : ScriptableObject
{
   [HideInInspector] public string BootsArmour = "BootsArmour";
    public string BootsName;
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
    public float StunBonus;
    public float MovementspeedBonus;
    public float AOEchanceBonus;
   [HideInInspector] public int Bootslevel;
   [HideInInspector] public string Class;
   [HideInInspector] public float BootsGoldNeeded;
    [HideInInspector] public bool BootsMaxGearLevel = false;

    //Random Stats
    private int NumOfRandomStats;
    [HideInInspector] public float Damage;
    // percentages 
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float MultiAttackBonus;
    [HideInInspector] public float BlockChanceBonus;
    [HideInInspector] public float StaminaRegenBonus;
    [HideInInspector] public float AbilityDamage;
    [HideInInspector] public float CooldownReduction;

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

        Gearlevel();
        RartiyStats();
    }

    public void MaxUpgradeMode()
    {
        switch (ItemLevel)
        {
            case ItemRarity.Common:
                BootsGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    HPBonus += 20;
                    StunBonus += 5;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 10;
                    MovementspeedBonus += 1;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 5;
                    AOEchanceBonus += 0.01f;
                }
                break;
            case ItemRarity.Uncommon:
                BootsGoldNeeded += 4000;
                if (Class == "Bruiser")
                {
                    HPBonus += 25;
                    StunBonus += 10;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 15;
                    MovementspeedBonus += 2;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 10;
                    AOEchanceBonus += 0.02f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
            case ItemRarity.Enchanted:
                BootsGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    HPBonus += 30;
                    StunBonus += 15;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 20;
                    MovementspeedBonus += 3;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 15;
                    AOEchanceBonus += 0.03f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
            case ItemRarity.Rare:
                BootsGoldNeeded += 8000;
                if (Class == "Bruiser")
                {
                    HPBonus += 35;
                    StunBonus += 20;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 25;
                    MovementspeedBonus += 4;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 20;
                    AOEchanceBonus += 0.04f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
            case ItemRarity.Mystical:
                BootsGoldNeeded += 12000;
                if (Class == "Bruiser")
                {
                    HPBonus += 40;
                    StunBonus += 25;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 30;
                    MovementspeedBonus += 5;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 25;
                    AOEchanceBonus += 0.05f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
            case ItemRarity.Legendary:
                BootsGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    HPBonus += 45;
                    StunBonus += 30;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 35;
                    MovementspeedBonus += 6;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 30;
                    AOEchanceBonus += 0.06f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
            case ItemRarity.Ancient:
                BootsGoldNeeded += 16000;
                if (Class == "Bruiser")
                {
                    HPBonus += 50;
                    StunBonus += 35;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 40;
                    MovementspeedBonus += 7;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 35;
                    AOEchanceBonus += 0.07f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
            case ItemRarity.Godly:
                BootsGoldNeeded += 20000;
                if (Class == "Bruiser")
                {
                    HPBonus += 55;
                    StunBonus += 40;
                }
                if (Class == "Assassin")
                {
                    HPBonus += 45;
                    MovementspeedBonus += 8;
                }
                if (Class == "Cultist")
                {
                    HPBonus += 40;
                    AOEchanceBonus += 0.08f;
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
                    CritChance += 0.02f;
                }
                if (DodgeBonus > 0.00)
                {
                    DodgeBonus += 0.02f;
                }
                if (CritDamageBonus > 0)
                {
                    CritDamageBonus += 3;
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
                    AbilityDamage += 0.02f;
                }
                if (CooldownReduction > 0.00)
                {
                    CooldownReduction += 0.02f;
                }
                break;
        }
    }
    public void Gearlevel()
    {
        switch (Bootslevel)
        {
            case 0:
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        BootsGoldNeeded = 4000;
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded = 8000;
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded = 12000;
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded = 16000;
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded = 20000;
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded = 24000;
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded = 28000;
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded = 32000;
                        break;
                }
                break;
            case 1:
             
            
                switch (ItemLevel)
                {
                    case ItemRarity.Common:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 20;
                            StunBonus += 5;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 10;
                            MovementspeedBonus += 1;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 5;
                            AOEchanceBonus += 0.01f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Uncommon:
                        BootsGoldNeeded += 4000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 25;
                            StunBonus += 10;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 15;
                            MovementspeedBonus += 2;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 10;
                            AOEchanceBonus += 0.02f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Enchanted:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 30;
                            StunBonus += 15;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 20;
                            MovementspeedBonus += 3;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 15;
                            AOEchanceBonus += 0.03f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Rare:
                        BootsGoldNeeded += 8000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 35;
                            StunBonus += 20;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 25;
                            MovementspeedBonus += 4;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 20;
                            AOEchanceBonus += 0.04f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Mystical:
                        BootsGoldNeeded += 12000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 40;
                            StunBonus += 25;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 30;
                            MovementspeedBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 25;
                            AOEchanceBonus += 0.05f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Legendary:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 45;
                            StunBonus += 30;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 35;
                            MovementspeedBonus += 6;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 30;
                            AOEchanceBonus += 0.06f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Ancient:
                        BootsGoldNeeded += 16000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 50;
                            StunBonus += 35;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 40;
                            MovementspeedBonus += 7;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 35;
                            AOEchanceBonus += 0.07f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
                        break;
                    case ItemRarity.Godly:
                        BootsGoldNeeded += 20000;
                        if (Class == "Bruiser")
                        {
                            HPBonus += 55;
                            StunBonus += 40;
                        }
                        if (Class == "Assassin")
                        {
                            HPBonus += 45;
                            MovementspeedBonus += 8;
                        }
                        if (Class == "Cultist")
                        {
                            HPBonus += 40;
                            AOEchanceBonus += 0.08f;
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
                            CritChance += 0.02f;
                        }
                        if (DodgeBonus > 0.00)
                        {
                            DodgeBonus += 0.02f;
                        }
                        if (CritDamageBonus > 0)
                        {
                            CritDamageBonus += 3;
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
                            AbilityDamage += 0.02f;
                        }
                        if (CooldownReduction > 0.00)
                        {
                            CooldownReduction += 0.02f;
                        }
                        BootsMaxGearLevel = true;
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
                    switch(Random.Range(0,11))
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
                        case 3:
                            {
                                CritChance = 0.02f;
                                break;
                            }
                        case 4:
                            {
                                DodgeBonus += 0.02f;
                                break;
                            }
                        case 5:
                            {
                                CritDamageBonus = 3;
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
                                StaminaRegenBonus = 3;
                                break;
                            }
                        case 9:
                            {
                                AbilityDamage = 0.02f;
                                break;
                            }
                        case 10:
                            {
                                CooldownReduction = 0.02f;
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
                        switch (Random.Range(0, 11))
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
                            case 3:
                                {
                                    CritChance = 0.04f;
                                    break;
                                }
                            case 4:
                                {
                                    DodgeBonus = 0.04f;
                                    break;
                                }
                            case 5:
                                {
                                    CritDamageBonus = 6;
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
                                    StaminaRegenBonus = 6;
                                    break;
                                }
                            case 9:
                                {
                                    AbilityDamage = 0.04f;
                                    break;
                                }
                            case 10:
                                {
                                    CooldownReduction = 0.04f;
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
                                    DodgeBonus = 0.06f;
                                    break;
                                }
                            case 5:
                                {
                                    CritDamageBonus = 9;
                                    break;
                                }
                            case 6:
                                {
                                    MultiAttackBonus = 0.06f;
                                    break;
                                }
                            case 7:
                                {
                                    BlockChanceBonus += 0.06f;
                                    break;
                                }
                            case 8:
                                {
                                    StaminaRegenBonus = 9;
                                    break;
                                }
                            case 9:
                                {
                                    AbilityDamage = 0.06f;
                                    break;
                                }
                            case 10:
                                {
                                    CooldownReduction = 0.06f;
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
                                    DodgeBonus = 0.08f;
                                    break;
                                }
                            case 5:
                                {
                                    CritDamageBonus = 12;
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
                                    StaminaRegenBonus = 12;
                                    break;
                                }
                            case 9:
                                {
                                    AbilityDamage = 0.08f;
                                    break;
                                }
                            case 10:
                                {
                                    CooldownReduction = 0.08f;
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
                                    DodgeBonus = 0.10f;
                                    break;
                                }
                            case 5:
                                {
                                    CritDamageBonus = 15;
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
                                    StaminaRegenBonus = 15;
                                    break;
                                }
                            case 9:
                                {
                                    AbilityDamage = 0.10f;
                                    break;
                                }
                            case 10:
                                {
                                    CooldownReduction = 0.10f;
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
                                    DodgeBonus = 0.12f;
                                    break;
                                }
                            case 5:
                                {
                                    CritDamageBonus = 18;
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
                                    StaminaRegenBonus = 18;
                                    break;
                                }
                            case 9:
                                {
                                    AbilityDamage = 0.12f;
                                    break;
                                }
                            case 10:
                                {
                                    CooldownReduction = 0.12f;
                                    break;
                                }
                        }
                    }

                    //Random legendary trait
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
                                    DodgeBonus = 0.14f;
                                    break;
                                }
                            case 5:
                                {
                                    CritDamageBonus = 21;
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
                                    StaminaRegenBonus = 21;
                                    break;
                                }
                            case 9:
                                {
                                    AbilityDamage = 0.14f;
                                    break;
                                }
                            case 10:
                                {
                                    CooldownReduction = 0.14f;
                                    break;
                                }
                        }
                    }

                    //2 Random legendary traits
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
