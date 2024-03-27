using System;
using Objects.key;
using Objects.token;
using TMPro;
using UI.timer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    /// <summary>
    /// Score of the game's current level
    /// </summary>
    public class Score: MonoBehaviour
    {
        private Timer Timer { get; set; }
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        /// <summary>
        /// the number of collected tokens
        /// </summary>
        public int Tokens { get;  set; }

        /// <summary>
        /// the number of collected keys
        /// </summary>
        public int Keys { get;  set; }

        public float Value => (float)(Keys * Key.value - Math.Clamp(Timer.ElpasedTime.TotalMinutes, 0, 4) + Tokens * Token.Value) * 52;

        private string Level { get; set; }

        // Start is called before the first frame update
        private void Start()
        {
            enabled = false;
            Tokens = 0;
            Keys = 0;
            Level = SceneManager.GetActiveScene().name;
            Timer = GameObject.Find("Timer").GetComponent<Timer>();
        }

        /// <summary>
        /// Save the score to the player prefs
        /// <remarks>This is not the base method to store the score but 🤷🏿‍♂️ it works</remarks>
        /// </summary>
        public void Save()
        {
            if(Value > PlayerPrefs.GetFloat(Level, -1))
                PlayerPrefs.SetFloat(Level, Value);
        }

        /// <summary>
        /// the high score of the current level
        /// </summary>
        public float HighScore => PlayerPrefs.GetFloat(Level, -1);

        /// <summary>
        /// Display the score on the screen
        /// </summary>
        public void Display()
        {
            Save();
            highScoreText.text = $"High Score: {HighScore}";
            scoreText.text = $"Score: {Value}";
        }
    }
}