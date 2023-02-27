using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
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

    public Transform spawn;
    public bool has_spawned;

    public float nav_x_bound_min;
    public float nav_x_bound_max;
    public float nav_z_bound_min;
    public float nav_z_bound_max;

    public float terror_radius_start_size;
    public float awareness_radius_start_size;
    public float movement_start_speed;

    public float increment_terror;
    public float increment_awareness;
    public float increment_speed;
	
	public float terror_radius_final_size;
    public float awareness_radius_final_size;
    public float movement_final_speed;
	
	public AudioSource my_terror;
	
	public GameObject overhead_light;

    // Start is called before the first frame update
    void Start()
    {
        my_agent.enabled = false;
    }

    public void SpawnsMommy()
    {
        self.position = spawn.position;
        my_agent.enabled = true;
        has_spawned = true;
        should_move = true;
        KnowsLocation(5f);
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
            SpawnsMommy();
        }
		
		terror_radius_final_size = terror_radius_start_size + (increment_terror * Mind.levers_flipped);
		awareness_radius_final_size = awareness_radius_start_size + (increment_awareness * Mind.levers_flipped);
		movement_final_speed = movement_start_speed - (increment_speed * Mind.levers_flipped);
		
		my_terror.maxDistance = terror_radius_final_size;
		
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

        RaycastHit hit;

        player_distance = Vector3.Distance(player.position, self.position);
        navigation_distance = Vector3.Distance(navigation_location, self.position);
        player_direction = (self.position - player.position);
        player_direction = player_direction * -1f;

        has_sight = Physics.Raycast(self.position, player_direction, out hit, player_distance, wall_layer);
        has_sight = !has_sight;
		
		if (awareness_radius_final_size > player_distance)
		{
			KnowsLocation(0.1f);
		}

        if (has_sight)
        {
            KnowsLocation(2f + Mind.levers_flipped);
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
