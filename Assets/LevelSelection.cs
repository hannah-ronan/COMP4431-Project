using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickAudio;
    public Animator crossFade;
    public void LevelOne()
    {
        StartCoroutine(LoadNextScene("Level1Scene"));
        PlayButtonClickSound();
    }

    public void LevelTwo()
    {
        StartCoroutine(LoadNextScene("Level2Scene"));
        PlayButtonClickSound();
    }

    public void LevelThree()
    {
        StartCoroutine(LoadNextScene("Level3Scene"));
        PlayButtonClickSound();
    }

    public void LevelFour()
    {
        StartCoroutine(LoadNextScene("Level4Scene"));
        PlayButtonClickSound();
    }
    private void PlayButtonClickSound()
    {
        if (buttonClickAudio != null)
        {
            buttonClickAudio.Play();
        }
    }

    IEnumerator LoadNextScene(string scene)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);

    }
}
