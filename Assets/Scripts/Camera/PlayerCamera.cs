using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
   [HideInInspector] public GameObject Player;
   Vector3 Position;
  [HideInInspector] public bool LostPlayer;

    private void Awake()
    {
        //GameObject.Find("PlayerData").GetComponent<Inventory>().GetUIElementsAndSetFalse();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
            if (Player != null)
             Position = transform.position - Player.transform.position;
            
        }
        if(Player != null)  
            transform.position = Player.transform.position + Position;

    }
}
