using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyAI : MonoBehaviour
{

    public NavMeshAgent nav_agent;

    public Transform self_transform;
    public Transform player_transform;

    public bool has_entered_labyrinth;

    public float knowing_time;

    public bool has_LOS; // Has Line Of Sight
    public float player_distance;
    public Vector3 player_direction;

    public LayerMask player_layer;
    public LayerMask wall_layer;
    public LayerMask floor_layer;

    public AudioSource terror_radius;

    public float target_distance;
    public Vector3 target_location;

    public Transform boundary_a;
    public Transform boundary_b;

    public Transform spawn_location;

    public float notification_cooldown;

    // public string special_ability;
    // There are no special abilities... Sorry

    [Header("Enemy Stats")]
    public float stat_awareness;
    public float stat_speed;
    public float stat_terror;
    public float stat_memory;
    public float increment_awareness;
    public float increment_speed;
    public float increment_terror;
    public float increment_memory;

    // Start is called before the first frame update
    void Start()
    {
        nav_agent.enabled = false;

        terror_radius.enabled = false;

        if (Mind.hell_mode) 
        {
            stat_awareness += 12f;
            stat_speed += 1.5f;
            stat_memory += 4f;
            increment_awareness += 2f;
            increment_speed += 1;
            increment_memory += 1;
        }
    }

    public void EnterLabyrinth()
    {
        self_transform.position = spawn_location.position;

        nav_agent.enabled = true;

        has_entered_labyrinth = true;
        Mind.enemy_present = true;

        terror_radius.enabled = true;
    }

    public void RandomlyRoam()
    {
        Vector3 proposed_location = self_transform.position;
        proposed_location.x = Random.Range(boundary_a.position.x, boundary_b.position.x);
        proposed_location.z = Random.Range(boundary_a.position.z, boundary_b.position.z);

        float proposed_distance_to_target = Vector3.Distance(self_transform.position, proposed_location);
        float proposed_to_player = Vector3.Distance(self_transform.position, player_transform.position);

        if (Physics.Raycast(proposed_location, -transform.up, 2f, floor_layer) && proposed_to_player < 140f)
        {
            Alerted(proposed_location);
        }

    }

    public void Alerted(Vector3 alert_origin)
    {
        if (notification_cooldown > 0f)
        {
            target_location = alert_origin;
            nav_agent.SetDestination(alert_origin);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (notification_cooldown > -1f) {notification_cooldown -= Time.deltaTime;}

        if (!has_entered_labyrinth && Mind.time_in_level > 15f && Mind.ability_two == 1)
        {
            EnterLabyrinth();
        }
        if (!has_entered_labyrinth && Mind.levers_flipped > 0)
        {
            EnterLabyrinth();
        }

        if (knowing_time > -1f) {knowing_time -= Time.deltaTime;}

        if (has_entered_labyrinth)
        {
            if (Mind.ability_two == 6)
            {
                terror_radius.maxDistance = (stat_terror + (increment_terror * Mind.levers_flipped)) / 2f;
            } else
            {
                terror_radius.maxDistance = stat_terror + (increment_terror * Mind.levers_flipped);
            }

            player_direction = (self_transform.position - player_transform.position);
            player_direction = player_direction * -1f;

            player_distance = Vector3.Distance(self_transform.position, player_transform.position);
            target_distance = Vector3.Distance(self_transform.position, target_location);

            has_LOS = Physics.Raycast(self_transform.position, player_direction, player_distance, player_layer) && !Physics.Raycast(self_transform.position, player_direction, player_distance, wall_layer);

            if (has_LOS)
            {
                knowing_time = stat_memory + (increment_memory * Mind.levers_flipped);
            }

            if (target_distance < 1.5f)
            {
                RandomlyRoam();
            }

            if (((stat_awareness + (increment_awareness * Mind.levers_flipped)) + (Mind.total_escapes)) > player_distance)
            {
                knowing_time = stat_memory + (increment_memory * Mind.levers_flipped);
            }

            if (Mind.lever_notification == true)
            {
                Mind.lever_notification = false;
                Alerted(player_transform.position);
            }

            if (knowing_time > 0f)
            {
                Alerted(player_transform.position);
            }

            if (Mind.levers_flipped > 3)
            {
                knowing_time = 1f;
            }

            nav_agent.speed = stat_speed + (increment_speed * Mind.levers_flipped);

        }
		
    }
}
