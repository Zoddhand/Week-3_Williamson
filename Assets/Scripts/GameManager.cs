using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject p;
    public bool quit = false;
    public int banana_Score = 0;
    public int banana_Numbers = 20;
    public bool pLive = true;
    // Start is called before the first frame update
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (quit)
        {
            Debug.Log("Quitting Game.");
            Application.Quit();
        }
        else
        {
            LoadNextLevel(banana_Score == banana_Numbers); // if we collect all the bananas loadNextlevel.
            PlayerDied(!pLive);
        }
    }

    /* Load next level in build settings and reset variables */
    void LoadNextLevel(bool b)
    {
        if (b)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            banana_Score = 0;
        }    
    }

    /* Reload level if we dies */
    void PlayerDied(bool b)
    {
        /* if the player falls through the floor kill him and reload level */
        if (p.transform.position.y <= -5.0f)
        {
            GameManager.instance.pLive = false;
        }

        if (b)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            banana_Score = 0;
        }
    }
}
