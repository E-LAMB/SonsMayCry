using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    
    public void Switch(int new_place)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(new_place);
    }

    public void RandomMaze()
    {
        int new_place = Random.Range(2,4);
        UnityEngine.SceneManagement.SceneManager.LoadScene(new_place);
    }

    public void HellDoor()
    {
        Mind.hell_mode = true;
        int new_place = Random.Range(2,4);
        UnityEngine.SceneManagement.SceneManager.LoadScene(new_place);
    }

    public void SwitchReset(int new_place)
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

        UnityEngine.SceneManagement.SceneManager.LoadScene(new_place);
    }

}
