using System.Collections;
using Objects.key;
using UI.Score;
using UI.timer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState: MonoBehaviour
{
    [SerializeField] private AudioSource gameOverSoundEffect;

    private Score Score { get; set; }
    private int InitialKeys { get; set; }
    private PlayerController[] Players { get; set; }
    private Timer Timer { get; set; }


    public GameObject NextSceneUI;

    public bool IsComplete { get; private set; }
    public string Level { get; set; }

    private void Awake()
    {
        IsComplete = false;
        Score = FindObjectOfType<Score>();
        InitialKeys = FindObjectsOfType<Key>().Length;
        Players = FindObjectsOfType<PlayerController>();
        Timer = GetComponent<Timer>();
        Level = SceneManager.GetActiveScene().name;
        StartCoroutine(nameof(GameOver));
    }

    private IEnumerator GameOver()
    {
        yield return new WaitUntil(() => Score.Keys == InitialKeys);
        foreach(var player in Players)
            player.active = false;
        IsComplete = true;
        if(gameOverSoundEffect != null)
            gameOverSoundEffect.Play();
        FindObjectOfType<Score>(true).Display();
        NextSceneUI.SetActive(true);
        yield return null;
    }
}