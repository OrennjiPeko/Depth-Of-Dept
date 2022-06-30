using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManagerment : MonoBehaviour
{
    public int Floor;
    public Text FloorDisplay;
    public GameObject InGameUI;

    public void Awake()
    {
        InGameUI = GameObject.Find("InGameUI");
    }
    public void Start()
    {

        FloorDisplay = InGameUI.transform.Find("FloorDisplay").GetComponent<Text>();
        

    }

    public void Update()
    {
        FloorDisplay.text = Floor.ToString();
    }
}
