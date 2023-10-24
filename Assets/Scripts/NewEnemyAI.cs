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

    public AudioSource terror_radius;

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

    public Vector3 target_location;

    // Start is called before the first frame update
    void Start()
    {
        nav_agent.enabled = false;
    }

    public void EnterLabyrinth()
    {
        self_transform.position = Vector3.zero;

        nav_agent.enabled = true;

        has_entered_labyrinth = true;
        Mind.enemy_present = true;
    }

    public void RandomlyRoam()
    {

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

        terror_radius.maxDistance = stat_terror + (increment_terror * Mind.levers_flipped);
		
    }
}
