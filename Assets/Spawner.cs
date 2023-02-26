using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject squirrel_object;
    // Start is called before the first frame update
    void Start()
    {
        GameObject new_tree;
        InventorySystem InvSys = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();

        string spawnObject = GameObject.Find("SwitchModeButton").GetComponent<SwitchModeButton>().what_to_spawn;
         if (spawnObject == "Squirrel")
        {
            new_tree = Instantiate(squirrel_object);
        }


        else if (spawnObject == "palm")
        {
            new_tree = GameObject.Instantiate(InvSys.palm_tree_prefab);
        }
        else if (spawnObject == "street")
        {
            new_tree = GameObject.Instantiate(InvSys.street_tree_prefab);
        }
        else if (spawnObject == "pine")
        {
            new_tree = GameObject.Instantiate(InvSys.pine_tree_prefab);
        }
        else if (spawnObject == "poplar")
        {
            new_tree = GameObject.Instantiate(InvSys.poplar_tree_prefab);
        }
        else if (spawnObject == "oak")
        {
            new_tree = GameObject.Instantiate(InvSys.oak_tree_prefab);
        }
        else if (spawnObject == "fir")
        {
            new_tree = GameObject.Instantiate(InvSys.fir_tree_prefab);
        }
        else
        {
            new_tree = GameObject.Instantiate(InvSys.fir_tree_prefab);
        }
       // Vector3 position = map.GeoToWorldPosition(lat_long, queryHeight: false);

        //new_tree.transform.SetPositionAndRotation(position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
