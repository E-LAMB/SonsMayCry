using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellMaterial : MonoBehaviour
{

    public Material hell_alternate;

    // Start is called before the first frame update
    void Start()
    {
        if (Mind.hell_mode)
        {
            gameObject.GetComponent<Renderer>().material = hell_alternate;
        }
    }

}
