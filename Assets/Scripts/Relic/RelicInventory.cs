using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RelicInventory : MonoBehaviour
{
   [HideInInspector] public bool RelicinventoryEnabled;
    [HideInInspector] public GameObject relicInventory;
    [HideInInspector] public GameObject relicslotholder;
    [HideInInspector] public GameObject Relicskilltooltip;
     public GameObject InGameUI;

    [HideInInspector] public int allrelicslots;
    public GameObject[] relicslots;

    [HideInInspector] public bool RelicBeginnerEquippedcheck;
    [HideInInspector] public bool RelicBattleHardenEquippedcheck;
    [HideInInspector] public bool RelicExpertEquippedcheck;
    [HideInInspector] public GameObject RelicBeginnerEquipped;
    [HideInInspector] public GameObject RelicBattleHardenEquipped;
    [HideInInspector] public GameObject RelicExpertEquipped;
    // Start is called before the first frame update
    public List<RelicItem> CollectedRelics = new List<RelicItem>();


    public static System.Action SaveInitiated;
    private Scene scene;
    private void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        scene = SceneManager.GetActiveScene();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.Equals(scene.path, this.scene.path)) return;
        
        if (relicInventory == null)
        {
            InGameUI = GameObject.Find("InGameUI");
            relicInventory = GameObject.Find("RelicInventory");
            relicslotholder = GameObject.Find("RelicSlotHolder");

            allrelicslots = relicslotholder.transform.childCount;

            relicslots = new GameObject[allrelicslots];

            for(int i=0; i < allrelicslots; i++)
            {
                relicslots[i] = relicslotholder.transform.GetChild(i).gameObject;
               if (relicslots[i].GetComponent<RelicSlot>().relic == null)
                    relicslots[i].GetComponent<RelicSlot>().empty = true;
                    
            }
        }

        
    }

 

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "GameOver")
        {
            if (SceneManager.GetActiveScene().name == "GameOver")
            {
                relicInventory.SetActive(false);
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
            RelicinventoryEnabled = !RelicinventoryEnabled;
        

        if (RelicinventoryEnabled == true)
        {
            Time.timeScale = 0;
            InGameUI.SetActive(false);
            relicInventory.SetActive(true);

        }
        else
        {
            if (GameObject.Find("PlayerData").GetComponent<Inventory>().inventoryEnabled == true) {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                InGameUI.SetActive(true);
            }
            relicInventory.SetActive(false);
            //Relicskilltooltip.SetActive(false);
        }
    }

    public void AddRelic(GameObject Relicobject,RelicItem Relic,int RelicID,string RelicDescription,Sprite RelicIcon,string RelicClass)
    {
        for(int i=0; i<allrelicslots; i++)
        {
            if (relicslots[i].GetComponent<RelicSlot>().empty == true)
            {
                if (relicslots[i].GetComponent<RelicSlot>().empty)
                {
                    Relicobject.GetComponent<RelicItem>().PickedUp = true;

                    relicslots[i].GetComponent<RelicSlot>().relic = Relic;
                    relicslots[i].GetComponent<RelicSlot>().ID = RelicID;
                    relicslots[i].GetComponent<RelicSlot>().icon = RelicIcon;
                    relicslots[i].GetComponent<RelicSlot>().description = RelicDescription;

                    relicslots[i].GetComponent<RelicSlot>().CreateCopyRelic();
                    Destroy(Relicobject);

                    relicslots[i].GetComponent<RelicSlot>().UpdateRelicslot();
                    relicslots[i].GetComponent<RelicSlot>().empty = false;

                }
                return;
            }
        }
    }

    public void ReApplyRelics()
    {
        if (RelicBeginnerEquipped != null)
            RelicBeginnerEquipped.GetComponent<RelicItem>().Relicusage();
        if (RelicBattleHardenEquipped != null)
            RelicBattleHardenEquipped.GetComponent<RelicItem>().Relicusage();
        if (RelicExpertEquipped != null)
            RelicExpertEquipped.GetComponent<RelicItem>().Relicusage();

    }

    public void SaveRelicInvenotroy()
    {
        this.GetComponent<SaveInventoryRelic>().FillRelicLists();
    }
}
