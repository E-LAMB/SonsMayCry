using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceAbility : MonoBehaviour
{

    public float gate_timer;
    public GameObject body;
    bool has_appeared;

    // Update is called once per frame
    void Update()
    {
        if (Mind.ability_two == 5 && Mind.levers_flipped > 3)
        {
            if (!has_appeared) {body.SetActive(true);}
            has_appeared = true;
            gate_timer -= Time.deltaTime;
            if (0f > gate_timer) 
            {
                body.transform.position = new Vector3(body.transform.position.x, 
                body.transform.position.y - (Time.deltaTime * 2f), body.transform.position.z);
            }
        }
    }
}
