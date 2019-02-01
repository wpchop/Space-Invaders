using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    Global globalObj;
    public GameObject laser;
    public Vector3 velocityVector;
    Camera firstPerson;

    bool CanSpawn = true;

	// Use this for initialization
	void Start () {
        velocityVector.x = 10.0f;
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        firstPerson = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space") && CanSpawn)
        {
            StartCoroutine(SpawnLaser());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            firstPerson.enabled = !firstPerson.enabled;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0
            && gameObject.transform.position.x < 7)
        {
            print("right");
            // Move ship to the right.
            GetComponent<Rigidbody>().velocity = velocityVector;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 
            && gameObject.transform.position.x > -7)
        {
            print("left");
            // Move ship to the left.
            GetComponent<Rigidbody>().velocity = -velocityVector;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// Asynchronous function that changes the CanSpawn flag to prevent the
    /// </summary>
    /// <returns>The laser.</returns>
    IEnumerator SpawnLaser ()
    {
        Vector3 spawnPos = gameObject.transform.position +
            new Vector3(0, 1, 0);
        // instantiate the Bullet
        GameObject obj = Instantiate(laser, spawnPos, Quaternion.identity)
            as GameObject;
        CanSpawn = false;
        yield return new WaitForSeconds(0.8f);
        CanSpawn = true;
    }

    public void Die()
    {
        if (globalObj.lives == 1)
        {
            //end game
            globalObj.EndGame();
        }
        else
        {
            globalObj.lives--;
        }
    }
}
