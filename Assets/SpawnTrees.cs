using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class SpawnTrees : MonoBehaviour
{
    // Start is called before the first frame update
    public AbstractMap map;
    void Start()
    {
        StartCoroutine(Waiter());

    }


    IEnumerator Waiter()
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
            GameObject new_tree;
            if (tree.tree_type == "palm")
            {
                new_tree = GameObject.Instantiate(InvSys.palm_tree_prefab);
            }
            else if (tree.tree_type == "street")
            {
                new_tree = GameObject.Instantiate(InvSys.street_tree_prefab);
            }
            else if (tree.tree_type == "pine")
            {
                new_tree = GameObject.Instantiate(InvSys.pine_tree_prefab);
            }
            else if (tree.tree_type == "poplar")
            {
                new_tree = GameObject.Instantiate(InvSys.poplar_tree_prefab);
            }
            else if (tree.tree_type == "oak")
            {
                new_tree = GameObject.Instantiate(InvSys.oak_tree_prefab);
            }
            else if (tree.tree_type == "fir")
            {
                new_tree = GameObject.Instantiate(InvSys.fir_tree_prefab);
            }
            else
            {
                new_tree = GameObject.Instantiate(InvSys.fir_tree_prefab);
            }
            new_tree.transform.SetPositionAndRotation(position, Quaternion.identity);
            GrowTrees growTrees = GameObject.Find("GrowTrees").GetComponent<GrowTrees>();
            Vector3 growth = new Vector3(growTrees.growthFactor, growTrees.growthFactor, growTrees.growthFactor);
            new_tree.transform.localScale += tree.growth_progress * growth;
            tree.treeObject = new_tree;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
