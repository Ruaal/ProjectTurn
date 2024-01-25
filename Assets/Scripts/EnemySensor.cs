using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            transform.parent.GetComponent<EnemyController>().MoveToPlayer(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player lost");
            transform.parent.GetComponent<EnemyController>().MoveToPlayer(null);
        }
    }
}
