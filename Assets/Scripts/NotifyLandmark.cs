using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyLandmark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("ResponsibleSpawner").GetComponent<SpawnLandmark>().PotentialSpot(gameObject);
    }

}
