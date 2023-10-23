using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlayer : MonoBehaviour
{

    private float yaw, pitch;
    public float sensitivity;

    public float walk_speed;
    public float sprint_speed;
    public float crouch_speed_penalty;
    
    public float stamina;
    public float max_stamina;
    public float time_since_ran;

    public bool is_crouching;
    public bool is_sprinting;
    public bool able_to_sprint;

    public KeyCode key_sprint;
    public KeyCode key_crouch;

    private Rigidbody rb;

    public bool should_be_in_control;

    public GameObject my_camera;
    public Transform cam_trans;

    public Transform trans_stand;
    public Transform trans_crouch;

    float speed;

    public bool false_standin;

    public GameObject standing_body;

    public float crouch_anim_speed;
	
	public float recovery_time;
	public bool is_recovering;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (should_be_in_control)
        {

            //Camera Control
            if (false_standin)
            {
                Cursor.lockState = CursorLockMode.Confined;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
                pitch = Mathf.Clamp(pitch, -90, 90);
                yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
                my_camera.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);  
            }

            if (Input.GetKeyDown(key_sprint) && !is_sprinting && able_to_sprint && !is_recovering)
            {
                is_sprinting = true;
            }
            if (Input.GetKeyUp(key_sprint) && is_sprinting)
            {
                is_sprinting = false;
            }

            if (is_sprinting)
            {

                speed = sprint_speed;

                if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Vertical") != 0f)
                {
                    stamina -= Time.deltaTime * 7.5f;
                    time_since_ran = 0f;
                }
				
				if (is_recovering)
				{
					is_sprinting = false;
				}

            } else
            {
                speed = walk_speed;
            }
			
			if (stamina <= 0f)
			{
				is_recovering = true;
			}
			
			if (stamina >= max_stamina)
			{
				is_recovering = false;
			}

            if (Input.GetKeyDown(key_crouch))
            {
                is_crouching = !is_crouching;
            }


            if (is_crouching)
            {
                speed -= crouch_speed_penalty;
                standing_body.SetActive(false);
                cam_trans.position = Vector3.MoveTowards(cam_trans.position, trans_crouch.position, crouch_anim_speed * Time.deltaTime);
            } else
            {
                standing_body.SetActive(true);
                cam_trans.position = Vector3.MoveTowards(cam_trans.position, trans_stand.position, crouch_anim_speed * Time.deltaTime);
            }

            time_since_ran += Time.deltaTime;
			
			if (time_since_ran > recovery_time && stamina < max_stamina)
			{
				stamina += Time.deltaTime * 30f;
			}
        }
    }

    private void FixedUpdate()
    {
        if (should_be_in_control)
        {
            //Movement
            if (false_standin)
            {
                // nothing happens
            } else
            {
                Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
                Vector3 forward = new Vector3(-my_camera.transform.right.z, 0, my_camera.transform.right.x);
                Vector3 wishDirection = (forward * axis.x + my_camera.transform.right * axis.y + Vector3.up * rb.velocity.y);
                rb.velocity = wishDirection;
            }
        } else
        {
                Vector2 axis = new Vector2(0f, 0f) * speed;
                Vector3 forward = new Vector3(-my_camera.transform.right.z, 0, my_camera.transform.right.x);
                Vector3 wishDirection = (forward * axis.x + my_camera.transform.right * axis.y + Vector3.up * rb.velocity.y);
                rb.velocity = wishDirection;
        }
    }
}