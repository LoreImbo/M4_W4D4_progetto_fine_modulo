using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public int damage = 10;

    //void Start()
    //{
    //    Destroy(gameObject, lifetime);
    //}

    void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(DisableSelf), lifetime);
    }
    
    void DisableSelf()
    {
        BulletPool.Instance.ReturnBullet(this);
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
            //Destroy(gameObject);
            BulletPool.Instance.ReturnBullet(this);
        }
        else if (other.CompareTag("Floor") || !other.isTrigger)
        {
            // Se colpisce il terreno, distruggi il proiettile
            BulletPool.Instance.ReturnBullet(this);
        }
    }
}

