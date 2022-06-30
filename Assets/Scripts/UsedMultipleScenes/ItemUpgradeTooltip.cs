using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUpgradeTooltip : MonoBehaviour
{
    public GameObject UpgradeTooltip;
    public Text UpgradeToolText;
    public int ItemRank;
    public float Gold;
    public float GoldNeeded;
    
    // Start is called before the first frame update
    void Start()
    {
        //Finds the upgrade tool tip and it's text
        UpgradeTooltip = GameObject.Find("UpgradeToolTip");
        UpgradeToolText = UpgradeTooltip.GetComponentInChildren<Text>();
        UpgradeTooltip.SetActive(false);
        ItemRank = GameObject.Find("ItemCopy").GetComponent<Item>().Rank;
        Gold = GameObject.Find("ItemCopy").GetComponent<Item>().Gold;
       
    }

    public void NeededGold(GameObject Button)
    {
        //Checks if the button has been stored
        if (Button != null)
        {
            //Gets the item rank from the item connected to the button
            ItemRank = Button.GetComponentInChildren<Item>().Rank;
            if (Button.GetComponent<Slot>().item != null)
            {
                //Makes the upgrade item tool tip visable
                UpgradeTooltip.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Button not sent over");
        }

        //Sets the tooltip's text
        GoldNeeded = Button.GetComponentInChildren<Item>().GoldNeeded;
        UpgradeToolText.text = "Costs " + GoldNeeded + " Gold to Uprgade Item";

        Button = null;
    }

    public void HideMe()
    {
        //If the system can't find the tool tip it will look for the tool tip
        if(UpgradeTooltip == null)
        {
            Debug.Log("Lost Tooltip");
            UpgradeTooltip = GameObject.Find("UpgradeToolTip");
            UpgradeToolText = UpgradeTooltip.GetComponentInChildren<Text>();
        }
        //Makes the tooltip not visable
        UpgradeTooltip.SetActive(false);
        //Removes text
        UpgradeToolText.text = "";
    }
}
