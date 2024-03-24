using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Objects.key;
using Objects.token;
using TMPro;
using UI.timer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace UI.Score
{
    public class Score: MonoBehaviour
    {
        private timer.Timer Timer { get; set; }
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        /// <summary>
        /// the number of collected tokens
        /// </summary>
        public int Tokens { get; set; }

        /// <summary>
        /// the number of collected keys
        /// </summary>
        public int Keys { get; set; }

        public float Value =>
            (float)(Math.Round((Tokens * Token.value + ReccommmededSecondsToComplete) / Timer.ElpasedTime.TotalSeconds +
                               Keys * Key.value) * 52);

        public int ReccommmededSecondsToComplete { get; private set; }

        private string Level { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            enabled = false;
            Tokens = 0;
            Keys = 0;
            Level = SceneManager.GetActiveScene().name;
            Timer = GameObject.Find("Timer").GetComponent<Timer>();
            ReccommmededSecondsToComplete =
                FindObjectsOfType<Token>().Length * 2 + FindObjectsOfType<Key>().Length * 5 + 10;
        }

        public void Save()
        {
            var path = System.IO.Path.Combine(Application.persistentDataPath, "scores.db");
            Debug.Log(path, this);
            if(Value > PlayerPrefs.GetFloat(Level, 0))
                PlayerPrefs.SetFloat(Level, Value);
        }

        public void Display()
        {
            Save();
            highScoreText.text = $"High Score: {PlayerPrefs.GetFloat(Level, 0)}";
            scoreText.text = $"Score: {Value}";
        }
    }
}