using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    public Color my_color;
    public RawImage raw;

    // Update is called once per frame
    void Update()
    {
        my_color.a -= Time.deltaTime * 0.3f;
        raw.color = my_color;
    }
}
