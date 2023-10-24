using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityShower : MonoBehaviour
{

    public Image ability_1;
    public Image ability_2;
    public Image only_one;

    public Image backing_only;
    public Image backing_ability_1;
    public Image backing_ability_2;

    public Sprite[] all_abilities;

    // Start is called before the first frame update
    void Start()
    {
        if (Mind.ability_one == 0 || Mind.ability_two == 0)
        {
            // One or no abilities

            ability_1.enabled = false;
            ability_2.enabled = false;
            backing_ability_1.enabled = false;
            backing_ability_2.enabled = false;

            if (Mind.ability_one != 0)
            {
                only_one.sprite = all_abilities[Mind.ability_one];
            } 
            if (Mind.ability_two != 0)
            {
                only_one.sprite = all_abilities[Mind.ability_two];
            }
            if (Mind.ability_one == 0 && Mind.ability_two == 0)
            {
                only_one.enabled = false;
                backing_only.enabled = false;
            }

        } else
        {
            // Two abilities

            only_one.enabled = false;
            backing_only.enabled = false;

            ability_1.sprite = all_abilities[Mind.ability_one];
            ability_2.sprite = all_abilities[Mind.ability_two];

        }
    }
}
