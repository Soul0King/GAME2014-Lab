using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyBullet;
    [SerializeField]
    private GameObject playerBullet;


    public GameObject CreateBullet(BulletType type = BulletType.Enemy)
    {
        GameObject tempBullet = null;

        switch (type)
        {
            case BulletType.Enemy:
                tempBullet = Instantiate(enemyBullet);
                break;
            case BulletType.Player:
                tempBullet = Instantiate(playerBullet);
                break;
        }
        tempBullet.transform.SetParent(transform);
        tempBullet.SetActive(false);
        return tempBullet;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BulletManager.Instance.Initialize(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
