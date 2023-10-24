using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaCan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InteractedWith()
    {
        Mind.shards_earnt_soda += 250;
        Mind.cans_collected += 1;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
