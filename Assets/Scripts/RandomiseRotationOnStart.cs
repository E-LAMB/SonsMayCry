using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseRotationOnStart : MonoBehaviour
{

    public bool rotate_x;
    public bool rotate_y;
    public bool rotate_z;

    // Start is called before the first frame update
    void Start()
    {
        if (rotate_x) {gameObject.transform.eulerAngles = new Vector3 (Random.Range(-360f, 360f), gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);}
        if (rotate_y) {gameObject.transform.eulerAngles = new Vector3 (gameObject.transform.eulerAngles.x, Random.Range(-360f, 360f), gameObject.transform.eulerAngles.z);}
        if (rotate_z) {gameObject.transform.eulerAngles = new Vector3 (gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, Random.Range(-360f, 360f));}
    }
}
