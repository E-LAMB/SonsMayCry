using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTexture : MonoBehaviour
{

    public Renderer my_renderer;
    public Material good_mat;
    public Material hell_mat;

    // Start is called before the first frame update
    void Start()
    {
        if (Mind.hell_mode)
        {
            my_renderer.material = hell_mat;
        } else
        {
            my_renderer.material = good_mat;
        }
    }

}
