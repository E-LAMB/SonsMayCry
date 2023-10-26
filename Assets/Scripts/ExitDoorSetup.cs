using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorSetup : MonoBehaviour
{

    public Transform my_trans;

    public int random_chosen_direction;
    // 1 = SOUTH (on my paper here)
    // 2 = WEST
    // 3 = NORTH
    // 4 = EAST

    public GameObject lever_a;
    public GameObject lever_b;
    public GameObject lever_c;
    public GameObject lever_d;

    public LineRenderer wire_a;
    public LineRenderer wire_b;
    public LineRenderer wire_c;
    public LineRenderer wire_d;

    public GameObject wire_object_a;
    public GameObject wire_object_b;
    public GameObject wire_object_c;
    public GameObject wire_object_d;

    public int levers_found;

    public bool is_tutorial;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetupWires(GameObject spot)
    {
        if (levers_found == 0)
        {
            lever_a = spot;
            levers_found += 1;
        } else if (levers_found == 1)
        {
            lever_b = spot;
            levers_found += 1;
        } else if (levers_found == 2)
        {
            lever_c = spot;
            levers_found += 1;

        } else if (levers_found == 3)
        {
            lever_d = spot;
            levers_found += 1;

            ConnectWires();
        } 
    }

    void ConnectWires()
    {
        if (!is_tutorial)
        {
            random_chosen_direction = Random.Range(1, 5); // Random number from 1, 2, 3, 4

            my_trans.eulerAngles = new Vector3 (0f, (random_chosen_direction * 90f) - 90f, 0f);

            float offset = Random.Range(0, 20) * 5f;

            if (random_chosen_direction == 1) { my_trans.position = new Vector3 (-47.5f + offset, 0f, 0f);}
            if (random_chosen_direction == 2) { my_trans.position = new Vector3 (-50f, 0f, 2.5f + offset);}
            if (random_chosen_direction == 3) { my_trans.position = new Vector3 (-47.5f + offset, 0f, 100f);}
            if (random_chosen_direction == 4) { my_trans.position = new Vector3 (50f, 0f, 2.5f + offset);}
        }

        wire_object_a.transform.position = my_trans.position;
        wire_object_b.transform.position = my_trans.position;
        wire_object_c.transform.position = my_trans.position;
        wire_object_d.transform.position = my_trans.position;

        wire_a.SetPosition(0, new Vector3 (0f, 0f, 0f));
        wire_b.SetPosition(0, new Vector3 (0f, 0f, 0f));
        wire_c.SetPosition(0, new Vector3 (0f, 0f, 0f));
        wire_d.SetPosition(0, new Vector3 (0f, 0f, 0f));

        wire_a.SetPosition(1, new Vector3 (0f, -2f, 0f));
        wire_b.SetPosition(1, new Vector3 (0f, -2f, 0f));
        wire_c.SetPosition(1, new Vector3 (0f, -2f, 0f));
        wire_d.SetPosition(1, new Vector3 (0f, -2f, 0f));

        wire_a.SetPosition(2, new Vector3 (my_trans.position.x - lever_a.transform.position.x, -2f, my_trans.position.z - lever_a.transform.position.z));
        wire_b.SetPosition(2, new Vector3 (my_trans.position.x - lever_b.transform.position.x, -2f, my_trans.position.z - lever_b.transform.position.z));
        wire_c.SetPosition(2, new Vector3 (my_trans.position.x - lever_c.transform.position.x, -2f, my_trans.position.z - lever_c.transform.position.z));
        wire_d.SetPosition(2, new Vector3 (my_trans.position.x - lever_d.transform.position.x, -2f, my_trans.position.z - lever_d.transform.position.z));

        wire_a.SetPosition(3, new Vector3 (my_trans.position.x - lever_a.transform.position.x, 0f, my_trans.position.z - lever_a.transform.position.z));
        wire_b.SetPosition(3, new Vector3 (my_trans.position.x - lever_b.transform.position.x, 0f, my_trans.position.z - lever_b.transform.position.z));
        wire_c.SetPosition(3, new Vector3 (my_trans.position.x - lever_c.transform.position.x, 0f, my_trans.position.z - lever_c.transform.position.z));
        wire_d.SetPosition(3, new Vector3 (my_trans.position.x - lever_d.transform.position.x, 0f, my_trans.position.z - lever_d.transform.position.z));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
