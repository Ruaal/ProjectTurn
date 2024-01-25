using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public bool isAttacking = false;

    private bool isCollisioning = false;

    // Start is called before the first frame update

    public void Attack()
    {
        if (isCollisioning)
        {
            isAttacking = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isCollisioning = true;
            if (isAttacking)
            {
                Debug.Log("Enemy hit");
                other.gameObject.GetComponent<EnemyController>().TakeDamage();
            }
        }
        isAttacking = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isCollisioning = false;
        }
    }
}
