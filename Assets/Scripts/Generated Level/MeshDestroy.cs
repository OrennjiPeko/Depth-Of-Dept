using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.GetComponent<MeshRenderer>());
        Destroy(this.GetComponent<BoxCollider>());
    }
}
