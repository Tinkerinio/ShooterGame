using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveZ = Input.GetAxis("Vertical") * moveSpeed;
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}
