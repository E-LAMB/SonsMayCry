using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBack : MonoBehaviour
{

    public float fade_time;
    public float time_till_fade;
    public RawImage the_image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_till_fade += Time.deltaTime;
        if (time_till_fade > 10f)
        {
            fade_time += Time.deltaTime * 0.5f;
            the_image.color = new Vector4(0f, 0f, 0f, fade_time);
            if (fade_time > 1.2f)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }
}
