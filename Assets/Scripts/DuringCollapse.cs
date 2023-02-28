using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuringCollapse : MonoBehaviour
{

    public Vector4 normal;
    public Vector4 endgame;

    // Start is called before the first frame update
    void Update()
    {
        RenderSettings.fogColor = endgame;
    }
}
