using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearLocked : MonoBehaviour
{

    public Sprite unlocked;
    public Sprite locked;

    public Image my_renderer;

    public int my_value;

    public int escapes_needed;
    public int price;
    public string price_text;

    void Start()
    {
        if (escapes_needed <= Mind.total_escapes)
        {
            my_renderer.sprite = unlocked;
            if (Mind.abilities_unlocked[my_value])
            {
                my_renderer.color = new Vector4 (1f, 1f, 1f, 1f);
            } else
            {
                my_renderer.color = new Vector4 (0.5f, 0.5f, 0.5f, 1f);
            }
        } else
        {
            my_renderer.sprite = locked;
            my_renderer.color = new Vector4 (1f, 1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (escapes_needed <= Mind.total_escapes)
        {
            my_renderer.sprite = unlocked;
            if (Mind.abilities_unlocked[my_value])
            {
                my_renderer.color = new Vector4 (1f, 1f, 1f, 1f);
            } else
            {
                my_renderer.color = new Vector4 (0.5f, 0.5f, 0.5f, 1f);
            }
        } else
        {
            my_renderer.sprite = locked;
            my_renderer.color = new Vector4 (1f, 1f, 1f, 1f);
        }
    }
}
