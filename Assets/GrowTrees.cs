using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class GrowTrees : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3);

        //InventorySystem InvSys = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();
        //TreeDataManager TDM = GameObject.Find("TreeDataManager").GetComponent<TreeDataManager>();
        foreach (TreeDatum tree in TreeDataManager.all_trees)
        {
            if (tree.growth_progress < 10.0f)
            {
                tree.growth_progress += 1.0f;
                tree.treeObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                MoneyManager.IncreaseMoney(tree.revenue_per_tick_adulthood);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
