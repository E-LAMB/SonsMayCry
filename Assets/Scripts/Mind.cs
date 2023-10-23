using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Mind 
{
    
    public static int levers_flipped = 0; // How many levers have been activated

    public static bool lever_a_flipped = false;
    public static bool lever_b_flipped = false;
    public static bool lever_c_flipped = false;
    public static bool lever_d_flipped = false;

    public static int cans_collected = 0;

    public static bool lever_notification;
    public static bool eye_notification;

    public static bool focus_wire;
    public static bool focus_threat;

}
