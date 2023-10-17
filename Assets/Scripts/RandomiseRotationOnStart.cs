using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseRotationOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3 (Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
    }
}
