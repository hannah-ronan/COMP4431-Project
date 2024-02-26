using System;
using System.Collections;
using System.Linq;
using Objects.key;
using Objects.token;
using UI.timer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
	[SerializeField] private AudioSource collectSoundEffect;
	[SerializeField] private AudioSource gameOverSoundEffect;
	private Key[] Keys { get; set; }
	private Token[] Tokens { get; set; }
	private PlayerController[] Players { get; set; }
	private Timer Timer { get; set; }

	public bool IsComplete { get; private set; }

	public string Level { get; set; }

	public int CollectedKeys => Keys.Where(key => key == null || key.Collected).ToList().Count;
	public int CollectedTokens => Tokens.Count(token => token == null || token.collected);
	public int Score => Convert.ToInt32(Math.Round(Timer.ElpasedTime.TotalSeconds * (CollectedKeys + CollectedTokens)));

	public GameObject NextSceneUI;

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
		foreach (var player in Players)
			player.active = false;
		IsComplete = true;
		if (gameOverSoundEffect != null)
		{
			gameOverSoundEffect.Play();
		}
		//todo: show game over screen, score & next level
		NextSceneUI.SetActive(true);
	}

	private void SaveScore() => PlayerPrefs.SetInt(Level, Score);

	public void PlayCollectSound()
	{
		if (collectSoundEffect != null)
		{
			collectSoundEffect.Play();
		}
	}
}