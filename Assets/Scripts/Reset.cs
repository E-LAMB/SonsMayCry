using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    bool got;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && got)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            ResetGame();
        }   
    }

    void ResetGame()
    {
        Mind.levers_flipped = 0; // How many levers have been activated

        Mind.lever_a_flipped = false;
        Mind.lever_b_flipped = false;
        Mind.lever_c_flipped = false;
        Mind.lever_d_flipped = false;

        Mind.cans_collected = 0;

        Mind.lever_notification = false;
        Mind.eye_notification = -1f;
        Mind.time_in_level = 0f;
        Mind.cans_collected = 0;

        Mind.enemy_present = false;

        Mind.shards_earnt_lever = 0;
        Mind.shards_earnt_escape = 0;
        Mind.shards_earnt_escape_bonus = 0;
        Mind.shards_earnt_memory = 0;
        Mind.shards_earnt_soda = 0;
        Mind.shards_earnt_unlocking = 0;

        Debug.Log("GOT CAUGHT!!");
        // Debug.Break();

        got = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
