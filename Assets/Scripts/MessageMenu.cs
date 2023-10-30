using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MessageMenu : MonoBehaviour
{

    public GameObject[] buttons;

    public TextMeshProUGUI title_comp;

    public string[] titles;
    [TextArea(10,40)]
    public string[] descriptions;

    public GameObject[] messages;

    public int currently_chosen;

    public GameObject my_menu;
    public HouseInteractor player_int;
    public HousePlayer player;
    public GameObject crosshair;
    public GameObject interact_text;

    // Start is called before the first frame update
    void Start()
    {
        currently_chosen = 0;
        CloseMemories();
    }

    public void OpenPage(int number)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            messages[i].SetActive(false);
        }

        if (currently_chosen == number)
        {
            currently_chosen = 0;

        } else
        {
            currently_chosen = number;
        }

        title_comp.text = titles[number];
        messages[number].SetActive(true);
    }

    public void OpenMemories()
    {
        CheckAllMessages();

        bool new_state = true;

        currently_chosen = 0;

        my_menu.SetActive(new_state);
        player.should_be_in_control = !new_state;
        player_int.enabled = !new_state;
        crosshair.SetActive(!new_state);
        interact_text.SetActive(!new_state);

        title_comp.text = titles[0];
        OpenPage(0);
        // desc_comp.text = descriptions[0];

        if (new_state)
        {
            Cursor.lockState = CursorLockMode.Confined;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void CloseMemories()
    {
        bool new_state = false;

        //Debug.Log("Log2");

        my_menu.SetActive(new_state);
        player.should_be_in_control = !new_state;
        player_int.enabled = !new_state;
        crosshair.SetActive(!new_state);
        interact_text.SetActive(!new_state);

        if (new_state)
        {
            Cursor.lockState = CursorLockMode.Confined;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void CheckAllMessages()
    {
        // Module
        buttons[0].SetActive(Mind.notes_collected > 0); // 1 note
        buttons[1].SetActive(Mind.notes_collected > 1); // 1 note
        buttons[2].SetActive(Mind.notes_collected > 2); // 1 note
        buttons[3].SetActive(Mind.notes_collected > 3); // 1 note
        buttons[4].SetActive(Mind.notes_collected > 4); // 1 note
        buttons[5].SetActive(Mind.notes_collected > 5); // 1 note
        buttons[6].SetActive(Mind.notes_collected > 6); // 1 note
        buttons[7].SetActive(Mind.notes_collected > 7); // 1 note

    }

}
