using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLaser : MonoBehaviour {

    public Quaternion heading;

    bool isThreat;

    // Use this for initialization
    void Start()
    {
        isThreat = true;
        // do not passively decelerate 
        GetComponent<Rigidbody>().drag = 0;

        GetComponent<Rigidbody>().velocity = new Vector3(0, -2, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isThreat)
        {
            return;
        }
        Collider collider = collision.collider;

        if (collider.CompareTag("Defense"))
        {
            DefenseBlock block = collider.GetComponent<DefenseBlock>();
            Destroy(block.gameObject);
        }

        if (collider.CompareTag("Ship"))
        {
            Ship ship = collider.GetComponent<Ship>();
            ship.Die();
        }

        if (collider.CompareTag("Platform"))
        {
            isThreat = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().useGravity = true;
            return;
        }

        Destroy(gameObject);
    }
}
