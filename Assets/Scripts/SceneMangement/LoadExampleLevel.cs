using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadExampleLevel : MonoBehaviour
{
    GameObject Canvas;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        if(Canvas != null)
        {
            //Canvas.SetActive(false);
        }
    }

    public void LoadExampleScene()
    {
        if (Canvas != null)
        {
            Canvas.SetActive(true);           
        }


        GameObject.Find("PlayerData").GetComponent<PlayerData>().Floor = 1;
        GameObject.FindGameObjectWithTag("PlayerData").GetComponent<Inventory>().Invoke("SetInGameUITrue", 0.0001f);
        SceneManager.LoadScene("ShowCaseLevel");
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void DeleteData()
    {
        SaveBianry.DeleteData();
        SaveBinaryInventory.DeleteInventory();
        SavePassiveBinary.DeleteAbilities();
        GameObject.Find("PlayerData").GetComponent<Inventory>().CollectedItems = new List<Item>();
        Canvas.transform.Find("SkillMenu").GetComponent<Skills>().DeleteDetails();
    }

    private void OnDestroy()
    {
        Canvas = null;
    }
}
