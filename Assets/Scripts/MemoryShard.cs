using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryShard : MonoBehaviour
{

    public Transform my_trans;
    public Vector3 final_position;
    public float distance;
    public float time_since_move;
    public Transform rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CollectShard()
    {
        Mind.shards_earnt_memory += 750;
        Destroy(gameObject);
    }

    void FinalNewPlace()
    {
        time_since_move = 0f;
        final_position = new Vector3(Random.Range(-19, 20) * 2.5f, 1.5f, Random.Range(1, 40) * 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        time_since_move += Time.deltaTime;
        if (time_since_move > 1f)
        {
            my_trans.position = Vector3.MoveTowards(my_trans.position, final_position, 2.5f);
            time_since_move = 0f;
            rotation.eulerAngles = new Vector3 (Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
        }
        distance = Vector3.Distance(my_trans.position, final_position);
        if (distance < 2f)
        {
            FinalNewPlace();
        }
    }
}
