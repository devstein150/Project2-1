using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSpawner : MonoBehaviour
{
    private int update_tree_num = 0;
    public Vector3 offset;
     GameObject[] Trees;

    public float spawnTime = 40.0f; // spawn every 40 seconds
    public GameObject whatToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SquirrelSpawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SquirrelSpawn()
    {
        //float placed_one_squirrel = 3.0f;
        Trees = GameObject.FindGameObjectsWithTag("Tree");
        if (Trees.Length == 0)
            return;
        var newSquirrel = GameObject.Instantiate(whatToSpawn);
        newSquirrel.transform.position = Trees[update_tree_num].gameObject.transform.position + offset; // Make sure y is 0
        update_tree_num += 1;
        update_tree_num = update_tree_num % Trees.Length;
    }
}
