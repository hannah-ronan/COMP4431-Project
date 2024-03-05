using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickAudio;
    public void LevelOne()
    {
        SceneManager.LoadScene("Level1Scene");
        PlayButtonClickSound();
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2Scene");
        PlayButtonClickSound();
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Level3Scene");
        PlayButtonClickSound();
    }

    public void LevelFour()
    {
        SceneManager.LoadScene("Level4Scene");
        PlayButtonClickSound();
    }
    private void PlayButtonClickSound()
    {
        if (buttonClickAudio != null)
        {
            buttonClickAudio.Play();
        }
    }
}
