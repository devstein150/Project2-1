using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;

public class TreeDataManager : MonoBehaviour
{
    public static List<TreeDatum> all_trees = new List<TreeDatum>();

    public List<TreeDatum> GetTreeData()
    {
        return all_trees;
    }

    public void AdvanceTreeGrowth()
    {
        foreach (TreeDatum tree in all_trees)
        {
            if (tree.growth_progress >= 1.0f)
            {
                tree.growth_progress = 1.0f;
                //Player.currency += tree.revenue_per_tick_adulthood;
            }
            else
            {
                tree.growth_progress += 0.1f;
            }
        }
    }
}

public class TreeDatum
{
    public string tree_type;
    public Vector2d lat_long_coords;
    public float growth_progress = 0.0f;
    public float revenue_per_tick_adulthood = 1.0f;
    public GameObject treeObject;

    public TreeDatum(string _tree_type, Vector2d _lat_long_coords, float _growth_progress, float _revenue_per_tick_adulthood)
    {
        tree_type = _tree_type;
        lat_long_coords = _lat_long_coords;
        growth_progress = _growth_progress;
        revenue_per_tick_adulthood = _revenue_per_tick_adulthood;
    }
}


