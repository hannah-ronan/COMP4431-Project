using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Objects.token
{
    /// <summary>
    /// Game Token
    /// </summary>
    public class Token: MonoBehaviour
    {
        public const int Score = 1;

        private static readonly int CollectedTriggerID = Animator.StringToHash("collected");

        public Element.Type element;
        public bool collected = false;

        private SpriteRenderer SpriteRenderer { get; set; }

        private IEnumerator Collect()
        {
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Animator>().SetTrigger(CollectedTriggerID);
            yield return new WaitUntil(() => collected);
            Destroy(gameObject);
        }

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteRenderer.material.color = global::Element.GetColour(element);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
                StartCoroutine(nameof(Collect));
        }
    }
}