using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    float GoldAmount;
    float GoldBonus;
    PlayerStats Player;
   [HideInInspector] public int Floor;
   [HideInInspector] public int GoldNumber;
   [HideInInspector] public int GoldAmounts;
    public GameObject EnemyData;

    private void Awake()
    {
        EnemyData = GameObject.Find("EnemyData");
    }


    public void Start()
    {
        Floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player touches the gold the player will get gold
        if(other.tag == "Player")
        {
            Player = other.gameObject.GetComponent<PlayerStats>();
            
            //Checks if the player hasn't got the maximum amount of gold
            if (!Player.MaxGoldReached)
            {
                int MaxGold = Player.MaxGold;
                //Adds the gold bonus
                GoldBonus = Player.GoldBonus;
                if (Floor <= 1)
                {
                    GoodsAmount();
                    GoldAmount = GoldNumber * GoldBonus;
                }
                else if (Floor < 22)
                {
                    GoldAmounts = Floor - 1;
                    GoodsAmount();
                    GoldAmount = GoldNumber * GoldBonus;
                }
                else
                {
                    GoldAmount = 20;
                    GoodsAmount();
                    GoldAmount = GoldNumber * GoldBonus;
                }

                if (Player.GoldRushActive)
                {
                    if(Random.value < 0.05)
                    {
                        GoldAmount *= 3;
                    }
                }

                //Sets the new gold amount
                Player.Gold += GoldAmount;

                //Checks if the player's gold has went over the max
                if (Player.Gold >= MaxGold)
                {
                    Player.Gold = MaxGold;
                    Player.MaxGoldReached = true;
                }
            }
            Player.CanPlayerSummonMinion();

            //Destroy the gold game object
            Destroy(this.gameObject);
        }

        if (other.tag == "Minion")
        {
            Player = other.GetComponent<MinionAI>().Player.GetComponent<PlayerStats>();

            //Checks if the player hasn't got the maximum amount of gold
            if (!Player.MaxGoldReached)
            {
                int MaxGold = Player.MaxGold;
                //Adds the gold bonus
                GoldBonus = Player.GoldBonus;
                if (Floor <= 1)
                {
                    GoodsAmount();
                    GoldAmount = GoldNumber * GoldBonus;
                }
                else if (Floor < 22)
                {
                    GoldAmounts = Floor - 1;
                    GoodsAmount();
                    GoldAmount = GoldNumber * GoldBonus;
                }
                else
                {
                    GoldAmount = 20;
                    GoodsAmount();
                    GoldAmount = GoldNumber * GoldBonus;
                }


                //Sets the new gold amount
                Player.Gold += GoldAmount;

                //Checks if the player's gold has went over the max
                if (Player.Gold >= MaxGold)
                {
                    Player.Gold = MaxGold;
                    Player.MaxGoldReached = true;
                }
            }
            Player.CanPlayerSummonMinion();

            //Destroy the gold game object
            Destroy(this.gameObject);
        }
    }


    public void GoodsAmount()
    {
        switch (GoldAmounts)
        {
            case 0:
                GoldNumber = 200;
                break;
            case 1:
                GoldNumber = 300;
                break;
            case 2:
                GoldNumber = 400;
                break;
            case 3:
                GoldNumber = 500;
                break;
            case 4:
                GoldNumber = 600;
                break;
            case 5:
                GoldNumber = 700;
                break;
            case 6:
                GoldNumber = 800;
                break;
            case 7:
                GoldNumber = 900;
                break;
            case 8:
                GoldNumber = 1000;
                break;
            case 9:
                GoldNumber = 1100;
                break;
            case 10:
                GoldNumber = 1200;
                break;
            case 11:
                GoldNumber = 1300;
                break;
            case 12:
                GoldNumber = 1400;
                break;
            case 13:
                GoldNumber = 1500;
                break;
            case 14:
                GoldNumber = 1600;
                break;
            case 15:
                GoldNumber = 1700;
                break;
            case 16:
                GoldNumber = 1800;
                break;
            case 17:
                GoldNumber = 1900;
                break;
            case 18:
                GoldNumber = 2000;
                break;
            case 19:
                GoldNumber = 2100;
                break;
            case 20:
                GoldNumber = 2200;
                break;
        }
    }

   
}


