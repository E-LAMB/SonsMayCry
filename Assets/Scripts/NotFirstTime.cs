using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFirstTime : MonoBehaviour
{

    public GameObject below;

    // Start is called before the first frame update
    void Start()
    {
        if (Mind.in_home_before)
        {
            below.SetActive(true);

        } else
        {
            Mind.in_home_before = true;
            Destroy(gameObject);
        }
    }

}
