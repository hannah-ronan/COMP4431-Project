using System.Collections;
using UI.Score;
using UnityEngine;

namespace Objects.key
{
    public class Key: MonoBehaviour
    {
        public const int value = 1;
        private static readonly int CollectedTriggerID = Animator.StringToHash("collected");

        public Elements element = Elements.None;
        private SpriteRenderer SpriteRenderer { get; set; }
        private Animator Animator { get; set; }
        public bool Collected { get; private set; }
        private Score Score { get; set; }

        public void Awake()
        {
            Score = GameObject.FindObjectOfType<Score>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            if(element != Elements.None)
                SpriteRenderer.color = Element.GetColour(element);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var obj = collision.gameObject;
            if(obj.CompareTag("Player"))
            {
                var player = obj.GetComponent<PlayerController>();
                if(element == Elements.None || player.Element == element)
                    Collect();
                else
                    StartCoroutine(Deny());
            }
        }

        private void Collect()
        {
            Collected = true;
            Score.Keys++;
            GetComponent<Animator>().SetTrigger(CollectedTriggerID); //<-- Trigger animation>
        }

        private void Remove() => Destroy(gameObject);

        private IEnumerator Deny()
        {
            var original = Element.GetColour(element);
            SpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            SpriteRenderer.color = original;
        }
    }
}