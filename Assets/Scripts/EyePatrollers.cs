using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePatrollers : MonoBehaviour
{

    public float range;
    public LayerMask player_layer;
    public Transform detector;

    public bool shaking;

    public float time_since_spot;

    public Vector3 new_target;
    public Transform self_trans;
    public Transform rotator;
    public float distance;
    public float time_till_path_find;

    public Quaternion shake_rotate;
    public Quaternion not_shake;

    public Light my_light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void PathFind()
    {
        new_target.y = self_trans.position.y;
        new_target.x = Random.Range(-155,20);
        new_target.z = Random.Range(-20,100);
        time_till_path_find = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (time_since_spot < 0f && Physics.CheckSphere(detector.position, range, player_layer))
        {
            time_since_spot = 20f;
            Mind.eye_notification = true;
        }    

        if (time_since_spot > 0f)
        {
            shaking = true;
        } else 
        {
            shaking = false;
        }

        if (shaking)
        {
            shake_rotate.x = Random.Range(-40,40);
            shake_rotate.y = Random.Range(-40,40);
            shake_rotate.z = Random.Range(-40,40);
            rotator.localRotation = shake_rotate;
            my_light.intensity = 0.5f;
        } else
        {
            rotator.localRotation = not_shake;
            my_light.intensity = 5f;
        }
        
        distance = Vector3.Distance(self_trans.position, new_target);

        if (distance < 2f)
        {
            time_till_path_find -= Time.deltaTime;
        }

        if (time_till_path_find < 0f)
        {
            PathFind();
        }

        time_since_spot -= Time.deltaTime;

        self_trans.position = Vector3.MoveTowards(self_trans.position, new_target, 5 * Time.deltaTime);

    }
}
