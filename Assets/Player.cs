using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h < 0){
            spriteRenderer.flipX = true;
        }
        else if(h > 0){
            spriteRenderer.flipX = false;
        }
        
        gameObject.transform.position = new Vector2 (transform.position.x + (h * speed), 
            transform.position.y + (v * speed));
    }
}
