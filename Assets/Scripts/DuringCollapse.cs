using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuringCollapse : MonoBehaviour
{

    public Vector4 normal;
    public Vector4 endgame;

    public GameObject sun;
    // public GameObject top;

    void Start()
    {
        sun.SetActive(false);
        // top.SetActive(true);
        // Debug.Log(gameObject.name);
    }

    // Start is called before the first frame update
    void Update()
    {
        RenderSettings.fogColor = endgame;
    }
}
