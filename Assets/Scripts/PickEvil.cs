using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickEvil : MonoBehaviour
{

    public GameObject[] evils;

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

        evils[random_number].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        RollEvils();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
