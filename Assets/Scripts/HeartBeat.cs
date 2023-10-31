using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{

    public AnimationCurve my_curve;
    public Transform my_trans;

    // Start is called before the first frame update
    void Update()
    {
        my_trans.localScale = new Vector3(my_curve.Evaluate(Mind.time_in_level), my_curve.Evaluate(Mind.time_in_level), my_curve.Evaluate(Mind.time_in_level));
    }

}
