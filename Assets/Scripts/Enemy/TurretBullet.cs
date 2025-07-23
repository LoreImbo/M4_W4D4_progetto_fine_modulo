using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _lifetime = 5f;
    [SerializeField] private int _damage = 2;

    void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(DisableSelf), _lifetime);
    }

    void DisableSelf()
    {
        BulletPool.Instance.ReturnBullet(this);
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Il giocatore {other.name} è stato colpito!");
            LifeController lifeController = other.GetComponent<LifeController>();
            if (lifeController != null)
            {
                lifeController.TakeDamage(_damage);
            }
            BulletPool.Instance.ReturnBullet(this);
        }
        else if (other.CompareTag("Floor") || !other.isTrigger)
        {
            // Se colpisce il terreno o altro, distruggi il proiettile
            BulletPool.Instance.ReturnBullet(this);
        }
    }
}

