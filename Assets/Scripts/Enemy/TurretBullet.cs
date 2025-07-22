using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public int damage = 10;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Applica danno qui
            Debug.Log("Player colpito!");
            LifeController lifeController = other.GetComponent<LifeController>();
            if (lifeController != null)
            {
                lifeController.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Floor"))
        {
            // Se colpisce il terreno, distruggi il proiettile
            Destroy(gameObject);
        }
        else if (!other.isTrigger)
        {
            // Distruggi il proiettile se colpisce qualsiasi altro oggetto non trigger
            Destroy(gameObject);
        }
    }
}

