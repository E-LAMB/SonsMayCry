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
    }

    public void EnterLabyrinth()
    {
        self_transform.position = Vector3.zero;

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
        target_location = alert_origin;
        nav_agent.SetDestination(alert_origin);
    }

    // Update is called once per frame
    void Update()
    {
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
            terror_radius.maxDistance = stat_terror + (increment_terror * Mind.levers_flipped);

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

            if ((stat_awareness + (increment_awareness * Mind.levers_flipped)) > player_distance)
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

            nav_agent.speed = stat_speed + (increment_speed * Mind.levers_flipped);

        }
		
    }
}