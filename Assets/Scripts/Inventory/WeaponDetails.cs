using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponDetails : ScriptableObject
{

    [HideInInspector] public string Type = "Weapon";
    public string WeaponName;
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
    public ItemRarity Itemlevel;
    public int ID;
    public string Description = "";
    public Sprite icon;
    //Base stats
    public float Damage;
    public float BlockChanceBonus;
    public float MultiAttackBonus;
    public float AbilityDamage;
    public int Weaponlevel;
    public string Class;

    [HideInInspector] public int WeaponNeededGold;
    [HideInInspector] public bool WeaponMaxGearLevel = false;

    //Randomised stats
    private int NumOfRandomStats;
   
    [HideInInspector] public float HPBonus;
    [HideInInspector] public float MovementSpeedBonus;
    // percentages    
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float StaminaRegenBonus;
    [HideInInspector] public float CooldownReduction;
    [HideInInspector] public float AOEchanceBonus;
    [HideInInspector] public float CritChance;

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
            Itemlevel = (ItemRarity)Random.Range(0, 8);
        }
        else
        {
            switch (ItemLoadedRarity)
            {
                case "Common":
                    {
                        Itemlevel = ItemRarity.Common;
                        break;
                    }
                case "Uncommon":
                    {
                        Itemlevel = ItemRarity.Uncommon;
                        break;
                    }
                case "Enchanted":
                    {
                        Itemlevel = ItemRarity.Enchanted;
                        break;
                    }
                case "Rare":
                    {
                        Itemlevel = ItemRarity.Rare;
                        break;
                    }
                case "Mystical":
                    {
                        Itemlevel = ItemRarity.Mystical;
                        break;
                    }
                case "Legendary":
                    {
                        Itemlevel = ItemRarity.Legendary;
                        break;
                    }
                case "Ancient":
                    {
                        Itemlevel = ItemRarity.Ancient;
                        break;
                    }
                case "Godly":
                    {
                        Itemlevel = ItemRarity.Godly;
                        break;
                    }
            }
        }

        RartiyStats();
        gearlevel();
    }

    public void MaxUpgrade()
    {
        switch (Itemlevel)
        {
            case ItemRarity.Common:
                WeaponNeededGold += 4000;
                if (Class == "Bruiser")
                {
                    Damage += 15;
                    BlockChanceBonus += 0.01f;

                }
                if (Class == "Assassin")
                {
                    Damage += 10;
                    MultiAttackBonus += 5;
                }
                if (Class == "Cultist")
                {
                    Damage += 5;
                    AbilityDamage += 0.01f;
                }
                break;
            case ItemRarity.Uncommon:
                WeaponNeededGold += 4000;
                if (Class == "Bruiser")
                {
                    Damage += 20;
                    BlockChanceBonus += 0.02f;

                }
                if (Class == "Assassin")
                {
                    Damage += 15;
                    MultiAttackBonus += 10;
                }
                if (Class == "Cultist")
                {
                    Damage += 10;
                    AbilityDamage += 0.02f;
                }
                break;
            case ItemRarity.Enchanted:
                WeaponNeededGold += 8000;
                if (Class == "Bruiser")
                {
                    Damage += 25;
                    BlockChanceBonus += 0.03f;

                }
                if (Class == "Assassin")
                {
                    Damage += 20;
                    MultiAttackBonus += 15;
                }
                if (Class == "Cultist")
                {
                    Damage += 15;
                    AbilityDamage += 0.03f;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
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
                WeaponNeededGold += 8000;
                if (Class == "Bruiser")
                {
                    Damage += 30;
                    BlockChanceBonus += 0.04f;

                }
                if (Class == "Assassin")
                {
                    Damage += 25;
                    MultiAttackBonus += 20;
                }
                if (Class == "Cultist")
                {
                    Damage += 20;
                    AbilityDamage += 0.04f;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
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
                WeaponNeededGold += 12000;
                if (Class == "Bruiser")
                {
                    Damage += 35;
                    BlockChanceBonus += 0.05f;

                }
                if (Class == "Assassin")
                {
                    Damage += 30;
                    MultiAttackBonus += 25;
                }
                if (Class == "Cultist")
                {
                    Damage += 25;
                    AbilityDamage += 0.05f;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
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
                WeaponNeededGold += 16000;
                if (Class == "Bruiser")
                {
                    Damage += 40;
                    BlockChanceBonus += 0.06f;

                }
                if (Class == "Assassin")
                {
                    Damage += 35;
                    MultiAttackBonus += 30;
                }
                if (Class == "Cultist")
                {
                    Damage += 30;
                    AbilityDamage += 0.06f;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
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
                WeaponNeededGold += 16000;
                if (Class == "Bruiser")
                {
                    Damage += 45;
                    BlockChanceBonus += 0.07f;

                }
                if (Class == "Assassin")
                {
                    Damage += 40;
                    MultiAttackBonus += 35;
                }
                if (Class == "Cultist")
                {
                    Damage += 35;
                    AbilityDamage += 0.07f;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
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
                WeaponNeededGold += 20000;
                if (Class == "Bruiser")
                {
                    Damage += 50;
                    BlockChanceBonus += 0.08f;

                }
                if (Class == "Assassin")
                {
                    Damage += 45;
                    MultiAttackBonus += 40;
                }
                if (Class == "Cultist")
                {
                    Damage += 40;
                    AbilityDamage += 0.08f;
                }
                if (CritChance > 0.00)
                {
                    CritChance += 0.02f;
                }
                if (HPBonus > 0)
                {
                    HPBonus += 3;
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

    // needs to add level and amount gold needs to spend to upgrade items
    public void gearlevel()
    {
        switch (Weaponlevel)
        {

            case 0:
                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold = 4000;
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold = 8000;
                        break;
                    case ItemRarity.Enchanted:
                        WeaponNeededGold = 12000;
                        break;
                    case ItemRarity.Rare:
                        WeaponNeededGold = 16000;
                        break;
                    case ItemRarity.Mystical:
                        WeaponNeededGold = 20000;
                        break;
                    case ItemRarity.Legendary:
                        WeaponNeededGold = 24000;
                        break;
                    case ItemRarity.Ancient:
                        WeaponNeededGold = 28000;
                        break;
                    case ItemRarity.Godly:
                        WeaponNeededGold = 32000;
                        break;

                }
               
                break;
            case 1:

                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage +=15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
              
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage +=15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage +=20;
                            MultiAttackBonus +=15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage +=15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold +=8000;
                        if (Class == "Bruiser")
                        {
                            Damage +=30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage+=25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage +=20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage +=30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage +=30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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

                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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

                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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

                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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

                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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


                switch (Itemlevel)
                {
                    case ItemRarity.Common:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 15;
                            BlockChanceBonus += 0.01f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 10;
                            MultiAttackBonus += 5;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 5;
                            AbilityDamage += 0.01f;
                        }
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Uncommon:
                        WeaponNeededGold += 4000;
                        if (Class == "Bruiser")
                        {
                            Damage += 20;
                            BlockChanceBonus += 0.02f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 15;
                            MultiAttackBonus += 10;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 10;
                            AbilityDamage += 0.02f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Enchanted:
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 25;
                            BlockChanceBonus += 0.03f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 20;
                            MultiAttackBonus += 15;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 15;
                            AbilityDamage += 0.03f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Rare:
                        WeaponNeededGold += 8000;
                        if (Class == "Bruiser")
                        {
                            Damage += 30;
                            BlockChanceBonus += 0.04f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 25;
                            MultiAttackBonus += 20;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 20;
                            AbilityDamage += 0.04f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Mystical:
                        WeaponNeededGold += 12000;
                        if (Class == "Bruiser")
                        {
                            Damage += 35;
                            BlockChanceBonus += 0.05f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 30;
                            MultiAttackBonus += 25;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 25;
                            AbilityDamage += 0.05f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Legendary:
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 40;
                            BlockChanceBonus += 0.06f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 35;
                            MultiAttackBonus += 30;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 30;
                            AbilityDamage += 0.06f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Ancient:
                        WeaponNeededGold += 16000;
                        if (Class == "Bruiser")
                        {
                            Damage += 45;
                            BlockChanceBonus += 0.07f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 40;
                            MultiAttackBonus += 35;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 35;
                            AbilityDamage += 0.07f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                    case ItemRarity.Godly:
                        WeaponNeededGold += 20000;
                        if (Class == "Bruiser")
                        {
                            Damage += 50;
                            BlockChanceBonus += 0.08f;

                        }
                        if (Class == "Assassin")
                        {
                            Damage += 45;
                            MultiAttackBonus += 40;
                        }
                        if (Class == "Cultist")
                        {
                            Damage += 40;
                            AbilityDamage += 0.08f;
                        }
                        if (CritChance > 0.00)
                        {
                            CritChance += 0.02f;
                        }
                        if (HPBonus > 0)
                        {
                            HPBonus += 3;
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
                        WeaponMaxGearLevel = true;
                        break;
                }

                break;

        }
    }

    public void RartiyStats()
    {
        switch (Itemlevel)
        {
            case ItemRarity.Common:
                {
                    break;
                }
            case ItemRarity.Uncommon:
                {
                    //Needs stuff added
                    NumOfRandomStats = 1;

                    //Adds random stat
                    switch (Random.Range(0, 9))
                    {
                        case 0:
                            {
                                CritChance = 0.02f;
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
                                DodgeBonus = 3;
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
                }
                break;
            case ItemRarity.Enchanted:
                {
                    //Add stuff
                    NumOfRandomStats = Random.Range(1, 3);
                    //Loops for each random stat
                    for(int i = 0; i < NumOfRandomStats; i++)
                    {
                        //Adds random stat
                        switch (Random.Range(0,9))
                        {
                            case 0:
                                {
                                    CritChance = 0.04f;
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
                                    DodgeBonus = 6;
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
                                    StaminaRegenBonus = 6;
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
                }
                break;
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
                                    CritChance = 0.06f;
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
                                    DodgeBonus = 0.06f;
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
                                    CritChance = 0.08f;
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
                                    DodgeBonus = 0.08f;
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
                }
                break;
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
                                    CritChance = 0.10f;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 14;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 14;
                                    break;
                                }
                            case 3:
                                {
                                    DodgeBonus = 0.10f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 14;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 14;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 14;
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

                    //random legendary trait
                    RandomLegendryTrait(LegendaryTrait);
                }
                break;
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
                                    CritChance = 0.12f;
                                    break;
                                }
                            case 1:
                                {
                                    HPBonus = 16;
                                    break;
                                }
                            case 2:
                                {
                                    StunChanceBonus = 16;
                                    break;
                                }
                            case 3:
                                {
                                    DodgeBonus = 0.12f;
                                    break;
                                }
                            case 4:
                                {
                                    CritDamageBonus = 16;
                                    break;
                                }
                            case 5:
                                {
                                    MovementSpeedBonus = 16;
                                    break;
                                }
                            case 6:
                                {
                                    StaminaRegenBonus = 16;
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
                    //random legendary trait
                    RandomLegendryTrait(LegendaryTrait);
                }
                break;
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
                                    CritChance = 0.14f;
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
                                    DodgeBonus = 0.014f;
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
                                    StaminaRegenBonus = 18;
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
                    //2 random legendary traits
                    RandomLegendryTrait(LegendaryTrait);
                    RandomLegendryTrait(SecondLegendaryTrait);
                }
                break;    
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
