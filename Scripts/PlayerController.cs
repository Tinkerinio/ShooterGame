using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Активируем одну камеру по умолчанию
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCamera();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.TransformDirection(new Vector3(moveX, 0f, moveZ)) * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z); // сохраняем Y от гравитации
    }

    void Shoot()
    {
        if (projectilePrefab && firePoint)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    void SwitchCamera()
    {
        bool isFirstPerson = firstPersonCamera.gameObject.activeSelf;
        firstPersonCamera.gameObject.SetActive(!isFirstPerson);
        thirdPersonCamera.gameObject.SetActive(isFirstPerson);
    }
}
