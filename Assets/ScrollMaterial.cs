using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaterial : MonoBehaviour
{

    public float time_x_switch;
    public float time_y_switch;

    public Material my_mat;

    public float x_speed;
    public float y_speed;

    void Start()
    {
        if (!Mind.hell_mode)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time_x_switch -= Time.deltaTime;
        time_y_switch -= Time.deltaTime;

        if (time_x_switch < 0f)
        {
            time_x_switch = Random.Range(2f, 6f);
            x_speed = Random.Range(0.2f,3f);
            if (Random.Range(0,2) == 1) {x_speed  = x_speed * -1f;}
        }
        if (time_y_switch < 0f)
        {
            time_y_switch = Random.Range(2f, 6f);
            y_speed = Random.Range(0.2f,3f);
            if (Random.Range(0,2) == 1) {y_speed  = y_speed * -1f;}
        }

        my_mat.mainTextureOffset = new Vector2(my_mat.mainTextureOffset.x + (Time.deltaTime * x_speed),
        my_mat.mainTextureOffset.y + (Time.deltaTime * y_speed));

    }
}
