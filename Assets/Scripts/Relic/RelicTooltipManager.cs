using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicTooltipManager : MonoBehaviour
{
    public GameObject Relictooltip;
    public Text Relictooltiptext;

   private void Start()
    {
        Relictooltip = GameObject.Find("Relictooltip");
        Relictooltiptext = Relictooltip.GetComponentInChildren<Text>();
        Relictooltip.SetActive(false);
    }

  public void showRelictooltip(Vector3 position,Relictip description)
    {
        Relictooltip.SetActive(true);
        Relictooltip.transform.position = new Vector3(position.x, position.y, position.z);
        Relictooltiptext.text = description.GetRelicDescription();

        Transform PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        RectTransform Ypos = Relictooltip.transform.GetComponent<RectTransform>();

        Vector3[] RelicTooltipCorners = new Vector3[4];

        Ypos.GetWorldCorners(RelicTooltipCorners);

        Rect ScreenRect = new Rect(PlayerPos.position.x,PlayerPos.position.z, Screen.width, Screen.height);

        if (!ScreenRect.Contains(RelicTooltipCorners[1]))
        {
            float YPosition = RelicTooltipCorners[1].y - ScreenRect.yMax;
            Relictooltip.transform.position = new Vector3(position.x, position.y - YPosition, position.z);
        }

        if (!ScreenRect.Contains(RelicTooltipCorners[0]))
        {
            float YPosition = RelicTooltipCorners[0].y - ScreenRect.yMax;
            Relictooltip.transform.position = new Vector3(position.x, position.y + YPosition, position.z);
        }
    }

    public void HideRelictooltip()
    {
        Relictooltip.SetActive(false);
    }

}
