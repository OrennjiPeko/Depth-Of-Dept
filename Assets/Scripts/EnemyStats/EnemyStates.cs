using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    //Enemy information
    public float AttackDamage;
    public float EnemyHealth;
    public float GroupDamage;
    public int EXPGiven;
    public GameObject ItemDrop;
    [HideInInspector] public int floor;

   [HideInInspector] public GameObject EnemyData;
    private void Awake()
    {
        //finds the Enemy Data
        EnemyData = GameObject.Find("EnemyData");
        UpdateEnemyStats();
    }
    private void Start()
    {
        floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;
        if (floor > 10)
        {
            StatsIncrease();
        }else if (floor > 201)
        {
            EnemyHealth *= 2;
            AttackDamage *= 2;
            EXPGiven *=2;
        }
    }

    public void UpdateEnemyStats()
    {
        // updates all the Range Enemies and Normal Enemies
        EnemyData.GetComponent<EnemyData>().EnemyHealth = EnemyHealth;
        EnemyData.GetComponent<EnemyData>().AttackDamage = AttackDamage;
        EnemyData.GetComponent<EnemyData>().groupDamage = GroupDamage;
        EnemyData.GetComponent<EnemyData>().RangedDamage = AttackDamage;
        EnemyData.GetComponent<EnemyData>().RangedHealth = EnemyHealth;
      
    }

    public void StatsIncrease()
    {
        switch (floor)
        {
            case 11:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 21:
                EnemyHealth *= 2;
                AttackDamage *= 2; 
                EXPGiven *= 2;
                break;
            case 31:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 41:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 51:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 61:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 71:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 81:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 91:
                EnemyHealth *=2;
                AttackDamage *=2; 
                EXPGiven *=2;
                break;
            case 101:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 111:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 121:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 131:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 141:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 151:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 161:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 171:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 181:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 191:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
            case 201:
                EnemyHealth *=2;
                AttackDamage *=2;
                EXPGiven *=2;
                break;
        }

     
    }
}
