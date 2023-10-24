using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusReveal : MonoBehaviour
{

    public string focus_type;
    Renderer my_renderer;

    void Start()
    {
        my_renderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (focus_type == "wire")
        {
            my_renderer.enabled = Mind.focus_wire;
        }
        if (focus_type == "threat")
        {
            my_renderer.enabled = Mind.focus_threat;
        }
        if (focus_type == "eye")
        {
            my_renderer.enabled = Mind.focus_eye;
        }
        if (focus_type == "memory")
        {
            my_renderer.enabled = Mind.focus_memory;
        }
    }

}
