using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class LatLongPosition : MonoBehaviour
{
    public Vector2d latlong_position;
    public AbstractMap map;

    // Update is called once per frame
    void Update()
    {
        //transform.position = map.GeoToWorldPosition(latlong_position, queryHeight:false);
    }
}
