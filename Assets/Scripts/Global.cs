using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public int score;
    public int lives;
    public Vector3 originInScreenCoords;
    
    public GameObject invader;
    public GameObject alien;
    public GameObject defenseTower;

    public bool isMovingLeft;

    public List<GameObject> allInvaders;

    Camera mainCamera;

    public bool hasAlien;

    public int invaderCount;

	// Use this for initialization
	void Start () {
        invaderCount = 0;
        score = 0;
        lives = 3;
        hasAlien = false;
        InstantiateInvaders();
        InstantiateShields();

        allInvaders = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update () {

        if (Time.frameCount % 80 == 0)
        {
            isMovingLeft = !isMovingLeft;
        }

        if (Time.frameCount % 250 == 0
             && Random.Range(0.0f,1.0f) < 0.7 && !hasAlien)
        {
            float width = Screen.width;
            float height = Screen.height;
            Vector3 topLeft = new Vector3(18.0f, 11.0f, 0.0f);
            Instantiate(alien, topLeft, Quaternion.identity);
            hasAlien = true;
        }
        
        if (invaderCount == 0)
        {
            EndGame();
        }

    }

    void InstantiateInvaders()
    {

        // Instantiate a grid of invaders.
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Vector3 v = new Vector3((i - 4.5f) * 1.5f, j * 1.5f + 5, 0);
                Instantiate(invader, v, Quaternion.identity);
                invaderCount++;
            }
        }

    }

    void InstantiateShields()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 v = new Vector3((i - 1.5f) * 4.0f, 0.0f, 0.0f);
            Instantiate(defenseTower, v, Quaternion.identity);
        }
    }

    public void EndGame()
    {
        Application.LoadLevel("EndScene");
    }
}
