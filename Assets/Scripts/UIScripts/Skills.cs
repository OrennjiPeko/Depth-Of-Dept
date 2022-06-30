using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;

public class Skills : MonoBehaviour
{
    public float PlayerLevel;
    
    //Send information to the gameobject that stores information for use over multiple scenes
    public GameObject GlobalData;

    public GameObject SkillMenu;

    //Stores all the skill choice buttons to change interactability
    private GameObject[] Skill1Skills;
    private GameObject[] Skill1Buffs;
    private GameObject[] Skill2Skills;
    private GameObject[] Skill2Buffs;
    private GameObject[] Skill3Skills;
    private GameObject[] Skill3Buffs;
    private GameObject[] PassiveAbilties;
    private GameObject[] UltimateSkills;
    private GameObject[] UltimateBuffs;

    //Button used to remove skills, variable to store it to change interactability
    public Button RemoveSkill1Button;
    public Button RemoveSkill2Button;
    public Button RemoveSkill3Button;
    public Button RemoveBuff1Button;
    public Button RemoveBuff2Button;
    public Button RemoveBuff3Button;
    public Button RemoveUltimateSkillButton;
    public Button RemoveUltimateBuffButton;
    public Button IncreaseSpeedRankButton;
    public Button IncreaseAutoAttackRankButton;
    public Button IncreaseHealthRegenButton;

    //Stored the chosen skill
    private GameObject Skill1;
    private GameObject Skill2;
    private GameObject Skill3;
    private GameObject Buff1;
    private GameObject Buff2;
    private GameObject Buff3;
    private GameObject UltimateSkill;
    private GameObject UltimateBuff;

    //Changes text to show player the skills chosen
    public Text ChosenSkill1;
    public Text ChosenSkill2;
    public Text ChosenSkill3;
    public Text ChosenBuff1;
    public Text ChosenBuff2;
    public Text ChosenBuff3;
    public Text ChosenUltimateSkill;
    public Text ChosenUltimateBuff;
    public Text CurrentSpeedRank;
    public Text CurrentAutoAttackRank;
    public Text CurrentHealthRegenRank;
    public string Description;

    //stores and displays skill points
    public int SkillPoints;
    public Text SkillPointsText;
    //Stores the skills that have been unlocked
    [HideInInspector] public string UnlockedAbilities;
    
    //Used to increase speed rank
    [HideInInspector]public int SpeedRank = 5;
    private int PlayerSpeed = 5;
    private int SkillPointNeededToIncreaseSpeed = 5;

    //Used to increase auto attack rate
    private int AutoAttackRate = 5;
    private int SkillPointsNeededToIncreaseAutoAttackRate = 5;

    //Used to increase the health regen rank
    [HideInInspector]public int HealthRegenRank = 5;
    private int SkillPointsNeededToIncreaseHealthRegen = 5;

    public int Gold;
    private UpgradeSkills SkillLevelTracker;

    private bool LoadPassive;

    //Default stats
    private int SpeedDefault;
    private int AttackSpeedDefault;
    private int HealthRegenDefault;
    private int SpeedSkillPointsDefault;
    private int AutoAttackSkillPointsDefault;
    private int HealthRegenSkillPointsDefault;

    private void Start()
    {
        GlobalData = GameObject.FindGameObjectWithTag("GlobalData");
        
        if(RemoveSkill1Button == null)
        {
            Debug.Log("Button not found");
        }

        //Remove skill button can't be interactable at the start since the player hasn't chosen any skills
        RemoveSkill1Button.interactable = false;
        RemoveSkill2Button.interactable = false;
        RemoveSkill3Button.interactable = false;
        RemoveBuff1Button.interactable = false;
        RemoveBuff2Button.interactable = false;
        RemoveBuff3Button.interactable = false;
        RemoveUltimateSkillButton.interactable = false;
        RemoveUltimateBuffButton.interactable = false;

        //Finds all the buttons with the tag skill buttons
        Skill1Skills = GameObject.FindGameObjectsWithTag("1SlotSkill");
        Skill1Buffs = GameObject.FindGameObjectsWithTag("1SlotBuff");
        Skill2Skills = GameObject.FindGameObjectsWithTag("2SlotSkill");
        Skill2Buffs = GameObject.FindGameObjectsWithTag("2SlotBuff");
        Skill3Skills = GameObject.FindGameObjectsWithTag("3SlotSkill");
        Skill3Buffs = GameObject.FindGameObjectsWithTag("3SlotBuff");
        PassiveAbilties = GameObject.FindGameObjectsWithTag("PassiveAbilitiesButtons");
        UltimateSkills = GameObject.FindGameObjectsWithTag("UltimateSkill");
        UltimateBuffs = GameObject.FindGameObjectsWithTag("UltimateBuff");
        SkillLevelTracker = GlobalData.GetComponent<UpgradeSkills>();

        //Sets the skill points text
        SkillPointsText.text = SkillPoints.ToString();
        //Sets the speed rank's text
        CurrentSpeedRank.text = SpeedRank.ToString();
        //sets the auto attack rank text
        CurrentAutoAttackRank.text = AutoAttackRate.ToString();
        //sets the health regen rank text
        CurrentHealthRegenRank.text = HealthRegenRank.ToString();

        //If the speed's rank is 1 or if the current skill points is lower then the points needed to increase speed then the speed increase button is uninteractable
        if(SpeedRank != 1 && SkillPoints < SkillPointNeededToIncreaseSpeed)
        {
            IncreaseSpeedRankButton.interactable = false;
        }
        //If the Auto attack rate's rank is 1 or if the current skill points is lower then the points needed to increase auto attack rate then the auto attack increase button is uninteractable
        if (AutoAttackRate != 1 && SkillPoints < SkillPointsNeededToIncreaseAutoAttackRate)
        {
            IncreaseAutoAttackRankButton.interactable = false;
        }
        //If the health regen's rank is 1 or if the current skill points is lower then the points needed to increase health regen rank then the health regen rank increase button is uninteractable
        if (HealthRegenRank != 1 && SkillPoints < SkillPointsNeededToIncreaseHealthRegen)
        {
            IncreaseHealthRegenButton.interactable = false;
        }

        GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
        GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;

        SpeedDefault = PlayerSpeed;
        AttackSpeedDefault = AutoAttackRate;
        HealthRegenDefault = HealthRegenRank;
        SpeedSkillPointsDefault = SkillPointNeededToIncreaseSpeed;
        AutoAttackSkillPointsDefault = SkillPointsNeededToIncreaseAutoAttackRate;
        HealthRegenSkillPointsDefault = SkillPointsNeededToIncreaseHealthRegen;

        //Checks if a save file exists
        if (File.Exists(Application.persistentDataPath + "/Player.data"))
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/Player.data", FileMode.Open, FileAccess.Read);
            //Will pull player's level from save system if there is something there
            if (stream.Length != 0)
            {
                //closes stream used to check information
                stream.Close();
                //Pulls the player's level from the file
                PlayerLevel = SaveBianry.LoadPlayer().Level;
                //Pulls the player's different stat ranks
                SpeedRank = (int)SaveBianry.LoadPlayer().SpeedRank;
                AutoAttackRate = (int)SaveBianry.LoadPlayer().AttackSpeedRank;
                HealthRegenRank = (int)SaveBianry.LoadPlayer().HealthRegenRank;
                //Pulls skill points
                SkillPoints = (int)SaveBianry.LoadPlayer().skillpoints;

                //Depending on the rank the speed and skill points needed to increase it will increase
                switch (SpeedRank)
                {
                    case 4:
                        {
                            PlayerSpeed += 5;
                            SkillPointNeededToIncreaseSpeed += 5;
                            GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
                            break;
                        }
                    case 3:
                        {
                            PlayerSpeed += 10;
                            SkillPointNeededToIncreaseSpeed += 10;
                            GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
                            break;
                        }
                    case 2:
                        {
                            PlayerSpeed += 15;
                            SkillPointNeededToIncreaseSpeed += 15;
                            GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
                            break;
                        }
                    case 1:
                        {
                            PlayerSpeed += 20;
                            SkillPointNeededToIncreaseSpeed += 20;
                            GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
                            break;
                        }
                }
                CurrentSpeedRank.text = SpeedRank.ToString();

                //Depending on the auto attack rate the skill points needed to increase it further will increase
                switch (AutoAttackRate)
                {
                    case 4:
                        {
                            SkillPointsNeededToIncreaseAutoAttackRate += 5;
                            GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;
                            break;
                        }
                    case 3:
                        {
                            SkillPointsNeededToIncreaseAutoAttackRate += 10;
                            GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;
                            break;
                        }
                    case 2:
                        {
                            SkillPointsNeededToIncreaseAutoAttackRate += 15;
                            GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;
                            break;
                        }
                    case 1:
                        {
                            SkillPointsNeededToIncreaseAutoAttackRate += 20;
                            GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;
                            break;
                        }
                }
                CurrentAutoAttackRank.text = AutoAttackRate.ToString();

                //Depending on the health regen rank the skill points needed to increase it further will increase
                switch (HealthRegenRank)
                {
                    case 4:
                        {
                            SkillPointsNeededToIncreaseHealthRegen += 5;
                            GlobalData.GetComponent<ChooseSkills>().HealthRegenRank = HealthRegenRank;
                            break;
                        }
                    case 3:
                        {
                            SkillPointsNeededToIncreaseHealthRegen += 10;
                            GlobalData.GetComponent<ChooseSkills>().HealthRegenRank = HealthRegenRank;
                            break;
                        }
                    case 2:
                        {
                            SkillPointsNeededToIncreaseHealthRegen += 15;
                            GlobalData.GetComponent<ChooseSkills>().HealthRegenRank = HealthRegenRank;
                            break;
                        }
                    case 1:
                        {
                            SkillPointsNeededToIncreaseHealthRegen += 20;
                            GlobalData.GetComponent<ChooseSkills>().HealthRegenRank = HealthRegenRank;
                            break;
                        }
                }
                CurrentHealthRegenRank.text = HealthRegenRank.ToString();
            }
            else
            {
                //closes stream used to check information
                stream.Close();
                PlayerLevel = 0;
            }
        }


        foreach (GameObject Passive in PassiveAbilties)
        {
            if (Passive.GetComponent<SkillValue>().RequiredLevelToUnlock > PlayerLevel)
            {
                Passive.GetComponent<Button>().interactable = false;
            }
        }

        //Checks if a save file for passive skills exists
        if (File.Exists(Application.persistentDataPath + "/PlayerPassiveAbilities.data"))
        {
            //Checks if the save file has anything in it
            FileStream AnotherStream = new FileStream(Application.persistentDataPath + "/PlayerPassiveAbilities.data", FileMode.Open, FileAccess.Read);
            //Checks if anything is stored within it
            if (AnotherStream.Length != 0)
            {
                //Allows check skill points to load passive information
                LoadPassive = true;
            }
            else
            {
                //Prevents CheckSkillPoints() from loading information
                LoadPassive = false;
            }
            //Closes stream
            AnotherStream.Close();
            CheckSkillPoints();
        }
    }

    public void DeleteDetails()
    {
        //Resets player's stats
        PlayerSpeed = SpeedDefault;
        SpeedRank = 5;
        SkillPointNeededToIncreaseSpeed = SpeedSkillPointsDefault;
        AutoAttackRate = AttackSpeedDefault;
        SkillPointsNeededToIncreaseAutoAttackRate = AutoAttackSkillPointsDefault;
        HealthRegenRank = HealthRegenDefault;
        SkillPointsNeededToIncreaseHealthRegen = HealthRegenSkillPointsDefault;

        //Sets the ranks back to normal
        GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
        GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;
        GlobalData.GetComponent<ChooseSkills>().HealthRegenRank = HealthRegenRank;

        CurrentSpeedRank.text = SpeedRank.ToString();
        CurrentHealthRegenRank.text = HealthRegenRank.ToString();
        CurrentAutoAttackRank.text = AutoAttackRate.ToString();

        SkillPoints = 0;

        //Sets all the skills buttons back to default
        foreach (GameObject Passive in PassiveAbilties)
        {
            Passive.GetComponent<SkillValue>().SkillUnlocked = false;
            Passive.GetComponent<SkillValue>().SkillLevel = 0;
        }
        CheckSkillPoints();
    }

    public void CheckSkillPoints()
    {

        //if the player has less skill points then the skill value they can't interact with the button
        foreach (GameObject Passive in PassiveAbilties)
        {
            //This will only activate if load passive is true
            if (LoadPassive)
            {
                //Creats a list to store unlocked passive skills
                List<string> UnlockedPassive = new List<string>();
                //Loads the saved list of passive abilities
                UnlockedPassive = SavePassiveBinary.LoadPassiveAbility().UnlockedPassiveAbilities;
                //Checks if the skill has been unlocked
                if (UnlockedPassive.Contains(Passive.name))
                {
                    Debug.Log("This activated");

                    //Gets the passive's skill level from the file using the index number of the unlocked passive list to pull the correct level
                    Passive.GetComponent<SkillValue>().SkillLevel = SavePassiveBinary.LoadPassiveAbility().UnlockedPassiveRank[UnlockedPassive.IndexOf(Passive.name)];
                }
                
            }

            switch (Passive.GetComponent<SkillValue>().SkillLevel)
            {
                case 0:
                    {
                        Passive.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                        break;
                    }
                case 1:
                    {
                        Passive.GetComponent<Image>().color = Color.cyan;
                        break;
                    }
                case 2:
                    {
                        Passive.GetComponent<Image>().color = Color.grey;
                        break;
                    }
                case 3:
                    {
                        Passive.GetComponent<Image>().color = Color.magenta;
                        break;
                    }
            }


            if ((SkillPoints < Passive.GetComponent<SkillValue>().ValueOfSkill) || Passive.GetComponent<SkillValue>().SkillLevel == 3 || Passive.GetComponent<SkillValue>().RequiredLevelToUnlock > PlayerLevel)
            {
                Passive.GetComponent<Button>().interactable = false;
            }
            else
            {
                if (((Passive.name == "Back At You Button") || (Passive.name == "Echo Button") || (Passive.name == "Gate Of Chaos Button") || (Passive.name == "Roll The Dice Button")) && GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Contains(Passive.name) == true)
                {
                    Passive.GetComponent<Button>().interactable = false;
                }
                else
                {
                    Passive.GetComponent<Button>().interactable = true;
                }
            }

        }
        LoadPassive = false;
        //Checks if the player has enough skill points to increase speed
        if (SpeedRank != 1 && SkillPoints >= SkillPointNeededToIncreaseSpeed)
        {
            IncreaseSpeedRankButton.interactable = true;
        }
        else
        {
            IncreaseSpeedRankButton.interactable = false;
        }
        //checks if the player has enough skill points to increase auto attack rank
        if (AutoAttackRate != 1 && SkillPoints >= SkillPointsNeededToIncreaseAutoAttackRate)
        {
            IncreaseAutoAttackRankButton.interactable = true;
        }
        else
        {
            IncreaseAutoAttackRankButton.interactable = false;
        }
        //checks if the player has enough skill points to increase health regen rank
        if (HealthRegenRank != 1 && SkillPoints >= SkillPointsNeededToIncreaseHealthRegen)
        {
            IncreaseHealthRegenButton.interactable = true;
        }
        else
        {
            IncreaseHealthRegenButton.interactable = false;
        }
        //changes the skill points text to match the current skill value
        SkillPointsText.text = SkillPoints.ToString();
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void IncreaseSpeedRank()
    {
        //Increases the speed rank
        SpeedRank -= 1;
        //Increases the actual speed
        PlayerSpeed += 5;
        //Changes text for the current speed rank
        CurrentSpeedRank.text = SpeedRank.ToString();
        //Lowers skill points
        SkillPoints -= SkillPointNeededToIncreaseSpeed;
        //Increases the amount of skill points to increase speed again
        SkillPointNeededToIncreaseSpeed += 5;
        //Changes the speed in global data
        GlobalData.GetComponent<ChooseSkills>().SpeedRank = PlayerSpeed;
        GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>().MovesRank = SpeedRank;
        //Checks skill points and what buttons will still be interactable
        CheckSkillPoints();
        Debug.Log(SpeedRank);
    }

    public void IncreaseAutoAttackRank()
    {
        //Increases the auto attack rank
        AutoAttackRate -= 1;
        //Changes the text of the auto attack rank display
        CurrentAutoAttackRank.text = AutoAttackRate.ToString();
        //Lowers skill points
        SkillPoints -= SkillPointsNeededToIncreaseAutoAttackRate;
        //Increases the amount of skill points to increase auto attack rank
        SkillPointsNeededToIncreaseAutoAttackRate += 5;
        //changes the auto attack rank in global data
        GlobalData.GetComponent<ChooseSkills>().AutoAttackRank = AutoAttackRate;
        //checks skill points and what buttons will still be interactable
        CheckSkillPoints();
    }

    public void IncreaseHealthRegenRank()
    {
        //Increases the health regen rank
        HealthRegenRank -= 1;
        //Changes the text of the health regen rank display
        CurrentHealthRegenRank.text = HealthRegenRank.ToString();
        //Lowers skill points
        SkillPoints -= SkillPointsNeededToIncreaseHealthRegen;
        //Increases the amount of skill points needed to increase health regen rank
        SkillPointsNeededToIncreaseHealthRegen += 5;
        //Changes the health regen rank in global data
        GlobalData.GetComponent<ChooseSkills>().HealthRegenRank = HealthRegenRank;
        //checks skill points and what buttons will still be interactable
        CheckSkillPoints();
    }

    public void RemoveSkill1()
    {
        //Removes the skill from Global Data
        GlobalData.GetComponent<ChooseSkills>().Slot1Skill = null;
        GlobalData.GetComponent<ChooseSkills>().Skill1Cooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().Skill1StaminaUsage = 0;
        //Makes skill 1 buttons interactable skill
        foreach (GameObject Skill in Skill1Skills)
        {
            Skill.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores skill 1
        Skill1 = null;
        //changes the text of the skill chosen back to default
        ChosenSkill1.text = "Skill 1";
        RemoveSkill1Button.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }

    }

    public void RemoveSkill2()
    {
        //Removes the skill from Global Data
        GlobalData.GetComponent<ChooseSkills>().Slot2Skill = null;
        GlobalData.GetComponent<ChooseSkills>().Skill2Cooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().Skill2StaminaUsage = 0;
        //Makes skill 2 buttons interactable skill
        foreach (GameObject Skill in Skill2Skills)
        {
            Skill.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores skill 2
        Skill2 = null;
        //changes the text of the skill chosen back to default
        ChosenSkill2.text = "Skill 2";
        RemoveSkill2Button.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void RemoveSkill3()
    {
        //Removes the skill from Global Data
        GlobalData.GetComponent<ChooseSkills>().Slot3Skill = null;
        GlobalData.GetComponent<ChooseSkills>().Skill3Cooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().Skill3StaminaUsage = 0;
        //Makes skill 3 buttons interactable skill
        foreach (GameObject Skill in Skill3Skills)
        {
            Skill.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores skill 3
        Skill3 = null;
        //changes the text of the skill chosen back to default
        ChosenSkill3.text = "Skill 3";
        RemoveSkill3Button.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void RemoveBuff1()
    {
        //Removes the buff from Global Data
        GlobalData.GetComponent<ChooseSkills>().Slot1Buff = null;
        GlobalData.GetComponent<ChooseSkills>().Buff1Cooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().Buff1StaminaUsage = 0;
        //Makes buff 1 buttons interactable skill
        foreach (GameObject Buff in Skill1Buffs)
        {
            Buff.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores buff 1
        Buff1 = null;
        //changes the text of the skill chosen back to default
        ChosenBuff1.text = "Buff 1";
        RemoveBuff1Button.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void RemoveBuff2()
    {
        //Removes the buff from Global Data
        GlobalData.GetComponent<ChooseSkills>().Slot2Buff = null;
        GlobalData.GetComponent<ChooseSkills>().Buff2Cooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().Buff2StaminaUsage = 0;
        //Makes buff 2 buttons interactable skill
        foreach (GameObject Buff in Skill2Buffs)
        {
            Buff.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores buff 2
        Buff2 = null;
        //changes the text of the skill chosen back to default
        ChosenBuff2.text = "Buff 2";
        RemoveBuff2Button.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void RemoveBuff3()
    {
        //Removes the buff from Global Data
        GlobalData.GetComponent<ChooseSkills>().Slot3Buff = null;
        GlobalData.GetComponent<ChooseSkills>().Buff3Cooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().Buff3StaminaUsage = 0;
        //Makes buff 3 buttons interactable skill
        foreach (GameObject Buff in Skill3Buffs)
        {
            Buff.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores buff 3
        Buff3 = null;
        //changes the text of the skill chosen back to default
        ChosenBuff3.text = "Buff 3";
        RemoveBuff3Button.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void RemoveUltimateSkill()
    {
        //Removes Ultimate Skill from Global Data
        GlobalData.GetComponent<ChooseSkills>().UltimateSkill = null;
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillCooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffStaminaUsage = 0;
        //Makes Ultimate skills interactable
        foreach (GameObject Ultimate in UltimateSkills)
        {
            Ultimate.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stores ultimate skill
        UltimateSkill = null;
        //changes the text of the ultimate skill back to default
        ChosenUltimateSkill.text = "Ultimate Skill";
        RemoveUltimateSkillButton.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void RemoveUltimateBuff()
    {
        //Removes Ultimate Buff from Global Data
        GlobalData.GetComponent<ChooseSkills>().UltimateBuff = null;
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillCooldown = 0;
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffStaminaUsage = 0;
        //Makes Ultimate Buffs interactable
        foreach ( GameObject UltimateBuff in UltimateBuffs)
        {
            UltimateBuff.GetComponent<Button>().interactable = true;
        }
        //Empties the variable that stored the ultimate buff
        UltimateBuff = null;
        //changes the text of the ultimate buff back to default
        ChosenUltimateBuff.text = "Ultimate Buff";
        RemoveUltimateBuffButton.interactable = false;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }


    public void SetGhostlyTime()
    {
        Buff2 = GameObject.Find("GhostlyTime");
        GlobalData.GetComponent<ChooseSkills>().Slot2Buff = "Ghostly Time";
        GlobalData.GetComponent<ChooseSkills>().Buff2Cooldown = Buff2.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff2StaminaUsage = Buff2.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff2.text = "Ghostly Time";
        foreach(GameObject Buff in Skill2Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff2Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetBurnBaby()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot2Skill = "Burn Baby";
        Skill2 = GameObject.Find("BurnBaby");
        GlobalData.GetComponent<ChooseSkills>().Skill2Cooldown = Skill2.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill2StaminaUsage = Skill2.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill2.text = "Burn Baby";
        foreach(GameObject Skill in Skill2Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill2Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetMirrorOfIce()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot3Buff = "Mirror Of Ice";
        Buff3 = GameObject.Find("MirrorOfIce");
        GlobalData.GetComponent<ChooseSkills>().Buff3Cooldown = Buff3.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff3StaminaUsage = Buff3.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff3.text = "Mirror Of Ice";
        foreach(GameObject Buff in Skill3Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff3Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetBreathOfLife()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot1Buff = "Breath Of Life";
        Buff1 = GameObject.Find("BreathOfLife");
        GlobalData.GetComponent<ChooseSkills>().Buff1Cooldown = Buff1.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff1StaminaUsage = Buff1.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff1.text = "Breath Of Life";
        foreach(GameObject Buff in Skill1Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff1Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetRage()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot1Skill = "Rage";
        Skill1 = GameObject.Find("Rage");
        GlobalData.GetComponent<ChooseSkills>().Skill1Cooldown = Skill1.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill1StaminaUsage = Skill1.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill1.text = "Rage";
        foreach(GameObject Skill in Skill1Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill1Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetSurvivalInstinct()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot1Buff = "Survival Instinct";
        Buff1 = GameObject.Find("SurvivalInstinct");
        GlobalData.GetComponent<ChooseSkills>().Buff1Cooldown = Buff1.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff1StaminaUsage = Buff1.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff1.text = "Survival Instinct";
        foreach(GameObject Buff in Skill1Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff1Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetHuntingInstinct()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot1Skill = "Hunting Instinct";
        Skill1 = GameObject.Find("HuntingInstinct");
        GlobalData.GetComponent<ChooseSkills>().Skill1Cooldown = Skill1.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill1StaminaUsage = Skill1.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill1.text = "Hunting Instinct";
        foreach(GameObject Skill in Skill1Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill1Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetPetrifyingPresence()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot1Buff = "Petrifying Presence";
        Buff1 = GameObject.Find("PetrifyingPresence");
        GlobalData.GetComponent<ChooseSkills>().Buff1Cooldown = Buff1.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff1StaminaUsage = Buff1.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff1.text = "Petrifying Presence";
        foreach(GameObject Buff in Skill1Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff1Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetPresenceOfPain()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot1Skill = "Presence Of Pain";
        Skill1 = GameObject.Find("PresenceOfPain");
        GlobalData.GetComponent<ChooseSkills>().Skill1Cooldown = Skill1.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill1StaminaUsage = Skill1.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill1.text = "Presence Of Pain";
        foreach(GameObject Skill in Skill1Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill1Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetBobAndWeave()
    {
        //Gets Bob and weave button
        GameObject PassiveButton = GameObject.Find("BobAndWeave");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if(PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("BobAndWeave");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.BobAndWeaveLevel = 1;
                    SkillLevelTracker.BobAndWeaveBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.BobAndWeaveLevel = 2;
                    SkillLevelTracker.BobAndWeaveBuff = 30;
                    //Gets the index number of the skill
                    int Index = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("BobAndWeave");
                    //changes the rank of the skill using the index number to locate it
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[Index] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.BobAndWeaveLevel = 3;
                    SkillLevelTracker.BobAndWeaveBuff = 40;
                    //Gets the index number of the skill
                    int Index = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("BobAndWeave");
                    //changes the rank of the skill using the index number to locate it
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[Index] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetBiggerArms()
    {
        //Finds the Bigger Arms button
        GameObject PassiveButton = GameObject.Find("BiggerArms");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("BiggerArms");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.BiggerArmsLevel = 1;
                    SkillLevelTracker.BiggerArmsBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.BiggerArmsLevel = 2;
                    SkillLevelTracker.BiggerArmsBuff = 15;
                    //Gets the index number of the skill
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("BiggerArms");
                    //changes the rank of the skill using the index number to locate it
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.BiggerArmsLevel = 3;
                    SkillLevelTracker.BiggerArmsBuff = 20;
                    //Gets the index number of the skill
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("BiggerArms");
                    //changes the rank of the skill using the index number to locate it
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetTargetPractice()
    {
        //Finds the Target Practice button
        GameObject PassiveButton = GameObject.Find("TargetPractice");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("TargetPractice");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.TargetPracticeLevel = 1;
                    SkillLevelTracker.TargetPracticeBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.TargetPracticeLevel = 2;
                    SkillLevelTracker.TargetPracticeBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("TargetPractice");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.TargetPracticeLevel = 3;
                    SkillLevelTracker.TargetPracticeBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("TargetPractice");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetForceOfWill()
    {
        //Finds the Force Of Will button
        GameObject PassiveButton = GameObject.Find("ForceOfWill");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ForceofWill");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ForceOfWillLevel = 1;
                    SkillLevelTracker.ForceOfWillBuff = 5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ForceOfWillLevel = 2;
                    SkillLevelTracker.ForceOfWillBuff = 10;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ForceofWill");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ForceOfWillLevel = 3;
                    SkillLevelTracker.ForceOfWillBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ForceofWill");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetThornSkin()
    {
        //Finds the art of training button
        GameObject PassiveButton = GameObject.Find("ThornSkin");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ThornSkin");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ThornSkinLevel = 1;
                    SkillLevelTracker.ThornSkinBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ThornSkinLevel = 2;
                    SkillLevelTracker.ThornSkinBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ThornSkin");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ThornSkinLevel = 3;
                    SkillLevelTracker.ThornSkinBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ThornSkin");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetRiposte()
    {
        //Finds the Riposte button
        GameObject PassiveButton = GameObject.Find("Riposte");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("Riposte");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.RiposteLevel = 1;
                    SkillLevelTracker.RiposteBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.RiposteLevel = 2;
                    SkillLevelTracker.RiposteBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Riposte");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.RiposteLevel = 3;
                    SkillLevelTracker.RiposteBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Riposte");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetImprovedMemory()
    {
        //Finds the Improved Memory button
        GameObject PassiveButton = GameObject.Find("ImprovedMemory");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ImprovedMemory");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ImprovedMemoryLevel = 1;
                    SkillLevelTracker.ImprovedMemoryBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ImprovedMemoryLevel = 2;
                    SkillLevelTracker.ImprovedMemoryBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ImprovedMemory");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ImprovedMemoryLevel = 3;
                    SkillLevelTracker.ImprovedMemoryBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ImprovedMemory");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetCleave()
    {
        //Finds the Cleave button
        GameObject PassiveButton = GameObject.Find("Cleave");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("Cleave");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.CleaveLevel = 1;
                    SkillLevelTracker.CleaveBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.CleaveLevel = 2;
                    SkillLevelTracker.CleaveBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Cleave");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.CleaveLevel = 3;
                    SkillLevelTracker.CleaveBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Cleave");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetMultipleHands()
    {
        //Finds the art of training button
        GameObject PassiveButton = GameObject.Find("MultipleHands");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("MultipleHands");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.MultipleHandsLevel = 1;
                    SkillLevelTracker.MultipleHandsBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.MultipleHandsLevel = 2;
                    SkillLevelTracker.MultipleHandsBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("MultipleHands");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.MultipleHandsLevel = 3;
                    SkillLevelTracker.MultipleHandsBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("MultipleHands");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetQuickRecharge()
    {
        //Finds the Quick Recharge button
        GameObject PassiveButton = GameObject.Find("QuickRecharge");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("QuickRecharge");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.QuickRechargeLevel = 1;
                    SkillLevelTracker.QuickRechargeBuff = 5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.QuickRechargeLevel = 2;
                    SkillLevelTracker.QuickRechargeBuff = 10;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("QuickRecharge");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.QuickRechargeLevel = 3;
                    SkillLevelTracker.QuickRechargeBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("QuickRecharge");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetConeOfTundra()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot2Buff = "Cone Of Tundra";
        Buff2 = GameObject.Find("ConeOfTundra");
        GlobalData.GetComponent<ChooseSkills>().Buff2Cooldown = Buff2.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff2StaminaUsage = Buff2.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff2.text = "Cone Of Tundra";
        foreach(GameObject Buff in Skill2Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff2Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetLimbHarvest()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot2Skill = "Limb Harvest";
        Skill2 = GameObject.Find("LimbHarvest");
        GlobalData.GetComponent<ChooseSkills>().Skill2Cooldown = Skill2.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill2StaminaUsage = Skill2.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill2.text = "Limb Harvest";
        foreach(GameObject Skill in Skill2Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill2Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetConeOfUnlife()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot2Skill = "Cone Of Unlife";
        Skill2 = GameObject.Find("ConeOfUnlife");
        GlobalData.GetComponent<ChooseSkills>().Skill2Cooldown = Skill2.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill2StaminaUsage = Skill2.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill2.text = "Cone Of Unlife";
        foreach(GameObject Skill in Skill2Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill2Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetArtOfTraining()
    {
        //Finds the art of training button
        GameObject PassiveButton = GameObject.Find("ArtOfTraining");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ArtOfTraining");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ArtOfTrainingLevel = 1;
                    SkillLevelTracker.ArtOfTrainingBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ArtOfTrainingLevel = 2;
                    SkillLevelTracker.ArtOfTrainingBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ArtOfTraining");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ArtOfTrainingLevel = 3;
                    SkillLevelTracker.ArtOfTrainingBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ArtOfTraining");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetPennies()
    {
        //Finds the pennies button
        GameObject PassiveButton = GameObject.Find("Pennies");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("Pennies");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.PenniesLevel = 1;
                    SkillLevelTracker.PenniesBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.PenniesLevel = 2;
                    SkillLevelTracker.PenniesBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Pennies");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.PenniesLevel = 3;
                    SkillLevelTracker.PenniesBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Pennies");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetRollTheDice()
    {
        GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("RollTheDice");
        GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(1);
        GameObject PassiveButton = GameObject.Find("RollTheDice");
        PassiveButton.GetComponent<Button>().interactable = false;
        PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        CheckSkillPoints();
    }

    public void SetFlurryOfAttacks()
    {
        GameObject PassiveButton = GameObject.Find("FlurryOfAttacks");
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("FlurryOfAttacks");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.FlurryOfAttacksLevel = 1;
                    SkillLevelTracker.FlurryOfAttacksBuff = 3;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.FlurryOfAttacksLevel = 2;
                    SkillLevelTracker.FlurryOfAttacksBuff = 5;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("FlurryOfAttacks");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.FlurryOfAttacksLevel = 3;
                    SkillLevelTracker.FlurryOfAttacksBuff = 7;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("FlurryOfAttacks");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetFrostbite()
    {
        //Finds the Frostbite button
        GameObject PassiveButton = GameObject.Find("Frostbite");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("Frostbite");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.FrostbiteLevel = 1;
                    SkillLevelTracker.FrostbiteBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.FrostbiteLevel = 2;
                    SkillLevelTracker.FrostbiteBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Frostbite");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.FrostbiteLevel = 3;
                    SkillLevelTracker.FrostbiteBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("Frostbite");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetReflectiveArmour()
    {
        //Finds the Frostbite button
        GameObject PassiveButton = GameObject.Find("ReflectiveArmour");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ReflectiveArmour");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ReflectiveArmourLevel = 1;
                    SkillLevelTracker.ReflectiveArmourBuff = 5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ReflectiveArmourLevel = 2;
                    SkillLevelTracker.ReflectiveArmourBuff = 10;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ReflectiveArmour");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ReflectiveArmourLevel = 3;
                    SkillLevelTracker.ReflectiveArmourBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ReflectiveArmour");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetBackAtYou()
    {
        GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("BackAtYou");
        GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(1);
        GameObject PassiveButton = GameObject.Find("BackAtYou");
        PassiveButton.GetComponent<Button>().interactable = false;
        PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        CheckSkillPoints();
    }

    public void SetEcho()
    {
        GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("Echo");
        GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(1);
        GameObject PassiveButton = GameObject.Find("Echo");
        PassiveButton.GetComponent<Button>().interactable = false;
        PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        CheckSkillPoints();
    }

    public void SetHeavyLanding()
    {
        //Finds the Heavy Landing button
        GameObject PassiveButton = GameObject.Find("HeavyLanding");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("HeavyLanding");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.HeavyLandingLevel = 1;
                    SkillLevelTracker.HeavyLandingBuff = 5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.HeavyLandingLevel = 2;
                    SkillLevelTracker.HeavyLandingBuff = 10;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("HeavyLanding");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.HeavyLandingLevel = 3;
                    SkillLevelTracker.HeavyLandingBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("HeavyLanding");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetDeathGrip()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot3Skill = "Death Grip";
        Skill3 = GameObject.Find("DeathGrip");
        GlobalData.GetComponent<ChooseSkills>().Skill3Cooldown = Skill3.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill3StaminaUsage = Skill3.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill3.text = "Death Grip";
        foreach(GameObject Skill in Skill3Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill3Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetBurstOfGore()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot3Skill = "Burst Of Gore";
        Skill3 = GameObject.Find("BurstOfGore");
        GlobalData.GetComponent<ChooseSkills>().Skill3Cooldown = Skill3.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill3StaminaUsage = Skill3.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill3.text = "Burst Of Gore";
        foreach(GameObject Skill in Skill3Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill3Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetDiamondBody()
    {
        //Finds the Diamond Body button
        GameObject PassiveButton = GameObject.Find("DiamondBody");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("DiamondBody");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.DiamondBodyLevel = 1;
                    SkillLevelTracker.DiamondBodyBuff = 20;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.DiamondBodyLevel = 2;
                    SkillLevelTracker.DiamondBodyBuff = 30;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("DiamondBody");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.DiamondBodyLevel = 3;
                    SkillLevelTracker.DiamondBodyBuff = 40;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("DiamondBody");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetMasterOfPennies()
    {
        //Finds the Master Of Pennies button
        GameObject PassiveButton = GameObject.Find("MasterOfPennies");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("MasterOfPennies");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.MasterOfPenniesLevel = 1;
                    SkillLevelTracker.MasterOfPenniesBuff = 5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.MasterOfPenniesLevel = 2;
                    SkillLevelTracker.MasterOfPenniesBuff = 10;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("MasterOfPennies");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.MasterOfPenniesLevel = 3;
                    SkillLevelTracker.MasterOfPenniesBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("MasterOfPennies");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetSoulCollector()
    {
        //Finds the Soul Collector button
        GameObject PassiveButton = GameObject.Find("SoulCollector");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("SoulCollector");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.SoulCollectorLevel = 1;
                    SkillLevelTracker.SoulCollectorBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.SoulCollectorLevel = 2;
                    SkillLevelTracker.SoulCollectorBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("SoulCollector");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.SoulCollectorLevel = 3;
                    SkillLevelTracker.SoulCollectorBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("SoulCollector");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetMoreGore()
    {
        //Finds the More Gore button
        GameObject PassiveButton = GameObject.Find("MoreGore");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("MoreGore");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.MoreGoreLevel = 1;
                    SkillLevelTracker.MoreGoreBuff = 0.5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.MoreGoreLevel = 2;
                    SkillLevelTracker.MoreGoreBuff = 0.7;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("MoreGore");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.MoreGoreLevel = 3;
                    SkillLevelTracker.MoreGoreBuff = 0.9;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("MoreGore");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetStealthCut()
    {
        //Finds the Stealth Cut Body button
        GameObject PassiveButton = GameObject.Find("StealthCut");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("StealthCut");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.StealthCutLevel = 1;
                    SkillLevelTracker.StealthCutBuff = 15;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.StealthCutLevel = 2;
                    SkillLevelTracker.StealthCutBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("StealthCut");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.StealthCutLevel = 3;
                    SkillLevelTracker.StealthCutBuff = 25;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("StealthCut");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetWhyAreYouRunning()
    {
        //Finds the Why Are You Running button
        GameObject PassiveButton = GameObject.Find("WhyAreYouRunning");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("WhyAreYouRunning");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.WhyAreYouRunningLevel = 1;
                    SkillLevelTracker.WhyAreYouRunningBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.WhyAreYouRunningLevel = 2;
                    SkillLevelTracker.WhyAreYouRunningBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("WhyAreYouRunning");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.WhyAreYouRunningLevel = 3;
                    SkillLevelTracker.WhyAreYouRunningBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("WhyAreYouRunning");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetImAngry()
    {
        //Finds the I'm Angry button
        GameObject PassiveButton = GameObject.Find("ImAngry");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ImAngry");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ImAngryLevel = 1;
                    SkillLevelTracker.ImAngryBuff = 0.5;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ImAngryLevel = 2;
                    SkillLevelTracker.ImAngryBuff = 0.7;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ImAngry");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ImAngryLevel = 3;
                    SkillLevelTracker.ImAngryBuff = 0.9;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ImAngry");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetThrowThings()
    {
        //Finds the Throw Things button
        GameObject PassiveButton = GameObject.Find("ThrowThings");
        //Adds one to the skills level
        PassiveButton.GetComponent<SkillValue>().SkillLevel += 1;
        //Stores the skill level
        int SkillLevel = PassiveButton.GetComponent<SkillValue>().SkillLevel;
        //If the player hasn't unlocked the skill then it will be added to the unlocked skills
        if (PassiveButton.GetComponent<SkillValue>().SkillUnlocked == false)
        {
            GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("ThrowThings");
            GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(SkillLevel);
            PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        }
        //Based on the level of the skill the better the buff is. Also increases the value of the skill
        switch (SkillLevel)
        {
            case 1:
                {
                    SkillLevelTracker.ThrowThingsLevel = 1;
                    SkillLevelTracker.ThrowThingsBuff = 10;
                    break;
                }
            case 2:
                {
                    SkillLevelTracker.ThrowThingsLevel = 2;
                    SkillLevelTracker.ThrowThingsBuff = 15;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ThrowThings");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    break;
                }
            case 3:
                {
                    SkillLevelTracker.ThrowThingsLevel = 3;
                    SkillLevelTracker.ThrowThingsBuff = 20;
                    int ListPosition = GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.IndexOf("ThrowThings");
                    GlobalData.GetComponent<ChooseSkills>().PassiveRanks[ListPosition] = SkillLevel;
                    PassiveButton.GetComponent<Button>().interactable = false;
                    break;
                }
        }
        //Removes skill points
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        //Increases value of the skill
        PassiveButton.GetComponent<SkillValue>().ValueOfSkill += 5;
        //Goes through all the skills to see if the player has enough skill points
        CheckSkillPoints();
    }

    public void SetImCalm()
    {
        GlobalData.GetComponent<ChooseSkills>().UltimateBuff = "I'm Calm";
        UltimateBuff = GameObject.Find("ImCalm");
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffCooldown = UltimateBuff.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffStaminaUsage = UltimateBuff.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenUltimateBuff.text = "I'm Calm";
        foreach (GameObject UltimateBuffThing in UltimateBuffs)
        {
            UltimateBuffThing.GetComponent<Button>().interactable = false;
        }
        RemoveUltimateBuffButton.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetSoulEater()
    {
        GlobalData.GetComponent<ChooseSkills>().UltimateBuff = "Soul Eater";
        UltimateBuff = GameObject.Find("SoulEater");
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffCooldown = UltimateBuff.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffStaminaUsage = UltimateBuff.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenUltimateBuff.text = "Soul Eater";
        foreach (GameObject UltimateBuffThing in UltimateBuffs)
        {
            UltimateBuffThing.GetComponent<Button>().interactable = false;
        }
        RemoveUltimateBuffButton.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetBlindRage()
    {
        GlobalData.GetComponent<ChooseSkills>().UltimateBuff = "Blind Rage";
        UltimateBuff = GameObject.Find("BlindRage");
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffCooldown = UltimateBuff.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateBuffStaminaUsage = UltimateBuff.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenUltimateBuff.text = "Blind Rage";
        foreach (GameObject UltimateBuffThing in UltimateBuffs)
        {
            UltimateBuffThing.GetComponent<Button>().interactable = false;
        }
        RemoveUltimateBuffButton.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetRampage()
    {
        GlobalData.GetComponent<ChooseSkills>().UltimateSkill = "Rampage";
        UltimateSkill = GameObject.Find("Rampage");
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillCooldown = UltimateSkill.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillStaminaUsage = UltimateSkill.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenUltimateSkill.text = "Rampage";
        foreach(GameObject UltimateSkillThing in UltimateSkills)
        {
            UltimateSkillThing.GetComponent<Button>().interactable = false;
        }
        RemoveUltimateSkillButton.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetWallOfSpears()
    {
        GlobalData.GetComponent<ChooseSkills>().UltimateSkill = "Wall Of Spears";
        UltimateSkill = GameObject.Find("WallOfSpears");
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillCooldown = UltimateSkill.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillStaminaUsage = UltimateSkill.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenUltimateSkill.text = "Wall Of Spears";
        foreach (GameObject UltimateSkillThing in UltimateSkills)
        {
            UltimateSkillThing.GetComponent<Button>().interactable = false;
        }
        RemoveUltimateSkillButton.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetElementalOverload()
    {
        GlobalData.GetComponent<ChooseSkills>().UltimateSkill = "Elemental Overload";
        UltimateSkill = GameObject.Find("ElementalOverload");
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillCooldown = UltimateSkill.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillStaminaUsage = UltimateSkill.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenUltimateSkill.text = "Elemental Overload";
        foreach (GameObject UltimateSkillThing in UltimateSkills)
        {
            UltimateSkillThing.GetComponent<Button>().interactable = false;
        }
        RemoveUltimateSkillButton.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetGateOfChaos()
    {
        GlobalData.GetComponent<ChooseSkills>().UnlockedPassiveAbilities.Add("Gate Of Chaos");
        GlobalData.GetComponent<ChooseSkills>().PassiveRanks.Add(1);
        GameObject PassiveButton = GameObject.Find("GateOfChaos");
        PassiveButton.GetComponent<Button>().interactable = false;
        PassiveButton.GetComponent<SkillValue>().SkillUnlocked = true;
        SkillPoints -= PassiveButton.GetComponent<SkillValue>().ValueOfSkill;
        CheckSkillPoints();
    }

    public void SetShieldStorm()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot3Buff = "Shield Storm";
        Buff3 = GameObject.Find("ShieldStorm");
        GlobalData.GetComponent<ChooseSkills>().Buff3Cooldown = Buff3.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().UltimateSkillStaminaUsage = UltimateSkill.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff3.text = "Shield Storm";
        foreach (GameObject Buff in Skill3Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff3Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetFireWall()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot3Buff = "FireWall";
        Buff3 = GameObject.Find("FireWall");
        GlobalData.GetComponent<ChooseSkills>().Buff3Cooldown = Buff3.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff3StaminaUsage = Buff3.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff3.text = "FireWall";
        foreach (GameObject Buff in Skill3Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff3Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetStunningQuake()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot2Buff = "Stunning Quake";
        Buff2 = GameObject.Find("StunningQuake");
        GlobalData.GetComponent<ChooseSkills>().Buff2Cooldown = Buff2.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Buff2StaminaUsage = Buff2.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenBuff2.text = "Stunning Quake";
        foreach (GameObject Buff in Skill2Buffs)
        {
            Buff.GetComponent<Button>().interactable = false;
        }
        RemoveBuff2Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

    public void SetGiftGiver()
    {
        GlobalData.GetComponent<ChooseSkills>().Slot3Skill = "Gift Giver";
        Skill3 = GameObject.Find("GiftGiver");
        GlobalData.GetComponent<ChooseSkills>().Skill3Cooldown = Skill3.GetComponent<SkillValue>().CooldownTime;
        GlobalData.GetComponent<ChooseSkills>().Skill3StaminaUsage = Skill3.GetComponent<SkillValue>().SkillStaminaUsage;
        ChosenSkill3.text = "Gift Giver";
        foreach (GameObject Skill in Skill3Skills)
        {
            Skill.GetComponent<Button>().interactable = false;
        }
        RemoveSkill3Button.interactable = true;

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            GlobalData.GetComponent<ChooseSkills>().PlayerNotFound();
        }
    }

}
