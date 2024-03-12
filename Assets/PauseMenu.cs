using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public Animator crossFade;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void Restart()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().name));

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        StartCoroutine(LoadNextScene("MainMenu"));
       
    }

    IEnumerator LoadNextScene(string scene)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
