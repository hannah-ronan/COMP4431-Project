using System;
using System.IO;
using System.Text.RegularExpressions;
using Objects.key;
using Objects.token;
using TMPro;
using UI.timer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Score
{
    public class Score: MonoBehaviour
    {
        private Timer Timer { get; set; }
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
            (float)Math.Round(
                Tokens * Token.value / Math.Clamp(ReccommmededMinutesToComplete - Timer.ElpasedTime.TotalMinutes, 1,
                    ReccommmededMinutesToComplete)
                + Keys * Key.value) * 52;

        public double ReccommmededMinutesToCompleteLevel =>
            int.Parse(Regex.Match(SceneManager.GetActiveScene().name, "\\d+").Value) switch
            {
                1 => 1,
                2 => 2,
                3 => 2.5,
                4 => 3,
                _ => 5
            } + .5; // half second buffer

        public double ReccommmededMinutesToComplete { get; set; }

        private string Level { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            enabled = false;
            Tokens = 0;
            Keys = 0;
            Level = SceneManager.GetActiveScene().name;
            Timer = GameObject.Find("Timer").GetComponent<Timer>();
            ReccommmededMinutesToComplete = ReccommmededMinutesToCompleteLevel + FindObjectsOfType<Key>().Length * .45;
        }

        public void Save()
        {
            var path = Path.Combine(Application.persistentDataPath, "scores.db");
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