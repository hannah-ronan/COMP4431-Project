using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.timer
{
	public class Timer : MonoBehaviour
	{
		private UIDocument UIDocument;
		private GameState GameState;
		public TimeSpan ElpasedTime { get; private set; }

		private void Awake()
		{
			UIDocument = GetComponent<UIDocument>();
			GameState = GetComponent<GameState>();
			ElpasedTime = new TimeSpan();
		}

		void Start()
		{
			StartCoroutine(nameof(Time));
		}

		private IEnumerator Time()
		{
			while (!GameState.IsComplete)
			{
				ElpasedTime = ElpasedTime.Add(TimeSpan.FromSeconds(UnityEngine.Time.deltaTime));
				UIDocument.rootVisualElement.Q<Label>("clock").text = ElpasedTime.ToString(@"hh\:mm\:ss");
				yield return null;
			}
			yield return null;
		}
	}
}
