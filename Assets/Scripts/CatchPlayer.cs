using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchPlayer : MonoBehaviour
{

    public float jumpscare_time;
    public bool play_JS;

    public Transform js_sprite;
    public GameObject black_screen;

    public Sprite my_character;
    public Image the_image;

    // Disable

    public PlayerController player;
    public Interactor player_int;
    public NewEnemyAI baddie_ai;
    public GameObject baddies;
    public GameObject other;
    public Transform player_cam;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            ResetGame();
        }   
    }

    void Update()
    {
        if (play_JS) {jumpscare_time += Time.deltaTime;}

        if (play_JS)
        {
            js_sprite.localScale = new Vector3 (Random.Range(1f, 1.5f), Random.Range(1f, 1.5f), Random.Range(1f, 1.5f));
            js_sprite.eulerAngles = new Vector3 (Random.Range(-6f, 6f), 0f, Random.Range(-6f, 6f));
            player_cam.eulerAngles = new Vector3 (player_cam.eulerAngles.x + Random.Range(-1f, 1f),
            player_cam.eulerAngles.y + Random.Range(-1f, 1f), player_cam.eulerAngles.z + Random.Range(-1f, 1f));
        }

        if (jumpscare_time > 5f)
        {
            black_screen.SetActive(true);
        }

        if (jumpscare_time > 6f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }

    // Update is called once per frame
    void ResetGame()
    {
        Mind.levers_flipped = 0; // How many levers have been activated

        Mind.lever_a_flipped = false;
        Mind.lever_b_flipped = false;
        Mind.lever_c_flipped = false;
        Mind.lever_d_flipped = false;

        Mind.cans_collected = 0;

        the_image.sprite = my_character;

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

        player.should_be_in_control = false;
        player_int.enabled = false;

        baddies.SetActive(false);
        baddie_ai.enabled = false;
        other.SetActive(false);

        play_JS = true;
    }
}
