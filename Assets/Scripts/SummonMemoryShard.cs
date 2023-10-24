using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMemoryShard : MonoBehaviour
{

    public bool is_ability_a;
    public GameObject to_summon;
    
    float reveal_time;

    void Start()
    {
        if (is_ability_a)
        {
            if (Mind.ability_one != 2) {Destroy(gameObject);}
        } 
        if (!is_ability_a)
        {
            if (Mind.ability_two != 2) {Destroy(gameObject);}
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_ability_a && Mind.levers_flipped > 0)
        {
            to_summon.SetActive(true);
            gameObject.GetComponent<SummonMemoryShard>().enabled = false;
        }

        if (!is_ability_a && Mind.levers_flipped > 3 && reveal_time == 0f)
        {
            to_summon.SetActive(true);
            reveal_time = 25f;
            Mind.focus_memory = true;
        }

        if (reveal_time > 0f) {reveal_time -= Time.deltaTime;}

        if (5f > reveal_time && Mind.levers_flipped > 3)
        {
            Mind.focus_memory = false;
            gameObject.GetComponent<SummonMemoryShard>().enabled = false;
        }
    }
}
