using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;

public class SpawnableManager : MonoBehaviour
{
    public GameObject what_to_spawn;
    public string areyougettingthis;
    public Vector3 Location = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        GameObject interactiveTree = Instantiate(what_to_spawn);

        interactiveTree.transform.position = Location;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
