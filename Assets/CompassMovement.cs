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

    public float vertical_offset;
    public float horizontal_offset;
    // Update is called once per frame
    void Update()
    {
        Vector3 convertor = new Vector3(1.0f, 1.0f, 1.0f);
        //transform.position = player_avatar.position + main_camera.GetComponent<OrbitCamera>().offset + offset;
        float height = main_camera.transform.position.y;
        transform.position = main_camera.transform.position + height * main_camera.transform.forward
            + height/100 * vertical_offset * main_camera.transform.up + height/100 * horizontal_offset * main_camera.transform.right;//main_camera.transform.position + offset;
        transform.rotation = Quaternion.Euler(-20, 0, 0);
        //Vector3 modifiedUp = new Vector3(-120.0f, -15.811f, -50.0f);
        //transform.LookAt(new Vector3(main_camera.position.x, -main_camera.position.y, main_camera.position.z));
        transform.rotation *= Quaternion.FromToRotation(Vector3.right, Vector3.back); 

        // 25 180 12
    }

}
