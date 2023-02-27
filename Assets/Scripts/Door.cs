using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public float door_speed;
    public int levers_required;

    public Transform left_door;
    public Transform right_door;

    public Transform left_go;
    public Transform right_go;

    public bool is_activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levers_required <= Mind.levers_flipped)
        {
            is_activated = true;
        }

        if (is_activated)
        {
            left_door.position = Vector3.MoveTowards(left_door.position, left_go.position, door_speed * Time.deltaTime);
            right_door.position = Vector3.MoveTowards(right_door.position, right_go.position, door_speed * Time.deltaTime);
        }
    }
}
