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
    public SpriteRenderer arrowSprite;
    public Vector2 groundCheckBoxSize;
    public float groundCheckCastDistance;

    //? prevent exterior modification to the element - https://docs.unity3d.com/Manual/script-Serialization.html
    [SerializeField]
    private Elements element = global::Elements.None;
    public Elements Element => element;
    [SerializeField] private AudioSource jumpSoundEffect;


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
            arrowSprite.enabled = true;
            float h = Input.GetAxisRaw($"P{playerNum}Horizontal");
            
            if(h < 0){
                spriteRenderer.flipX = true;
            }
            else if(h > 0){
                spriteRenderer.flipX = false;
            }

            anim.SetBool("isMoving",h!=0);
          
            if (Input.GetButtonDown($"P{playerNum}Vertical") && isGrounded()){
                anim.SetTrigger("Jump");
                jumpSoundEffect.Play();
                float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            
            gameObject.transform.position = new Vector2 (transform.position.x + (h * Time.deltaTime * walkSpeed),transform.position.y);
        }
        else{
            arrowSprite.enabled = false;
            anim.SetBool("isMoving", false);
        }
    }

    bool isGrounded(){
        var hitLayers = LayerMask.GetMask("JumpableObjects") | LayerMask.GetMask("Ground");
         if(Element == Elements.Air){
            hitLayers = hitLayers | LayerMask.GetMask("CloudPlatforms");
        }
        return Physics2D.BoxCast(transform.position, groundCheckBoxSize ,0, -transform.up, groundCheckCastDistance, hitLayers);
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckCastDistance, groundCheckBoxSize);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            anim.SetTrigger("Land");
        }
        if(Element != Elements.Air && other.gameObject.layer == 9){
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            anim.ResetTrigger("Land");
        }
    }

}
