using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickAudio;
    public void levelOne()
    {
        SceneManager.LoadScene("Level1Scene");
        PlayButtonClickSound();
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("Level2Scene");
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
