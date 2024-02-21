using UnityEngine;

namespace Objects.token
{
    /// <summary>
    /// Game Token
    /// </summary>
    public class Token: MonoBehaviour
    {
        public const int Score = 1;

        private static readonly int CollectedTriggerID = Animator.StringToHash("collect");

        public Elements element;
        public bool collected = false;

        private SpriteRenderer SpriteRenderer { get; set; }
        private Animator Animator { get; set; }

        private void Collect()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Animator = GetComponent<Animator>();
            SpriteRenderer.color = Element.GetColour(element);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
                Animator.SetTrigger(CollectedTriggerID);
        }
    }
}