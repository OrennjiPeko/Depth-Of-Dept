using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour
{
    
    public GameObject Tooltip;
    public Text TooltipText;

    private void Start()
    {
        Tooltip = GameObject.Find("ToolTip");
        TooltipText = Tooltip.GetComponentInChildren<Text>();
        Tooltip.SetActive(false);

    }


    public void ShowTooltip(Vector3 position,Itemtip description)
    {
        //Makes the tooltip viewable
        Tooltip.SetActive(true);

        //Sets initial position of the tooltip
        Tooltip.transform.position = new Vector3(position.x, position.y, position.z);
        //Gets the item's description
        TooltipText.text = description.GetDescription();

        //Forces canvas to update the size of the image
        Canvas.ForceUpdateCanvases();

        Transform PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Stores the tooltips transform
        RectTransform YPos = Tooltip.transform.GetComponent<RectTransform>();

        //Will store the corners of the tool tip
        Vector3[] ToolTipCorners = new Vector3[4];

        //Stores the location of the corners of the tooltips
        YPos.GetWorldCorners(ToolTipCorners);

        //Creates a rectange that is the size of the screen
        Rect screenRect = new Rect(PlayerPos.position.x, PlayerPos.position.y, Screen.width, Screen.height);

        //check if top left corner is in the screen
        if (!screenRect.Contains(ToolTipCorners[1]))
        {
            float YPosition = ToolTipCorners[1].y - screenRect.yMax;
            Tooltip.transform.position = new Vector3(position.x, position.y - YPosition, position.z);
        }

        //Check if bottom left corner is in the screen
        if (!screenRect.Contains(ToolTipCorners[0]))
        {
            float YPosition = Mathf.Abs(ToolTipCorners[0].y + screenRect.yMin);
            Tooltip.transform.position = new Vector3(position.x, position.y + YPosition, position.z);
        }
    }

    public void hideTooltip()
    {
        Tooltip.SetActive(false);
        TooltipText.text = "";
    }
}
