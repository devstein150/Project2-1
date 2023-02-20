using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class SpawnTrees : MonoBehaviour
{
    // Start is called before the first frame update
    public AbstractMap map;
    void Start()
    {
        StartCoroutine(waiter());
    }

    

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);

        InventorySystem InvSys = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();
        //TreeDataManager TDM = GameObject.Find("TreeDataManager").GetComponent<TreeDataManager>();
        float count = 0;
        print("all trees: " + TreeDataManager.all_trees.Count);
        foreach (TreeDatum tree in TreeDataManager.all_trees)
        {
            print(count++);
            Vector2d lat_long = tree.lat_long_coords;
            print(lat_long);
            Vector3 position = map.GeoToWorldPosition(lat_long, queryHeight: false);
            print("pos " + position);
            position = new Vector3(position.x, 0.0f, position.z);
            print(position);
            if (tree.tree_type == "palm")
            {
                GameObject new_tree = GameObject.Instantiate(InvSys.palm_tree_prefab);
                new_tree.transform.SetPositionAndRotation(position, Quaternion.identity);
            }
            else if (tree.tree_type == "magnolia")
            {
                GameObject new_tree = GameObject.Instantiate(InvSys.magnolia_tree_prefab);
                new_tree.transform.SetPositionAndRotation(position, Quaternion.identity);
            }
            else if (tree.tree_type == "pine")
            {
                GameObject new_tree = GameObject.Instantiate(InvSys.pine_tree_prefab);
                new_tree.transform.SetPositionAndRotation(position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
