using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    private float fireCooldown = 0f;
    public int towerPrice = 1;

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        Enemy target = FindBestTarget();
        if (target != null && fireCooldown <= 0f)
        {
            Shoot(target);
            fireCooldown = 1f / fireRate;
        }
    }
    Enemy FindBestTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        Enemy best = null;
        float bestProgress = -1f;
        foreach (Enemy e in enemies)
        {
            float distance = Vector2.Distance(transform.position, e.transform.position);

            if (distance <= range)
            {
                if(e.currentWayPoint > bestProgress)
                {
                    bestProgress = e.currentWayPoint;
                    best = e;
                }
            }
        }
        return best;
    }
    void Shoot(Enemy target)
    {
        GameObject p = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile pr = p.GetComponent<Projectile>();
        pr.target = target.transform;
    }
}
