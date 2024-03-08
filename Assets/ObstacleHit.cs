using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public static bool isObstacleHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if(gameObject.CompareTag("Fire") && player.Element==Elements.Fire){
            return;
        }
        player.Die();
        StartCoroutine(DelayGameOver(1f));
    }

    IEnumerator DelayGameOver(float delayTime){
        yield return new WaitForSeconds(delayTime);
        isObstacleHit = true;
    }
}
