using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInHell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Mind.hell_mode)
        {
            Destroy(gameObject);
        }
    }
}
