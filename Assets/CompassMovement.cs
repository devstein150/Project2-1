using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassMovement : MonoBehaviour
{
    public Transform player_avatar;
    public Transform main_camera;
    public Vector3 rotation_offset;

    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 convertor = new Vector3(1.0f, 1.0f, 1.0f);
        transform.position = player_avatar.position + offset;
        transform.LookAt(main_camera, Vector3.forward);
        transform.eulerAngles = transform.eulerAngles + rotation_offset;

        // 25 180 12
    }

}
