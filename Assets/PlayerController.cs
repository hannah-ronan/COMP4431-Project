using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int playerNum;
    public bool active;
    public SpriteRenderer spriteRenderer;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            float h = Input.GetAxisRaw($"P{playerNum}Horizontal");
            float v = Input.GetAxisRaw($"P{playerNum}Vertical");

            if(h < 0){
                spriteRenderer.flipX = true;
            }
            else if(h > 0){
                spriteRenderer.flipX = false;
            }

            anim.SetBool("isMoving",h!=0);
            
            gameObject.transform.position = new Vector2 (transform.position.x + (h * speed), 
                transform.position.y + (v * speed));
        }
    }
}
