using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool isGameOver = false;

    public Animator crossFade;

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
            isGameOver = true;
            gameOverUI.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        isGameOver = false;
        StartCoroutine(LoadNextScene("MainMenu"));
        ObstacleHit.isObstacleHit = false;
    }

    public void Restart()
    {
        Time.timeScale = 1; 
        isGameOver = false;
        StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().name));
        gameOverUI.SetActive(false);
        ObstacleHit.isObstacleHit = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadNextScene(string scene)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
