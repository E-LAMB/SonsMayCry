using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reloading : MonoBehaviour
{

    public float countdown;
    public bool main_menu;
    public int scene_to_go;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "WelcomeBack" + ".txt"))
        {
            scene_to_go = 1;

        } else
        {
            scene_to_go = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        if (countdown > 10f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_go);
        }
    }
}
