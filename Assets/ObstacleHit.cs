using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public bool isObstacleHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isObstacleHit = true;
    }

    public bool ObstacleCollide()
    {
        return isObstacleHit;
    }
}
