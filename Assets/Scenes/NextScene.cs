using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject NextLevelUI, nextLevelButton;

    public Animator crossFade;

    private void Start()
    {
        NextLevelUI.SetActive(false);
        if((SceneManager.GetActiveScene().buildIndex + 1) > 5)
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
            nextLevelButton.SetActive(false);
        }
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
