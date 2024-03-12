using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator crossFade;

    public void PlayGame()
    {
        StartCoroutine(LoadNextScene("LevelSelectionScene"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        StartCoroutine(LoadNextScene("MainMenu"));
    }

    IEnumerator LoadNextScene(string scene)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);

    }
}

