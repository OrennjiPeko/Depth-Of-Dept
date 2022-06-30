using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public bool inventoryEnabled;
    [HideInInspector] public GameObject inventory;
    [HideInInspector] public GameObject InGameUI;
    [HideInInspector] public GameObject SlotHolder;
    [HideInInspector] public GameObject SkillTooltip;
    [HideInInspector] public GameObject UpgradeTooltip;

    //Stores the number of slots in the inventory along with the slots themselves
    [HideInInspector]public int allSlots;
    private int enabledSlots;
    public GameObject[] Slot;
    public GameObject Tooltip;

    //Booleans used to track if items have been equipped
    [HideInInspector] public bool WeaponEquippedCheck;
    [HideInInspector] public bool HeadArmourEquippedCheck;
    [HideInInspector] public bool ChestArmourEquippedCheck;
    [HideInInspector] public bool LegsArmourEquippedCheck;
    [HideInInspector] public bool GlovesEquippedCheck;
    [HideInInspector] public bool BootsEquippedCheck;

    //Stored the equipped items
    [HideInInspector] public Item WeaponEquipped;
    [HideInInspector] public Item HeadArmourEquipped;
    [HideInInspector] public Item ChestArmourEquipped;
    [HideInInspector] public Item LegsArmourEquipped;
    [HideInInspector] public Item GlovesEquipped;
    [HideInInspector] public Item BootsEquipped;

    //Stores the information on the items the player has collected
    public List<Item> CollectedItems = new List<Item>();
    public GameObject SkillMenu;
    [HideInInspector] public bool SkillMenuActivated;

    public static System.Action SaveInitiated;

    private Scene scene;

    [HideInInspector] public GameObject LoadingScreen;

    private void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        scene = SceneManager.GetActiveScene();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetInGameUITrue()
    {
        InGameUI.SetActive(true);
        LoadingScreen.SetActive(true);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Prevents inventory from activating on main menu
        if (string.Equals(scene.path, this.scene.path)) return;

        //Counts the amount of slots the player has
        allSlots = SlotHolder.transform.childCount;

        Slot = new GameObject[allSlots];

        //Adds the slots into an array untill all the slots are used up
        for (int i = 0; i < allSlots; i++)
        {
            Slot[i] = SlotHolder.transform.GetChild(i).gameObject;

            if (Slot[i].GetComponent<Slot>().item == null)
                Slot[i].GetComponent<Slot>().empty = true;
        }

        //Sets the inventory and in game UI to no longer be visable
        InGameUI.SetActive(true);
        LoadingScreen.SetActive(false);
        inventory.SetActive(false);
        SkillMenu.SetActive(false);
        SkillMenuActivated = false;
        Tooltip.SetActive(false);
        UpgradeTooltip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "GameOver")
        {
            if (SceneManager.GetActiveScene().name == "GameOver")
            {
                InGameUI.SetActive(false);
            }
            return;
        }
        //Pauses the game/unpauses the game
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
        {
            //Stops the rest of the game from moving
            Time.timeScale = 0;
            //Makes the in game UI invisable as to not overlap with the pause menu
            InGameUI.SetActive(false);
            //Updates the player's stats in the menu
            GameObject.Find("Player").GetComponent<PlayerCombat>().SetStats();
            //Hids inventory if the skill menu has been opened
            if (SkillMenuActivated == false)
                inventory.SetActive(true);
        }
        else
        {
            if (GameObject.Find("PlayerData").GetComponent<RelicInventory>().RelicinventoryEnabled == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                //Sets the game to move again
                Time.timeScale = 1;
            }
           
            //in game ui is visable again
            InGameUI.SetActive(true);
            //Sets the inventory and in game UI to no longer be visable
            inventory.SetActive(false);
            SkillMenu.SetActive(false);
            SkillMenuActivated = false;
            Tooltip.SetActive(false);
            UpgradeTooltip.SetActive(false);  
        }
    }

    public void AddItem(GameObject ItemObject, Item Item, int itemId, string itemType, string itemDescription, Sprite ItemIcon)
    {   
        for (int i = 0; i < allSlots; i++)
        {
            if (Slot[i].GetComponent<Slot>().empty == true)
            {
                if (Slot[i].GetComponent<Slot>().empty)
                {
                    //add item to slot
                    ItemObject.GetComponent<Item>().PickedUp = true;

                    //Set the information in the slot to match the item's
                    Slot[i].GetComponent<Slot>().item = Item;
                    Slot[i].GetComponent<Slot>().icon = ItemIcon;
                    Slot[i].GetComponent<Slot>().type = itemType;
                    Slot[i].GetComponent<Slot>().ID = itemId;
                    Slot[i].GetComponent<Slot>().description = itemDescription;
                    Slot[i].GetComponent<Slot>().Rank = Item.Rank;
                    //Creates a copy of the item for everything to be stored
                    Slot[i].GetComponent<Slot>().CreateItemCopy();

                    Destroy(ItemObject);

                    Slot[i].GetComponent<Slot>().UpdateSlot();
                    Slot[i].GetComponent<Slot>().empty = false;
                }
                return;
            }
        }

    }

    public void ReApplyBuffs()
    {
        //Reapplies the equipped items' buffs

        if (WeaponEquipped != null)
            WeaponEquipped.GetComponent<Item>().ItemUsage();
        
        
        if(HeadArmourEquipped != null)
            HeadArmourEquipped.GetComponent<Item>().ItemUsage();
        

        if (ChestArmourEquipped != null)
            ChestArmourEquipped.GetComponent<Item>().ItemUsage();

        if (GlovesEquipped != null)
            GlovesEquipped.GetComponent<Item>().ItemUsage();

        if (LegsArmourEquipped != null)
            LegsArmourEquipped.GetComponent<Item>().ItemUsage();

        if (BootsEquipped != null)
            BootsEquipped.GetComponent<Item>().ItemUsage();
    }


    //Sends the player's inventory data to get saved on disk
    public void SaveInventory()
    {
        this.GetComponent<SaveplayerInventory>().FillLists();
    }
}
