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

    public Transform left_anch;
    public Transform right_anch;

    public bool is_activated;

    public bool fixed_amount;

    // Start is called before the first frame update
    void Start()
    {
        if (!fixed_amount)
        {
            levers_required = Random.Range(1,5);
        }
        left_door.position = left_anch.position;
        right_door.position = right_anch.position;
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
