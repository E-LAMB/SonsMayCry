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

    // Update is called once per frame
    void Update()
    {
        if (Mind.abilities_unlocked[my_value])
        {
            my_renderer.sprite = unlocked;
        } else
        {
            my_renderer.sprite = locked;
        }
    }
}
