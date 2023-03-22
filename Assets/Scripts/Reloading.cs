using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading : MonoBehaviour
{

    public float countdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        if (countdown > 10f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
