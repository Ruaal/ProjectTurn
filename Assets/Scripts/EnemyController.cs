using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public int Life = 2;
    private float Velocity;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isColliding = false;
    public float force = 5f;
    public float maxVelocity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", Velocity);
    }

    public void TakeDamage()
    {
        animator.SetTrigger("TakeDmg");
        Life--;
        if (spriteRenderer.flipX)
        {
            rb.AddForce(new Vector2(3, 1), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(-3, 1), ForceMode2D.Impulse);
        }
        if (Life <= 0)
        {
            animator.SetTrigger("Death");
            rb.simulated = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = true;
            animator.SetTrigger("Attack");
            other.gameObject.GetComponent<PlayerController>().TakeDamage();
            if (spriteRenderer.flipX)
            {
                rb.AddForce(new Vector2(2, 1), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(-2, 1), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    public void MoveToPlayer(Transform player)
    {
        Debug.Log("MoveToPlayer");
        if (!isColliding && player != null)
        {
            Debug.Log("ismoving");
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce(new Vector2(direction.x * force, 0));

            // Rotate to face the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GetComponent<SpriteRenderer>().flipX = angle > 90 || angle < -90 ? true : false;

            // Limit the maximum velocity
            if (rb.velocity.magnitude > maxVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.normalized.x * maxVelocity, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
