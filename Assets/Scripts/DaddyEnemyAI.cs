using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DaddyEnemyAI : MonoBehaviour
{
    public NavMeshAgent my_agent;

    public Vector3 navigation_location;

    public float interest_time;

    public Transform player;
    public Transform self;

    public bool has_sight;

    public float player_distance;
    public Vector3 player_direction;

    public float navigation_distance;

    public LayerMask wall_layer;

    public bool should_move;

    public bool has_spawned;

    public float nav_x_bound_min;
    public float nav_x_bound_max;
    public float nav_z_bound_min;
    public float nav_z_bound_max;

    public float movement_start_speed;
    public float increment_speed;
    public float movement_final_speed;
	
	public AudioSource my_terror;
	
	public GameObject overhead_light;

    public float awareness_radius;

    // Start is called before the first frame update
    void Start()
    {
        my_agent.enabled = false;
    }

    public void SpawnsDaddy()
    {
        self.position = new Vector3 (0f, 0f, 3f);
        my_agent.enabled = true;
        has_spawned = true;
        should_move = true;
        KnowsLocation(5f);
        Mind.enemy_present = true;
    }

    void FindNewNavigation()
    {
        Vector3 new_nav;
        new_nav.x = Random.Range(nav_x_bound_min, nav_x_bound_max);
        new_nav.z = Random.Range(nav_z_bound_min, nav_z_bound_max);
        new_nav.y = self.position.y;
        navigation_location = new_nav;
    }

    public void KnowsLocation(float knowing_time)
    {
        interest_time = knowing_time;
    }

    // Update is called once per frame
    void Update()
    {

        Mind.levers_flipped = 0;
        if (Mind.lever_a_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_b_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_c_flipped) {Mind.levers_flipped += 1;}
        if (Mind.lever_d_flipped) {Mind.levers_flipped += 1;}

        if (!has_spawned && Mind.levers_flipped > 0)
        {
            SpawnsDaddy();
        }

        if (!has_spawned && Mind.time_in_level > 15f && Mind.ability_two == 1)
        {
            SpawnsDaddy();
        }
		
		movement_final_speed = movement_start_speed - (increment_speed * Mind.levers_flipped);
		
		if (Mind.levers_flipped == 4)
		{
			KnowsLocation(5f);
			movement_final_speed += 1;
			overhead_light.SetActive(true);
		}
		
		if (has_spawned)
		{
			my_agent.speed = movement_final_speed;
		}

        if (Mind.lever_notification == true && has_spawned)
        {
            Mind.lever_notification = false;
            KnowsLocation(5f + (Mind.levers_flipped * 2f));
        }

        if (Mind.eye_notification > 0f && has_spawned)
        {
            KnowsLocation(1f);
        }

        RaycastHit hit;

        player_distance = Vector3.Distance(player.position, self.position);
        navigation_distance = Vector3.Distance(navigation_location, self.position);
        player_direction = (self.position - player.position);
        player_direction = player_direction * -1f;

        has_sight = Physics.Raycast(self.position, player_direction, out hit, player_distance, wall_layer);
        has_sight = !has_sight;
		
		if (awareness_radius > player_distance)
		{
			KnowsLocation(0.1f);
		}

        if (has_sight)
        {
            KnowsLocation(2.5f + Mind.levers_flipped);
        }

        if (interest_time > -10f)
        {
            interest_time -= Time.deltaTime;
        }

        if (interest_time > 0f)
        {
            navigation_location = player.position;
        }

        if (navigation_distance < 5f && interest_time < -5f)
        {
            FindNewNavigation();
        }

        if (should_move)
        {
            my_agent.SetDestination(navigation_location);
        }
    }
}
