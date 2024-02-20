using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.timer
{
    public class Timer : MonoBehaviour
    {
        UIDocument UIDocument;
        public TimeSpan ElpasedTime { get; private set; }

        private void Awake()
        {
            UIDocument = GetComponent<UIDocument>();
            ElpasedTime = new TimeSpan();
        }

        // Update is called once per frame
        void Update()
        {
            ElpasedTime = ElpasedTime.Add(TimeSpan.FromSeconds(Time.deltaTime));
            UIDocument.rootVisualElement.Q<Label>("clock").text = ElpasedTime.ToString(@"hh\:mm\:ss");
        }
    }
}
