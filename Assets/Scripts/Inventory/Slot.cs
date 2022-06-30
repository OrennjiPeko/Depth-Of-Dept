using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IPointerExitHandler
{
   //Stores the information about the item in the slot
   [HideInInspector]public Item item;
    public Transform ItemCopy;
   [HideInInspector] public int ID;
   [HideInInspector] public string type;
   [HideInInspector] public string description;
   [HideInInspector] public bool empty;
   [HideInInspector] public int Rank;
   [HideInInspector] public Sprite icon;

   [HideInInspector] public Transform slotIconGO;

    //Stores the inventory
    private Inventory inventory;



    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (item.type == "Weapon")
        {
            //checks to see if an item is equipped and activates the approriate code
            if (inventory.WeaponEquippedCheck == false)
            {
                //Equip the item as usual, stores the equipped item in the inventory for later use
                UseItem();
                inventory.WeaponEquippedCheck = true;
                inventory.WeaponEquipped = item;
            }
            else
            {
                //checks to see if the item clicked is as the item equipped
                if (inventory.WeaponEquipped == item)
                {
                    //If it's the same then remove the item and it's buff, empties the equipped weapon variable
                    RemoveItem();
                    inventory.WeaponEquippedCheck = false;
                    inventory.WeaponEquipped = null;
                }
                else
                {
                    //Activates the function in the item script to equip a different item
                    item.EquipDifferentWeapon();
                    //changes the item stored in weapon equipped
                    inventory.WeaponEquipped = item;
                }
            }
        }
        else if(item.type == "HeadArmour")
        {
            //checks to see if an item is equipped and activates the approriate code
            if (inventory.HeadArmourEquippedCheck == false)
            {
                //Equip the item as usual, stores the equipped item in the inventory for later use
                UseItem();
                inventory.HeadArmourEquippedCheck = true;
                inventory.HeadArmourEquipped = item;
            }
            else
            {
                //checks to see if the item clicked is as the item equipped
                if (inventory.HeadArmourEquipped == item)
                {
                    //If it's the same then remove the item and it's buff, empties the equipped weapon variable
                    RemoveItem();
                    inventory.HeadArmourEquippedCheck = false;
                    inventory.HeadArmourEquipped = null;
                }
                else
                {
                    //Activates the function in the item script to equip a different item
                    item.EquipDifferentHeadArmour();
                    //changes the item stored in head armour equipped
                    inventory.HeadArmourEquipped = item;
                }
            }
        }
        else if(item.type == "ChestArmour")
        {
            //checks to see if an item is equipped and activates the approriate code
            if (inventory.ChestArmourEquippedCheck == false)
            {
                //Equip the item as usual, stores the equipped item in the inventory for later use
                UseItem();
                inventory.ChestArmourEquippedCheck = true;
                inventory.ChestArmourEquipped = item;
            }
            else
            {
                //checks to see if the item clicked is as the item equipped
                if (inventory.ChestArmourEquipped == item)
                {
                    //If it's the same then remove the item and it's buff, empties the equipped weapon variable
                    RemoveItem();
                    inventory.ChestArmourEquippedCheck = false;
                    inventory.ChestArmourEquipped = null;
                }
                else
                {
                    //Activates the function in the item script to equip a different item
                    item.EquipDifferentChestArmour();
                    //changes the item stored in weapon equipped
                    inventory.ChestArmourEquipped = item;
                }
            }
        }
        else if(item.type == "Gloves")
        {
            //checks to see if an item is equipped and activates the approriate code
            if (inventory.GlovesEquippedCheck == false)
            {
                //Equip the item as usual, stores the equipped item in the inventory for later use
                UseItem();
                inventory.GlovesEquippedCheck= true;
                inventory.GlovesEquipped = item;
            }
            else
            {
                //checks to see if the item clicked is as the item equipped
                if (inventory.GlovesEquipped == item)
                {
                    //If it's the same then remove the item and it's buff, empties the equipped weapon variable
                    RemoveItem();
                    inventory.GlovesEquippedCheck = false;
                    inventory.GlovesEquipped = null;
                }
                else
                {
                    //Activates the function in the item script to equip a different item
                    item.EquipDifferentGloves();
                    //changes the item stored in weapon equipped
                    inventory.GlovesEquipped = item;
                }
            }
        }
        else if(item.type == "LegsArmour")
        {
            //checks to see if an item is equipped and activates the approriate code
            if (inventory.LegsArmourEquippedCheck == false)
            {
                //Equip the item as usual, stores the equipped item in the inventory for later use
                UseItem();
                inventory.LegsArmourEquippedCheck = true;
                inventory.LegsArmourEquipped = item;
            }
            else
            {
                //checks to see if the item clicked is as the item equipped
                if (inventory.LegsArmourEquipped == item)
                {
                    //If it's the same then remove the item and it's buff, empties the equipped weapon variable
                    RemoveItem();
                    inventory.LegsArmourEquippedCheck = false;
                    inventory.LegsArmourEquipped = null;
                }
                else
                {
                    //Activates the function in the item script to equip a different item
                    item.EquipDifferentLegsArmour();
                    //changes the item stored in weapon equipped
                    inventory.LegsArmourEquipped = item;
                }
            }
        }
        else if(item.type == "BootsArmour")
        {
            //checks to see if an item is equipped and activates the approriate code
            if (inventory.BootsEquippedCheck == false)
            {
                //Equip the item as usual, stores the equipped item in the inventory for later use
                UseItem();
                inventory.BootsEquippedCheck = true;
                inventory.BootsEquipped = item;
            }
            else
            {
                //checks to see if the item clicked is as the item equipped
                if (inventory.BootsEquipped == item)
                {
                    //If it's the same then remove the item and it's buff, empties the equipped weapon variable
                    RemoveItem();
                    inventory.BootsEquippedCheck = false;
                    inventory.BootsEquipped = null;
                }
                else
                {
                    //Activates the function in the item script to equip a different item
                    item.EquipDifferentBootsArmour();
                    //changes the item stored in weapon equipped
                    inventory.BootsEquipped = item;
                }
            }
        }
    }


    private void Start()
    {
        slotIconGO = transform.GetChild(0);
        ItemCopy = transform.GetChild(1);
        //stored the inventory script that the player has for use later
        inventory = GameObject.Find("PlayerData").GetComponent<Inventory>();
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.ItemUsage();
    }

    public void RemoveItem()
    {
        item.RemoveItem();
    }

    //creates copy of the items information and stores it in an empty gameobject attached to the slot
    public void CreateItemCopy()
    {
        //Sets all the details to be the same as the item it's copying
        item.SetTitle();
        ItemCopy.GetComponent<Item>().ID = item.ID;
        ItemCopy.GetComponent<Item>().Damage = item.Damage;
        ItemCopy.GetComponent<Item>().type = item.type;
        ItemCopy.GetComponent<Item>().description = item.description;
        ItemCopy.GetComponent<Item>().icon = item.icon;
        ItemCopy.GetComponent<Item>().data = item.data;
        ItemCopy.GetComponent<Item>().HeadData = item.HeadData;
        ItemCopy.GetComponent<Item>().ChestData = item.ChestData;
        ItemCopy.GetComponent<Item>().GloveData = item.GloveData;
        ItemCopy.GetComponent<Item>().LegData = item.LegData;
        ItemCopy.GetComponent<Item>().BootsData = item.BootsData;
        ItemCopy.GetComponent<Item>().Rank = item.Rank;
        ItemCopy.GetComponent<Item>().ItemName = item.ItemName;
        ItemCopy.GetComponent<Item>().Title = item.Title;
        ItemCopy.GetComponent<Item>().Class = item.Class;
        ItemCopy.GetComponent<Item>().HPBonus = item.HPBonus;
        ItemCopy.GetComponent<Item>().BlockChanceBonus = item.BlockChanceBonus;
        ItemCopy.GetComponent<Item>().StaminaRegenBonus = item.StaminaRegenBonus;
        ItemCopy.GetComponent<Item>().CritChance = item.CritChance;
        ItemCopy.GetComponent<Item>().CooldownReduction = item.CooldownReduction;
        ItemCopy.GetComponent<Item>().CritDamageBonus = item.CritDamageBonus;
        ItemCopy.GetComponent<Item>().DodgeBonus = item.DodgeBonus;
        ItemCopy.GetComponent<Item>().Gold = item.Gold;
        ItemCopy.GetComponent<Item>().AbilityDamage = item.AbilityDamage;
        ItemCopy.GetComponent<Item>().AOEchanceBonus = item.AOEchanceBonus;
        ItemCopy.GetComponent<Item>().MovementSpeedBonus = item.MovementSpeedBonus;
        ItemCopy.GetComponent<Item>().MultiAttackBonus = item.MultiAttackBonus;
        ItemCopy.GetComponent<Item>().StunChanceBonus = item.StunChanceBonus;
        ItemCopy.GetComponent<Item>().MainDescription = item.MainDescription;
        ItemCopy.GetComponent<Item>().GoldNeeded = item.GoldNeeded;
        ItemCopy.GetComponent<Item>().Itemrarity = item.Itemrarity;
        ItemCopy.GetComponent<Item>().ArmourStats = item.ArmourStats;
        //Changes the item be the clone
        item = ItemCopy.GetComponent<Item>();
        //Adds the clone item to the inventory
        GameObject.Find("PlayerData").GetComponent<Inventory>().CollectedItems.Add(item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (empty == false)
        {
            GameObject.Find("Canvas").GetComponent<ToolTipManager>().ShowTooltip(transform.position,item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Find("Canvas").GetComponent<ToolTipManager>().hideTooltip();
    }

    //Removes the item in the currentl slot
    public void DeleteItem()
    {
        ID = 0;
        type = null;
        description = null;
        //Items can now be placed in the slot
        empty = true;
        Rank = 0;
        icon = null;
        //Unequips item if equipped
        if (item.Equipped)
        {
            item.RemoveItem();
        }
        //Updates slot icon
        UpdateSlot();
        //Removes the item from the collected items list
        GameObject.Find("PlayerData").GetComponent<Inventory>().CollectedItems.Remove(item);
        //Removes all the information from the item copy
        item.ID = 0;
        item.Damage = 0;
        item.type = null;
        item.description = null;
        item.icon = null;
        item.data = null;
        item.HeadData = null;
        item.ChestData = null;
        item.GloveData = null;
        item.LegData = null;
        item.BootsData = null;
        item.Rank = 0;
        item.ItemName = null;
        item.Title = null;
        item.Class = null;
        item.HPBonus = 0;
        item.BlockChanceBonus = 0;
        item.StaminaRegenBonus = 0;
        item.CritChance = 0;
        item.CooldownReduction = 0;
        item.DodgeBonus = 0;
        item.Gold = 0;
        item.AbilityDamage = 0;
        item.AOEchanceBonus = 0;
        item.MovementSpeedBonus = 0;
        item.MultiAttackBonus = 0;
        item.StunChanceBonus = 0;
        item.ArmourStats = 0;
        item.MainDescription = null;
        item.GoldNeeded = 0;
        item.Itemrarity = null;
    }
}
