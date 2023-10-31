using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Reloading : MonoBehaviour
{

    public float countdown;
    public bool main_menu;
    public int scene_to_go;

    public float first;
    public float second;

    public Image my_image_F;
    public Image my_image_S;

    public float fade;

    public RawImage my_hide;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "WelcomeBack" + ".txt"))
        {
            scene_to_go = 1;

        } else
        {
            scene_to_go = 3;
        }

        if (main_menu)
        {
            if (!File.Exists(Application.persistentDataPath + "/" + "Shards" + ".txt"))
            {
                File.Create(Application.persistentDataPath + "/" + "Shards" + ".txt");
            }
            if (!File.Exists(Application.persistentDataPath + "/" + "Notes" + ".txt"))
            {
                File.Create(Application.persistentDataPath + "/" + "Notes" + ".txt");
            }
            if (!File.Exists(Application.persistentDataPath + "/" + "Perk1" + ".txt"))
            {
                File.Create(Application.persistentDataPath + "/" + "Perk1" + ".txt");
            }
            if (!File.Exists(Application.persistentDataPath + "/" + "Perk2" + ".txt"))
            {
                File.Create(Application.persistentDataPath + "/" + "Perk2" + ".txt");
            }
        }

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown < -2.5f)
        {
            Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_go);
        }

        fade = (countdown + 1.5f) * -1f;
        if (0f > fade) { fade = 0f; }
        if (1f < fade) { fade = 1f; }

        my_hide.color = new Vector4 (0f, 0f, 0f, fade);

        first = (5f - countdown) / 5f;
        second = first * (1f + ((countdown) / 25f));

        if (second > 1f) {second = 1f;}

        my_image_F.fillAmount = first;
        my_image_S.fillAmount = second;
    }
}
