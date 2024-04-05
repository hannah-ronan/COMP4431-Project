using System.Collections;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public Animator crossFade;

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(0);
    }

    private void Start()
    {
        GameObject.Find("BG Music").GetComponent<AudioSource>().volume = Audio.Audio.GetCombinedVolume(AudioTypes.BgMusic);
    }

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