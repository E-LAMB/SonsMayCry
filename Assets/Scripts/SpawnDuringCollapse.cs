using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDuringCollapse : MonoBehaviour
{

    public GameObject object_to_enable;
    public bool is_collapse;

    // Start is called before the first frame update
    void Start()
    {
        object_to_enable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mind.levers_flipped == 4)
        {
            is_collapse = true;
        }
        
        if (is_collapse)
        {
            object_to_enable.SetActive(true);
        }
    }
}
