using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public static bool isObstacleHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("Fire") && collision.gameObject.GetComponent<PlayerController>().Element==Elements.Fire){
            return;
        }
        isObstacleHit = true;
    }
}
