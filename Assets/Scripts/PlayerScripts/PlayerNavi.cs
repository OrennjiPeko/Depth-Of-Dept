using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerNavi : MonoBehaviour
{
    //used to calculate the closest object with tag
    public Vector3 Destination;
    GameObject[] FindDestination;
    [HideInInspector]public bool TargetFound;
    Rigidbody RB;
    //set navmeshagent
    NavMeshAgent PathFinder;
    //Buttons for attacks
   [HideInInspector] public Button MultiAttack;
   [HideInInspector] public Button Slot1;
   [HideInInspector] public Button Slot2;
   [HideInInspector] public Button Slot3;
   [HideInInspector] public Button Buff1;
   [HideInInspector] public Button Buff2;
   [HideInInspector] public Button Buff3;
   [HideInInspector] public Button UltimateAttack;
   [HideInInspector] public Button UltimateBuff;
   [HideInInspector] public int FloorNumber;
    [HideInInspector] public Button Reset;
    //Used to Display change UI
   [HideInInspector] public GameObject InGameUI;
   [HideInInspector] public GameObject Floor;

    //Stores chests on scene
    GameObject[] chest;
    //Tracks if the needs to fight a boss
    bool BossTime = false;
    //Stores gameobject that stores the player's information between scenes
    public GameObject PlayerData;

    public bool FloorNumbers;
    //Tracks when the player is in a boss room
    bool InBossRoom;
    //Tracks if the player is in combat, used as a safety net to exit combat mode once an enemy is dead
    bool Triggered = false;
    //Stores the camera
    public Camera cam;
    //
    public LayerMask movementmask;
    //Tracks if the movement mode is to chase enemies or explore
    public bool ChasingEnemy;
    //tracks if the player will ineteract with destination points
    private bool ActivateDestination;
    //Stores button that allows the player to chage the movement mode
    private GameObject ChangeTarget;
    //Tracks if the navigation should look for the next target
    [HideInInspector] public bool LookForNextTarget;
    //Stores the barrier in boss scenes
    GameObject[] Barriers;

    GameObject closest;

    //Stuff for renaigation if things break, god help me I hope this works I've been trying for so long
    private bool NotMovingCheck;
    private int ActivationCounter;
    public GameObject Renavigation;

    private void Awake()
    {
        //Gets GameObjects where all UI elements are stored
        InGameUI = GameObject.Find("InGameUI");
        Floor = GameObject.Find("FloorDisplay");
        PlayerData = GameObject.Find("PlayerData");
        
        if(InGameUI == null)
        {
            InGameUI = GameObject.Find("Canvas").GetComponent<ReChooseSkills>().InGameUI;
        }
        LookForNextTarget = false;

        if (SceneManager.GetActiveScene().name == "BossRoom" || SceneManager.GetActiveScene().name == "SampleScene")
            InBossRoom = true;
        else
            InBossRoom = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Sets the button that changes the player's target;
        ChangeTarget = InGameUI.transform.Find("ChangeTarget").gameObject;
        ChangeTarget.GetComponent<Button>().onClick.AddListener(delegate { ChoosePlayerTarget(); });

        //Assigns all the buttons in the script
        MultiAttack = InGameUI.transform.Find("MultiAttack").GetComponent<Button>();
        Slot1 = InGameUI.transform.Find("Slot1").GetComponent<Button>();
        Slot2 = InGameUI.transform.Find("Slot2").GetComponent<Button>();
        Slot3 = InGameUI.transform.Find("Slot3").GetComponent<Button>();
        Buff1 = InGameUI.transform.Find("Buff1").GetComponent<Button>();
        Buff2 = InGameUI.transform.Find("Buff2").GetComponent<Button>();
        Buff3 = InGameUI.transform.Find("Buff3").GetComponent<Button>();
        Reset = GameObject.FindGameObjectWithTag("ResetButton").GetComponent<Button>();
        
        UltimateAttack = InGameUI.transform.Find("UltimateAttack").GetComponent<Button>();
        UltimateBuff = InGameUI.transform.Find("UltimateBuff").GetComponent<Button>();
        FloorNumber = Floor.GetComponent<FloorManagerment>().Floor;
        FloorNumbers = false;

        //Sets navigation
        PathFinder = GetComponent<NavMeshAgent>();
        RB = GetComponent<Rigidbody>();
        TargetFound = false;

        //Buttons are un-interactable
        MultiAttack.interactable = false;
        Slot1.interactable = false;
        Slot2.interactable = false;
        Slot3.interactable = false;
        Buff1.interactable = false;
        Buff2.interactable = false;
        Buff3.interactable = false;
        UltimateAttack.interactable = false;
        UltimateBuff.interactable = false;

        //Stores the camera
        cam = Camera.main;

        //Makes system set the initial navigation after enemies have spawned in
        Invoke("SetInitialNavigation", 1f);
    }

    private void SetInitialNavigation()
    {
        //If in boss room the player will target the boss, otherwise player can choose to explore the floor or chase enemies 
        if (!InBossRoom)
        {
            ChasingEnemy = PlayerData.GetComponent<PlayerData>().ChasingEnemy;
            ChangeTarget.GetComponent<Button>().interactable = true;
            if (ChasingEnemy)
            {
                //Look for nearest enemy
                SearchForEnemies();
                //Player won't interact with destination points
                ActivateDestination = false;
                //Change the text of the button
                ChangeTarget.GetComponentInChildren<Text>().text = "Mode: Targeting Enemies";
            }
            else if (!ChasingEnemy)
            {
                //Search for next destination
                SearchForDestination();
                //Player will interact with destination points
                ActivateDestination = true;
                //Changes the text of the button
                ChangeTarget.GetComponentInChildren<Text>().text = "Mode: Explore floor";
            }
        }
        else
        {
            ChangeTarget.GetComponent<Button>().interactable = false;
            if (GameObject.FindGameObjectsWithTag("Barrier").Length != 0)
            {
                Barriers = GameObject.FindGameObjectsWithTag("Barrier");
                SearchForBoss();
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {   
        if (LookForNextTarget == true)
        {
            if (!InBossRoom)
            {
                if (ChasingEnemy)
                    Invoke("SearchForEnemies", 0.0001f);
                else
                    SearchForDestination();
            }
            else
            {
                SearchForBoss();
            }
            LookForNextTarget = false;
        }
        
        if(ChasingEnemy)
        {
            if(closest.transform.tag != "FinalDestination" && Vector3.Distance(this.transform.position, Destination) < 2)
            {
                PathFinder.destination = closest.transform.position;
            }
        }

        //if targetfound is false and the system cannot find gameobjects with the tag destination then it will set the destination to finaldestination
        if (TargetFound == false && GameObject.FindGameObjectsWithTag("Destination").Length == 0)
        {
            //if there is no destinations check if the player is in a boss room
            if (!InBossRoom)
            {
                Destination = GameObject.FindGameObjectWithTag("FinalDestination").transform.position;
                PathFinder.destination = Destination;
            }
            else
                SearchForBoss();
        }
        else if (TargetFound == false)
        {
            SearchForDestination();
        }

        //Safety net in case the OnTriggerExit doesn't work
        if(Triggered == true)
        {
            if(this.GetComponent<PlayerCombat>().Enemy == null)
            {
                PathFinder.isStopped = false;
                RB.constraints = RigidbodyConstraints.None;
                MultiAttack.interactable = false;
                Slot1.interactable = false;
                Slot2.interactable = false;
                Slot3.interactable = false;
                Buff1.interactable = false;
                Buff2.interactable = false;
                Buff3.interactable = false;
                UltimateAttack.interactable = false;
                UltimateBuff.interactable = false;
                Triggered = false;
            }
        }

        //if the mouse button is clicked 
        if (Input.GetMouseButtonDown(0))
        {
            //fires a raycast where the mouse point it
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //The raycast that is fired
            RaycastHit hit;
            //If the object is on screeen and has the tag enemy, item or chest the code will activate
            if(Physics.Raycast(ray, out hit, 100, movementmask) && (hit.transform.tag == "Enemy" || hit.transform.tag == "Item" || hit.transform.tag == "Chest"))
            {
                
                //sets the player's destination to the object hit
                PathFinder.destination = hit.transform.position;
                //target found set to true so it won't search for a destination
                TargetFound = true;
            }

            //Can only be activated if the player isn't in a boss room
            if (InBossRoom)
            {
                //checks if the player clicks a barrier or a boss
                if (Physics.Raycast(ray, out hit, 100, movementmask) && (hit.transform.tag == "Boss") || (hit.transform.tag == "Barrier"))
                {
                    PathFinder.destination = hit.transform.position;
                    TargetFound = true;
                }
            }

        }

        //Updates the location of the enemy when the player is close to it allowing the player to chase it properly
        if ((Vector3.Distance(this.transform.position, Destination) <= 1) && ChasingEnemy)
        {
            SearchForEnemies();
        }


        //checks if the player isn't moving and isn't already going through a check and no in combar
        if (!this.transform.hasChanged && !NotMovingCheck && !PathFinder.isStopped)
        {
            NotMovingCheck = true;
            StartCoroutine(ActivateRenavigation());
        }

        //Only activates if the moving check has activated =
        if (NotMovingCheck)
        {
            //Checks if the position has changed
            if (this.transform.hasChanged)
            {
                //Stops coroutine and sets the counter to 0
                StopCoroutine(ActivateRenavigation());
                ActivationCounter = 0;
            }
        }
    }

    private IEnumerator ActivateRenavigation()
    {
        //If the counter is lower then 5 add to it and start coroutine again
        if(ActivationCounter > 5)
        {
            ActivationCounter += 1;
            yield return new WaitForSeconds(2);
            StartCoroutine(ActivateRenavigation());
        }
        //If the counter is more then 5 then spawn renavigation gameobject and set it as navigation target
        else
        {
            Instantiate(Renavigation, GameObject.Find("PlayerSpawnPoint").transform.position, Quaternion.identity);
            PathFinder.destination = Renavigation.transform.position;
            InvokeRepeating("FollowRenavigation", 5, 5);
        }  
    }

    private void FollowRenavigation()
    {
        PathFinder.destination = Renavigation.transform.position;
    }

    public void FindNextTarget()
    {
        //Checks if the player is in a boss room
        if (!InBossRoom)
        {
            //Look for enemy
            if (ChasingEnemy)
            {
                SearchForEnemies();
            }
            //Look for destination points
            else if (!ChasingEnemy)
            {
                SearchForDestination();
            }
        }
        else
            SearchForBoss();
    }

    //Changes the player's target from the normal path to chase enemies and vice versa
    public void ChoosePlayerTarget()
    {
        Debug.Log(ChasingEnemy);
        if (!ChasingEnemy)
        {
            SearchForEnemies();
            Debug.Log("Activated");
            ChangeTarget.GetComponentInChildren<Text>().text = "Mode: Targeting Enemies";
        }
        else if (ChasingEnemy)
        {
            SearchForDestination();
            ChangeTarget.GetComponentInChildren<Text>().text = "Mode: Explore Floor";
        }
    }

    private void SearchForDestination()
    {
        //find all gameobjects tagged destination and calculates which is the cloesest one
        FindDestination = GameObject.FindGameObjectsWithTag("Destination");
        GameObject closest = null;
        float Distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in FindDestination)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < Distance)
            {
                closest = go;
                Distance = curDistance;
            }
        }
        
        //Checks if their are destinations to find, if not will go to the final destination
        if (GameObject.FindGameObjectsWithTag("Destination").Length != 0)
        {
            //takes the closest Game Object with the tag destination and sets it as the player's target
            Destination = closest.gameObject.transform.position;
            PathFinder.destination = Destination;
            TargetFound = true;
            ChasingEnemy = false;
            ActivateDestination = true;
        }
        else
        {
            Destination = GameObject.FindGameObjectWithTag("FinalDestination").transform.position;
            PathFinder.destination = Destination;
        }
    }

    private void SearchForEnemies()
    {
        //find all gameobjects tagged destination and calculates which is the cloesest one
        FindDestination = GameObject.FindGameObjectsWithTag("Enemy");
        closest = null;
        float Distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in FindDestination)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < Distance)
            {
                closest = go;
                Distance = curDistance;
            }
        }


        //Checks if there are any enemies on the scene to chase, if not then the player will go to the final destination
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            //takes the closest Game Object with the tag destination and sets it as the player's target
            Destination = closest.gameObject.transform.position;
            PathFinder.destination = Destination;
            TargetFound = true;
            ChasingEnemy = true;
            ActivateDestination = false;
        }
        else
        {
            closest = GameObject.FindGameObjectWithTag("FinalDestination").gameObject;
            Destination = closest.transform.position;
            PathFinder.destination = Destination;
        }
    }

    public void SearchForBoss()
    {
        //Stores the boss in case it's needed later
        GameObject Boss = GameObject.FindGameObjectWithTag("Boss");

        //Checks if their are any barriers on the scene
        if (GameObject.FindGameObjectsWithTag("Barrier").Length != 0)
        {
            //Variables used to calculate the distance between the player and the barriers
            closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            //Makes the system goes through every barrier in the array
            foreach (GameObject Barrier in Barriers)
            {
                //Ignore the game objects if it's been destroyed
                if (Barrier.gameObject != null)
                {
                    //Calculates the difference between the player and the barrier
                    Vector3 diff = Barrier.transform.position - position;
                    //Turns that number into a float that can be compared to each other
                    float curDistance = diff.sqrMagnitude;
                    //Checks if the current distance is smaller then the previously saved distance
                    if (curDistance < distance)
                    {
                        //Stores the barrier as the closest barrier
                        closest = Barrier;
                        //sets curDistance as the new smallest distance
                        distance = curDistance;
                    }
                }
            }
            //Sets the destination to the closest barrier after all calculations are done
            Destination = closest.transform.position;
            //Tells the player's AI where to go
            PathFinder.destination = Destination;
            //Traget found
            TargetFound = true;
            //Stops the player from activating destination points and going on a different path
            ActivateDestination = false;
        }
        //If there is a boss on scene then this code will activate
        else if(Boss != null)
        {
            //Sets the player's destination to the bosses location
            Destination = Boss.transform.position;
            //Makes the player's AI move towards the destination
            PathFinder.destination = Destination;

            closest = Boss;
        }
        //Only activates if the boss has been destroyed
        else
        {
            closest = GameObject.FindGameObjectWithTag("FinalDestination");
            //Sets the player's destination to the final destination
            Destination = GameObject.FindGameObjectWithTag("FinalDestination").transform.position;
            //Makes the player go to the final destination
            PathFinder.destination = Destination;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destination" && ActivateDestination)
        {
            //if the player touches the destination it will delete the destination point and set target found to false to have the system search for the next destination
            Destroy(other.gameObject);
            TargetFound = false;
        }
        if (other.gameObject.tag == "FinalDestination")
        {

            if (FloorNumbers == false)
            {
                FloorNumber += 1;
                Debug.Log(FloorNumber);
                Floor.GetComponent<FloorManagerment>().Floor = FloorNumber;
                PlayerData.GetComponent<PlayerData>().Floor = Floor.GetComponent<FloorManagerment>().Floor;
                FloorNumbers = true;
                //Reset.GetComponent<ResetMechanics>().Floorcheck();
            }
            
            if (BossTime == false)
            {
                Debug.Log("No Boss yet");
                OHOHOHBoss();
            }
            //Stores the mode the player was in
            GameObject.Find("PlayerData").GetComponent<PlayerData>().ChasingEnemy = ChasingEnemy;

            //Saves the Player's inventory, stats and unlocked passive abilities
            GameObject.Find("PlayerData").GetComponent<PlayerData>().SavePlayer();
            GameObject.Find("PlayerData").GetComponent<Inventory>().SaveInventory();
            this.transform.GetComponent<PlayerCombat>().SavePassiveAbilities();

            if (BossTime == true)
            {
                SceneManager.LoadScene("BossRoom");
            }
            else
            {
                SceneManager.LoadScene("RandomLevelBuild");
            }
           

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Triggered = true;

            //stops the player and enemy's movement if they touch each other
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            transform.LookAt(other.transform);
            RB.constraints = RigidbodyConstraints.FreezePosition;
            RB.constraints = RigidbodyConstraints.FreezeRotation;
            other.gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
           
            //These buttons are interactable if the player's stamina is not 0
            if (GetComponent<PlayerStats>().currentstanima != 0)
            {
                //checks auto activation skills/buttons with no skills attached to them and prevents those buttons from being interactable
                MultiAttack.interactable = true;
                if(Slot1.GetComponentInChildren<Text>().text == "")
                {
                    Slot1.interactable = false;
                }
                else
                {
                    Slot1.interactable = true;
                }

                if (Slot2.GetComponentInChildren<Text>().text == "")
                {
                    Slot2.interactable = false;
                }
                else
                {
                    Slot2.interactable = true;
                }

                if (Slot3.GetComponentInChildren<Text>().text == "" || (Slot3.GetComponentInChildren<Text>().text == "Gift Giver" && this.GetComponent<PlayerCombat>().MinionOnScene == false))
                {
                    Slot3.interactable = false;
                }
                else
                {
                    Slot3.interactable = true;
                }

                if (Buff1.GetComponentInChildren<Text>().text == "")
                {
                    Buff1.interactable = false;
                }
                else
                {
                    Buff1.interactable = true;
                }

                if (Buff2.GetComponentInChildren<Text>().text == "")
                {
                    Buff2.interactable = false;
                }
                else
                {
                    Buff2.interactable = true;
                }

                if (Buff3.GetComponentInChildren<Text>().text == "")
                {
                    Buff3.interactable = false;
                }
                else
                {
                    Buff3.interactable = true;
                }

                if(UltimateAttack.GetComponentInChildren<Text>().text == "")
                {
                    UltimateAttack.interactable = false;
                }
                else
                {
                    UltimateAttack.interactable = true;
                }

                if(UltimateBuff.GetComponentInChildren<Text>().text == "")
                {
                    UltimateBuff.interactable = false;
                }
                else
                {
                    UltimateBuff.interactable = true;
                }
            }
        }
        
        
        //checks if the object collided with is an item
        if (other.gameObject.tag == "Item")
        {
            Inventory Inventory = GameObject.Find("PlayerData").GetComponent<Inventory>();
            
            if (ChasingEnemy)
                SearchForEnemies();
            else
                TargetFound = false;

            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            Inventory.AddItem(itemPickedUp, item, item.ID, item.type, item.description, item.icon);
        }
        
        //checks if the object collided with is a chest
        if (other.gameObject.tag == "Chest")
        {
            //if the player is looking for enemies then go to the nearest enemies, otherwise next destination point
            if (ChasingEnemy)
                SearchForEnemies();
            else
                TargetFound = false;
        }

        if(other.gameObject.tag == "Wall")
        {
            FindNextTarget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Lets the player move again if they aren't touching the enemy anymore
        if(other.gameObject.tag == "Enemy")
        {
            PathFinder.isStopped = false;
            RB.constraints = RigidbodyConstraints.None;
            MultiAttack.interactable = false;
            Slot1.interactable = false;
            Slot2.interactable = false;
            if (Slot3.GetComponentInChildren<Text>().text == "Gift Giver" && this.GetComponent<PlayerCombat>().MinionOnScene == true)
            {
                Slot3.interactable = true;
            }
            else
            {
                Slot3.interactable = false;
            }
            Buff1.interactable = false;
            Buff2.interactable = false;
            Buff3.interactable = false;
            UltimateAttack.interactable = false;
            UltimateBuff.interactable = false;

            Triggered = false;

            //look for next enemy if player's are chasing after enemies
            if (ChasingEnemy)
                Invoke("SearchForEnemies", 0.0001f);
        }
    }


    public void OHOHOHBoss()
    {
        switch (FloorNumber)
        {
            case 10:
                BossTime = true;
                break;
            case 20:
                BossTime = true;
                break;
            case 30:
                BossTime = true;
                break;
            case 40:
                BossTime = true;
                break;
            case 50:
                BossTime = true;
                break;
            case 60:
                BossTime = true;
                break;
            case 70:
                BossTime = true;
                break;
            case 80:
                BossTime = true;
                break;
            case 90:
                BossTime = true;
                break;
            case 100:
                BossTime = true;
                break;
            case 120:
                BossTime = true;
                break;
            case 130:
                BossTime = true;
                break;
            case 140:
                BossTime = true;
                break;
            case 150:
                BossTime = true;
                break;
            case 160:
                BossTime = true;
                break;
            case 170:
                BossTime = true;
                break;
            case 180:
                BossTime = true;
                break;
            case 190:
                BossTime = true;
                break;
            case 200:
                BossTime = true;
                break;
            case 210:
                BossTime = true;
                break;
            case 220:
                BossTime = true;
                break;
            case 230:
                BossTime = true;
                break;
            case 240:
                BossTime = true;
                break;
            case 250:
                BossTime = true;
                break;
            case 260:
                BossTime = true;
                break;
            case 270:
                BossTime = true;
                break;
            case 280:
                BossTime = true;
                break;
            case 290:
                BossTime = true;
                break;
            case 300:
                BossTime = true;
                break;
            case 310:
                BossTime = true;
                break;
            case 320:
                BossTime = true;
                break;
            case 330:
                BossTime = true;
                break;
            case 340:
                BossTime = true;
                break;
            case 350:
                BossTime = true;
                break;
            case 360:
                BossTime = true;
                break;
            case 370:
                BossTime = true;
                break;
            case 380:
                BossTime = true;
                break;
            case 390:
                BossTime = true;
                break;
            case 400:
                BossTime = true;
                break;
            case 410:
                BossTime = true;
                break;
            case 420:
                BossTime = true;
                break;
            case 430:
                BossTime = true;
                break;
            case 440:
                BossTime = true;
                break;
            case 450:
                BossTime = true;
                break;
            case 460:
                BossTime = true;
                break;
            case 470:
                BossTime = true;
                break;
            case 480:
                BossTime = true;
                break;
            case 490:
                BossTime = true;
                break;
            case 500:
                BossTime = true;
                break;
            case 510:
                BossTime = true;
                break;
            case 520:
                BossTime = true;
                break;
            case 530:
                BossTime = true;
                break;
            case 540:
                BossTime = true;
                break;
            case 550:
                BossTime = true;
                break;
            case 560:
                BossTime = true;
                break;
            case 570:
                BossTime = true;
                break;
            case 580:
                BossTime = true;
                break;
            case 590:
                BossTime = true;
                break;
            case 600:
                BossTime = true;
                break;















        }

    }  
}

