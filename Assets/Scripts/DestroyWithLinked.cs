using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithLinked : MonoBehaviour
{

    public GameObject linked;

    // Update is called once per frame
    void Update()
    {
        if (linked == null) {Destroy(gameObject);}
    }
}
