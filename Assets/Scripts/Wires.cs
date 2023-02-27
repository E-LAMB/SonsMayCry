using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{

    public Renderer my_render;

    public Material unpowered;
    public Material powered;

    public string attached_lever;

    public bool should_be_active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attached_lever == "a" && Mind.lever_a_flipped) {should_be_active = true;}
        if (attached_lever == "b" && Mind.lever_b_flipped) {should_be_active = true;}
        if (attached_lever == "c" && Mind.lever_c_flipped) {should_be_active = true;}
        if (attached_lever == "d" && Mind.lever_d_flipped) {should_be_active = true;}

        if (should_be_active) {my_render.material = powered;} else {my_render.material = unpowered;}
    }
}
