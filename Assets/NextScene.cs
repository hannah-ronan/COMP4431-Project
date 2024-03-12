using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject NextLevelUI;

    public Animator crossFade;

    private void Start()
    {
        NextLevelUI.SetActive(false);
    }

    public void NextLevel()
    {
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadNextScene("MainMenu"));
    }
    
    IEnumerator LoadNextLevel(int level)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }

    IEnumerator LoadNextScene(string scene)
    {
        crossFade.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
