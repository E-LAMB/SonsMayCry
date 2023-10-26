using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMaingame : MonoBehaviour
{

    public float timer;
    public bool should_play;

    public Transform the_camera;
    public Quaternion camera_angle;
    public Vector3 camera_transform;

    public AnimationCurve angle_curve;
    public AnimationCurve position_curve;

    public Transform self;

    public PlayerController my_cam_controller;

    public bool should_give_control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (should_play)
        {
            timer += Time.deltaTime;

            camera_angle.x = angle_curve.Evaluate(timer);
            camera_transform.y = position_curve.Evaluate(timer);

            the_camera.position = camera_transform + self.position;
            the_camera.localRotation = camera_angle;

            if (timer > 5f && should_give_control)
            {
                should_play = false;
                my_cam_controller.should_be_in_control = true;
            }
        }

    }
}
