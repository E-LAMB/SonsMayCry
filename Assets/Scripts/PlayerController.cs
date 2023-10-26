using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public GameObject canvas;

    public float yaw, pitch;
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

    public TextMeshProUGUI shard_count;

    public bool false_standin;

    public GameObject standing_body;

    public float crouch_anim_speed;
	
	public float recovery_time;
	public bool is_recovering;

    public Transform sprint_bar;

    public float total_length;

    public Vector3 length_vec;
    
    public bool should_show_bar;
    public GameObject bar_object;

    public Vector4 color_active;
    public Vector4 color_inactive;
    public RawImage bar_rend;

    public float time_active;

    public GameObject[] mazes;

    public float time_since_first_lever;
    public float time_since_last_lever;
    public float time_since_enemy_spawn;

    public float timer_sec;
    public int timer_min_int;
    public int timer_sec_int;
    public TextMeshProUGUI timer_text;

    public float time_since_last_activation;

    public GameObject overhead;

    public bool is_tutorial;

    public void LeverFlipped()
    {
        if (Mind.ability_two == 3)
        {
            is_recovering = false;
            time_since_ran = 2f;
            stamina = max_stamina;
        }
        Mind.levers_flipped = 0;
        if (Mind.lever_a_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_b_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_c_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_d_flipped) {Mind.levers_flipped += 1;}

        if (Mind.levers_flipped == 4)
        {
            overhead.SetActive(true);
        }
    }

    private void Start()
    {

        for (int i = 0; i < mazes.Length; i++)
        {
            mazes[i].SetActive(false);
        }

        if (!is_tutorial) {
            gameObject.transform.position = new Vector3((Random.Range(-9, 11) * 5f)-2.5f, gameObject.transform.position.y, (Random.Range(1, 21) * 5f)-2.5f);
            gameObject.transform.eulerAngles = new Vector3 (0f, Random.Range(0, 4) * 90f, 0f);
        }

        mazes[Random.Range(0, mazes.Length)].SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        canvas.SetActive(true);

        Mind.time_in_level = 0f;

        Mind.levers_flipped = 0;
        if (Mind.lever_a_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_b_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_c_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_d_flipped) {Mind.levers_flipped += 1;}
    }

    private void Update()
    {   

        time_since_last_activation += Time.deltaTime;

        timer_sec += Time.deltaTime;
        if (timer_sec > 1f)
        {
            timer_sec -= 1f;
            timer_sec_int += 1;
            if (timer_sec_int > 59)
            {
                timer_sec_int -= 60;
                timer_min_int += 1;
            }
            if (timer_sec_int > 9)
            {
                timer_text.text = timer_min_int.ToString() + ":" + timer_sec_int.ToString();
            } else
            {
                timer_text.text = timer_min_int.ToString() + ":0" + timer_sec_int.ToString();
            }
        }

        shard_count.text = (Mind.shards_earnt_escape + 
        Mind.shards_earnt_escape_bonus + Mind.shards_earnt_lever + 
        Mind.shards_earnt_memory + Mind.shards_earnt_soda
        + Mind.shards_earnt_unlocking).ToString();

        if (Mind.levers_flipped > 0)
        {
            time_since_first_lever += Time.deltaTime;
        }
        if (Mind.levers_flipped > 3)
        {
            time_since_last_lever += Time.deltaTime;
        }
        if (Mind.enemy_present)
        {
            time_since_enemy_spawn += Time.deltaTime;
        }

        if (Mind.ability_one == 1 && time_since_enemy_spawn < 20f && Mind.enemy_present)
        {
            Mind.focus_threat = true;
        } else if (Mind.ability_one == 1 && time_since_last_lever < 10f && Mind.levers_flipped > 3)
        {
            Mind.focus_threat = true;

        } else if (Mind.ability_one == 6 && Mind.levers_flipped > 0 && time_since_last_activation < 5f)
        {
            Mind.focus_threat = true;

        } else
        {
            Mind.focus_threat = false;
        }

        // Mind.focus_threat = true;

        Mind.time_in_level += Time.deltaTime;

        bar_object.SetActive(should_show_bar);
        if (!should_be_in_control)
        {
            should_show_bar = false; 
            time_active = 0f;
        }
        if (should_be_in_control)
        {
            time_active += Time.deltaTime;

            if (is_recovering)
            {
                bar_rend.color = color_inactive;
            } else
            {
                bar_rend.color = color_active;
            }

            if (Mind.ability_one == 3 && stamina < 20f && Mind.time_in_level < 60f)
            {
                stamina = 20f;
                bar_rend.color = Color.yellow;
            }

            should_show_bar = false;

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

            length_vec.x = total_length * (stamina / max_stamina);
            sprint_bar.localScale = length_vec;

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

                time_active = 5f;

                should_show_bar = true;

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

            if (time_since_ran <= 3f)
            {
                should_show_bar = true;
            }

            if (Input.GetKeyDown(key_crouch))
            {
                is_crouching = !is_crouching;
            }

            if (is_crouching)
            {
                speed -= crouch_speed_penalty;
                if (is_sprinting) {speed -= crouch_speed_penalty;}
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
                stamina += Time.deltaTime * 25f;

                stamina += Time.deltaTime * Mind.cans_collected * 10f;

                should_show_bar = true;
            }      

            if (3.2f > time_active)
            {
                should_show_bar = false;
            } 

            if (stamina < 0f) {stamina = 0f;}

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
            rb.velocity = Vector3.zero;
        }
    }
}
