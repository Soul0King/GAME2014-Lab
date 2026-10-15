
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private Boundary movementBounds;

    [SerializeField]
    private Boundary startingRange;

    private float startingPoint;
    private float randomSpeed;

    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    int frameDelay = 10;

    private BulletManager bulletManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();


        randomSpeed = Random.Range(
            movementBounds.min,
            movementBounds.max
            );

        startingPoint = Random.Range(
            startingRange.min,
            startingRange.max
            );

        transform.position = new Vector2(
            startingPoint,
            transform.position.y
            );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            Mathf.PingPong(Time.time, randomSpeed) + startingPoint,
            transform.position.y
            );
    }

    void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0) {
            //var tempBullet = Instantiate(bulletPrefab);
            //tempBullet.transform.position = bulletSpawn.position;
            bulletManager.GetBullet(
                bulletSpawn.position
                );
        }
    }
}
