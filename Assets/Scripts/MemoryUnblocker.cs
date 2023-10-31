using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryUnblocker : MonoBehaviour
{

    public GameObject block;
    public GameObject unblock;

    public void Activate()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        block.SetActive(Mind.notes_collected < 8);
        unblock.SetActive(Mind.notes_collected > 7);
    }
}
