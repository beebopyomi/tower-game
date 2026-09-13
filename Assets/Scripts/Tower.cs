using UnityEngine;

[System.Serializable]
public class TowerUpgradeStages
{
    public float range;
    public float fireRate;
    public Sprite sprite;
    public int price;
}
public class Tower : MonoBehaviour
{
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public TowerUpgradeStages[] upgradeStages;
    public int upgradeStage = 0;
    private SpriteRenderer SR;
    public GameObject towerUpgradeUIPrefab;
    private GameObject currentUI;   
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

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
    public void Upgrade()
    {
        TowerUpgradeStages currentUpgradeStage = upgradeStages[upgradeStage];
        range = currentUpgradeStage.range;
        fireRate = currentUpgradeStage.fireRate;
        SR.sprite = currentUpgradeStage.sprite;
        CoinManager.instance.UpdateCoins(-currentUpgradeStage.price);
        upgradeStage += 1;
    }
    private void OnMouseDown()
    {
        Debug.Log("ik doe ook echt iets he");
        if(currentUI == null)
        {
            currentUI = Instantiate(towerUpgradeUIPrefab, FindAnyObjectByType<Canvas>().transform);
        }
        TowerUpgradeUI currentUpgradeUI = currentUI.GetComponent<TowerUpgradeUI>();
        currentUpgradeUI.tower = this;

        currentUI.transform.position = Input.mousePosition + new Vector3(50, -50);

        if (upgradeStage >= upgradeStages.Length) return;
        currentUpgradeUI.priceTxt.text = upgradeStages[upgradeStage].price.ToString();
        
    }
}

