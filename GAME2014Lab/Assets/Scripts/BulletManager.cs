using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    [SerializeField]
    private Queue<GameObject> bulletPool;
    [SerializeField]
    private int bulletNumber = 50;

    [SerializeField]
    private GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletPool= new Queue<GameObject>();
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < bulletNumber; i++)
        {
            var tempBullet = Instantiate(bulletPrefab);
            tempBullet.SetActive(false);
            tempBullet.transform.SetParent(transform);
            bulletPool.Enqueue(tempBullet);
        }
    }

    private void AddBullet()
    {
        var tempBullet = Instantiate(bulletPrefab);
        tempBullet.SetActive(false);
        tempBullet.transform.SetParent(transform);
        bulletPool.Enqueue(tempBullet);
        bulletNumber++;
    }

    public GameObject GetBullet(Vector2 spawnPosition)
    {

        if (bulletPool.Count < 1)
        {
            AddBullet();
        }

        var bullet = bulletPool.Dequeue();
        bullet.transform.position = spawnPosition;
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
