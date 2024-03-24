using System;
using System.Collections;
using System.Linq;
using Objects.key;
using Objects.token;
using UI.Score;
using UI.timer;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState: MonoBehaviour
{
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource gameOverSoundEffect;

    private Key[] Keys { get; set; }
    private Token[] Tokens { get; set; }
    private PlayerController[] Players { get; set; }
    private Timer Timer { get; set; }


    public GameObject NextSceneUI;

    public bool IsComplete { get; private set; }
    public string Level { get; set; }

    private void Awake()
    {
        IsComplete = false;
        Keys = FindObjectsOfType<Key>();
        Tokens = FindObjectsOfType<Token>();
        Players = FindObjectsOfType<PlayerController>();
        Timer = GetComponent<Timer>();
        Level = SceneManager.GetActiveScene().name;
        StartCoroutine(nameof(GameOver));
    }

    private IEnumerator GameOver()
    {
        yield return new WaitUntil(() => Array.TrueForAll(Keys, key => key == null || key.Collected));
        foreach(var player in Players)
            player.active = false;
        IsComplete = true;
        if(gameOverSoundEffect != null)
            gameOverSoundEffect.Play();
        FindObjectOfType<Score>(true).Display();
        NextSceneUI.SetActive(true);
        yield return null;
    }

    public void PlayCollectSound()
    {
        if(collectSoundEffect != null)
            collectSoundEffect.Play();
    }
}