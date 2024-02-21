using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Objects.key;
using UnityEngine;

public class GameState: MonoBehaviour
{
    private PlayerController[] Players { get; set; }
    public bool IsComplete { get; private set; }
    private Key[] Keys { get; set; }

    private void Awake()
    {
        IsComplete = false;
        Keys = FindObjectsOfType<Key>();
        Players = FindObjectsOfType<PlayerController>();
        StartCoroutine(nameof(GameOver));
    }

    private IEnumerator GameOver()
    {
        yield return new WaitUntil(() => Array.TrueForAll(Keys, key => key == null));
        foreach(var player in Players)
            player.active = false;
        //todo: show game over screen, score & next level
    }
}