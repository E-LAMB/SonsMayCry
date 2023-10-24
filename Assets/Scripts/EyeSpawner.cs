using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSpawner : MonoBehaviour
{

    public int maximum_eyes;
    public int spawned_eyes;
    public float time_since_eye_spawned;

    public GameObject[] eye_list;

    public bool activated;

    public float reveal_timer;

    // Start is called before the first frame update
    void Start()
    {
        maximum_eyes = 10;
        if (Mind.ability_two == 4)
        {
            maximum_eyes -= 3;
        }

        reveal_timer = 0f;

    }

    // Update is called once per frame
    void Update()
    {

        if (Mind.ability_one == 4 && Mind.levers_flipped > 1)
        {
            activated = true;

        } else if (Mind.ability_one != 4 && Mind.levers_flipped > 0)
        {
            activated = true;
        }

        Mind.focus_eye = (reveal_timer > 0f);

        // time_since_eye_spawned = 200f;

        if (activated)
        {
            if (Mind.eye_notification > -1f)
            {
                Mind.eye_notification -= Time.deltaTime;
            }
            if (reveal_timer > -1f)
            {
                reveal_timer -= Time.deltaTime;
            }

            time_since_eye_spawned += Time.deltaTime;

            if (time_since_eye_spawned > (15f + (spawned_eyes * 5f)) && spawned_eyes != maximum_eyes)
            {
                eye_list[spawned_eyes].SetActive(true);
                spawned_eyes += 1;
                time_since_eye_spawned = 0f;
                if (Mind.ability_two == 4) {reveal_timer = 10f;}
            }
        }
    }
}
