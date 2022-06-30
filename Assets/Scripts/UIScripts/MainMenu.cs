using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Settings;
    public GameObject Skill;
    public GameObject Canvas;

    private void Awake()
    {

        Menu = null;
        Settings = null;
        Skill = null;
        
        Menu = GameObject.Find("Menu");
        Settings = GameObject.Find("SettingsMenu");
        Canvas = GameObject.Find("Canvas");
        Skill = Canvas.transform.Find("SkillMenu").gameObject;
    }

    private void Start()
    {
        // sets these two Canvas as false and hidden from the player when scene loads
        Settings.SetActive(false);
        if (Skill == null)
            Skill = GameObject.Find("Canvas").transform.Find("SkillMenu").GetComponent<Skills>().SkillMenu;
        Skill.SetActive(false);
        Canvas.transform.Find("InGameUI").gameObject.SetActive(false);
        Canvas.transform.Find("Inventory").gameObject.SetActive(false);
    }


    public void NewGame()
    {
        // New Game code goes here
    }

    public void Continue()
    {
        // Contiune code goes here 
    }

    public void SetSettings()
    {
        // Deactives the Menu Canvas hiding it from the player 
        Menu.SetActive(false);
        // shows the SettingsCanvas to the player when button is clicked 
        Settings.SetActive(true);
    }

    public void SetSkills()
    {
        //Deactivates the main menu
        Menu.SetActive(false);
        //Activates skill menu
        Skill.SetActive(true);
        //GameObject.Find("Main Camera").GetComponent<SpawnDontDestroys>().UpdateSkillBackButton();
        Button SkillButton = Canvas.transform.Find("SkillMenu").Find("SkillBack").GetComponent<Button>();

        SkillButton.onClick.RemoveAllListeners();
        //Finds the skillback button and changes it's listener to one that will work on the main menu
        SkillButton.onClick.AddListener(delegate { BackSkill(); });
    }

    public void CloseGame()
    {
        // Closes the game on the click
        Application.Quit();
    }

    public void BackSetting()
    {
        //shows the player Menu Canvas again after settings been changed by the player. 
        Settings.SetActive(false);
        Menu.SetActive(true);
    }

    public void BackSkill()
    {
        Debug.Log("Go back");
        //Loads the main menu after closing skill menu
        Skill.SetActive(false);
        Menu.SetActive(true);
    }

}
