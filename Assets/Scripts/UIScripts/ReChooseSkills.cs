using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReChooseSkills : MonoBehaviour
{
    public GameObject SkillMenu;
    public GameObject InventoryMenu;
    public GameObject InGameUI;

    // Start is called before the first frame update
    void Awake()
    {
        SkillMenu = GameObject.FindGameObjectWithTag("Canvas").transform.Find("SkillMenu").gameObject;
    }

    //opens the skill menu
    public void OpenSkillMenu()
    {
        SkillMenu.SetActive(true);
        SkillMenu.GetComponent<Skills>().CheckSkillPoints();
        //changes the skill back button to work differently as it used a GameObject on the main menu
        Button SkillBack = GameObject.Find("SkillBack").GetComponent<Button>();
        //removes previous listener
        SkillBack.onClick.RemoveAllListeners();
        //Changes the listener to close skill menu, allowing the button to work on scenes besides the main menu
        SkillBack.onClick.AddListener(delegate { CloseSkillMenu(); });
        GameObject.Find("PlayerData").GetComponent<Inventory>().SkillMenuActivated = true;
        InventoryMenu.SetActive(false);
    }

    public void CloseSkillMenu()
    {
        SkillMenu.SetActive(false);
        GameObject.Find("PlayerData").GetComponent<Inventory>().SkillMenuActivated = false;
        InventoryMenu.SetActive(true);
    }
}
