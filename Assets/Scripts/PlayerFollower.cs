using UnityEngine;
/**
 * This script is used to make the camera follow the player
 */
public class PlayerFollower : MonoBehaviour
{
    public Transform Player;

    private Vector3 offset;

    private void Start()
    {
        offset = Player.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position = Player.position - offset;
    }
}
