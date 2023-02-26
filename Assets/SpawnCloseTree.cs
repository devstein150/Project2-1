using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class SpawnCloseTree : MonoBehaviour
{
    ARRaycastManager ar_raycast_manager;
    // Start is called before the first frame update
    void Start()
    {
        if (TreeDataManager.all_trees.Count > 0)
        {
            Vector2 screen_center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f); /* Change B */
            List<ARRaycastHit> result_hits = new List<ARRaycastHit>(); /* Change C */

            ar_raycast_manager.Raycast(screen_center, result_hits); /* Change D */

            if (result_hits.Count > 0) /* Change E */
            {
                GameObject interactiveTree;// = Instantiate(what_to_spawn);
                foreach (TreeDatum tree in TreeDataManager.all_trees)
                {
                    if (Mathf.Abs((float)tree.lat_long_coords.x - (float)SwitchModeButton.currentLocation.x) < 0.001 &&
                        Mathf.Abs((float)tree.lat_long_coords.y - (float)SwitchModeButton.currentLocation.y) < 0.001)
                    {
                        InventorySystem invSys = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();
                        interactiveTree = invSys.SpawnTree(tree.tree_type, result_hits[0].pose.position, false);
                        GrowTrees growTrees = GameObject.Find("growTrees").GetComponent<GrowTrees>();
                        Vector3 growth = new Vector3(growTrees.growthFactor, growTrees.growthFactor, growTrees.growthFactor);
                        interactiveTree.transform.localScale += tree.growth_progress * growth;
                        break;
                    }
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
