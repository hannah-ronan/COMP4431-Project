using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ObstacleHit.isObstacleHit)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        ObstacleHit.isObstacleHit = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        ObstacleHit.isObstacleHit = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
