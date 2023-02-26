using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using UnityEngine.SceneManagement;

public class GrowTrees : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Waiter());
    }

    /*IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);

        //InventorySystem InvSys = GameObject.Find("InventorySystem").GetComponent<InventorySystem>();
        //TreeDataManager TDM = GameObject.Find("TreeDataManager").GetComponent<TreeDataManager>();
        foreach (TreeDatum tree in TreeDataManager.all_trees)
        {
            print(tree);
            if (tree.growth_progress < 10.0f)
            {
                tree.growth_progress += 1.0f;
                tree.treeObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                MoneyManager mm = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
                mm.IncreaseMoney(tree.revenue_per_tick_adulthood);
            }
        }
    }*/
    // Update is called once per frame
    float count = 0;
    public float growthFactor;
    void Update()
    {
        if (count > 300.0f)
        {
            count = 0;
            foreach (TreeDatum tree in TreeDataManager.all_trees)
            {
                //print(tree);
                if (tree.growth_progress < 10.0f)
                {
                    tree.growth_progress += 1.0f;
                    if (SceneManager.GetActiveScene().name == "exploration_scene")
                    {
                        Vector3 growth = new Vector3(growthFactor, growthFactor, growthFactor);
                        tree.treeObject.transform.localScale += growth;
                    }
                }
                else
                {
                    MoneyManager mm = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
                    mm.IncreaseMoney(tree.revenue_per_tick_adulthood);
                }
            }
        }
        else
        {
            count++;
        }

    }
}
