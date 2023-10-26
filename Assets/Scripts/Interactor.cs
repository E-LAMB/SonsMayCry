using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{

    public LayerMask interactable_layer;
    public float interact_distance;

    UnityEvent on_interact;

    public KeyCode interaction_key;
    public TextMeshProUGUI my_text;

    public Image cursor;
    public Sprite interact;
    public Sprite normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interact_distance, interactable_layer))
        {
            if (hit.collider.GetComponent<Interactible>() != false)
            {
                on_interact = hit.collider.GetComponent<Interactible>().when_interacted;
                my_text.text = hit.collider.GetComponent<Interactible>().interaction_description;
                if (Input.GetKeyDown(interaction_key))
                {
                    on_interact.Invoke();
                }
                cursor.sprite = interact;
                my_text.text = "";
            } else
            {
                my_text.text = "";
                cursor.sprite = normal;
            }
        } else
        {
            my_text.text = "";
            cursor.sprite = normal;
        }
    }

}
