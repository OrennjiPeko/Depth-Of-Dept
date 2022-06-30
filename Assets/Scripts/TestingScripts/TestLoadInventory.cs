using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLoadInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate { GameObject.Find("PlayerData").GetComponent<SaveplayerInventory>().LoadPlayerInventory();});
    }
}
