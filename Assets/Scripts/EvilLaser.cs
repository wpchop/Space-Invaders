using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLaser : MonoBehaviour {

    public Quaternion heading;

    // Use this for initialization
    void Start()
    {
        // do not passively decelerate 
        GetComponent<Rigidbody>().drag = 0;

        GetComponent<Rigidbody>().velocity = new Vector3(0, -2, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
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

        Destroy(gameObject);
    }
}
