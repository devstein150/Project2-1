using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUpdate : MonoBehaviour
{
    public float standardCurrencyOutput = 10.0f;
    public string age = "sapling";
    public float growth_rate = 0.01f;    // Start is called before the first frame update
    public float grown_up_size = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(growth_rate * transform.localScale.x, growth_rate * transform.localScale.y, growth_rate * transform.localScale.z);
        if (transform.localScale.x > grown_up_size)
        {
            age = "adult";
            standardCurrencyOutput = 20.0f;
        }
    }
}
