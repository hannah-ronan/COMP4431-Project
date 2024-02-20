using System.Collections;
using UnityEngine;

namespace Objects.key
{
    public class Key: MonoBehaviour
    {
        private static readonly int CollectedTriggerID = Animator.StringToHash("collected");

        /// <summary>
        /// This is a flag to indicate if the key has been collected or not.
        /// Specifically, it is a signal when the animation of the key being collected is finished.
        /// </summary>
        public bool collected = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
                StartCoroutine(nameof(Collect));
        }

        private IEnumerator Collect()
        {
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Animator>().SetTrigger(CollectedTriggerID); //<-- Trigger animation>
            yield return new WaitUntil(() => collected);
            Destroy(gameObject);
        }
    }
}