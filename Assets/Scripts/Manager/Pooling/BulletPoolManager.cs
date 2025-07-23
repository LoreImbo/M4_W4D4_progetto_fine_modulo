using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    
    [SerializeField] private TurretBullet _bulletPrefab;
    [SerializeField] private int _poolSize = 20;
    public static BulletPool Instance { get; private set; }

    private Queue<TurretBullet> _bulletPool = new Queue<TurretBullet>();

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < _poolSize; i++)
        {
            TurretBullet bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }

    public TurretBullet GetBullet()
    {
        if (_bulletPool.Count > 0)
        {
            TurretBullet bullet = _bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            TurretBullet newBullet = Instantiate(_bulletPrefab);
            return newBullet;
        }
    }

    public void ReturnBullet(TurretBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}

