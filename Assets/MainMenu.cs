using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject howToPlay;
    GameObject options;

    public Animator crossFade;

    public void Start()
    {
        howToPlay = GameObject.Find("HowToPlayCanvas");
        options = GameObject.Find("OptionsCanvas");

        howToPlay.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        //crossFade.SetTrigger("Start");
       // yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("LevelSelectionScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

