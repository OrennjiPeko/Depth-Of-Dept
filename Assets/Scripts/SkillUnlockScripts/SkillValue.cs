using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillValue : MonoBehaviour, IPointerEnterHandler
{
    //value of the skill
    public int ValueOfSkill;
    //SkillLevel
    public int SkillLevel;
    //sets to true if the player has unlocked the skill
    [HideInInspector] public bool SkillUnlocked;
    //The level the player needs to be in order to unlock the skill
    public int RequiredLevelToUnlock;
    //Description of the skill
    public string SkillDescription;

    public int CooldownTime;

    public int SkillStaminaUsage;

    private GameObject SkillToolTip;
    private string SkillName;
    private RectTransform canvas;

    private void Start()
    {
        SkillToolTip = GameObject.Find("SkillToolTip");
        canvas = GameObject.Find("GlobalData").GetComponent<RectTransform>();
        SkillName = this.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillToolTip.SetActive(true);
        
        SkillToolTip.GetComponent<SkillsTooltipManager>().SendMessage("Show" + SkillName, new Vector3(this.transform.position.x, this.transform.position.y + 20));

        Canvas.ForceUpdateCanvases();

        Vector3[] TooltipCorners = new Vector3[4];

        RectTransform XPos = SkillToolTip.GetComponent<RectTransform>();

        XPos.GetWorldCorners(TooltipCorners);

        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);

        Vector2 anchoredPosition = SkillToolTip.transform.GetComponent<RectTransform>().anchoredPosition;

        if(!screenRect.Contains(TooltipCorners[1]))
        {
            float XPosition = Mathf.Abs(TooltipCorners[1].x - screenRect.xMin);
            SkillToolTip.GetComponent<SkillsTooltipManager>().SendMessage("Show" + SkillName, new Vector3(this.transform.position.x + XPosition, this.transform.position.y + 20));
        }
    }
}
