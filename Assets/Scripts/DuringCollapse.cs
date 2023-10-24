using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuringCollapse : MonoBehaviour
{

    public Vector4 normal;
    public Vector4 endgame;

    public GameObject sun;

    void Start()
    {
        sun.SetActive(false);
    }

    // Start is called before the first frame update
    void Update()
    {
        RenderSettings.fogColor = endgame;
    }
}
