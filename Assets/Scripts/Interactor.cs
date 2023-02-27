using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{

    public LayerMask interactable_layer;
    public float interact_distance;

    UnityEvent on_interact;

    public KeyCode interaction_key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interact_distance, interactable_layer))
        {
            if (hit.collider.GetComponent<Interactible>() != false)
            {
                on_interact = hit.collider.GetComponent<Interactible>().when_interacted;
                if (Input.GetKeyDown(interaction_key))
                {
                    on_interact.Invoke();
                }
            }
        }
    }

}
