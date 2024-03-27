using System.Collections;
using Audio;
using UI;
using UnityEngine;

namespace Objects.key
{
    /// <summary>
    /// key collectable to complete the level
    /// </summary>
    public class Key: MonoBehaviour
    {
        /// <summary>
        /// point value of the key
        /// </summary>
        public const int Value = 1;
        private static readonly int CollectedTriggerID = Animator.StringToHash("collected");

        [SerializeField]
        private Elements element = Elements.None;
        [SerializeField]
        private AudioClip collectedSound;
        [SerializeField]
        private AudioClip deniedSound;

        private SpriteRenderer SpriteRenderer { get; set; }
        private Animator Animator { get; set; }
        private Score Score { get; set; }

        public void Awake()
        {
            Score = FindObjectOfType<Score>();
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
            Destroy(GetComponent<BoxCollider2D>());
            if(collectedSound != null)
                Audio.Audio.Play(collectedSound, AudioTypes.Sfx);
            Score.Keys++;
            Animator.SetTrigger(CollectedTriggerID); //<-- Trigger animation>
        }

        private void Remove() => Destroy(gameObject);

        private IEnumerator Deny()
        {
            Audio.Audio.Play(deniedSound, AudioTypes.Sfx, transform.position);
            SpriteRenderer.color = Color.black;
            yield return new WaitForSeconds(0.5f);
            SpriteRenderer.color = Element.GetColour(element);
        }
    }
}