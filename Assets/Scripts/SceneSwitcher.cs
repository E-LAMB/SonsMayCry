using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    
    public void Switch(int new_place)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(new_place);
    }

}
