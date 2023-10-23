using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusReveal : MonoBehaviour
{

    public string focus_type;
    public Renderer my_renderer;

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
    }

}
