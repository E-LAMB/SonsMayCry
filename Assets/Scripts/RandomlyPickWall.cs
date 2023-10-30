using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyPickWall : MonoBehaviour
{

    public GameObject[] selection;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (Random.Range(0, 35) == 2)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                selection[i].SetActive(false);
            }
            selection[Random.Range(0, selection.Length)].SetActive(true);

        } else
        {
            gameObject.GetComponent<RandomlyPickWall>().enabled = false;
        }
        */
    }

}
