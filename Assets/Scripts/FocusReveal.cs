using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusReveal : MonoBehaviour
{

    public string focus_type;
    Renderer my_renderer;

    public Material my_temp_material;
    public Vector4 color_is;

    public bool should_be_revealed;

    void Start()
    {
        my_renderer = gameObject.GetComponent<Renderer>();

        my_temp_material = my_renderer.material;

        color_is = my_temp_material.color;
        color_is.w = 0f;
    }

    void Update()
    {
        if (focus_type == "wire")
        {
            should_be_revealed = Mind.focus_wire;
        }
        if (focus_type == "threat")
        {
            should_be_revealed = Mind.focus_threat;
        }
        if (focus_type == "eye")
        {
            should_be_revealed = Mind.focus_eye;
        }
        if (focus_type == "memory")
        {
            should_be_revealed = Mind.focus_memory;
        }

        if (should_be_revealed)
        {
            color_is.w += Time.deltaTime;
            if (color_is.w > 1f)
            {
                color_is.w = 1f;
            }

        } else
        {
            color_is.w -= Time.deltaTime;
            if (color_is.w < 0f)
            {
                color_is.w = 0f;
            }
        }

        my_temp_material.color = color_is;

        // my_renderer.enabled = should_be_revealed;
    }

}
