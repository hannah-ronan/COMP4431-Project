using Audio;
using UI;
using UnityEngine;

namespace Objects.token
{
    /// <summary>
    /// Game Token to earn more points
    /// </summary>
    public class Token : MonoBehaviour
    {
        /// <summary>
        /// point value of the token
        /// </summary>
        public const int Value = 5;

        private static readonly int CollectedTriggerID = Animator.StringToHash("collect");

        [SerializeField]
        private Elements element = Elements.None;
        [SerializeField]
        private AudioClip collectedSound;

        private SpriteRenderer SpriteRenderer { get; set; }
        private Animator Animator { get; set; }
        private Score Score { get; set; }

        private void Collect()
        {
            Destroy(GetComponent<BoxCollider2D>());
            Score.Tokens++;
            if(collectedSound != null)
                Audio.Audio.Play(collectedSound, AudioTypes.Sfx, transform.position);
            Animator.SetTrigger(CollectedTriggerID);
        }

        private void Awake()
        {
            Score = FindObjectOfType<Score>();
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