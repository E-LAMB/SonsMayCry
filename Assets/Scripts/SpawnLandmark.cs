using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLandmark : MonoBehaviour
{

    public GameObject[] my_spawnables;
    public int chosen_landmark;

    public int landmark_spots;
    public GameObject landmark_a;
    public GameObject landmark_b;
    public GameObject landmark_c;

    public int heat;

    public void PotentialSpot(GameObject spot)
    {
        if (landmark_spots == 0)
        {
            landmark_a = spot;
            landmark_spots += 1;
        } else if (landmark_spots == 1)
        {
            landmark_b = spot;
            landmark_spots += 1;
        } else if (landmark_spots == 2)
        {
            landmark_c = spot;
            landmark_spots += 1;
            PerformSpawns();
        } 
    }

    void PerformSpawns()
    {
        chosen_landmark = 0;
        while ((chosen_landmark < 1 || my_spawnables[chosen_landmark] == null) && heat < 200)
        {
            heat += 1;
            chosen_landmark = Random.Range(1, my_spawnables.Length);
        }
        Instantiate(my_spawnables[chosen_landmark], landmark_a.transform);
        my_spawnables[chosen_landmark] = null;
        chosen_landmark = 0;
        while ((chosen_landmark < 1 || my_spawnables[chosen_landmark] == null) && heat < 200)
        {
            heat += 1;
            chosen_landmark = Random.Range(1, my_spawnables.Length);
        }
        Instantiate(my_spawnables[chosen_landmark], landmark_b.transform);
        my_spawnables[chosen_landmark] = null;
        chosen_landmark = 0;
        while ((chosen_landmark < 1 || my_spawnables[chosen_landmark] == null) && heat < 200)
        {
            heat += 1;
            chosen_landmark = Random.Range(1, my_spawnables.Length);
        }
        Instantiate(my_spawnables[chosen_landmark], landmark_c.transform);
        my_spawnables[chosen_landmark] = null;
        
    }

}
