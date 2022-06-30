using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicSystem : MonoBehaviour
{
    public GameObject Relic;
    public GameObject[] RelicSlot;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       
       
       
        RelicSlot = GameObject.FindGameObjectsWithTag("RelicTag");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
