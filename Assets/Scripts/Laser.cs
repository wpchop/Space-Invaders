using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public Vector3 thrust;
    public Quaternion heading;

    public AudioClip laserSound;
    public AudioClip explosion;

	// Use this for initialization
	void Start () {

        AudioSource.PlayClipAtPoint(laserSound, gameObject.transform.position);

        // travel straight in the X-axis
        thrust.y = 400.0f;
        // do not passively decelerate 
        GetComponent<Rigidbody>().drag = 0;

        // set the direction it will travel in 
        GetComponent<Rigidbody>().MoveRotation(heading.normalized);

        // apply thrust once, no need to apply it again since // it will not decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;

        if (collider.CompareTag("Invader"))
        {
            Invader invader = collider.GetComponent<Invader>();
            AudioSource.PlayClipAtPoint(explosion, invader.transform.position);
            invader.Die();
        }

        if (collider.CompareTag("Alien"))
        {
            Alien alien = collider.GetComponent<Alien>();
            alien.Die();
        }

        if (collider.CompareTag("Defense"))
        {
            DefenseBlock block = collider.GetComponent<DefenseBlock>();
            Destroy(block.gameObject);
        }
        Destroy(gameObject);
    }
}
