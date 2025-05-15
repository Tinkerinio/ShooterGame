using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    public GameObject explosionEffect;

    void Start()
    {
        // Задать скорость пули в направлении взгляда
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed;
        }

        // Удалить пулю через время
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, если пуля попала во врага
        if (other.CompareTag("Enemy"))
        {
            // Эффект взрыва
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            // Уничтожить врага и пулю
            Destroy(other.gameObject);
            Destroy(gameObject);

            // Увеличить очки (если есть GameManager)
            GameManager.Instance.AddScore(10);
        }
    }
}
