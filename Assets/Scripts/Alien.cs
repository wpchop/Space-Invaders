using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    Global globalObj;
    Vector3 velocityVector;
    public GameObject evilLaser;

    public AudioClip laserSound;

    int pointValue;

    // Use this for initialization
    void Start () {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        velocityVector.x = -3.0f;
        GetComponent<Rigidbody>().velocity = velocityVector;
        pointValue = 100;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x < -15.0)
        {
            globalObj.hasAlien = false;
            Destroy(gameObject);
        }

        if (Time.frameCount % 45 == 0 && this.transform.position.x < 10.0f &&
            this.transform.position.x > -10.0f && Random.Range(0.0f,1.0f) < 0.8)
        {
            SpawnLaser();
        }

    }

    public void Die()
    {
        globalObj.score += pointValue;
        globalObj.hasAlien = false;
        Destroy(gameObject);
    }

    void SpawnLaser()
    {
        AudioSource.PlayClipAtPoint(laserSound, gameObject.transform.position);
        Vector3 spawnPos = gameObject.transform.position +
            new Vector3(0, 0, 0);
        // instantiate the Bullet
        GameObject obj = Instantiate(evilLaser, spawnPos, Quaternion.identity)
            as GameObject;
    }
}
