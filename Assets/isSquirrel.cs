using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSquirrel : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //Not launching anything else, don't need???
        if (collision.gameObject.tag != "acorn")
            return;
        else
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
