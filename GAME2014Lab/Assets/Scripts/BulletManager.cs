using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager
{
    private static BulletManager instance = null;
    public static BulletManager Instance {
        get
        {
            if(instance == null)
            {
                instance = new BulletManager();
            }
            return instance;
        }
    
    }

    private Queue<GameObject> enemyBulletPool;
    private Queue<GameObject> playerBulletPool;
    private int enemyBulletNumber = 50;
    private int playerBulletNumber = 50;

    private BulletFactory factory = null;

    public void Initialize(BulletFactory bulletFactory)
    {
        factory = bulletFactory;
        enemyBulletPool = new Queue<GameObject>();
        playerBulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < enemyBulletNumber; i++)
        {
            AddBullet(BulletType.Enemy);
        }
        for(int i = 0; i < playerBulletNumber; i++)
        {
            AddBullet(BulletType.Player);
        }
    }

    private void AddBullet(BulletType type)
    {
        /*
        var tempBullet = Instantiate(bulletPrefab);
        tempBullet.SetActive(false);
        tempBullet.transform.SetParent(transform);
        bulletPool.Enqueue(tempBullet);
        */
        var tempBullet = factory.CreateBullet(type);
        tempBullet.GetComponent<BulletBehaviour>().bulletManager = this;
        switch (type)
        {
            case BulletType.Enemy:
                enemyBulletPool.Enqueue(tempBullet);
                break;
            case BulletType.Player:
                playerBulletPool.Enqueue(tempBullet);
                break;
        }
        
        
    }

    public GameObject GetBullet(Vector2 spawnPosition, BulletType type)
    {
        Queue<GameObject> bulletPool = null;
        switch (type)
        {
            case BulletType.Enemy:
                bulletPool = enemyBulletPool;
                break;
            case BulletType.Player:
                bulletPool = playerBulletPool;
                break;
        }

        if (bulletPool.Count < 1)
        {
            AddBullet(type);
            switch (type)
            {
                case BulletType.Enemy:
                    enemyBulletNumber++;
                    break;
                case BulletType.Player:
                    playerBulletNumber++;
                    break;
            }
        }

        var bullet = bulletPool.Dequeue();
        bullet.transform.position = spawnPosition;
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet, BulletType type)
    {
        bullet.SetActive(false);
        switch (type)
        {
            case BulletType.Enemy:
                enemyBulletPool.Enqueue(bullet);
                break;
            case BulletType.Player:
                playerBulletPool.Enqueue(bullet);
                break;
        }

        
    }

}
