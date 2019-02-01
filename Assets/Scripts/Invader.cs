﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {

    Global globalObj;
    Vector3 velocityVector;

    public int pointValue;

    public GameObject evilLaser;

    // Use this for initialization
    void Start () {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();
        velocityVector.x = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
		if (globalObj.isMovingLeft)
        {
            GetComponent<Rigidbody>().velocity = -velocityVector;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = velocityVector;
        }

        if (Time.frameCount % 15 == 0 && Random.Range(0.0f, 1.0f) < 0.3f &&
            Random.Range(0.0f,1.0f) < 0.15f && Random.Range(0.0f,1.0f)< 0.2f)
        {
            SpawnLaser();
        }
    }

    public void Die ()
    {
        globalObj.score += pointValue;
        globalObj.invaderCount--;
        Destroy(gameObject);
    }

    void SpawnLaser()
    {
        Vector3 spawnPos = gameObject.transform.position +
            new Vector3(0, 0, 0);
        // instantiate the Bullet
        GameObject obj = Instantiate(evilLaser, spawnPos, Quaternion.identity)
            as GameObject;
    }
}