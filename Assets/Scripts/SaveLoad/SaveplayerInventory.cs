using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveplayerInventory : MonoBehaviour
{
    //Stores the a list of the different items
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

    //Blank item prefab to place save item details
    public GameObject BlankItem;

    public void FillLists()
    {
        //Gets the list of items the player has collected
        List<Item> CollectedItems = GameObject.Find("PlayerData").GetComponent<Inventory>().CollectedItems;

        //Seperates the items based on the type of item
        foreach(Item item in CollectedItems)
        {
            switch (item.type)
            {
                case "Weapon":
                    {
                        WeaponsCollectedID.Add(item.ID);
                        WeaponCollectedRank.Add(item.Rank);
                        WeaponsCollectedRarity.Add(item.Itemrarity);
                        break;
                    }
                case "HeadArmour":
                    {
                        HeadArmourCollectedID.Add(item.ID);
                        HeadArmourCollectedRank.Add(item.Rank);
                        HeadArmourCollectedRarity.Add(item.Itemrarity);
                        break;
                    }
                case "ChestArmour":
                    {
                        ChestArmourCollectedID.Add(item.ID);
                        ChestArmourCollectedRank.Add(item.Rank);
                        ChestArmourCollectedRarity.Add(item.Itemrarity);
                        break; 
                    }
                case "Gloves":
                    {
                        GlovesCollectedId.Add(item.ID);
                        GlovesCollectedRank.Add(item.Rank);
                        GlovesCollectedRarity.Add(item.Itemrarity);
                        break;
                    }
                case "LegsArmour":
                    {
                        LegsArmourCollectedId.Add(item.ID);
                        LegsArmourCollectedRank.Add(item.Rank);
                        LegsArmourCollectedRarity.Add(item.Itemrarity);
                        break;
                    }
                case "BootsArmour":
                    {
                        BootsCollectedID.Add(item.ID);
                        BootsArmourCollectdRank.Add(item.Rank);
                        BootsCollectedRarity.Add(item.Itemrarity);
                        break;
                    }
            }
        }
        //Sends the lists to be the file that gets saved
        SaveBinaryInventory.SaveInvenotry(this);

        //Clears the lists as to prevent items being duplicated whenever the game saves multiple times per session
        WeaponsCollectedID.Clear();
        WeaponCollectedRank.Clear();
        WeaponsCollectedRarity.Clear();
        HeadArmourCollectedID.Clear();
        HeadArmourCollectedRank.Clear();
        HeadArmourCollectedRarity.Clear();
        ChestArmourCollectedID.Clear();
        ChestArmourCollectedRank.Clear();
        ChestArmourCollectedRarity.Clear();
        GlovesCollectedId.Clear();
        GlovesCollectedRank.Clear();
        GlovesCollectedRarity.Clear();
        LegsArmourCollectedId.Clear();
        LegsArmourCollectedRank.Clear();
        LegsArmourCollectedRarity.Clear();
        BootsCollectedID.Clear();
        BootsArmourCollectdRank.Clear();
        BootsCollectedRarity.Clear();
    }

    public void LoadPlayerInventory()
    {
        //Gets the ID of the items the player saved
        SaveSystem data = SaveBinaryInventory.LoadInventory();
        WeaponsCollectedID = data.WeaponsCollectedID;
        HeadArmourCollectedID = data.HeadArmourCollectedID;
        ChestArmourCollectedID = data.ChestArmourCollectedID;
        GlovesCollectedId = data.GlovesCollectedId;
        LegsArmourCollectedId = data.LegsArmourCollectedId;
        BootsCollectedID = data.BootsCollectedID;

        WeaponCollectedRank = data.WeaponCollectedRank;
        HeadArmourCollectedRank = data.HeadArmourCollectedRank;
        ChestArmourCollectedRank = data.ChestArmourCollectedRank;
        GlovesCollectedRank = data.GlovesCollectedRank;
        LegsArmourCollectedRank = data.LegsArmourCollectedRank;
        BootsArmourCollectdRank = data.BootsArmourCollectdRank;

        WeaponsCollectedRarity = data.WeaponsCollectedRarity;
        HeadArmourCollectedRarity = data.HeadArmourCollectedRarity;
        ChestArmourCollectedRarity = data.ChestArmourCollectedRarity;
        GlovesCollectedRarity = data.GlovesCollectedRarity;
        LegsArmourCollectedRarity = data.LegsArmourCollectedRarity;
        BootsCollectedRarity = data.BootsCollectedRarity;

        //Checks to see if there are weapon IDs stored
        if (WeaponsCollectedID != null)
        {
            WeaponDetails[] AllWeapons = Resources.FindObjectsOfTypeAll<WeaponDetails>();
            for (int i = 0; i < WeaponsCollectedID.Count; i++)
            {
                int WeaponID = WeaponsCollectedID[i];
                //Goes through all the weapons
                foreach(WeaponDetails weapon in AllWeapons)
                {
                    if(weapon.ID == WeaponID)
                    {
                        WeaponDetails Item = weapon;
                        //Spawns a blank item with no details
                        GameObject MyInstantiate = Instantiate(BlankItem, new Vector3(-10, -10, -10), Quaternion.identity);
                        //Sets the item's details to match those of the item saved
                        MyInstantiate.GetComponent<Item>().data = Item;
                        MyInstantiate.GetComponent<Item>().Itemrarity = WeaponsCollectedRarity[i];
                        MyInstantiate.GetComponent<Item>().Rank = WeaponCollectedRank[i];
                        //Sets boolean that will activate code that will add the item to the player's inventory
                        MyInstantiate.GetComponent<Item>().FromSaveFile = true;
                    }
                }
            }
        }

        //Checks to see if there are Head Armour IDs stored
        if (HeadArmourCollectedID != null)
        {
            HeadPieceDetials[] AllHeadArmour = Resources.FindObjectsOfTypeAll<HeadPieceDetials>();
            for (int i = 0; i < HeadArmourCollectedID.Count; i++)
            {
                int HeadID = HeadArmourCollectedID[i];
                foreach(HeadPieceDetials HeadArmour in AllHeadArmour)
                {
                    if(HeadArmour.ID == HeadID)
                    {
                        HeadPieceDetials Item = HeadArmour;
                        //Spawns a blank item with no details
                        GameObject MyInstantiate = Instantiate(BlankItem, new Vector3(-10, -10, -10), Quaternion.identity);
                        //Sets the item's details to match those of the item saved
                        MyInstantiate.GetComponent<Item>().HeadData = Item;
                        MyInstantiate.GetComponent<Item>().Itemrarity = HeadArmourCollectedRarity[i];
                        MyInstantiate.GetComponent<Item>().Rank = HeadArmourCollectedRank[i];
                        //Sets boolean that will activate code that will add the item to the player's inventory
                        MyInstantiate.GetComponent<Item>().FromSaveFile = true;
                    }
                }
            }
           
        }

        //Checks to see if there are chest armour IDs stored
        if (ChestArmourCollectedID != null)
        {
            ChestArmourDetails[] AllChestArmour = Resources.FindObjectsOfTypeAll<ChestArmourDetails>();
            for (int i = 0; i < ChestArmourCollectedID.Count; i++)
            {
                int ChestID = ChestArmourCollectedID[i];
                foreach(ChestArmourDetails ChestArmour in AllChestArmour)
                {
                    if(ChestArmour.ID == ChestID)
                    {
                        ChestArmourDetails Item = ChestArmour;
                        //Spawns a blank item with no details
                        GameObject MyInstantiate = Instantiate(BlankItem, new Vector3(-10, -10, -10), Quaternion.identity);
                        //Sets the item's details to match those of the item saved
                        MyInstantiate.GetComponent<Item>().ChestData = Item;
                        MyInstantiate.GetComponent<Item>().Itemrarity = ChestArmourCollectedRarity[i];
                        MyInstantiate.GetComponent<Item>().Rank = ChestArmourCollectedRank[i];
                        //Sets boolean that will activate code that will add the item to the player's inventory
                        MyInstantiate.GetComponent<Item>().FromSaveFile = true;
                    }
                }
            }
        }

        //Checks to see if there are Glove IDs stored
        if (GlovesCollectedId != null)
        {
            GlovesDetails[] AllGloves = Resources.FindObjectsOfTypeAll<GlovesDetails>();
            for (int i = 0; i < GlovesCollectedId.Count; i++)
            {
                int GlovesID = GlovesCollectedId[i];
                foreach(GlovesDetails Glove in AllGloves)
                {
                    if(Glove.ID == GlovesID)
                    {
                        GlovesDetails Item = Glove;
                        //Spawns a blank item with no details
                        GameObject MyInstantiate = Instantiate(BlankItem, new Vector3(-10, -10, -10), Quaternion.identity);
                        //Sets the item's details to match those of the item saved
                        MyInstantiate.GetComponent<Item>().GloveData = Item;
                        MyInstantiate.GetComponent<Item>().Itemrarity = GlovesCollectedRarity[i];
                        MyInstantiate.GetComponent<Item>().Rank = GlovesCollectedRank[i];
                        //Sets boolean that will activate code that will add the item to the player's inventory
                        MyInstantiate.GetComponent<Item>().FromSaveFile = true;
                    }
                }
            }
        }

        //Checks to see if there are Legs Armour IDs stored
        if (LegsArmourCollectedId != null)
        {
            LegsArmourDetails[] AllLegArmour = Resources.FindObjectsOfTypeAll<LegsArmourDetails>();
            for (int i = 0; i < LegsArmourCollectedId.Count; i++)
            {
                int LegsID = LegsArmourCollectedId[i];
                foreach(LegsArmourDetails LegArmour in AllLegArmour)
                {
                    if(LegArmour.ID == LegsID)
                    {
                        LegsArmourDetails Item = LegArmour;
                        //Spawns a blank item with no details
                        GameObject MyInstantiate = Instantiate(BlankItem, new Vector3(-10, -10, -10), Quaternion.identity);
                        //Sets the item's details to match those of the item saved
                        MyInstantiate.GetComponent<Item>().LegData = Item;
                        MyInstantiate.GetComponent<Item>().Itemrarity = LegsArmourCollectedRarity[i];
                        MyInstantiate.GetComponent<Item>().Rank = LegsArmourCollectedRank[i];
                        //Sets boolean that will activate code that will add the item to the player's inventory
                        MyInstantiate.GetComponent<Item>().FromSaveFile = true;
                    }
                }
            }
        }

        //Checks to see if there are Boot IDs stored
        if (BootsCollectedID != null)
        {
            BootsDetails[] AllBoots = Resources.FindObjectsOfTypeAll<BootsDetails>();
            for (int i = 0; i < BootsCollectedID.Count; i++)
            {
                int BootsID = BootsCollectedID[i];
                foreach(BootsDetails Boot in AllBoots)
                {
                    if(Boot.ID == BootsID)
                    {
                        BootsDetails Item = Boot;
                        //Spawns a blank item with no details
                        GameObject MyInstantiate = Instantiate(BlankItem, new Vector3(-10, -10, -10), Quaternion.identity);
                        //Sets the item's details to match those of the item saved
                        MyInstantiate.GetComponent<Item>().BootsData = Item;
                        MyInstantiate.GetComponent<Item>().Itemrarity = BootsCollectedRarity[i];
                        MyInstantiate.GetComponent<Item>().Rank = BootsArmourCollectdRank[i];
                        //Sets boolean that will activate code that will add the item to the player's inventory
                        MyInstantiate.GetComponent<Item>().FromSaveFile = true;
                    }
                }
            }
        }

        //Clears out lists to prevent duplicates when next saving items
        WeaponsCollectedID.Clear();
        WeaponCollectedRank.Clear();
        HeadArmourCollectedID.Clear();
        HeadArmourCollectedRank.Clear();
        ChestArmourCollectedID.Clear();
        ChestArmourCollectedRank.Clear();
        GlovesCollectedId.Clear();
        GlovesCollectedRank.Clear();
        LegsArmourCollectedId.Clear();
        LegsArmourCollectedRank.Clear();
        BootsCollectedID.Clear();
        BootsArmourCollectdRank.Clear();
    }
}
