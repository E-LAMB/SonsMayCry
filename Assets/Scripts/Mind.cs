using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Mind 
{
    
    public static string ReadFile(string file_name)
    {
        StreamReader reader = new StreamReader(file_name);
        string content = reader.ReadToEnd(); // Reads the content in the file
        reader.Close();
        return content;
    }

    public static void WriteFile(string file_name, string content)
    {
        StreamWriter writer = new StreamWriter(file_name, false); // Writes the progress to the file when the scene is loaded
        writer.Write(content);
        writer.Close();
    }


    public static int levers_flipped = 0; // How many levers have been activated

    public static bool lever_a_flipped = false;
    public static bool lever_b_flipped = false;
    public static bool lever_c_flipped = false;
    public static bool lever_d_flipped = false;

    public static int cans_collected = 0;

    public static bool lever_notification;
    public static float eye_notification;

    public static bool focus_wire;
    public static bool focus_threat;
    public static bool focus_memory;
    public static bool focus_eye;

    public static bool[] abilities_unlocked = new bool[9]; //(false, false, false, false, false, false, false, false, false);

    public static int ability_one;
    public static int ability_two;
    public static int ability_item_taken;

    public static bool enemy_present;

    public static float time_in_level;

    public static int shards_earnt_lever;
    public static int shards_earnt_soda;
    public static int shards_earnt_escape;
    public static int shards_earnt_memory;
    public static int shards_earnt_unlocking;
    public static int shards_earnt_escape_bonus;

    public static int total_shards;

    public static int escapes_to_add;
    public static int total_escapes;

    public static bool in_home_before;

}
