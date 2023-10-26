using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentUnlocking : MonoBehaviour
{

    public float time_stay_raised;
    public int times_raised;

    public Interactible my_interactible;

    public Collider my_col;

    public bool is_up;

    public float curve_time;

    public AnimationCurve ani_rotation;
    public AnimationCurve ani_position;

    public Transform mover;

    public float rotation_modifier;

    public void Raise()
    {

        if (!is_up)
        {
            time_stay_raised = Random.Range(20f, 30f) + (times_raised * 5f);
            is_up = true;

            if (times_raised < 4)
            {
                Mind.shards_earnt_unlocking += 100 - (times_raised * 25);
            }

            times_raised += 1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        if (Random.Range(0,2) == 1)
        {
            rotation_modifier = Random.Range(0.6f,1f);
        } else
        {
            rotation_modifier = Random.Range(0.6f,1f) * -1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        mover.localPosition = new Vector3 (0f, ani_position.Evaluate(curve_time), 0f);
        mover.eulerAngles = new Vector3 (mover.eulerAngles.x, mover.eulerAngles.y, ani_rotation.Evaluate(curve_time) * rotation_modifier);

        if (time_stay_raised > -1f) {time_stay_raised -= Time.deltaTime;}

        if (time_stay_raised < 0f && is_up)
        {
            is_up = false;
        }

        my_col.enabled = (curve_time < 0.9f);

        if (is_up)
        {
            if (curve_time < 1f) {curve_time += Time.deltaTime;}

        } else
        {
            if (curve_time > 0f) {curve_time -= Time.deltaTime * 2f;}
        }

    }
}
