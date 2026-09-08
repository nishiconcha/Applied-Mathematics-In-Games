using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Up and Down
        float vertical = Input.GetAxisRaw("Vertical"); // Left and Right

        Vector3 move = new Vector3(horizontal, 0f, vertical);

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        // Movement based on direction
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}