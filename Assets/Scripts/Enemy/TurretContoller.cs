using UnityEngine;

using System;
public class TurretController : MonoBehaviour
{
    public Transform firePoint;          // Dove spawna il proiettile
    public TurretBullet projectilePrefab;  // Prefab del proiettile
    public float fireRate = 1f;          // Colpi al secondo
    public float range = 10f;            // Solo informativo
    public Transform target;             // Il player

    private bool playerInRange = false;
    private float nextFireTime = 0f;

    void Update()
    {
        if (!playerInRange || target == null || !target.gameObject.activeInHierarchy) return;

        if (playerInRange && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            Fire();
        }
    }

    void Fire()
    {
        if (target == null) return;

        Vector3 direction = (target.position - firePoint.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Instantiate(projectilePrefab, firePoint.position, lookRotation);
        // Puoi aggiungere effetti sonori o animazioni qui
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            target = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            target = null;
        }
    }
}

