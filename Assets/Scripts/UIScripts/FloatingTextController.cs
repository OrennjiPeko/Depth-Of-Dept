using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    //Stores the prefab of PopUpText
    private static FloatingText PopUpTextPrefab;
    //Stores the InGameUI
    private static GameObject InGameUI;

    public static void Initialise()
    {
        //Stores the InGameUI of the scene
        InGameUI = GameObject.Find("Canvas").transform.Find("InGameUI").gameObject;
        //Makes the system load the prefab if the variable is empty
        if(!PopUpTextPrefab)
            //Goes inside the resources folder, into the prefab folder and loads the PopUpParent prefab
            PopUpTextPrefab = Resources.Load<FloatingText>("Prefab/PopUpParent");
    }

    public static void CreatFloatingText(string text, Transform location)
    {
        //Spawns the prefab
        FloatingText instance = Instantiate(PopUpTextPrefab);
        //Locates the position of the screen where the pop up text should spawn
        Vector2 ScreenPosition = Camera.main.WorldToScreenPoint(location.position);
        //Sets the the InGameUI to be the floating text's parent
        instance.transform.SetParent(InGameUI.transform, false);
        //Sets the Pop Up text's position
        instance.transform.position = ScreenPosition;
        //Changes the text
        instance.SetText(text);
    }
}
