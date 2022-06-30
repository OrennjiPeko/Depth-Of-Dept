using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReNavigateScript : MonoBehaviour
{
    NavMeshAgent AI;
    
    // Start is called before the first frame update
    void Start()
    {
        AI.destination = GameObject.Find("FinalDestination").gameObject.transform.position;
    }
}
