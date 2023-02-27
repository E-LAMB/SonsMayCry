using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public string corresponding_letter;

    public bool flipped = false;

    public float timer;

    public Transform my_rotator;
    public Quaternion rotating;

    public AnimationCurve rotating_curve;

    public void FlippedLever()
    {
        if (flipped == false)
        {
            flipped = true;
            if (corresponding_letter == "a") {Mind.lever_a_flipped = true;}
            if (corresponding_letter == "b") {Mind.lever_b_flipped = true;}
            if (corresponding_letter == "c") {Mind.lever_c_flipped = true;}
            if (corresponding_letter == "d") {Mind.lever_d_flipped = true;}
            Mind.lever_notification = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flipped)
        {
            timer += Time.deltaTime;
        }

        rotating.x = rotating_curve.Evaluate(timer);
        my_rotator.localRotation = rotating;

    }
}
