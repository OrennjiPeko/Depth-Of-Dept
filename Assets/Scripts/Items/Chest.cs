using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    float goldAmount;
    float GoldBonus;
    GameObject Player;
    Vector3 chestpostion;
    public GameObject[] Item;
    public int Floor;
    public int GoldChest;
    public int ChestGolds;


    private void Start()
    {
        Item = Player.GetComponent<PlayerCombat>().Item;
        Floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            //adds the gold bonus
            GoldBonus = Player.GetComponent<PlayerStats>().GoldBonus;
            if (Floor <= 1)
            {
                GoodsAmount();
                goldAmount = ChestGolds * 2 * GoldBonus;
            }
            else if (Floor < 22)
            {
                GoldChest = Floor - 1;
                GoodsAmount();
                goldAmount = ChestGolds * 2 * GoldBonus;
            }
            else
            {
                GoldChest = 20;
                GoodsAmount();
                goldAmount = ChestGolds * 2 * GoldBonus;
            }


            //sets the gold amount on the UI
            other.GetComponent<PlayerStats>().Gold += goldAmount;

            // chance to spawn item when check is opened by the player
            if (Random.value > 0.1)
            {
                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public void GoodsAmount()
    {
        switch (GoldChest)
        {
            case 0:
                ChestGolds = 200;
                break;
            case 1:
                ChestGolds = 300;
                break;
            case 2:
                ChestGolds = 400;
                break;
            case 3:
                ChestGolds = 500;
                break;
            case 4:
                ChestGolds = 600;
                break;
            case 5:
                ChestGolds = 700;
                break;
            case 6:
                ChestGolds = 800;
                break;
            case 7:
                ChestGolds = 900;
                break;
            case 8:
                ChestGolds = 1000;
                break;
            case 9:
                ChestGolds = 1100;
                break;
            case 10:
                ChestGolds = 1200;
                break;
            case 11:
                ChestGolds = 1300;
                break;
            case 12:
                ChestGolds = 1400;
                break;
            case 13:
                ChestGolds = 1500;
                break;
            case 14:
                ChestGolds = 1600;
                break;
            case 15:
                ChestGolds = 1700;
                break;
            case 16:
                ChestGolds = 1800;
                break;
            case 17:
                ChestGolds = 1900;
                break;
            case 18:
                ChestGolds = 2000;
                break;
            case 19:
                ChestGolds = 2100;
                break;
            case 20:
                ChestGolds = 2200;
                break;
        }
    }
}
