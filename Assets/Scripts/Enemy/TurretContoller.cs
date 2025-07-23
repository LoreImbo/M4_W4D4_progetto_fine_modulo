using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;          
    //[SerializeField] private TurretBullet _bulletPrefab;  
    [SerializeField] private float _fireRate = 1f;          
    [SerializeField] private Transform _target;             

    private bool _playerInRange = false;
    private float _nextFireTime = 0f;
    private Vector3 _aimOffset = new Vector3(0, 1f, 0); // offset verticale regolabile

    void Update()
    {
        if (!_playerInRange || _target == null || !_target.gameObject.activeInHierarchy) return;

        if (_playerInRange && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / _fireRate;
            // mira leggermente sopra il transform del target
            Vector3 dir = (_target.position + _aimOffset - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            Fire();
        }
    }

    void Fire()
    {
        if (_target == null) return;

        // mira leggermente sopra il transform del target
        Vector3 direction = (_target.position + _aimOffset - _firePoint.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        TurretBullet bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = lookRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
            _target = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
            _target = null;
        }
    }
}

