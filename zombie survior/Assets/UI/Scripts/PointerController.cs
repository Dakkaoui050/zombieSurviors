using UnityEngine;

public class PointerController : MonoBehaviour
{
    public Transform player;      // Reference to the player's transform
    public Transform targetObject; // Reference to the object to point towards
    public float offset = 5f;     // Offset distance from the player

    void Update()
    {
        if (player != null && targetObject != null)
        {
            // Calculate the position with an offset from the player
            Vector2 offsetPosition = (Vector2)player.position + offset * ((Vector2)targetObject.position - (Vector2)player.position).normalized;
            transform.position = offsetPosition;

            // Point the object towards the target object
            Vector2 direction = targetObject.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Debug.LogWarning("Player or target object not assigned.");
        }
    }
}
