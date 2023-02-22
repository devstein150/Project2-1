using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSpawner : MonoBehaviour
{
    public GameObject[] Trees;

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
        float placed_one_squirrel = 3.0f;
        Trees = GameObject.FindGameObjectsWithTag("Tree");

        var newSquirrel = GameObject.Instantiate(whatToSpawn);
        foreach(GameObject tree in Trees)
        {
            if()
        }
    }
}
