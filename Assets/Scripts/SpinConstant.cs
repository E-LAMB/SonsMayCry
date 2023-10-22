using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinConstant : MonoBehaviour
{

    public Vector3 our_vec;
    public Transform[] transforms_to_modify;

    int current_modify = 0;

    public Vector3[] the_trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current_modify = 0;

        while (current_modify < transforms_to_modify.Length)
        {
            the_trans[current_modify] += our_vec * Time.deltaTime * (current_modify + 1);

            the_trans[current_modify].x += Random.Range(0f, 8f) * Time.deltaTime;
            the_trans[current_modify].y += Random.Range(0f, 8f) * Time.deltaTime;
            the_trans[current_modify].z += Random.Range(0f, 8f) * Time.deltaTime;

            if (the_trans[current_modify].x > 360f) {the_trans[current_modify].x -= 360f;}
            if (the_trans[current_modify].y > 360f) {the_trans[current_modify].y -= 360f;}
            if (the_trans[current_modify].z > 360f) {the_trans[current_modify].z -= 360f;}

            transforms_to_modify[current_modify].eulerAngles = the_trans[current_modify];
            current_modify += 1;
        }
    }
}
