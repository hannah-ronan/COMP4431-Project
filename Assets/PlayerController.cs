using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 0.015f;
    public float jumpHeight = 3; 
    public int playerNum;
    public bool active;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Rigidbody2D rb;
    public bool isGrounded = true;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            float h = Input.GetAxisRaw($"P{playerNum}Horizontal");
            
            if(h < 0){
                spriteRenderer.flipX = true;
            }
            else if(h > 0){
                spriteRenderer.flipX = false;
            }

            anim.SetBool("isMoving",h!=0);
          
            if (Input.GetButtonDown($"P{playerNum}Vertical") && isGrounded){
                anim.SetTrigger("Jump");
                float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            
            gameObject.transform.position = new Vector2 (transform.position.x + (h * Time.deltaTime * walkSpeed),transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
            anim.SetTrigger("Land");
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
            anim.ResetTrigger("Land");
        }
    }

}
