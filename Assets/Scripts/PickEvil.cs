using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PickEvil : MonoBehaviour
{

    public GameObject[] evils;

    bool playmate;

    public Transform spawn_location;

    public float location_a_dist;
    public float location_b_dist;

    public Transform player;

    void RollEvils()
    {
        int random_number = 0;
        bool valid = false;
        int heat = 0;

        while (!valid && 500 > heat)
        {
            random_number = Random.Range(0, evils.Length);
            heat += 1;
            if (evils[random_number] != null)
            {
                valid = true;
            }
        }
        if (heat > 450)
        {
            Debug.Log("Heat Broke");
        }

        evils[random_number].SetActive(true);
        // Debug.Log(evils[random_number].name);
        evils[random_number] = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/" + "EscapedLabyrinth" + ".txt"))
        {
            // File.Create(Application.persistentDataPath + "/" + "BeenInLabyrinth" + ".txt"); // obviously not seen
            gameObject.GetComponent<PickEvil>().enabled = false;

        } else
        {
            RollEvils();
        }
    }

    // Update is called once per frame
    void Update()
    {
        location_a_dist = Vector3.Distance(player.position, new Vector3(-45.5f, 0f, 97.5f));
        location_b_dist = Vector3.Distance(player.position, new Vector3(47.5f, 0f, 2.5f));

        if (location_a_dist < location_b_dist)
        {
            spawn_location.position = new Vector3(47.5f, 0f, 2.5f);
        } else
        {
            spawn_location.position = new Vector3(-45.5f, 0f, 97.5f);
        }

        if (Mind.ability_one == 5 && Mind.levers_flipped > 2 && !playmate)
        {
            RollEvils();
            playmate = true;
        }
    }
}
