using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEyeEnemy : MonoBehaviour
{

    public Transform my_trans;
    public Vector3 final_position;

    public int currently_moving;
    public float time_until_move;
    public float current_charge;

    public bool in_place;
    public Light my_light;

    public float size;

    public AnimationCurve the_y;
    public float anim_time;

    public GameObject detector;
    public LayerMask player_layer;

    // Start is called before the first frame update
    void Start()
    {
        currently_moving = 2;
        my_trans.position = new Vector3((Random.Range(-9, 11) * 5f)-2.5f, 200f, (Random.Range(1, 21) * 5f)-2.5f);
        in_place = false;
    }

    void FindNewPlace()
    {
        final_position = new Vector3((Random.Range(-9, 11) * 5f)-2.5f, 7f, (Random.Range(1, 21) * 5f)-2.5f);
        currently_moving = 1;
        time_until_move = 30f;
        current_charge = 20f;
        in_place = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (current_charge > 18f && Physics.CheckSphere(detector.transform.position, 1.5f, player_layer) && in_place)
        {
            current_charge = 0f;
            in_place = false;
            FindNewPlace();
            time_until_move = 0f;
            Mind.eye_notification = true;
        }    

        size = 1f - ((my_trans.position.y - 7f) / 50f);
        if (size > 1f) {size = 1f;}
        if (size < 0f) {size = 0f;}
        my_trans.localScale = new Vector3 (size, size, size);

        my_light.enabled = in_place;
        time_until_move -= Time.deltaTime;

        if (currently_moving == 1)
        {
            anim_time += Time.deltaTime;
            my_trans.position = new Vector3 (my_trans.position.x, the_y.Evaluate(anim_time), my_trans.position.z);
            current_charge += Time.deltaTime;
            if (my_trans.position.y > 180f && current_charge > 20f)
            {
                currently_moving = 2;
                my_trans.position = final_position;
                my_trans.position = new Vector3 (my_trans.position.x, 180f, my_trans.position.z);
            }
        }
        if (currently_moving == 2)
        {
            anim_time -= Time.deltaTime;
            my_trans.position = new Vector3 (my_trans.position.x, the_y.Evaluate(anim_time), my_trans.position.z);
            if (my_trans.position.y <= 7f)
            {
                my_trans.position = new Vector3 (my_trans.position.x, 7f, my_trans.position.z);
                currently_moving = 0;
                time_until_move = 25f;;
                in_place = true;
            }
        }

        if (time_until_move < 0f)
        {
            FindNewPlace();
        }
    }
}
