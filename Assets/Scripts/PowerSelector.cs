using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelector : MonoBehaviour
{

    public GameObject my_menu;
    public HousePlayer player;
    public HouseInteractor player_int;

    public int selected_slot;

    public int power_1;
    public int power_2;

    public Sprite[] all_sprites;

    public Image power_1_image;
    public Image power_2_image;

    public GameObject outline_PS1;
    public GameObject outline_PS2;

    public bool[] unlocked_abilities;

    public void OpenMenu()
    {
        bool new_state = true;

        Debug.Log("Log1");

        my_menu.SetActive(new_state);
        player.enabled = !new_state;
        player_int.enabled = !new_state;

        if (new_state)
        {
            Cursor.lockState = CursorLockMode.Confined;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void CloseMenu()
    {
        bool new_state = false;

        Debug.Log("Log2");

        my_menu.SetActive(new_state);
        player.enabled = !new_state;
        player_int.enabled = !new_state;

        if (new_state)
        {
            Cursor.lockState = CursorLockMode.Confined;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void ChangeSelectedSlot(int new_slot)
    {
        selected_slot = new_slot;
        outline_PS1.SetActive(new_slot == 1);
        outline_PS2.SetActive(new_slot == 2);
    }

    public void PlaceIntoSlot(int to_place)
    {
        if (unlocked_abilities[to_place])
        {
            if (selected_slot == 1)
            {
                power_1 = to_place;
            }
            if (selected_slot == 2)
            {
                power_2 = to_place;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CloseMenu();
        selected_slot = 1;
        outline_PS1.SetActive(true);
        outline_PS2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        power_1_image.sprite = all_sprites[power_1];
        power_2_image.sprite = all_sprites[power_2];
    }
}
