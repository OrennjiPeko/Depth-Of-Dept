using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetMechanics : MonoBehaviour
{
    public GameObject PlayerData;
   [HideInInspector] public int Floor;
    [HideInInspector] public Button Reset;
    [HideInInspector] public float Gold;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WorkingReset");
        PlayerData = GameObject.Find("PlayerData");
        Reset = GameObject.FindGameObjectWithTag("ResetButton").GetComponent<Button>();
        Floorcheck();
    }


    public void Resettime()
    {
        Gold = GameObject.Find("Player").GetComponent<PlayerStats>().Gold;
        PlayerData.GetComponent<PlayerData>().Floor = 0;
        PlayerData.GetComponent<PlayerData>().ItemDroprate = 0.01f;
        PlayerData.GetComponent<PlayerData>().Level = 1;
        PlayerData.GetComponent<PlayerData>().skillpoints = 0;
        PlayerData.GetComponent<PlayerData>().EXPtoNext = 0;
        SaveBinaryInventory.DeleteInventory();
        SavePassiveBinary.DeleteAbilities();
        SaveBianry.DeleteData();
        
        
        
        

    }

    public void Floorcheck()
    {
        Debug.Log(Floor);
        Floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;
       
        if (Floor < 101)
        {
            Reset.interactable = false;
        }
        else if (Floor >= 101)
        {
            Reset.interactable = true;
        }
    }

  
}
