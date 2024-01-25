using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the player's movement
public class PlayerController : MonoBehaviour
{
    public float LinearSpeed = 1;
    public float JumpForce = 5.0f;

    private float distanceToGround;
    private Animator animator;

    private string winOrLoose = "winOrLoose";
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool isBlocking = false;
    public PlayerSensor frontCollider;
    public PlayerSensor backCollider;
    public int Life = 3;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("VelocityY", rb.velocity.y);

        if (isOnTopOfLayer(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        animator.SetBool("Grounded", isGrounded);

        float inputX = Input.GetAxis("Horizontal");
        if (inputX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (inputX < 0)
        {
            spriteRenderer.flipX = true;
        }
        rb.velocity = new Vector2(inputX * LinearSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isOnTopOfLayer(LayerMask.GetMask("Ground")))
        {
            jump();
            animator.SetTrigger("Jump");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            block();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("IdleBlock", false);
            isBlocking = false;
        }
        if (isOnTopOfLayer(LayerMask.GetMask("Spikes")))
        {
            death();
        }
    }

    private void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    private bool isOnTopOfLayer(LayerMask layerMask)
    {
        return Physics2D.Raycast(
            transform.position,
            Vector2.down,
            distanceToGround + 0.1f,
            layerMask
        );
    }

    private void attack()
    {
        animator.SetTrigger("Attack");
        if (spriteRenderer.flipX)
        {
            backCollider.Attack();
        }
        else
        {
            frontCollider.Attack();
        }
    }

    private void block()
    {
        isBlocking = true;
        animator.SetTrigger("Block");
        animator.SetBool("IdleBlock", true);
    }

    public void TakeDamage()
    {
        if (!isBlocking)
        {
            animator.SetTrigger("Hurt");
            Life--;
        }
        if (Life <= 0)
        {
            death();
        }
    }

    private void death()
    {
        PlayerPrefs.SetString(winOrLoose, "Has Perdido");
        SceneManager.LoadScene("Menu");
    }
}
