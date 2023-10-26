using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class EscapeDoor : MonoBehaviour
{

    public GameObject[] my_texts;
    public float height;

    public GameObject darks;
    public GameObject other;

    public GameObject baddies;

    public GameObject dark_door;
    public GameObject esc_door;

    /*
    public int points_lever;
    public int points_soda;
    public int points_escape;
    public int points_memory;
    public int points_unlocking;
    */

    public TextMeshProUGUI collected_shards;
    public TextMeshProUGUI total_shards;

    public PlayerController player;
    public Interactor player_int;

    public Interactible my_int;

    public bool on_menu;

    public void Escaped()
    {

        if (!File.Exists(Application.persistentDataPath + "/" + "EscapedLabyrinth" + ".txt"))
        {
            File.Create(Application.persistentDataPath + "/" + "EscapedLabyrinth" + ".txt");
        }

        if (!File.Exists(Application.persistentDataPath + "/" + "PlayerEscapes" + ".txt"))
        {
            File.Create(Application.persistentDataPath + "/" + "PlayerEscapes" + ".txt");
        }

        Mind.escapes_to_add += 1;

        /*
        Debug.Log("Escape Count: " + current_escapes.ToString());
        */

        // Mind.WriteFile(Application.persistentDataPath + "/" + "PlayerEscapes" + ".txt", current_escapes.ToString());

        player.should_be_in_control = false;
        player_int.enabled = false;

        baddies.SetActive(false);
        darks.SetActive(true);
        other.SetActive(false);

        Mind.shards_earnt_escape = 2000;
        Mind.shards_earnt_escape -= (Mathf.RoundToInt(Mind.time_in_level / 10)) * 10;
        if (Mind.shards_earnt_escape < 500) {Mind.shards_earnt_escape = 500;}

        if (Mind.ability_two == 1) {Mind.shards_earnt_escape_bonus += 250;}
        if (Mind.ability_one == 5) {Mind.shards_earnt_escape_bonus += 650;}
        if (Mind.ability_two == 5) {Mind.shards_earnt_escape_bonus += 500;}
        if (Mind.ability_two == 6) {Mind.shards_earnt_escape_bonus += 250;}

        int current_text = 0;
        height = 200f;

        if (Mind.shards_earnt_lever > 0)
        {
            // my_texts[current_text].transform.position = new Vector3 (960, height + 440, 0);
            my_texts[current_text].SetActive(true);
            my_texts[current_text].GetComponent<TextMeshProUGUI>().text = "Levers Activated -        " + Mind.shards_earnt_lever.ToString() + " Shards";
            height -= 100;
            current_text += 1;
        }

        if (Mind.shards_earnt_unlocking > 0)
        {
            // my_texts[current_text].transform.position = new Vector3 (960, height + 440, 0);
            my_texts[current_text].SetActive(true);
            my_texts[current_text].GetComponent<TextMeshProUGUI>().text = "Passages Unlocked -       " + Mind.shards_earnt_unlocking.ToString() + " Shards";
            height -= 100;
            current_text += 1;
        }

        if (Mind.shards_earnt_soda > 0)
        {
            // my_texts[current_text].transform.position = new Vector3 (960, height + 440, 0);
            my_texts[current_text].SetActive(true);
            my_texts[current_text].GetComponent<TextMeshProUGUI>().text = "Soda Cans Drunk -         " + Mind.shards_earnt_soda.ToString() + " Shards";
            height -= 100;
            current_text += 1;
        }

        if (Mind.shards_earnt_memory > 0)
        {
            // my_texts[current_text].transform.position = new Vector3 (960, height + 440, 0);
            my_texts[current_text].SetActive(true);
            my_texts[current_text].GetComponent<TextMeshProUGUI>().text = "Memories Restored -       " + Mind.shards_earnt_memory.ToString() + " Shards";
            height -= 100;
            current_text += 1;
        }

        if (Mind.shards_earnt_escape > 0)
        {
            // my_texts[current_text].transform.position = new Vector3 (960, height + 440, 0);
            my_texts[current_text].SetActive(true);
            my_texts[current_text].GetComponent<TextMeshProUGUI>().text = "ESCAPED! -                " + Mind.shards_earnt_escape.ToString() + " Shards";
            height -= 100;
            current_text += 1;
        }

        if (Mind.shards_earnt_escape_bonus > 0)
        {
            // my_texts[current_text].transform.position = new Vector3 (960, height + 440, 0);
            my_texts[current_text].SetActive(true);
            my_texts[current_text].GetComponent<TextMeshProUGUI>().text = "Escape Bonus -            " + Mind.shards_earnt_escape_bonus.ToString() + " Shards";
            height -= 100;
            current_text += 1;
        }

        collected_shards.text = "Shards Collected -   " + (Mind.shards_earnt_escape + 
        Mind.shards_earnt_escape_bonus + Mind.shards_earnt_lever + 
        Mind.shards_earnt_memory + Mind.shards_earnt_soda
        + Mind.shards_earnt_unlocking).ToString();

        Mind.total_shards += (Mind.shards_earnt_escape + 
        Mind.shards_earnt_escape_bonus + Mind.shards_earnt_lever + 
        Mind.shards_earnt_memory + Mind.shards_earnt_soda
        + Mind.shards_earnt_unlocking);

        total_shards.text = "Total Shards -   " + Mind.total_shards.ToString();

        Mind.WriteFile((Application.persistentDataPath + "/" + "Shards" + ".txt"),Mind.total_shards.ToString());

        on_menu = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        darks.SetActive(false);
        other.SetActive(true);

        esc_door.SetActive(false);
        dark_door.SetActive(true);
    }

    public void PlayedUsed()
    {
        if (Mind.ability_two == 5 && player.time_since_last_activation < 20f)
        {
            my_int.interaction_description = "(NOT YET...)"; 

        } else
        {
            my_int.interaction_description = "(ESCAPE!)"; 
            Escaped();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (on_menu)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Mind.levers_flipped > 3)
        {
            if (Mind.ability_two == 5 && player.time_since_last_activation < 20f)
            {
                my_int.interaction_description = "(NOT YET...)"; 

            } else
            {
                my_int.interaction_description = "(ESCAPE!)"; 
            }

            dark_door.SetActive(false);
            esc_door.SetActive(true);
        }
    }
}
