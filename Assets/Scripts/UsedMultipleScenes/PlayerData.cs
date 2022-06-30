using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerData : MonoBehaviour
{
    Skills SkillMenu;

    // creates all ints needed of the player stats and are hiden from the Inspector so no one can change them.
   [HideInInspector] public float Level;
   [HideInInspector] public float mainexp;
   [HideInInspector] public float skillpoints;
   [HideInInspector] public float Gold;
   [HideInInspector] public float Health;
   [HideInInspector] public float baseDamage;
   [HideInInspector] public float AOEDamage;
   [HideInInspector] public float StaminaMax;
   [HideInInspector] public float MultiAttckX;
   [HideInInspector] public float HealthRegen;
   [HideInInspector] public float StaminaRegen;
   [HideInInspector] public float HealthRegenRank;
   [HideInInspector] public float CriticalDamage;
   [HideInInspector] public float AttackSpeedRank;
   [HideInInspector] public float StunChance;
   [HideInInspector] public float MultiattackChance;
   [HideInInspector] public float DodgeChance;
   [HideInInspector] public float AbilityDamage;
   [HideInInspector] public float AOEChance;
   [HideInInspector] public float HealthBonus;
   [HideInInspector] public float CriticalChance;
   [HideInInspector] public float BlockChance;
   [HideInInspector] public float CooldownReduction;
   [HideInInspector] public float GoldBonus;
   [HideInInspector] public float DamageBonus;
   [HideInInspector] public float MovesRank;
   [HideInInspector] public float Movespeed;
   [HideInInspector] public float EXPBonus;
   [HideInInspector] public float DamageReflect;
   [HideInInspector] public float RarityIncrease;
   [HideInInspector] public int Floor;
   [HideInInspector] public float MaxHealth;
   [HideInInspector] public float ItemDroprate;
   [HideInInspector] public float EXPtoNext;
   [HideInInspector] public float Armour;
   [HideInInspector] public int MinionCount;

    // bools used to catch an error for the player and the floor manager 
    [HideInInspector] public bool NoPlayer;
    [HideInInspector] public bool NoFloor;
    

     // gameObjects of the player and the floormanager
    [HideInInspector] public PlayerStats Player;
    [HideInInspector] public GameObject FloorMan;

    //Stores the player's navigation mode between scenes
    [HideInInspector] public bool ChasingEnemy;

    private Scene scene;

    private void Awake()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        //code stops unity from destorying the gameobject when the scene changes 
        DontDestroyOnLoad(this.gameObject);
        
        scene = SceneManager.GetActiveScene();
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        // sets Player and Floor Manager to null to stop errors from happening 
        Player = null;
        FloorMan = null;
        

    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Checks if a save file exists
        if (File.Exists(Application.persistentDataPath + "/Player.data"))
        {
            //Checks if the save file has anything in it
            FileStream stream = new FileStream(Application.persistentDataPath + "/Player.data", FileMode.Open, FileAccess.Read);
            if (stream.Length != 0)
            {
                //Closes stream used to check iformation
                stream.Close();
                //Loads player if there is information to be pulled
                if (SaveBianry.LoadPlayer().Level > 0 && Floor == 1)
                {
                    LoadPlayer();
                }
            }
            //Closes stream used to check iformation
            stream.Close();
        }

        SkillMenu = GameObject.Find("Canvas").transform.Find("SkillMenu").GetComponent<Skills>();

        // stops the playerdata from over writing the stats on showcase level 
        if (string.Equals(scene.path, this.scene.path) || SceneManager.GetActiveScene().name == "ShowCaseLevel" || SceneManager.GetActiveScene().name == "SampleScene") return;

        // finds the player and floordisplay to update the numbers
        //Player = GameObject.Find("Player").GetComponent<PlayerStats>();
        FloorMan = GameObject.Find("FloorDisplay");

        if (Player != null)
        {
            // finds the player and updates the stats of the player for the next scene
            Player.Level = Level;
            Player.StartingHealth = MaxHealth;
            Player.exp = mainexp;
            Player.skillpoints = skillpoints;
            Player.Gold = Gold;
            Player.Health = Health;
            Player.BaseDamage = baseDamage;
            Player.AOEDamage = AOEDamage;
            Player.StaminaMax = StaminaMax;
            Player.MultiAttckX = MultiAttckX;
            Player.HealthRegen = HealthRegen;
            Player.StaminaRegen = StaminaRegen;
            Player.HealthRegenRank = HealthRegenRank;
            Player.CriticalDamage = CriticalDamage;
            Player.AttackSpeedRank = AttackSpeedRank;
            Player.StunChance = StunChance;
            Player.MultiattackChance = MultiattackChance;
            Player.DodgeChance = DodgeChance;
            Player.AbilityDamage = AbilityDamage;
            Player.AOEChance = AOEChance;
            Player.HealthBonus = HealthBonus;
            Player.CriticalChance = CriticalChance;
            Player.BlockChance = BlockChance;
            Player.CooldownReduction = CooldownReduction;
            Player.GoldBonus = GoldBonus;
            Player.DamageBonus = DamageBonus;
            Player.Movespeed = Movespeed;
            Player.EXPBonus = EXPBonus;
            Player.DamageReflect = DamageReflect;
            Player.RarityIncrease = RarityIncrease;
            Player.GetComponent<PlayerNavi>().ChasingEnemy = ChasingEnemy;
            Player.GetComponent<PlayerNavi>().FloorNumber = Floor;
            Player.EXPToNext = EXPtoNext;
            Player.armour = Armour;
            Player.GetComponent<PlayerCombat>().MinionCount = MinionCount;

        }
        else
        {
            // if the player unable to be found this will be set as false
            NoPlayer = false;
        }

        if (FloorMan != null)
        {
            // finds the floor and updates information for the next scene
            FloorMan.GetComponent<FloorManagerment>().Floor = Floor;
            
        }
        else
        {
            // if the floor unable to be found, the code will set as false
            NoFloor = false;
        }
    }

   public void NoPlayerFound()
    {
        // updates the stats when No Player found in the start method
        Debug.Log("working2");
        Player = GameObject.Find("Player").GetComponent<PlayerStats>();
        Player.Level = Level;
        Player.StartingHealth = MaxHealth;
        Player.exp = mainexp;
        Player.skillpoints = skillpoints;
        Player.Gold = Gold;
        Player.Health = Health;
        Player.BaseDamage = baseDamage;
        Player.AOEDamage = AOEDamage;
        Player.StaminaMax = StaminaMax;
        Player.MultiAttckX = MultiAttckX;
        Player.HealthRegen = HealthRegen;
        Player.StaminaRegen = StaminaRegen;
        Player.HealthRegenRank = HealthRegenRank;
        Player.CriticalDamage = CriticalDamage;
        Player.AttackSpeedRank = AttackSpeedRank;
        Player.StunChance = StunChance;
        Player.MultiattackChance = MultiattackChance;
        Player.DodgeChance = DodgeChance;
        Player.AbilityDamage = AbilityDamage;
        Player.AOEChance = AOEChance;
        Player.HealthBonus = HealthBonus;
        Player.CriticalChance = CriticalChance;
        Player.BlockChance = BlockChance;
        Player.CooldownReduction = CooldownReduction;
        Player.GoldBonus = GoldBonus;
        Player.DamageBonus = DamageBonus;
        Player.Movespeed = Movespeed;
        Player.EXPBonus = EXPBonus;
        Player.DamageReflect = DamageReflect;
        Player.RarityIncrease = RarityIncrease;
        Player.GetComponent<PlayerNavi>().ChasingEnemy = ChasingEnemy;
        Player.GetComponent<PlayerNavi>().FloorNumber = Floor;
        Player.EXPToNext = EXPtoNext;
        Player.armour = Armour;
        Player.GetComponent<PlayerCombat>().MinionCount = MinionCount;

        //SkillMenu = GameObject.Find("Canvas").transform.Find("SkillMenu").GetComponent<Skills>();

        SkillMenu.GetComponent<Skills>().PlayerLevel = Level;
        
        NoPlayer = true;
    }

    public void NoFloorManagerment()
    {
        // finds the floor and updates information for the next scene
        FloorMan.GetComponent<FloorManagerment>().Floor = Floor;
        NoFloor = true;
    }

    public void SavePlayer()
    {
        GetPlayersStats();
        Debug.Log(Level);
        //Saves all the information in this script into binary
        SaveBianry.SavePlayer(this);
    }

    private void GetPlayersStats()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerStats>();
        Level = Player.Level;
        MaxHealth = Player.StartingHealth;
        mainexp = Player.exp;
        skillpoints = Player.skillpoints;
        Gold = Player.Gold;
        Health = Player.Health;
        baseDamage = Player.BaseDamage;
        AOEDamage = Player.AOEDamage;
        StaminaMax = Player.StaminaMax;
        MultiAttckX = Player.MultiAttckX;
        HealthRegen = Player.HealthRegen;
        StaminaRegen = Player.StaminaRegen;
        HealthRegenRank = Player.HealthRegenRank;
        CriticalDamage = Player.CriticalDamage;
        AttackSpeedRank = Player.AttackSpeedRank;
        StunChance = Player.StunChance;
        MultiattackChance = Player.MultiattackChance;
        DodgeChance = Player.DodgeChance;
        AbilityDamage = Player.AbilityDamage;
        AOEChance = Player.AOEChance;
        HealthBonus = Player.HealthBonus;
        CriticalChance = Player.CriticalChance;
        BlockChance = Player.BlockChance;
        CooldownReduction = Player.CooldownReduction;
        GoldBonus = Player.GoldBonus;
        DamageBonus = Player.DamageBonus;
        MovesRank = SkillMenu.SpeedRank;
        Movespeed = Player.Movespeed;
        EXPBonus = Player.EXPBonus;
        DamageReflect = Player.DamageReflect;
        RarityIncrease = Player.RarityIncrease;
        ChasingEnemy = Player.GetComponent<PlayerNavi>().ChasingEnemy;
        Floor = Player.GetComponent<PlayerNavi>().FloorNumber;
        EXPtoNext = Player.EXPToNext;
        Armour = Player.armour;
        MinionCount = Player.GetComponent<PlayerCombat>().MinionCount;
    }

    public void LoadPlayer()
    {
        //Pulls the information from save system
        SaveSystem data = SaveBianry.LoadPlayer();

        //Sets all the statistics
        Level = data.Level;
        mainexp = data.mainexp;
        skillpoints = data.skillpoints;
        Gold = data.Gold;
        Health = data.Health;
        baseDamage = data.baseDamage;
        AOEDamage = data.AOEDamage;
        StaminaMax = data.StaminaMax;
        MultiAttckX = data.MultiAttckX;
        HealthRegen = data.HealthRegen;
        StaminaRegen = data.StaminaRegen;
        HealthRegenRank = data.HealthRegenRank;
        CriticalDamage = data.CriticalDamage;
        AttackSpeedRank = data.AttackSpeedRank;
        StunChance = data.StunChance;
        MultiattackChance = data.MultiattackChance;
        DodgeChance = data.DodgeChance;
        AbilityDamage = data.AbilityDamage;
        AOEChance = data.AOEChance;
        HealthBonus = data.HealthBonus;
        CriticalChance = data.CriticalChance;
        BlockChance = data.BlockChance;
        CooldownReduction = data.CooldownReduction;
        GoldBonus = data.GoldBonus;
        DamageBonus = data.DamageBonus;
        MovesRank = data.SpeedRank;
        Movespeed = data.Movespeed;
        EXPBonus = data.EXPBonus;
        DamageReflect = data.DamageReflect;
        RarityIncrease = data.RarityIncrease;
        Floor = data.Floor;
        MaxHealth = data.MaxHealth;
        EXPtoNext = data.EXPtoNext;

        GameObject.Find("Canvas").transform.Find("SkillMenu").GetComponent<Skills>().PlayerLevel = Level;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().LoadPassiveAbilities();

        NoPlayerFound();

        this.GetComponent<SaveplayerInventory>().Invoke("LoadPlayerInventory", 0.0001f);
    }
    
 
}
