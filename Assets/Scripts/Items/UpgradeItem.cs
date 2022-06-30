using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Stores the specfic upgrade buttons parent to be referenced when upgrading an item
    public Slot Parent;
    //Stores the tool tip to allow access to it's mechanics
    private ItemUpgradeTooltip ToolTip;

    private void Awake()
    {
        //Finds the tooltip which is needed to displayed whenever the player moves the mouse over the upgrade button
        ToolTip = GameObject.Find("UpgradeToolTip").GetComponent<ItemUpgradeTooltip>();
    }

    public void LevelUpItem()
    {
        //Upgrades the item
        Parent.item.UpgradeItems();
        ToolTip.NeededGold(Parent.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Activates script that displays the tooltip and changes the text
        ToolTip.NeededGold(Parent.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Hides the tooltip when the player moves the mouse of the upgrade button
        ToolTip.HideMe();
    }
}
