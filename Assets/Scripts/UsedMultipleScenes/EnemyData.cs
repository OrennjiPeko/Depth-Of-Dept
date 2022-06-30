using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyData : MonoBehaviour
{
    //ints to store the enemy stats
    [HideInInspector] public float AttackDamage;
    [HideInInspector] public float EnemyHealth;
    [HideInInspector] public float groupDamage;
    [HideInInspector] public float RangedDamage;
    [HideInInspector] public float RangedHealth;
  
   
    //Bools to detect used to track if there is normal and ranged enemies on the scene
    [HideInInspector] public bool NoEnemyFound;
    [HideInInspector] public bool NoRangedEnemyFound;
   

    //Arrays used to store both enemies and ranged enemies on a scene
     public GameObject[] Enemy;
     public GameObject[] EnemyRange;


    private Scene scene;

    private void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        DontDestroyOnLoad(this.gameObject);

        //Gets original scene the game object is loaded in. Used to prevent the script that loads every scene from activating on the first scene
        scene = SceneManager.GetActiveScene();

        //Fills in both arrays to have enough space for all the enemies on the scene
        Enemy = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        EnemyRange = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        
    }

    private void OnDestroy()
    {
        //Empties all the variables on destroy
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Enemy = null;
        EnemyRange = null;
      

    }

    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //Prevents anything from happening on the first scene the script is loaded in
        if (string.Equals(scene.path, this.scene.path)) return;

        //creates temporary array to make it easier to place all the regular enemies and ranged enemies in their respective arrays
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Keeps count of the amount of gameobjects stored in the arrays
        int EnemyCount = 0;
        int RangedEnemyCount = 0;

        //clears the array of the enemies from the previous scene
        Array.Clear(Enemy, 0, Enemy.Length);
        Array.Clear(EnemyRange, 0, EnemyRange.Length);
       

        //Updates the arrays to have the correct amount of space for the enemies on the current scene
        Enemy = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        EnemyRange = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
       

        //For loops that place the enemies in their respective arrays
        for (int i = 0; i < Enemies.Length; i++)
        {
            if(Enemies[i].GetComponent<EnemyAI>() != false)
            {
                //Places regular enemies in their array in the next free slot
                Enemy[EnemyCount] = Enemies[i];
                //Adds 1 to the counter that tracks the amount of enemies in the regular enemy array
                EnemyCount += 1;
            }
            else if (Enemies[i].GetComponent<RangedEnemyAI>() != null)
            {
                //Places ranged enemies in their array in the next free slot
                EnemyRange[RangedEnemyCount] = Enemies[i];
                //Adds 1 to the counter that tracks the amount of enemies in the ranged enemy array
                RangedEnemyCount += 1;
            }
        }


        //checks to make sure the regular enemy array is not empty before activating the script that places their stats
        if (Enemy != null)
        {
            //Goes through the enemy array to set all the stats of the enemies
            for(int E = 0; E < EnemyCount; E++)
            {
                Enemy[E].GetComponent<EnemyStates>().EnemyHealth = EnemyHealth;
                Enemy[E].GetComponent<EnemyStates>().AttackDamage = AttackDamage;
                Enemy[E].GetComponent<EnemyStates>().GroupDamage = groupDamage;
            }
        }
        else
        {
            //Sets the boolean that tracks if their are enemies in the array to false
            NoEnemyFound = false;
        }

        //Checks the ranged enemy array is not empty before setting the stats
        if (EnemyRange != null)
        {
            //Goes through the ranged enemy array to set all the stats of the enmies
            for (int R = 0; R < RangedEnemyCount; R++)
            {
                EnemyRange[R].GetComponent<RangedEnemyAI>().EnemyHealth = RangedHealth;
                EnemyRange[R].GetComponent<RangedEnemyAI>().ProjectileDamage = RangedDamage;
              
            }
        }
        else
        {
            //Sets the boolean that tracks if their are ranged enemies in the array to false
            NoRangedEnemyFound = false;
        }
    }

    //Function that activates if their are no enemies
    public void NoEnemiesFound()
    {
        //sets the length of the array for the regular enemy
        Enemy = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        //Temporary array to store all the enemies on the scene
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Keeps count of the amount of enemies in the regular enemy array
        int EnemyCount = 0;

        //Goes through every enemy on the scene
        for (int i = 0; i < Enemies.Length; i++)
        {
            //Checks if the enemy is a regular enemy
            if (Enemies[i].GetComponent<EnemyAI>() != false)
            {
                //Sets the stats of the enemy
                Enemy[EnemyCount] = Enemies[i].gameObject;
                Enemy[EnemyCount].GetComponent<EnemyStates>().EnemyHealth = EnemyHealth;
                Enemy[EnemyCount].GetComponent<EnemyStates>().AttackDamage = AttackDamage;
                Enemy[EnemyCount].GetComponent<EnemyStates>().GroupDamage = groupDamage;
                //Adds 1 to the counter that tracks the amount of regular enemies
                EnemyCount += 1;
            }
        }
        //Sets the enemy found variable to true
        NoEnemyFound = true;
    }

    public void NoRangedEnemiesFound()
    {
        //sets the length of the array for the ranged enemy
        EnemyRange = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        //Temporary array to store all the enemies on the scene
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Keeps count of the amount of enemies in the ranged enemy array
        int RangedEnemyCount = 0;

        //Goes through every enemy on the scene
        for (int i = 0; i < Enemies.Length; i++)
        {
            //Checks if the enemy is a ranged enemy
            if (Enemies[i].GetComponent<RangedEnemyAI>() != null)
            {
                //Sets the stats of the enemy
                EnemyRange[RangedEnemyCount] = Enemies[i].gameObject;
                EnemyRange[RangedEnemyCount].GetComponent<EnemyStates>().EnemyHealth = RangedHealth;
                EnemyRange[RangedEnemyCount].GetComponent<RangedEnemyAI>().ProjectileDamage = RangedDamage;
                
                //Adds 1 to the counter that tracks the amount of ranged enemies
                RangedEnemyCount += 1;
            }
        }
        //Sets the ranged enemy found variable to true
        NoRangedEnemyFound = true;
    }

 
}
