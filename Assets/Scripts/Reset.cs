using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            ResetGame();
        }   
    }

    void ResetGame()
    {
        Mind.levers_flipped = 0; // How many levers have been activated

        Mind.lever_a_flipped = false;
        Mind.lever_b_flipped = false;
        Mind.lever_c_flipped = false;
        Mind.lever_d_flipped = false;

        Mind.cans_collected = 0;

        Mind.lever_notification = false;
        Mind.eye_notification = false;

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
