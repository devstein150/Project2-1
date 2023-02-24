using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class LatLongPositionT : MonoBehaviour
{
    public Vector2d latlong_position;
    public AbstractMap map;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Waiter());
    }
    
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
        transform.position = map.GeoToWorldPosition(latlong_position, queryHeight: false);
        transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
    }
}
