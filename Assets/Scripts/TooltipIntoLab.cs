using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TooltipIntoLab : MonoBehaviour
{

    public CutsceneMaingame the_main;

    public bool has_seen_tooltip;

    public string tooltip_name;

    public string action_to_take;

    [Header("Hiding Factors")]
    public PlayerController maze_player;
    public Interactor maze_int;
    public HousePlayer home_player;
    public HouseInteractor home_int;
    public GameObject cursor_1;
    public GameObject cursor_2;
    public GameObject cursor_3;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/" + tooltip_name + ".txt"))
        {
            File.Create(Application.persistentDataPath + "/" + tooltip_name + ".txt"); // obviously not seen
            has_seen_tooltip = false;

            if (maze_player != null) {maze_player.should_be_in_control = false;}
            if (maze_int != null) {maze_int.enabled = false;}
            if (home_player != null) {home_player.should_be_in_control = false;}
            if (home_int != null) {home_int.enabled = false;}
            if (cursor_1 != null) {cursor_1.SetActive(false);}
            if (cursor_2 != null) {cursor_2.SetActive(false);}
            if (cursor_3 != null) {cursor_3.SetActive(false);}

            Cursor.lockState = CursorLockMode.Confined;

            the_main.should_give_control = false;

        } else
        {
            the_main.should_give_control = true;
            has_seen_tooltip = true;
            if (action_to_take == "des") {Destroy(gameObject);}
        }
    }

    public void TooltipClosed()
    {
        if (maze_player != null) {maze_player.should_be_in_control = true;}
        if (maze_int != null) {maze_int.enabled = true;}
        if (home_player != null) {home_player.should_be_in_control = true;}
        if (home_int != null) {home_int.enabled = true;}
        if (cursor_1 != null) {cursor_1.SetActive(true);}
        if (cursor_2 != null) {cursor_2.SetActive(true);}
        if (cursor_3 != null) {cursor_3.SetActive(true);}

        the_main.should_give_control = true;

        Cursor.lockState = CursorLockMode.Locked;

        if (action_to_take == "des") {Destroy(gameObject);}
    }
}
