using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void levelOne()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("Level2Scene");
    }
}
