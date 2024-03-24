using System.Collections;
using System.Collections.Generic;
using UI.Score;
using UnityEngine;

namespace Objects.token
{
    /// <summary>
    /// Game Token
    /// </summary>
    public class Token : MonoBehaviour
    {
        public const int value = 5;

        private static readonly int CollectedTriggerID = Animator.StringToHash("collect");

        public Elements element = Elements.None;
        public AudioClip collectedSound;

        private SpriteRenderer SpriteRenderer { get; set; }
        private Animator Animator { get; set; }
        private Score Score { get; set; }

        private void Collect()
        {
            Destroy(GetComponent<BoxCollider2D>());
            Score.Tokens++;
            if(collectedSound != null)
                AudioSource.PlayClipAtPoint(collectedSound, transform.position, PlayerPrefs.GetFloat("SFXVolume", 3f));
            Animator.SetTrigger(CollectedTriggerID);
        }

        private void Awake()
        {
            Score = GameObject.FindObjectOfType<Score>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            SpriteRenderer.color = Element.GetColour(element);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.gameObject;
            if(obj.CompareTag("Player"))
            {
                var player = obj.GetComponent<PlayerController>();
                if(element == Elements.None || player.Element == element)
                    Collect();
            }
        }

        private void Remove() => Destroy(gameObject);
    }
}