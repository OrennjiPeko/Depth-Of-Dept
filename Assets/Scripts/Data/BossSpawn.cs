using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Spawn;

    void Start()
    {
        Spawn = GameObject.FindWithTag("BossSpawn");

        GameObject go = Instantiate(Boss, Spawn.transform.position, Quaternion.identity);
        
    }

}
