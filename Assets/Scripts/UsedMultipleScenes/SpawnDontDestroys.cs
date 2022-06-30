using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnDontDestroys : MonoBehaviour
{
    public GameObject PlayerData;
    public GameObject Canvas;
    public GameObject GlobalData;
    public GameObject EnemyData;
    public GameObject RelicInventory;

    [HideInInspector] public GameObject InGameUI;
    [HideInInspector] public GameObject SkillMenu;
    [HideInInspector] public GameObject Inventory;
    [HideInInspector] public GameObject ToolTip;
    [HideInInspector] public GameObject UpgradeToolTip;


    // Start is called before the first frame update
    void Awake()
    {
        //checks if the active scene is the main menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //Looks for the gameobject
            GameObject FindPlayerData = GameObject.Find("PlayerData");
            //If doen't find the player data spawn the player data and global data
            if (!FindPlayerData)
            {
                //Spawns the prefabs for player data and global data
                GameObject Go = Instantiate(PlayerData, new Vector3(0, 0, 0), Quaternion.identity);
                GameObject Do = Instantiate(GlobalData, new Vector3(0, 0, 0), Quaternion.identity);
                //changed the name to default
                Go.name = PlayerData.name;
                Do.name = GlobalData.name;
            }

            //Looks for the canvas
            GameObject FindCanvas = GameObject.Find("Canvas");
            //Checks if their is a canvas on the scene if not the system will spawn one along with the enemy data
            if (FindCanvas == null)
            {
                //Spawns the prefabs for the canvas and the enemy data
                GameObject Go = Instantiate(Canvas, new Vector3(0, 0, 0), Quaternion.identity);
                //changed the name to default
                Go.name = Canvas.name;
                Go.SetActive(true);
                InGameUI = Go.transform.Find("InGameUI").gameObject;
                SkillMenu = Go.transform.Find("SkillMenu").gameObject;
                Inventory = Go.transform.Find("Inventory").gameObject;
                ToolTip = Go.transform.Find("ToolTip").gameObject;
                UpgradeToolTip = Go.transform.Find("UpgradeToolTip").gameObject;

                GameObject LoadingScreen = Go.transform.Find("LoadingScreen").gameObject;

                //Gets the inventory script to store UI correctly
                Inventory inventory = GameObject.Find("PlayerData").GetComponent<Inventory>();

                //Sets the inventories UI information for use in later scenes
                inventory.InGameUI = InGameUI;
                inventory.SkillMenu = SkillMenu;
                inventory.inventory = Inventory;
                inventory.SlotHolder = Inventory.transform.Find("Viewport").transform.Find("SlotHolder").gameObject;
                inventory.Tooltip = ToolTip;
                inventory.SkillTooltip = SkillMenu.transform.Find("SkillToolTip").gameObject;
                inventory.UpgradeTooltip = UpgradeToolTip;
                inventory.LoadingScreen = LoadingScreen;
                LoadingScreen.SetActive(false);

                GameObject.Find("PlayerData").GetComponent<RelicInventory>().InGameUI = InGameUI;
            }
            else
            {
                Canvas = FindCanvas;
                InGameUI = FindCanvas.transform.Find("InGameUI").gameObject;
                SkillMenu = FindCanvas.transform.Find("SkillMenu").gameObject;
                Inventory = FindCanvas.transform.Find("Inventory").gameObject;
                ToolTip = FindCanvas.transform.Find("ToolTip").gameObject;
                UpgradeToolTip = FindCanvas.transform.Find("UpgradeToolTip").gameObject;
            }

        }
        //checks if the scene currently loaded is the showcase level
        else if(SceneManager.GetActiveScene().name == "ShowCaseLevel")
        {
            GameObject FindRelicInventory = GameObject.Find("RelicInventory");
            if (FindRelicInventory == null)
            {
                GameObject Go = Instantiate(RelicInventory, new Vector3(0, 0, 0), Quaternion.identity);
                Go.name = RelicInventory.name;
            }

            GameObject FindEnemyData = GameObject.Find("EnemyData");

            if (!FindEnemyData)
            {
                //Spawns the prefabs for the canvas and the enemy data
                GameObject Do = Instantiate(EnemyData, new Vector3(0, 0, 0), Quaternion.identity);
                //changed the name to default
                Do.name = EnemyData.name;
            }
        }
    }
}
