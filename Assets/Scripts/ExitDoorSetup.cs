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

    public int levers_found;

    // Start is called before the first frame update
    void Start()
    {
        random_chosen_direction = Random.Range(1, 5); // Random number from 1, 2, 3, 4

        my_trans.eulerAngles = new Vector3 (0f, (random_chosen_direction * 90f) - 90f, 0f);

        float offset = Random.Range(0, 20) * 5f;

        if (random_chosen_direction == 1) { my_trans.position = new Vector3 (-47.5f + offset, 0f, 0f);}
        if (random_chosen_direction == 2) { my_trans.position = new Vector3 (-50f, 0f, 2.5f + offset);}
        if (random_chosen_direction == 3) { my_trans.position = new Vector3 (-47.5f + offset, 0f, 100f);}
        if (random_chosen_direction == 4) { my_trans.position = new Vector3 (50f, 0f, 2.5f + offset);}
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
        wire_a.positions[0] = new Vector3(2f, 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
