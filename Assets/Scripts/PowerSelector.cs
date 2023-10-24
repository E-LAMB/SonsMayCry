using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerSelector : MonoBehaviour
{

    public GameObject my_menu;
    public HousePlayer player;
    public HouseInteractor player_int;

    public GameObject crosshair;
    public GameObject interact_text;

    public int selected_slot;

    public Sprite[] all_sprites;
    public GameObject[] all_outlines;

    public Image power_1_image;
    public Image power_2_image;

    public GameObject outline_PS1;
    public GameObject outline_PS2;

    public bool[] unlocked_abilities;

    public string[] titles;
    [TextArea(10,40)]
    public string[] descriptions_a;
    [TextArea(10,40)]
    public string[] descriptions_b;

    public TextMeshProUGUI title_comp;
    public TextMeshProUGUI desc_comp;

    public void SelectText()
    {

        if (selected_slot == 1) 
        {
            title_comp.text = titles[Mind.ability_one];
            desc_comp.text = descriptions_a[Mind.ability_one];
        }
        if (selected_slot == 2) 
        {
            title_comp.text = titles[Mind.ability_two];
            desc_comp.text = descriptions_b[Mind.ability_two];
        }

    }

    public void SelectTextOverride()
    {
        title_comp.text = titles[0];
        desc_comp.text = descriptions_a[0];
    }

    public void OpenMenu()
    {
        bool new_state = true;

        //Debug.Log("Log1");

        my_menu.SetActive(new_state);
        player.should_be_in_control = !new_state;
        player_int.enabled = !new_state;
        crosshair.SetActive(!new_state);
        interact_text.SetActive(!new_state);

        HideOutlines();
        SelectTextOverride();

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

        //Debug.Log("Log2");

        my_menu.SetActive(new_state);
        player.should_be_in_control = !new_state;
        player_int.enabled = !new_state;
        crosshair.SetActive(!new_state);
        interact_text.SetActive(!new_state);

        HideOutlines();
        SelectText();

        if (new_state)
        {
            Cursor.lockState = CursorLockMode.Confined;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void HideOutlines()
    {
        all_outlines[0].SetActive(false);
        all_outlines[1].SetActive(false);
        all_outlines[2].SetActive(false);
        all_outlines[3].SetActive(false);
        all_outlines[4].SetActive(false);
        all_outlines[5].SetActive(false);
        all_outlines[6].SetActive(false);
        all_outlines[7].SetActive(false);
        all_outlines[8].SetActive(false);
        if (selected_slot == 1) {all_outlines[Mind.ability_one].SetActive(true);}
        if (selected_slot == 2) {all_outlines[Mind.ability_two].SetActive(true);}
    }

    public void ChangeSelectedSlot(int new_slot)
    {
        if (selected_slot != new_slot)
        {
            selected_slot = new_slot;
            outline_PS1.SetActive(new_slot == 1);
            outline_PS2.SetActive(new_slot == 2);
            HideOutlines();
            SelectText();
        } else
        {
            if (selected_slot == 1)
            {
                Mind.ability_one = 0;
            } 
            if (selected_slot == 2)
            {
                Mind.ability_two = 0;
            }
            HideOutlines();
            SelectText();
        }
    }

    public void PlaceIntoSlot(int to_place)
    {
        if (unlocked_abilities[to_place])
        {
            if (selected_slot == 1)
            {
                Mind.ability_one = to_place;
            }
            if (selected_slot == 2)
            {
                Mind.ability_two = to_place;
            }
        }
        HideOutlines();
        SelectText();
    }

    // Start is called before the first frame update
    void Start()
    {
        CloseMenu();
        selected_slot = 1;
        outline_PS1.SetActive(true);
        outline_PS2.SetActive(false);
        HideOutlines();
    }

    // Update is called once per frame
    void Update()
    {
        power_1_image.sprite = all_sprites[Mind.ability_one];
        power_2_image.sprite = all_sprites[Mind.ability_two];
    }
}
