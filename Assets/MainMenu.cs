using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject howToPlay;
    GameObject options;

    public void Start()
    {
        howToPlay = GameObject.Find("HowToPlayCanvas");
        options = GameObject.Find("OptionsCanvas");

        howToPlay.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

