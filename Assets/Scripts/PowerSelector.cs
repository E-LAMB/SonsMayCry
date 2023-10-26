using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

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

    public string[] titles;
    [TextArea(10,40)]
    public string[] descriptions_a;
    [TextArea(10,40)]
    public string[] descriptions_b;

    public TextMeshProUGUI title_comp;
    public TextMeshProUGUI desc_comp;
    public TextMeshProUGUI shard_comp;

    public void SavePower(string power_name)
    {
        File.Create(Application.persistentDataPath + "/power-" + power_name + ".txt");
    } 

    public bool CheckPower(string power_name)
    {
        return File.Exists(Application.persistentDataPath + "/power-" + power_name + ".txt");
    }

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

        if (!File.Exists(Application.persistentDataPath + "/" + "Shards" + ".txt"))
        {
            File.Create(Application.persistentDataPath + "/" + "Shards" + ".txt");
        }

        string content = Mind.ReadFile((Application.persistentDataPath + "/" + "Shards" + ".txt"));
        if (content == "")
        {
            Mind.total_shards = 0;
        } else
        {
            Mind.total_shards = int.Parse(content);
        }

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
        if (Mind.abilities_unlocked[to_place])
        {
            if (selected_slot == 1)
            {
                Mind.ability_one = to_place;
            }
            if (selected_slot == 2)
            {
                Mind.ability_two = to_place;
            }
        } else
        {
            if (Mind.total_shards > 2499)
            {
                Mind.total_shards -= 2500;
                Mind.abilities_unlocked[to_place] = true;

                Mind.WriteFile((Application.persistentDataPath + "/" + "Shards" + ".txt"), Mind.total_shards.ToString());

                if (to_place == 1) {SavePower("EVIL");}
                if (to_place == 2) {SavePower("WITH");}
                if (to_place == 3) {SavePower("HAST");}
                if (to_place == 4) {SavePower("RFTW");}
                if (to_place == 5) {SavePower("PLAY");}
                if (to_place == 6) {SavePower("SHIV");}
                if (to_place == 7) {SavePower("ENDU");}
                if (to_place == 8) {SavePower("ELEC");}

                if (selected_slot == 1)
                {
                    Mind.ability_one = to_place;
                }
                if (selected_slot == 2)
                {
                    Mind.ability_two = to_place;
                }
            }
        }
        
        HideOutlines();
        SelectText();
    }

    // Start is called before the first frame update
    void Start() // USED TO BE START
    {
        string content = Mind.ReadFile(Application.persistentDataPath + "/" + "PlayerEscapes" + ".txt");
        int current_escapes;
        if (content == "")
        {
            current_escapes = 0;
        } else
        {
            current_escapes = int.Parse(content);
        }

        if (Mind.escapes_to_add > 0) {current_escapes += Mind.escapes_to_add; Mind.escapes_to_add = 0;}

        Mind.total_escapes = current_escapes;

        Mind.WriteFile(Application.persistentDataPath + "/" + "PlayerEscapes" + ".txt", current_escapes.ToString());
        Debug.Log("Current Escapes - " + current_escapes.ToString());

        if (Mind.abilities_unlocked[0] == false) // Have we loaded abilities before?
        {
            Mind.abilities_unlocked[0] = true; // This makes us know we loaded 'em

            Mind.abilities_unlocked[1] = CheckPower("EVIL");
            Mind.abilities_unlocked[2] = CheckPower("WITH");
            Mind.abilities_unlocked[3] = CheckPower("HAST");
            Mind.abilities_unlocked[4] = CheckPower("RFTW");
            Mind.abilities_unlocked[5] = CheckPower("PLAY");
            Mind.abilities_unlocked[6] = CheckPower("SHIV");
            Mind.abilities_unlocked[7] = CheckPower("ENDU");
            Mind.abilities_unlocked[8] = CheckPower("ELEC");

        }

        // CloseMenu();

        HideOutlines();
        SelectText();

        Cursor.lockState = CursorLockMode.Locked;

        selected_slot = 1;
        outline_PS1.SetActive(true);
        outline_PS2.SetActive(false);
        HideOutlines();

        my_menu.SetActive(false);

    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Mind.total_shards += 100;
        }

        shard_comp.text = "Total Shards: " + Mind.total_shards.ToString();

        power_1_image.sprite = all_sprites[Mind.ability_one];
        power_2_image.sprite = all_sprites[Mind.ability_two];
    }
}
