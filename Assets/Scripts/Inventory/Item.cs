using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;


public class Item : MonoBehaviour,Itemtip
{
   [HideInInspector] public int ID;
   

    //Stores the different item types
   

    //Store item information
   [HideInInspector] public string type;
   [HideInInspector] public string Class;
   [HideInInspector] public string Itemrarity;

    public string description;
    public Sprite icon;
    public bool PickedUp;
    public WeaponDetails data;
    public HeadPieceDetials HeadData;
    public GlovesDetails GloveData;
    public ChestArmourDetails ChestData;
    public LegsArmourDetails LegData;
    public BootsDetails BootsData;

    [HideInInspector]
    public bool Equipped;
    
    //Used to gain access to where equipped items are stored on the player
    [HideInInspector] public GameObject Weapon;
    [HideInInspector] public GameObject HeadArmour;
    [HideInInspector] public GameObject ChestArmour;
    [HideInInspector] public GameObject Gloves;
    [HideInInspector] public GameObject LegsArmour;
    [HideInInspector] public GameObject BootsArmour;
    
    public bool PlayerWeapon;
    public Image ToolTip;
    public Text ToolTipText;
    
    //Stores the item manager
    public GameObject WeaponManager;

    //Item stats
    [HideInInspector] public float Damage;
    [HideInInspector] public float HPBonus;
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float MovementSpeedBonus;
    [HideInInspector] public float MultiAttackBonus;
    [HideInInspector] public float BlockChanceBonus;
    [HideInInspector] public float StaminaRegenBonus;
    [HideInInspector] public float AbilityDamage;
    [HideInInspector] public float CooldownReduction;
    [HideInInspector] public float AOEchanceBonus;
    [HideInInspector] public float Gold;
    [HideInInspector] public string ItemName;
    [SerializeField] public string Title;
    [HideInInspector] public float GoldNeeded;
    [HideInInspector] public float ArmourStats;

    [HideInInspector] public string LegendaryTrait;
    [HideInInspector] public string SecondLegendaryTrait;


    public string MainDescription;
    public int Rank;

    [HideInInspector] public bool FromSaveFile = false;

    public void Start()
    {

        //Sets the stats of the item using the scripitable object that stores the info
        if (data != null)
        {
            if (FromSaveFile)
            {
                data.ItemLoadedRarity = Itemrarity;
            }

            data.SetRarity(FromSaveFile);

            ID = data.ID;
            ItemName = data.WeaponName;
            description = data.Description;
            icon = data.icon;
            Damage = data.Damage;
            BlockChanceBonus = data.BlockChanceBonus;
            MultiAttackBonus = data.MultiAttackBonus;
            AbilityDamage = data.AbilityDamage;
            CritChance = data.CritChance;
            HPBonus = data.HPBonus;
            // percentages 
            StunChanceBonus = data.StunChanceBonus;
            DodgeBonus = data.DodgeBonus;
            CritDamageBonus = data.CritDamageBonus;
            MovementSpeedBonus = data.MovementSpeedBonus;
            StaminaRegenBonus = data.StaminaRegenBonus;
            CooldownReduction = data.CooldownReduction;
            AOEchanceBonus = data.AOEchanceBonus;
            
            type = data.Type;
            Class = data.ArmourClass.ToString();
            Itemrarity = data.Itemlevel.ToString();
            Rank = data.Weaponlevel;

            LegendaryTrait = data.LegendaryTrait;
            SecondLegendaryTrait = data.SecondLegendaryTrait;
            
            GoldNeeded = data.WeaponNeededGold;
        }

        if(HeadData != null)
        {
            if (FromSaveFile)
            {
                HeadData.ItemLoadedRarity = Itemrarity;
            }

            HeadData.SetRarity(FromSaveFile);

            ID = HeadData.ID;
            ItemName = HeadData.HeadName;
            description = HeadData.Description;
            icon = HeadData.icon;
            HPBonus = HeadData.HPBonus;
            CritChance = HeadData.CritChance;
            CooldownReduction = HeadData.CooldownReduction;
            type = HeadData.HeadArmour;
            Class = HeadData.ArmourClass.ToString();
            Itemrarity = HeadData.ItemLevel.ToString();
            Rank = HeadData.Headlevel;
            ArmourStats = HeadData.ArmourStats;
            Damage = HeadData.Damage;
            StunChanceBonus = HeadData.StunChanceBonus;
            // percentages 
            DodgeBonus = HeadData.DodgeBonus;
            CritDamageBonus = HeadData.CritDamageBonus;
            MovementSpeedBonus = HeadData.MovementSpeedBonus;
            MultiAttackBonus = HeadData.MultiAttackBonus;
            BlockChanceBonus = HeadData.BlockChanceBonus;
            StaminaRegenBonus = HeadData.StaminaRegenBonus;
            AbilityDamage = HeadData.AbilityDamage;
            AOEchanceBonus = HeadData.AOEchanceBonus;

            LegendaryTrait = HeadData.LegendaryTrait;
            SecondLegendaryTrait = HeadData.SecondLegendaryTrait;

            GoldNeeded = HeadData.HeadGoldNeeded;

        }
        if (GloveData != null)
        {
            if (FromSaveFile)
            {
                GloveData.ItemLoadedRarity = Itemrarity;
            }

            GloveData.SetRarity(FromSaveFile);

            ID = GloveData.ID;
            ItemName = GloveData.GloveNames;
            description = GloveData.Description;
            icon = GloveData.icon;
            Damage = GloveData.Damage;
            HPBonus = GloveData.HPBonus;
            CritDamageBonus = GloveData.CritDamageBonus;
            AbilityDamage = GloveData.AbilityDamage;
            type = GloveData.Gloves;
            Class = GloveData.ArmourClass.ToString();
            Itemrarity = GloveData.ItemLevel.ToString();
            Rank = GloveData.Gloveslevel;
            // percentages 
            StunChanceBonus = GloveData.StunChanceBonus;
            CritChance = GloveData.CritChance;
            DodgeBonus = GloveData.DodgeBonus;
            MovementSpeedBonus = GloveData.MovementSpeedBonus;
            MultiAttackBonus = GloveData.MultiAttackBonus;
            BlockChanceBonus = GloveData.BlockChanceBonus;
            StaminaRegenBonus = GloveData.StaminaRegenBonus;
            CooldownReduction = GloveData.CooldownReduction;
            AOEchanceBonus = GloveData.AOEchanceBonus;

            LegendaryTrait = GloveData.LegendaryTrait;
            SecondLegendaryTrait = GloveData.SecondLegendaryTrait;
            
            GoldNeeded = GloveData.GlovesGoldNeeded;

    

        }
        if (ChestData !=null)
        {
            if (FromSaveFile)
            {
                ChestData.ItemLoadedRarity = Itemrarity;
            }

            ChestData.SetRarity(FromSaveFile);

            ID = ChestData.ID;
            ItemName = ChestData.ChestName;
            description = ChestData.Description;
            icon = ChestData.icon;
           
            DodgeBonus = ChestData.DodgeBonus;
            StaminaRegenBonus = ChestData.StaminaRegenBonus;
            type = ChestData.ChestArmour;
            Class = ChestData.ArmourClass.ToString();
            Itemrarity = ChestData.ItemLevel.ToString();
            Rank = ChestData.ChestLevel;
            ArmourStats = ChestData.ArmourStats;
            Damage = ChestData.Damage;
            HPBonus = ChestData.HPBonus;
            // percentages 
            StunChanceBonus = ChestData.StunChanceBonus;
            CritChance = ChestData.CritChance;
            CritDamageBonus = ChestData.CritDamageBonus;
            MovementSpeedBonus = ChestData.MovementSpeedBonus;
            MultiAttackBonus = ChestData.MultiAttackBonus;
            BlockChanceBonus = ChestData.BlockChanceBonus;
            AbilityDamage = ChestData.AbilityDamage;
            CooldownReduction = ChestData.CooldownReduction;
            AOEchanceBonus = ChestData.AOEchanceBonus;

            LegendaryTrait = ChestData.LegendaryTrait;
            SecondLegendaryTrait = ChestData.SecondLegendaryTrait;
            
            GoldNeeded = ChestData.ChestGoldNeeded;  
        }
        if (LegData != null)
        {
            if (FromSaveFile)
            {
                LegData.ItemLoadedRarity = Itemrarity;
            }

            LegData.SetRarity(FromSaveFile);

            ID = LegData.ID;
            ItemName = LegData.LegsName;
            description = LegData.Description;
            icon = LegData.icon;
            HPBonus = LegData.HPBonus;
            DodgeBonus = LegData.DodgeBonus;
            StaminaRegenBonus = LegData.StaminaRegenBonus;
            type = LegData.LegsArmour;
            Class = LegData.ArmourClass.ToString();
            Itemrarity = LegData.ItemLevel.ToString();
            Rank = LegData.Legslevel;
            ArmourStats = LegData.ArmourStats;
            Damage = LegData.Damage;
            StunChanceBonus = LegData.StunChanceBonus;
            CritChance = LegData.CritChance;
            CritDamageBonus = LegData.CritDamageBonus;
            MovementSpeedBonus = LegData.MovementSpeedBonus;
            MultiAttackBonus = LegData.MultiAttackBonus;
            BlockChanceBonus = LegData.BlockChanceBonus;
            AbilityDamage = LegData.AbilityDamage;
            CooldownReduction = LegData.CooldownReduction;
            AOEchanceBonus = LegData.AOEchanceBonus;

            LegendaryTrait = LegData.LegendaryTrait;
            SecondLegendaryTrait = LegData.SecondLegendaryTrait;

            GoldNeeded = LegData.LegsGoldNeeded;

        }
        if (BootsData != null)
        {

            if (FromSaveFile)
            {
                BootsData.ItemLoadedRarity = Itemrarity;
            }

            BootsData.SetRarity(FromSaveFile);

            ID = BootsData.ID;
            ItemName = BootsData.BootsName;
            description = BootsData.Description;
            icon = BootsData.icon;
            HPBonus = BootsData.HPBonus;
            StunChanceBonus = BootsData.StunBonus;
            MovementSpeedBonus = BootsData.MovementspeedBonus;
            AOEchanceBonus = BootsData.AOEchanceBonus;
            type = BootsData.BootsArmour;
            Class = BootsData.ArmourClass.ToString();
            Itemrarity = BootsData.ItemLevel.ToString();
            Rank = BootsData.Bootslevel;
            Damage = BootsData.Damage;
            StunChanceBonus = BootsData.StunChanceBonus;
            CritChance = BootsData.CritChance;
            DodgeBonus = BootsData.DodgeBonus;
            CritDamageBonus = BootsData.CritDamageBonus;
            MultiAttackBonus = BootsData.MultiAttackBonus;
            BlockChanceBonus = BootsData.BlockChanceBonus;
            StaminaRegenBonus = BootsData.StaminaRegenBonus;
            AbilityDamage = BootsData.AbilityDamage;
            CooldownReduction = BootsData.CooldownReduction;

            LegendaryTrait = BootsData.LegendaryTrait;
            SecondLegendaryTrait = BootsData.SecondLegendaryTrait;

            GoldNeeded = BootsData.BootsGoldNeeded;
        }

        if (FromSaveFile == true)
        {
            GameObject.Find("PlayerData").GetComponent<Inventory>().AddItem(this.gameObject, this, ID, type, description, icon);
            FromSaveFile = false;
        }


        SetTitle();
        //Converts the type chosen to a string that is used in the other scripts

        
  
        //Finds the weapon manager
        WeaponManager = GameObject.FindGameObjectWithTag("WeaponManager");

        //Finds the holder where equipped items are stored
        if (!PlayerWeapon)
        {
            FindHolder();
        }
    }
   
    void FindHolder()
    {
        if (!WeaponManager)
        {
            WeaponManager = GameObject.FindGameObjectWithTag("WeaponManager");
        }

        //depending on the type of the item it locates where it'll be stored if equipped
        int allWeapons = WeaponManager.transform.childCount;
        for (int i = 0; i < allWeapons; i++)
        {
            if (WeaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().type == type)
            {
                if (type == "Weapon")
                {
                    Weapon = WeaponManager.transform.GetChild(i).gameObject;
                }
                else if (type == "HeadArmour")
                {
                    HeadArmour = WeaponManager.transform.GetChild(i).gameObject;
                }
                else if (type == "ChestArmour")
                {
                    ChestArmour = WeaponManager.transform.GetChild(i).gameObject;
                }
                else if (type == "Gloves")
                {
                    Gloves = WeaponManager.transform.GetChild(i).gameObject;
                }
                else if (type == "LegsArmour")
                {
                    LegsArmour = WeaponManager.transform.GetChild(i).gameObject;
                }
                else if (type == "BootsArmour")
                {
                    BootsArmour = WeaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    public void ItemUsage()
    {
        //Adds the appropriate buffs depending on what kind of item it is

        //If the object doesn't have a holder look for it
        if (!Weapon)
            FindHolder();

        GameObject EquippedItemHolder = GameObject.Find("EquippedItems");

        Equipped = true;

        PlayerCombat Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();

        //Applies the weapon's attack bonus
        if (type == "Weapon")
        {
            Weapon.SetActive(true);

            Player.AttackDamage += Damage;
            if (Class == "Bruiser")
                Player.BlockChance += BlockChanceBonus;
            if (Class == "Assassin")
                Player.MultiAttackChance += MultiAttackBonus;
            if (Class == "Cultist")
                Player.AbilityDamage += AbilityDamage;

            if (HPBonus > 0)
            {
                Player.GetComponent<PlayerStats>().StartingHealth += HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus += HPBonus;
            }
            if(CritChance > 0)
                Player.GetComponent<PlayerStats>().CriticalChance += CritChance;
            if(StunChanceBonus > 0)
                Player.StunChance += StunChanceBonus;
            if(CritDamageBonus > 0)
                Player.CriticalDamage += CritDamageBonus;
            if(DodgeBonus > 0.00)
                Player.DodgeChance += DodgeBonus;
            if(MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed += MovementSpeedBonus;
            if(StaminaRegenBonus > 0)
                Player.StaminaRegen += StaminaRegenBonus;
            if(CooldownReduction >0)
                Player.CooldownReduction += CooldownReduction;
            if(AOEchanceBonus > 0.00)
                Player.AOEChance += AOEchanceBonus;

            //Activates legendary trait
            if(LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, true);
            }

            if(SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, true);
            }

            EquippedItemHolder.transform.Find("Weapon").GetComponent<Image>().sprite = icon;
        }

        //Applies head armour's health bonus
        if (type == "HeadArmour")
        {

            HeadArmour.SetActive(true);
            Player.GetComponent<PlayerStats>().StartingHealth += HPBonus;
            Player.GetComponent<PlayerStats>().HealthBonus += HPBonus;
            if (Class == "Bruiser")
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            if (Class == "Assassin")
                Player.GetComponent<PlayerStats>().CriticalChance += CritChance;
            if (Class == "Cultist")
                Player.GetComponent<PlayerStats>().CooldownReduction += CooldownReduction;
            
            if(Damage>0)
                Player.AttackDamage += Damage;
            if(StunChanceBonus > 0)
                Player.StunChance += StunChanceBonus;
            if(DodgeBonus > 0.00)
                Player.DodgeChance += DodgeBonus;
            if(CritDamageBonus> 0)
                Player.CriticalDamage += CritDamageBonus;
            if(MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed += MovementSpeedBonus;
            if(MultiAttackBonus > 0)
                Player.MultiAttackChance += MultiAttackBonus;
            if(BlockChanceBonus > 0.00)
                Player.BlockChance += BlockChanceBonus;
            if(StaminaRegenBonus > 0)
                Player.StaminaRegen += StaminaRegenBonus;
            if(AbilityDamage > 0)
                Player.AbilityDamage += AbilityDamage;
            if(AOEchanceBonus > 0.00)
                Player.AOEChance += AOEchanceBonus;

            //Activates legendary trait
            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, true);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, true);
            }


            EquippedItemHolder.transform.Find("HeadArmour").GetComponent<Image>().sprite = icon;
        }
        if (type == "ChestArmour")
        {

            ChestArmour.SetActive(true);
            if (Class == "Bruiser")
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            if (Class == "Assassin") {
                Player.GetComponent<PlayerStats>().DodgeChance += DodgeBonus;
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            }
            if (Class == "Cultist")
            {
                Player.GetComponent<PlayerStats>().StaminaRegen += StaminaRegenBonus;
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            }

            if(Damage > 0)
               Player.AttackDamage += Damage;
            if (HPBonus > 0)
            {
                Player.GetComponent<PlayerStats>().StartingHealth += HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus += HPBonus;
            }
            if(StunChanceBonus>0)
                Player.StunChance += StunChanceBonus;
            if(CritChance>0)
                Player.CriticalChance += CritChance;
            if (CritDamageBonus > 0)
                Player.CriticalDamage += CritDamageBonus;
            if(MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed += MovementSpeedBonus;
            if(MultiAttackBonus > 0)
                Player.MultiAttackChance += MultiAttackBonus;
            if(BlockChanceBonus > 0.00)
                Player.BlockChance += BlockChanceBonus;
            if(AbilityDamage > 0)
                Player.AbilityDamage += AbilityDamage;
            if(CooldownReduction > 0.00)
                Player.CooldownReduction += CooldownReduction;
            if(AOEchanceBonus > 0.00)
                Player.AOEChance += AOEchanceBonus;

            //Activates legendary trait
            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, true);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, true);
            }

            EquippedItemHolder.transform.Find("ChestArmour").GetComponent<Image>().sprite = icon;
        }
        //Applies gloves damage and health bonus
        if (type == "Gloves")
        {
            Gloves.SetActive(true);
            Player.AttackDamage += Damage;
            if (Class == "Bruiser")
            {
                Player.GetComponent<PlayerStats>().StartingHealth += HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus += HPBonus;
            }
            if (Class == "Assassin")
                Player.GetComponent<PlayerStats>().CriticalDamage += CritDamageBonus;
            if (Class == "Cultist")
                Player.GetComponent<PlayerStats>().AbilityDamage += AbilityDamage;
            
            if(StunChanceBonus>0)
                Player.StunChance += StunChanceBonus;
            if(CritChance>0)
                Player.CriticalChance += CritChance;
            if(DodgeBonus>0)
                Player.DodgeChance += DodgeBonus;
            if(MovementSpeedBonus>0)
                Player.GetComponent<PlayerStats>().Movespeed += MovementSpeedBonus;
            if(MultiAttackBonus>0)
                Player.MultiAttackChance += MultiAttackBonus;
            if(BlockChanceBonus>0)
                Player.BlockChance += BlockChanceBonus;
            if(StaminaRegenBonus>0)
                Player.GetComponent<PlayerStats>().StaminaRegen += StaminaRegenBonus;
            if(AOEchanceBonus>0)
                Player.AOEChance += AOEchanceBonus;

            //Activates legendary trait
            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, true);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, true);
            }

            EquippedItemHolder.transform.Find("Gloves").GetComponent<Image>().sprite = icon;
        }
        //Applies legs armour's health bonus
        if (type == "LegsArmour")
        {
            LegsArmour.SetActive(true);
            
            if (Class == "Bruiser")
            {
                Player.GetComponent<PlayerStats>().StartingHealth += HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus += HPBonus;
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            }
            if (Class == "Assassin")
            {
                Player.GetComponent<PlayerStats>().DodgeChance += DodgeBonus;
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            }
                

            if (Class == "Cultist")
            {
                Player.GetComponent<PlayerStats>().StaminaRegen += StaminaRegenBonus;
                Player.GetComponent<PlayerStats>().armour += ArmourStats;
            }

            if(Damage>0)
                Player.AttackDamage += Damage;
            if(StunChanceBonus>0)
                Player.StunChance += StunChanceBonus;
            if(CritChance>0)
                Player.CriticalChance += CritChance;
            if(CritDamageBonus>0)
                Player.CriticalDamage += CritDamageBonus;
            if(MovementSpeedBonus>0)
                Player.GetComponent<PlayerStats>().Movespeed += MovementSpeedBonus;
            if(MultiAttackBonus>0)
                Player.MultiAttackChance += MultiAttackBonus;
            if(BlockChanceBonus>0)
                Player.BlockChance += BlockChanceBonus;
            if(AbilityDamage>0)
                Player.AbilityDamage += AbilityDamage;
            if(CooldownReduction >0)
                Player.CooldownReduction += CooldownReduction;
            if(AOEchanceBonus>0)
                Player.AOEChance += AOEchanceBonus;


            EquippedItemHolder.transform.Find("LegArmour").GetComponent<Image>().sprite = icon;

        }
        //Applies boots armour health and stun chance bonus
        if (type == "BootsArmour")
        {
            BootsArmour.SetActive(true);
            Player.GetComponent<PlayerStats>().StartingHealth += HPBonus;
            Player.GetComponent<PlayerStats>().HealthBonus += HPBonus;
            if(Class=="Bruiser")
               Player.StunChance += StunChanceBonus;
            if (Class == "Assassin")
                Player.GetComponent<PlayerStats>().Movespeed += MovementSpeedBonus;
            if (Class == "Cultist")
                Player.GetComponent<PlayerStats>().AOEChance += AOEchanceBonus;
            
            if(Damage>0)
                Player.AttackDamage += Damage;
            if(StunChanceBonus>0)
                Player.StunChance += StunChanceBonus;
            if(CritChance>0)
                Player.CriticalChance += CritChance;
            if(DodgeBonus>0)
                Player.DodgeChance += DodgeBonus;
            if(CritDamageBonus>0)
                Player.CriticalDamage += CritDamageBonus;
            if(MultiAttackBonus>0)
                Player.MultiAttackChance += MultiAttackBonus;
            if(BlockChanceBonus>0)
                Player.BlockChance += BlockChanceBonus;
            if(StaminaRegenBonus>0)
                Player.GetComponent<PlayerStats>().StaminaRegen += StaminaRegenBonus;
            if(AbilityDamage>0)
                Player.AbilityDamage += AbilityDamage;
            if(CooldownReduction>0)
                Player.CooldownReduction += CooldownReduction;

            //Activates legendary trait
            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, true);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, true);
            }

            EquippedItemHolder.transform.Find("Boots").GetComponent<Image>().sprite = icon;
        }
        Debug.Log(CooldownReduction);
    }

    public void RemoveItem()
    {
        //If the object doesn't have a holder look for it
        if (!Weapon)
            FindHolder();
        
        //Remoes the approriate item and buffs depending of the type

        GameObject EquippedItemHolder = GameObject.Find("EquippedItems");

        Equipped = false;

        PlayerCombat Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();

        //Removes the weapon and the attack bonus it gives
        if (type == "Weapon")
        {
            Weapon.SetActive(false);
            Player.AttackDamage -= Damage;
            if (Class == "Bruiser")
                Player.BlockChance -= BlockChanceBonus;
            if (Class == "Assassin")
                Player.MultiAttackChance -= MultiAttackBonus;
            if (Class == "Cultist")
                Player.AbilityDamage -= AbilityDamage;
            
            
            if (CritChance > 0)
                Player.CriticalChance -= CritChance;
            if (HPBonus > 0)
            {
                Player.GetComponent<PlayerStats>().StartingHealth -= HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus -= HPBonus;
            }
            if (StunChanceBonus > 0)
                Player.StunChance -= StunChanceBonus;
            if (DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if (CritDamageBonus > 0)
                Player.CriticalDamage -= CritDamageBonus;
            if (MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed -= MovementSpeedBonus;
            if (StaminaRegenBonus > 0)
                Player.StaminaRegen -= StaminaRegenBonus;
            if (CooldownReduction > 0.00)
                Player.CooldownReduction -= CooldownReduction;
            if (AOEchanceBonus > 0.00)
                Player.AOEChance -= AOEchanceBonus;

            if(LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, false);
            }

            if(SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, false);
            }
       
            EquippedItemHolder.transform.Find("Weapon").GetComponent<Image>().sprite = null;
        }
        //Removes the head armour and the health bonus it gives
        if (type == "HeadArmour")
        {
            HeadArmour.SetActive(false);
            Player.GetComponent<PlayerStats>().StartingHealth -= HPBonus;
            Player.GetComponent<PlayerStats>().HealthBonus -= HPBonus;
            if (Class == "Bruiser")
                Player.GetComponent<PlayerStats>().armour -= ArmourStats;
            if (Class == "Assassin")
                Player.GetComponent<PlayerStats>().CriticalChance -= CritChance;
            if (Class == "Cultist")
                Player.GetComponent<PlayerStats>().CooldownReduction -= CooldownReduction;
            if(Damage>0)
                Player.AttackDamage = Damage;
            if(StunChanceBonus > 0)
                Player.StunChance -= StunChanceBonus;
            if(DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if(CritDamageBonus > 0)
                Player.CriticalDamage -= CritDamageBonus;
            if(MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed -= MovementSpeedBonus;
            if(MultiAttackBonus > 0)
                Player.MultiAttackChance -= MultiAttackBonus;
            if(BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if(StaminaRegenBonus > 0)
                Player.StaminaRegen -= StaminaRegenBonus;
            if(AbilityDamage > 0)
                Player.AbilityDamage -= AbilityDamage;
            if(AOEchanceBonus > 0.00)
                Player.AOEChance -= AOEchanceBonus;


            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, false);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, false);
            }

            EquippedItemHolder.transform.Find("HeadArmour").GetComponent<Image>().sprite = null;
        }
        //Removes the chest armour and the bonuses it gives
        if (type == "ChestArmour")
        {
            if(Class== "Bruiser")
            {
                Player.GetComponent<PlayerStats>().armour -= ArmourStats;
            }
            if (Class == "Assassin")
            {
                Player.GetComponent<PlayerStats>().armour-=ArmourStats;
                Player.GetComponent<PlayerStats>().DodgeChance -= DodgeBonus;
            }
                
            if (Class == "Cultist")
            {
                Player.GetComponent<PlayerStats>().armour -= ArmourStats;
                Player.GetComponent<PlayerStats>().StaminaRegen -= StaminaRegenBonus;
            }

            if(Damage > 0)
                Player.AttackDamage -= Damage;
            if (HPBonus > 0)
            {
                Player.GetComponent<PlayerStats>().StartingHealth -= HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus -= HPBonus;
            }
            if(StunChanceBonus > 0)
                Player.StunChance -= StunChanceBonus;
            if(CritChance > 0)
                Player.CriticalChance -= CritChance;
            if(CritDamageBonus >0)
                Player.CriticalDamage -= CritDamageBonus;
            if(MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed -= MovementSpeedBonus;
            if(MultiAttackBonus> 0)
                Player.MultiAttackChance -= MultiAttackBonus;
            if(BlockChanceBonus>0)
                Player.BlockChance -= BlockChanceBonus;
            if(AbilityDamage > 0)
                Player.AbilityDamage -= AbilityDamage;
            if(CooldownReduction > 0.00)
                Player.CooldownReduction -= CooldownReduction;
            if(AOEchanceBonus > 0.00)
                Player.AOEChance -= AOEchanceBonus;


            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, false);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, false);
            }

            EquippedItemHolder.transform.Find("ChestArmour").GetComponent<Image>().sprite = null;
        }
        //Removes the gloves and the damage/health bonus it gives
        if (type == "Gloves")
        {
            Gloves.SetActive(false);
            Player.AttackDamage -= Damage;
            if (Class == "Bruiser")
            {
                Player.GetComponent<PlayerStats>().StartingHealth -= HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus -= HPBonus;
            }
            if (Class == "Assassin")
                Player.GetComponent<PlayerStats>().CriticalDamage -= CritDamageBonus;
            if (Class == "Cultist")
                Player.GetComponent<PlayerStats>().AbilityDamage -= AbilityDamage;
            if(StunChanceBonus > 0)
                Player.StunChance -= StunChanceBonus;
            if(CritChance > 0)
                Player.CriticalChance -= CritChance;
            if(DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if(MovementSpeedBonus > 0)
                Player.GetComponent<PlayerStats>().Movespeed -= MovementSpeedBonus;
            if(MultiAttackBonus > 0)
                Player.MultiAttackChance -= MultiAttackBonus;
            if(BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if(StaminaRegenBonus>0)
                Player.GetComponent<PlayerStats>().StaminaRegen -= StaminaRegenBonus;
          if(AOEchanceBonus>0)
                Player.AOEChance -= AOEchanceBonus;


            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, false);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, false);
            }

            EquippedItemHolder.transform.Find("Gloves").GetComponent<Image>().sprite = null;
        }
        //Removes the legs armour and the health bonus it gives
        if (type == "LegsArmour")
        {
            LegsArmour.SetActive(false);
           
            if (Class == "Bruiser")
            {
                Player.GetComponent<PlayerStats>().armour -= ArmourStats;
                Player.GetComponent<PlayerStats>().StartingHealth -= HPBonus;
                Player.GetComponent<PlayerStats>().HealthBonus -= HPBonus;
            }
            if (Class == "Assassin")
            {
                Player.GetComponent<PlayerStats>().DodgeChance -= DodgeBonus;
                Player.GetComponent<PlayerStats>().armour -= ArmourStats;
            }
                
            if (Class == "Cultist")
            {
                Player.GetComponent<PlayerStats>().StaminaRegen -= StaminaRegenBonus;
                Player.GetComponent<PlayerStats>().armour -= ArmourStats;
            }
            if(Damage > 0)
                Player.AttackDamage -= Damage;
            if(StunChanceBonus > 0)
                Player.StunChance -= StunChanceBonus;
            if(CritChance > 0)
                Player.CriticalChance -= CritChance;
            if(CritDamageBonus > 0 )
                Player.CriticalDamage -= CritDamageBonus;
            if(MovementSpeedBonus > 0 )
                Player.GetComponent<PlayerStats>().Movespeed -= MovementSpeedBonus;
            if(MultiAttackBonus > 0)
                Player.MultiAttackChance -= MultiAttackBonus;
            if(BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if(AbilityDamage > 0)
                Player.AbilityDamage -= AbilityDamage;
            if(CooldownReduction > 0.00)
                Player.CooldownReduction -= CooldownReduction;
            if(AOEchanceBonus > 0.00)
                Player.AOEChance += AOEchanceBonus;


            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, false);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, false);
            }

            EquippedItemHolder.transform.Find("LegArmour").GetComponent<Image>().sprite = null;
        }
        //Removes the boots armour and the health/Stun chance bonus it gives
        if (type == "BootsArmour")
        {
            BootsArmour.SetActive(false);
            Player.GetComponent<PlayerStats>().StartingHealth -= HPBonus;
            Player.GetComponent<PlayerStats>().HealthBonus -= HPBonus;
            if (Class == "Bruiser")
                Player.StunChance -= StunChanceBonus;
            if (Class == "Assassin")
                Player.GetComponent<PlayerStats>().Movespeed -= MovementSpeedBonus;
            if (Class == "Cultist")
                Player.GetComponent<PlayerStats>().AOEChance -= AOEchanceBonus;
            if(Damage > 0)
                Player.AttackDamage -= Damage;
            if(StunChanceBonus > 0)
                Player.StunChance -= StunChanceBonus;
            if(CritChance > 0)
                Player.CriticalChance -= CritChance;
            if(DodgeBonus > 0.00)
                Player.DodgeChance -= DodgeBonus;
            if(CritDamageBonus > 0)
                Player.CriticalDamage -= CritDamageBonus;
            if(MultiAttackBonus > 0)
                Player.MultiAttackChance -= MultiAttackBonus;
            if(BlockChanceBonus > 0.00)
                Player.BlockChance -= BlockChanceBonus;
            if(StaminaRegenBonus > 0)
                Player.GetComponent<PlayerStats>().StaminaRegen -= StaminaRegenBonus;
            if(AbilityDamage > 0)
                Player.AbilityDamage -= AbilityDamage;
            if(CooldownReduction > 0.00)
                Player.CooldownReduction -= CooldownReduction;


            if (LegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(LegendaryTrait, false);
            }

            if (SecondLegendaryTrait != "")
            {
                Player.GetComponent<PlayerStats>().StartCoroutine(SecondLegendaryTrait, false);
            }

            EquippedItemHolder.transform.Find("Boots").GetComponent<Image>().sprite = null;
        }
    }

    public void EquipDifferentWeapon()
    {
        //Stores the previously equipped weapon
        Item PreviousItem = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().WeaponEquipped.GetComponent<Item>();
        //Removes the previous item
        PreviousItem.RemoveItem();
        //Equips current item
        ItemUsage();

    }

    public void EquipDifferentHeadArmour()
    {
        //Stores the previously equipped item
        Item PreviousItem = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().HeadArmourEquipped.GetComponent<Item>();
        //Removes the previous item
        PreviousItem.RemoveItem();
        //Equips current item
        ItemUsage();

    }
    public void EquipDifferentChestArmour()
    {
        //Stores the previously equipped item
        Item PreviousItem = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().ChestArmourEquipped.GetComponent<Item>();
        //Removes the previous item
        PreviousItem.RemoveItem();
        //Equips current item
        ItemUsage();

    }

    public void EquipDifferentGloves()
    {
        //Stores the previously equipped item
        Item PreviousItem = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().GlovesEquipped.GetComponent<Item>();
        //Removes the previous item
        PreviousItem.RemoveItem();
        //Equips current item
        ItemUsage();
    }
    public void EquipDifferentLegsArmour()
    {
        //Stores the previously equipped item
        Item PreviousItem = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().LegsArmourEquipped.GetComponent<Item>();
        //Removes the previous item
        PreviousItem.RemoveItem();
        //Equips current item
        ItemUsage();
    }
    public void EquipDifferentBootsArmour()
    {
        //Stores the previously equipped item
        Item PreviousItem = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().BootsEquipped.GetComponent<Item>();
        //Removes the previous item
        PreviousItem.RemoveItem();
        //Equips current item
        ItemUsage();
    }

    public void UpgradeItems()
    {
        Gold = GameObject.Find("Player").GetComponent<PlayerStats>().Gold;
        if (type == "Weapon")
        {
            if (Gold >= GoldNeeded && data.WeaponMaxGearLevel == false)
            {
                RemoveItem();
                data.Weaponlevel += 1;
                data.gearlevel();
                
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = data.ID;
                ItemName = data.WeaponName;
                description = data.Description;
                icon = data.icon;
                Damage = data.Damage;
                BlockChanceBonus = data.BlockChanceBonus;
                MultiAttackBonus = data.MultiAttackBonus;
                AbilityDamage = data.AbilityDamage;
                CritChance = data.CritChance;
                HPBonus = data.HPBonus;
                StunChanceBonus = data.StunChanceBonus;
                DodgeBonus = data.DodgeBonus;
                CritDamageBonus = data.CritDamageBonus;
                MovementSpeedBonus = data.MovementSpeedBonus;
                StaminaRegenBonus = data.StaminaRegenBonus;
                CooldownReduction = data.CooldownReduction;
                AOEchanceBonus = data.AOEchanceBonus;
                type = data.Type;
                Class = data.ArmourClass.ToString();
                Itemrarity = data.Itemlevel.ToString();
                Rank = data.Weaponlevel;
                GoldNeeded = data.WeaponNeededGold;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;

            }else if (Gold >= GoldNeeded && data.WeaponMaxGearLevel == true)
            {
                RemoveItem();
                data.Weaponlevel += 1;
                data.MaxUpgrade();
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = data.ID;
                ItemName = data.WeaponName;
                description = data.Description;
                icon = data.icon;
                Damage = data.Damage;
                BlockChanceBonus = data.BlockChanceBonus;
                MultiAttackBonus = data.MultiAttackBonus;
                AbilityDamage = data.AbilityDamage;
                CritChance = data.CritChance;
                HPBonus = data.HPBonus;
                StunChanceBonus = data.StunChanceBonus;
                DodgeBonus = data.DodgeBonus;
                CritDamageBonus = data.CritDamageBonus;
                MovementSpeedBonus = data.MovementSpeedBonus;
                StaminaRegenBonus = data.StaminaRegenBonus;
                CooldownReduction = data.CooldownReduction;
                AOEchanceBonus = data.AOEchanceBonus;
                type = data.Type;
                Class = data.ArmourClass.ToString();
                Itemrarity = data.Itemlevel.ToString();
                Rank = data.Weaponlevel;
                GoldNeeded = data.WeaponNeededGold;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }
        }
        if (type == "HeadArmour")
        {
            if (Gold >= GoldNeeded && HeadData.HeadMaxGearLevel == false)
            {
                RemoveItem();
                HeadData.Headlevel += 1;
                HeadData.gearLevel();
                
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = HeadData.ID;
                ItemName = HeadData.HeadName;
                description = HeadData.Description;
                icon = HeadData.icon;
                HPBonus = HeadData.HPBonus;
                CritChance = HeadData.CritChance;
                CooldownReduction = HeadData.CooldownReduction;
                type = HeadData.HeadArmour;
                Class = HeadData.ArmourClass.ToString();
                Itemrarity = HeadData.ItemLevel.ToString();
                Rank = HeadData.Headlevel;
                ArmourStats = HeadData.ArmourStats;
                Damage = HeadData.Damage;
                StunChanceBonus = HeadData.StunChanceBonus;
                DodgeBonus = HeadData.DodgeBonus;
                CritDamageBonus = HeadData.CritDamageBonus;
                MovementSpeedBonus = HeadData.MovementSpeedBonus;
                MultiAttackBonus = HeadData.MultiAttackBonus;
                BlockChanceBonus = HeadData.BlockChanceBonus;
                StaminaRegenBonus = HeadData.StaminaRegenBonus;
                AbilityDamage = HeadData.AbilityDamage;
                AOEchanceBonus = HeadData.AOEchanceBonus;
                GoldNeeded = HeadData.HeadGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;

            }else if (Gold >= GoldNeeded && HeadData.HeadMaxGearLevel == true)
            {
                RemoveItem();
                HeadData.Headlevel += 1;
                HeadData.MaxUpgradeMode();

                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = HeadData.ID;
                ItemName = HeadData.HeadName;
                description = HeadData.Description;
                icon = HeadData.icon;
                HPBonus = HeadData.HPBonus;
                CritChance = HeadData.CritChance;
                CooldownReduction = HeadData.CooldownReduction;
                type = HeadData.HeadArmour;
                Class = HeadData.ArmourClass.ToString();
                Itemrarity = HeadData.ItemLevel.ToString();
                Rank = HeadData.Headlevel;
                ArmourStats = HeadData.ArmourStats;
                Damage = HeadData.Damage;
                StunChanceBonus = HeadData.StunChanceBonus;
                DodgeBonus = HeadData.DodgeBonus;
                CritDamageBonus = HeadData.CritDamageBonus;
                MovementSpeedBonus = HeadData.MovementSpeedBonus;
                MultiAttackBonus = HeadData.MultiAttackBonus;
                BlockChanceBonus = HeadData.BlockChanceBonus;
                StaminaRegenBonus = HeadData.StaminaRegenBonus;
                AbilityDamage = HeadData.AbilityDamage;
                AOEchanceBonus = HeadData.AOEchanceBonus;
                GoldNeeded = HeadData.HeadGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;

            }
        }
        if (type == "ChestArmour")
        {
            if (Gold >= GoldNeeded && ChestData.ChestMaxGearLevel == false)
            {
                RemoveItem();
                ChestData.ChestLevel += 1;
                ChestData.GearLevel();
                
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = ChestData.ID;
                ItemName = ChestData.ChestName;
                description = ChestData.Description;
                icon = ChestData.icon;
                DodgeBonus = ChestData.DodgeBonus;
                StaminaRegenBonus = ChestData.StaminaRegenBonus;
                type = ChestData.ChestArmour;
                Class = ChestData.ArmourClass.ToString();
                Itemrarity = ChestData.ItemLevel.ToString();
                Rank = ChestData.ChestLevel;
                ArmourStats = ChestData.ArmourStats;
                Damage = ChestData.Damage;
                HPBonus = ChestData.HPBonus;
                StunChanceBonus = ChestData.StunChanceBonus;
                CritChance = ChestData.CritChance;
                CritDamageBonus = ChestData.CritDamageBonus;
                MovementSpeedBonus = ChestData.MovementSpeedBonus;
                MultiAttackBonus = ChestData.MultiAttackBonus;
                BlockChanceBonus = ChestData.BlockChanceBonus;
                AbilityDamage = ChestData.AbilityDamage;
                CooldownReduction = ChestData.CooldownReduction;
                AOEchanceBonus = ChestData.AOEchanceBonus;
                GoldNeeded = ChestData.ChestGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }else if (Gold >= GoldNeeded && ChestData.ChestMaxGearLevel == true)
            {
                RemoveItem();
                ChestData.ChestLevel += 1;
                ChestData.MaxUpgradeMode();

                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = ChestData.ID;
                ItemName = ChestData.ChestName;
                description = ChestData.Description;
                icon = ChestData.icon;
                DodgeBonus = ChestData.DodgeBonus;
                StaminaRegenBonus = ChestData.StaminaRegenBonus;
                type = ChestData.ChestArmour;
                Class = ChestData.ArmourClass.ToString();
                Itemrarity = ChestData.ItemLevel.ToString();
                Rank = ChestData.ChestLevel;
                ArmourStats = ChestData.ArmourStats;
                Damage = ChestData.Damage;
                HPBonus = ChestData.HPBonus;
                StunChanceBonus = ChestData.StunChanceBonus;
                CritChance = ChestData.CritChance;
                CritDamageBonus = ChestData.CritDamageBonus;
                MovementSpeedBonus = ChestData.MovementSpeedBonus;
                MultiAttackBonus = ChestData.MultiAttackBonus;
                BlockChanceBonus = ChestData.BlockChanceBonus;
                AbilityDamage = ChestData.AbilityDamage;
                CooldownReduction = ChestData.CooldownReduction;
                AOEchanceBonus = ChestData.AOEchanceBonus;
                GoldNeeded = ChestData.ChestGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }
        }
        if (type == "Gloves")
        {
            if (Gold >= GoldNeeded && GloveData.GlovesMaxGearLevel == false)
            {
                RemoveItem();
                GloveData.Gloveslevel += 1;
                GloveData.GearLevel();
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = GloveData.ID;
                ItemName = GloveData.GloveNames;
                description = GloveData.Description;
                icon = GloveData.icon;
                Damage = GloveData.Damage;
                HPBonus = GloveData.HPBonus;
                CritDamageBonus = GloveData.CritDamageBonus;
                AbilityDamage = GloveData.AbilityDamage;
                type = GloveData.Gloves;
                Class = GloveData.ArmourClass.ToString();
                Itemrarity = GloveData.ItemLevel.ToString();
                Rank = GloveData.Gloveslevel;
                StunChanceBonus = GloveData.StunChanceBonus;
                CritChance = GloveData.CritChance;
                DodgeBonus = GloveData.DodgeBonus;
                MovementSpeedBonus = GloveData.MovementSpeedBonus;
                MultiAttackBonus = GloveData.MultiAttackBonus;
                BlockChanceBonus = GloveData.BlockChanceBonus;
                StaminaRegenBonus = GloveData.StaminaRegenBonus;
                CooldownReduction = GloveData.CooldownReduction;
                AOEchanceBonus = GloveData.AOEchanceBonus;
                GoldNeeded = GloveData.GlovesGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }else if (Gold >= GoldNeeded && GloveData.GlovesMaxGearLevel == true)
            {
                RemoveItem();
                GloveData.Gloveslevel += 1;
                GloveData.MaxUpgradeMode();

                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = GloveData.ID;
                ItemName = GloveData.GloveNames;
                description = GloveData.Description;
                icon = GloveData.icon;
                Damage = GloveData.Damage;
                HPBonus = GloveData.HPBonus;
                CritDamageBonus = GloveData.CritDamageBonus;
                AbilityDamage = GloveData.AbilityDamage;
                type = GloveData.Gloves;
                Class = GloveData.ArmourClass.ToString();
                Itemrarity = GloveData.ItemLevel.ToString();
                Rank = GloveData.Gloveslevel;
                StunChanceBonus = GloveData.StunChanceBonus;
                CritChance = GloveData.CritChance;
                DodgeBonus = GloveData.DodgeBonus;
                MovementSpeedBonus = GloveData.MovementSpeedBonus;
                MultiAttackBonus = GloveData.MultiAttackBonus;
                BlockChanceBonus = GloveData.BlockChanceBonus;
                StaminaRegenBonus = GloveData.StaminaRegenBonus;
                CooldownReduction = GloveData.CooldownReduction;
                AOEchanceBonus = GloveData.AOEchanceBonus;
                GoldNeeded = GloveData.GlovesGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }
        }
        if (type == "LegsArmour")
        {
            if (Gold >= GoldNeeded && LegData.LegsMaxGearLevel == false)
            {
                RemoveItem();
                LegData.Legslevel += 1;
                LegData.GearLevel();
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = LegData.ID;
                ItemName = LegData.LegsName;
                description = LegData.Description;
                icon = LegData.icon;
                HPBonus = LegData.HPBonus;
                DodgeBonus = LegData.DodgeBonus;
                StaminaRegenBonus = LegData.StaminaRegenBonus;
                type = LegData.LegsArmour;
                Class = LegData.ArmourClass.ToString();
                Itemrarity = LegData.ItemLevel.ToString();
                Rank = LegData.Legslevel;
                ArmourStats = LegData.ArmourStats;
                Damage = LegData.Damage;
                StunChanceBonus = LegData.StunChanceBonus;
                CritChance = LegData.CritChance;
                CritDamageBonus = LegData.CritDamageBonus;
                MovementSpeedBonus = LegData.MovementSpeedBonus;
                MultiAttackBonus = LegData.MultiAttackBonus;
                BlockChanceBonus = LegData.BlockChanceBonus;
                AbilityDamage = LegData.AbilityDamage;
                CooldownReduction = LegData.CooldownReduction;
                AOEchanceBonus = LegData.AOEchanceBonus;
                GoldNeeded = LegData.LegsGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }else if (Gold >= GoldNeeded && LegData.LegsMaxGearLevel == true)
            {
                RemoveItem();
                LegData.Legslevel += 1;
                LegData.MaxxUpgradeMode();
                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = LegData.ID;
                ItemName = LegData.LegsName;
                description = LegData.Description;
                icon = LegData.icon;
                HPBonus = LegData.HPBonus;
                DodgeBonus = LegData.DodgeBonus;
                StaminaRegenBonus = LegData.StaminaRegenBonus;
                type = LegData.LegsArmour;
                Class = LegData.ArmourClass.ToString();
                Itemrarity = LegData.ItemLevel.ToString();
                Rank = LegData.Legslevel;
                ArmourStats = LegData.ArmourStats;
                Damage = LegData.Damage;
                StunChanceBonus = LegData.StunChanceBonus;
                CritChance = LegData.CritChance;
                CritDamageBonus = LegData.CritDamageBonus;
                MovementSpeedBonus = LegData.MovementSpeedBonus;
                MultiAttackBonus = LegData.MultiAttackBonus;
                BlockChanceBonus = LegData.BlockChanceBonus;
                AbilityDamage = LegData.AbilityDamage;
                CooldownReduction = LegData.CooldownReduction;
                AOEchanceBonus = LegData.AOEchanceBonus;
                GoldNeeded = LegData.LegsGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }
        }
        if (type == "BootsArmour")
        {
            if (Gold >= GoldNeeded && BootsData.BootsMaxGearLevel == false)
            {
                RemoveItem();
                BootsData.Bootslevel += 1;
                BootsData.Gearlevel();
               GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
               GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = BootsData.ID;
                ItemName = BootsData.BootsName;
                description = BootsData.Description;
                icon = BootsData.icon;
                HPBonus = BootsData.HPBonus;
                StunChanceBonus = BootsData.StunBonus;
                MovementSpeedBonus = BootsData.MovementspeedBonus;
                AOEchanceBonus = BootsData.AOEchanceBonus;
                type = BootsData.BootsArmour;
                Class = BootsData.ArmourClass.ToString();
                Itemrarity = BootsData.ItemLevel.ToString();
                Rank = BootsData.Bootslevel;
                Damage = BootsData.Damage;
                StunChanceBonus = BootsData.StunChanceBonus;
                CritChance = BootsData.CritChance;
                DodgeBonus = BootsData.DodgeBonus;
                CritDamageBonus = BootsData.CritDamageBonus;
                MultiAttackBonus = BootsData.MultiAttackBonus;
                BlockChanceBonus = BootsData.BlockChanceBonus;
                StaminaRegenBonus = BootsData.StaminaRegenBonus;
                AbilityDamage = BootsData.AbilityDamage;
                CooldownReduction = BootsData.CooldownReduction;
                GoldNeeded = BootsData.BootsGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;
            }else if (Gold >= GoldNeeded && BootsData.BootsMaxGearLevel == true)
            {
                RemoveItem();
                BootsData.Bootslevel += 1;
                BootsData.MaxUpgradeMode();

                GameObject.Find("Player").GetComponent<PlayerStats>().Gold -= GoldNeeded;
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxGoldReached = false;

                ID = BootsData.ID;
                ItemName = BootsData.BootsName;
                description = BootsData.Description;
                icon = BootsData.icon;
                HPBonus = BootsData.HPBonus;
                StunChanceBonus = BootsData.StunBonus;
                MovementSpeedBonus = BootsData.MovementspeedBonus;
                AOEchanceBonus = BootsData.AOEchanceBonus;
                type = BootsData.BootsArmour;
                Class = BootsData.ArmourClass.ToString();
                Itemrarity = BootsData.ItemLevel.ToString();
                Rank = BootsData.Bootslevel;
                Damage = BootsData.Damage;
                StunChanceBonus = BootsData.StunChanceBonus;
                CritChance = BootsData.CritChance;
                DodgeBonus = BootsData.DodgeBonus;
                CritDamageBonus = BootsData.CritDamageBonus;
                MultiAttackBonus = BootsData.MultiAttackBonus;
                BlockChanceBonus = BootsData.BlockChanceBonus;
                StaminaRegenBonus = BootsData.StaminaRegenBonus;
                AbilityDamage = BootsData.AbilityDamage;
                CooldownReduction = BootsData.CooldownReduction;
                GoldNeeded = BootsData.BootsGoldNeeded;
                ItemUsage();
                SetTitle();
                GetDescription();
                ToolTipText.text = Title + "\n" + MainDescription;

            }
        }
      
    }

    public void SetTitle()
    {
        Title = ItemName;
        if (type == "Weapon")
        {
            if (Class == "Bruiser")
            {
                MainDescription = description + "\n Damage = " + Damage + "\n Block Chance = " + BlockChanceBonus + "\n Item Rank = " + Rank;
                if (data.HPBonus > 0)
                {
                    MainDescription += "\n Health Bonus = " + data.HPBonus;
                }
                if (data.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + data.CritChance;
                }
                if (data.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bouns = " + data.StunChanceBonus;
                }
                if (data.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + data.DodgeBonus;
                }
                if (data.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + data.CritDamageBonus;
                }
                if (data.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + data.MovementSpeedBonus;
                }
                if (data.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + data.StaminaRegenBonus;
                }
                if (data.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Redcution = " + data.CooldownReduction;
                }
                if (data.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + data.AOEchanceBonus;
                }

            }
            if (Class == "Assassin")
            {
                MainDescription = description + "\n Damage = " + Damage + "\n Muti Attack Bonus = " + MultiAttackBonus + "\n Item Rank = " + Rank;
                if (data.HPBonus > 0)
                {
                    MainDescription += "\n Health Bonus = " + data.HPBonus;
                }
                if (data.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + data.CritChance;
                }
                if (data.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bouns = " + data.StunChanceBonus;
                }
                if (data.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + data.DodgeBonus;
                }
                if (data.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + data.CritDamageBonus;
                }
                if (data.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + data.MovementSpeedBonus;
                }
                if (data.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + data.StaminaRegenBonus;
                }
                if (data.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Redcution = " + data.CooldownReduction;
                }
                if (data.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + data.AOEchanceBonus;
                }

            }
            if (Class == "Cultist")
            {
                MainDescription = description + "\n Damage = " + Damage + "\n Ability Damage = " + AbilityDamage + "\n Item Rank = " + Rank;
                if (data.HPBonus > 0)
                {
                    MainDescription += "\n Health Bonus = " + data.HPBonus;
                }
                if (data.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + data.CritChance;
                }
                if (data.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bouns = " + data.StunChanceBonus;
                }
                if (data.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + data.DodgeBonus;
                }
                if (data.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + data.CritDamageBonus;
                }
                if (data.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + data.MovementSpeedBonus;
                }
                if (data.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + data.StaminaRegenBonus;
                }
                if (data.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Redcution = " + data.CooldownReduction;
                }
                if (data.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + data.AOEchanceBonus;
                }

            }
        }
        if (type == "HeadArmour")
        {
            if (Class == "Bruiser")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus+ "\n Armour protection = "+ ArmourStats + "\n Item Rank = " + Rank;
                if (HeadData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + HeadData.Damage;
                }
                if (HeadData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + HeadData.StunChanceBonus;
                }
                if (HeadData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + HeadData.DodgeBonus;
                }
                if (HeadData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + HeadData.CritDamageBonus;
                }
                if (HeadData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + HeadData.MovementSpeedBonus;
                }
                if (HeadData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + HeadData.MultiAttackBonus;
                }
                if (HeadData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + HeadData.BlockChanceBonus;
                }
                if (HeadData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + HeadData.StaminaRegenBonus;
                }
                if (HeadData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + HeadData.AbilityDamage;
                }
                if (HeadData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + HeadData.AOEchanceBonus;
                }
            }
            if (Class == "Assassin")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus + "\n Crit chance = " + CritChance + "%" + "\n Item Rank = " + Rank;
                if (HeadData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + HeadData.Damage;
                }
                if (HeadData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + HeadData.StunChanceBonus;
                }
                if (HeadData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + HeadData.DodgeBonus;
                }
                if (HeadData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + HeadData.CritDamageBonus;
                }
                if (HeadData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + HeadData.MovementSpeedBonus;
                }
                if (HeadData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + HeadData.MultiAttackBonus;
                }
                if (HeadData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + HeadData.BlockChanceBonus;
                }
                if (HeadData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + HeadData.StaminaRegenBonus;
                }
                if (HeadData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + HeadData.AbilityDamage;
                }
                if (HeadData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + HeadData.AOEchanceBonus;
                }
            }
            if (Class == "Cultist")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus + "\n Cool down Reduction = " + CooldownReduction + "\n Item Rank = " + Rank;
                if (HeadData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + HeadData.Damage;
                }
                if (HeadData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + HeadData.StunChanceBonus;
                }
                if (HeadData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + HeadData.DodgeBonus;
                }
                if (HeadData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + HeadData.CritDamageBonus;
                }
                if (HeadData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + HeadData.MovementSpeedBonus;
                }
                if (HeadData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + HeadData.MultiAttackBonus;
                }
                if (HeadData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + HeadData.BlockChanceBonus;
                }
                if (HeadData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + HeadData.StaminaRegenBonus;
                }
                if (HeadData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + HeadData.AbilityDamage;
                }
                if (HeadData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + HeadData.AOEchanceBonus;
                }
            }

              
    
   
 
    
    
        }
        if (type == "ChestArmour")
        {
            if (Class == "Bruiser")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus+ "\n Armour protection = "+ ArmourStats + "\n Item Rank = " + Rank;
                if (ChestData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + Damage;
                }
                if (ChestData.HPBonus > 0)
                {
                    MainDescription += "\n Health Bonus = " + ChestData.HPBonus;
                }
                if (ChestData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + ChestData.StunChanceBonus;
                }
                if (ChestData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + ChestData.CritChance;
                }
                if (ChestData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + ChestData.CritDamageBonus;
                }
                if (ChestData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + ChestData.MovementSpeedBonus;
                }
                if (ChestData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + ChestData.MultiAttackBonus;
                }
                if (ChestData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + ChestData.BlockChanceBonus;
                }
                if (ChestData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + ChestData.AbilityDamage;
                }
                if (ChestData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Recution = " + ChestData.CooldownReduction;
                }
                if (ChestData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + ChestData.AOEchanceBonus;
                }
            }
            if (Class == "Assassin")
            {
                MainDescription = description  + "\n Dodge Bonus = " + DodgeBonus + "%" + "\n Armour protection = " + ArmourStats + "\n Item Rank = " + Rank;
                if (ChestData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + Damage;
                }
                if (ChestData.HPBonus > 0)
                {
                    MainDescription += "\n Health Bonus = " + ChestData.HPBonus;
                }
                if (ChestData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + ChestData.StunChanceBonus;
                }
                if (ChestData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + ChestData.CritChance;
                }
                if (ChestData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + ChestData.CritDamageBonus;
                }
                if (ChestData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + ChestData.MovementSpeedBonus;
                }
                if (ChestData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + ChestData.MultiAttackBonus;
                }
                if (ChestData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + ChestData.BlockChanceBonus;
                }
                if (ChestData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + ChestData.AbilityDamage;
                }
                if (ChestData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Recution = " + ChestData.CooldownReduction;
                }
                if (ChestData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + ChestData.AOEchanceBonus;
                }
            }
            if (Class == "Cultist")
            {
                MainDescription = description +  "\n Stamina Regen Bonus = " + StaminaRegenBonus + "\n Armour protection = " + ArmourStats + "\n Item Rank = " + Rank;
                if (ChestData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + Damage;
                }
                if (ChestData.HPBonus > 0)
                {
                    MainDescription += "\n Health Bonus = " + ChestData.HPBonus;
                }
                if (ChestData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + ChestData.StunChanceBonus;
                }
                if (ChestData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + ChestData.CritChance;
                }
                if (ChestData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + ChestData.CritDamageBonus;
                }
                if (ChestData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + ChestData.MovementSpeedBonus;
                }
                if (ChestData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + ChestData.MultiAttackBonus;
                }
                if (ChestData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + ChestData.BlockChanceBonus;
                }
                if (ChestData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + ChestData.AbilityDamage;
                }
                if (ChestData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Recution = " + ChestData.CooldownReduction;
                }
                if (ChestData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + ChestData.AOEchanceBonus;
                }
            }
 

        }
        if (type == "Gloves")
        {
            if (Class == "Bruiser")
            {
                MainDescription = description + "\n Damage = " + Damage + "\n Health Bonus = " + HPBonus + "\n Item Rank = " + Rank;
                if (GloveData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + GloveData.StunChanceBonus;
                }
                if (GloveData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + GloveData.CritChance;
                }
                if (GloveData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + GloveData.DodgeBonus;
                }
                if (GloveData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + GloveData.MovementSpeedBonus;
                }
                if (GloveData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + GloveData.MultiAttackBonus;
                }
                if (GloveData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + GloveData.BlockChanceBonus;
                }
                if (GloveData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + GloveData.StaminaRegenBonus;
                }
                if (GloveData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + GloveData.CooldownReduction;
                }
                if (GloveData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + GloveData.AOEchanceBonus;
                }
            }
            if (Class == "Assassin")
            {
                MainDescription = description + "\n Damage = " + Damage + "\n Crit Damage Bonus = " + CritDamageBonus + "\n Item Rank = " + Rank;
                if (GloveData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + GloveData.StunChanceBonus;
                }
                if (GloveData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + GloveData.CritChance;
                }
                if (GloveData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + GloveData.DodgeBonus;
                }
                if (GloveData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + GloveData.MovementSpeedBonus;
                }
                if (GloveData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + GloveData.MultiAttackBonus;
                }
                if (GloveData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + GloveData.BlockChanceBonus;
                }
                if (GloveData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + GloveData.StaminaRegenBonus;
                }
                if (GloveData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + GloveData.CooldownReduction;
                }
                if (GloveData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + GloveData.AOEchanceBonus;
                }
            }
            if (Class == "Cultist")
            {
                MainDescription = description + "\n Damage = " + Damage + "\n Ability Damage = " + AbilityDamage + "\n Item Rank = " + Rank;
                if (GloveData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + GloveData.StunChanceBonus;
                }
                if (GloveData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + GloveData.CritChance;
                }
                if (GloveData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + GloveData.DodgeBonus;
                }
                if (GloveData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + GloveData.MovementSpeedBonus;
                }
                if (GloveData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + GloveData.MultiAttackBonus;
                }
                if (GloveData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + GloveData.BlockChanceBonus;
                }
                if (GloveData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + GloveData.StaminaRegenBonus;
                }
                if (GloveData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + GloveData.CooldownReduction;
                }
                if (GloveData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + GloveData.AOEchanceBonus;
                }
    
            }

        }
        if (type == "LegsArmour")
        {
            if (Class == "Bruiser")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus + "\n Item Rank = " + Rank;

                if (LegData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + LegData.Damage;
                }
                if (LegData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + LegData.StunChanceBonus;
                }
                if (LegData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + LegData.CritChance;
                }
                if (LegData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + LegData.CritDamageBonus;
                }
                if (LegData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + MovementSpeedBonus;
                }
                if (LegData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + LegData.MultiAttackBonus;
                }
                if (LegData.BlockChanceBonus > 0.00) {
                    MainDescription += "\n Block Chance Bonus = " + LegData.BlockChanceBonus;
                }
                if (LegData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + LegData.AbilityDamage;
                }
                if (LegData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + LegData.CooldownReduction;
                }
                if (LegData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + LegData.AOEchanceBonus;
                }
                         
            }
            if (Class == "Assassin")
            {
                MainDescription = description+ "\n Armour protection" + ArmourStats + "\n Dodge Bonus = " + DodgeBonus + "%" + "\n Item Rank = " + Rank;
                if (LegData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + LegData.Damage;
                }
                if (LegData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + LegData.StunChanceBonus;
                }
                if (LegData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + LegData.CritChance;
                }
                if (LegData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + LegData.CritDamageBonus;
                }
                if (LegData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + MovementSpeedBonus;
                }
                if (LegData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + LegData.MultiAttackBonus;
                }
                if (LegData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + LegData.BlockChanceBonus;
                }
                if (LegData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + LegData.AbilityDamage;
                }
                if (LegData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + LegData.CooldownReduction;
                }
                if (LegData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + LegData.AOEchanceBonus;
                }

            }
            if (Class == "Cultist")
            {
                MainDescription = description + "\n Armour protection" + ArmourStats + "\n Stamina Regen Bonus = " + StaminaRegenBonus + "\n Item Rank = " + Rank;
                if (LegData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + LegData.Damage;
                }
                if (LegData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + LegData.StunChanceBonus;
                }
                if (LegData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + LegData.CritChance;
                }
                if (LegData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + LegData.CritDamageBonus;
                }
                if (LegData.MovementSpeedBonus > 0)
                {
                    MainDescription += "\n Movement Speed Bonus = " + MovementSpeedBonus;
                }
                if (LegData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + LegData.MultiAttackBonus;
                }
                if (LegData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + LegData.BlockChanceBonus;
                }
                if (LegData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + LegData.AbilityDamage;
                }
                if (LegData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + LegData.CooldownReduction;
                }
                if (LegData.AOEchanceBonus > 0.00)
                {
                    MainDescription += "\n AOE Chance Bonus = " + LegData.AOEchanceBonus;
                }

            }


        }
        if (type == "BootsArmour")
        {
            if (Class == "Bruiser")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus + "\n Stun Chance Bonus = " + StunChanceBonus + "\n Item Rank = " + Rank;
                if (BootsData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + BootsData.Damage;
                }
                if (BootsData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + BootsData.StunChanceBonus;
                }
                if (BootsData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + BootsData.CritChance;
                }
                if (BootsData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + BootsData.DodgeBonus;
                }
                if (BootsData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + BootsData.CritDamageBonus;
                }
                if (BootsData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + BootsData.MultiAttackBonus;
                }
                if (BootsData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + BootsData.BlockChanceBonus;
                }
                if (BootsData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + BootsData.StaminaRegenBonus;
                }
                if (BootsData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + BootsData.AbilityDamage;
                }
                if (BootsData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + BootsData.CooldownReduction;
                }
            }
            if (Class == "Assassin")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus + "\n Movement Speed Bonus = " + MovementSpeedBonus + "\n Item Rank = " + Rank;
                if (BootsData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + BootsData.Damage;
                }
                if (BootsData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + BootsData.StunChanceBonus;
                }
                if (BootsData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + BootsData.CritChance;
                }
                if (BootsData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + BootsData.DodgeBonus;
                }
                if (BootsData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + BootsData.CritDamageBonus;
                }
                if (BootsData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + BootsData.MultiAttackBonus;
                }
                if (BootsData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + BootsData.BlockChanceBonus;
                }
                if (BootsData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + BootsData.StaminaRegenBonus;
                }
                if (BootsData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + BootsData.AbilityDamage;
                }
                if (BootsData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + BootsData.CooldownReduction;
                }
            }
            if (Class == "Cultist")
            {
                MainDescription = description + "\n Health Bonus = " + HPBonus + "\n AOE Chance Bonus = " + AOEchanceBonus + "%" + "\n Item Rank = " + Rank;
                if (BootsData.Damage > 0)
                {
                    MainDescription += "\n Damage = " + BootsData.Damage;
                }
                if (BootsData.StunChanceBonus > 0)
                {
                    MainDescription += "\n Stun Chance Bonus = " + BootsData.StunChanceBonus;
                }
                if (BootsData.CritChance > 0)
                {
                    MainDescription += "\n Crit Chance = " + BootsData.CritChance;
                }
                if (BootsData.DodgeBonus > 0.00)
                {
                    MainDescription += "\n Dodge Bonus = " + BootsData.DodgeBonus;
                }
                if (BootsData.CritDamageBonus > 0)
                {
                    MainDescription += "\n Crit Damage Bonus = " + BootsData.CritDamageBonus;
                }
                if (BootsData.MultiAttackBonus > 0)
                {
                    MainDescription += "\n Multi Attack Bonus = " + BootsData.MultiAttackBonus;
                }
                if (BootsData.BlockChanceBonus > 0.00)
                {
                    MainDescription += "\n Block Chance Bonus = " + BootsData.BlockChanceBonus;
                }
                if (BootsData.StaminaRegenBonus > 0)
                {
                    MainDescription += "\n Stamina Regen Bonus = " + BootsData.StaminaRegenBonus;
                }
                if (BootsData.AbilityDamage > 0)
                {
                    MainDescription += "\n Ability Damage = " + BootsData.AbilityDamage;
                }
                if (BootsData.CooldownReduction > 0.00)
                {
                    MainDescription += "\n Cool Down Reduction = " + BootsData.CooldownReduction;
                }

            }

         
        }

    }

    public string GetDescription()
    {
        ToolTip = GameObject.Find("ToolTip").GetComponent<Image>();
        ToolTipText = ToolTip.GetComponentInChildren<Text>();

        switch (Itemrarity)
        {
            // changes the background image to display the colour of rarity of the image. 
            case "Common":
                //dark Grey Colour
                ToolTip.GetComponent<Image>().color = new Color32(113, 113, 113,255);
                ToolTipText.GetComponent<Text>().color = new Color(0, 0, 0);
                break;
            case "UnCommon":
                //Light Green colour
                ToolTip.GetComponent<Image>().color = new Color32(95,196,84,255);
                ToolTipText.GetComponent<Text>().color = new Color(255, 255, 255);
                break;
            case "Enchanted":
                // Light blue colour
                ToolTip.GetComponent<Image>().color = new Color32(77,77,203,255);
                ToolTipText.GetComponent<Text>().color = new Color(0, 0, 0);
                break;
            case "Rare":
                // dark yellow colour
                ToolTip.GetComponent<Image>().color = new Color32(255,255,26,255);
                ToolTipText.GetComponent<Text>().color = new Color(0, 0, 0);
                break;
            case "Mystical":
                // Dark purple colour 
                ToolTip.GetComponent<Image>().color = new Color32(204, 0, 204,255);
                ToolTipText.GetComponent<Text>().color = new Color(255, 255, 255);
                break;
            case "Legendary":
                //dark Orange colour
                ToolTip.GetComponent<Image>().color = new Color32(204, 132, 0, 255);
                ToolTipText.GetComponent<Text>().color = new Color(255, 255, 255);
                break;
            case "Ancient":
                //Dark red colour
                ToolTip.GetComponent<Image>().color = new Color32(255,0,0,255);
                ToolTipText.GetComponent<Text>().color = new Color(255, 255, 255);
                break;
            case "Godly":
                // ligher grey colour
                ToolTip.GetComponent<Image>().color = new Color32(230,230,230,255);
                ToolTipText.GetComponent<Text>().color = new Color(0, 0, 0);
                break;

        }

        return Title+"\n"+MainDescription;
    }
}


