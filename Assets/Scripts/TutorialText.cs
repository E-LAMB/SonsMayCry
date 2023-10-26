using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{

    public bool should_delete;
    public string new_text;
    public TextMeshProUGUI text;
    public GameObject box;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            box.SetActive(true);
            text.text = new_text;
            // if (should_delete) {Destroy(gameObject);}
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            box.SetActive(false);
            text.text = new_text;
            if (should_delete) {Destroy(gameObject);}
        }
    }
}
