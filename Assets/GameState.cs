using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private PlayerController[] Players { get; set; }
    public bool IsComplete { get; private set; }

    public GameState()
    {
        IsComplete = false;
    }

    private void Awake()
    {
        Players = FindObjectsOfType<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IsComplete = Array.TrueForAll(Players, player => player.active);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
