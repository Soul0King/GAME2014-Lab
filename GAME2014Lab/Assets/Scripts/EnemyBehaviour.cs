using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private Boundary movementBounds;

    [SerializeField]
    private Boundary startingRange;

    private float startY;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletFireRate = 1;

    [Header("Sine Wave Settings")]
    [SerializeField] private float frequencyMin = 1f;
    [SerializeField] private float frequencyMax = 3f;
    [SerializeField] private float amplitudeMin = 0.5f;
    [SerializeField] private float amplitudeMax = 1.5f;

    private float frequency;
    private float amplitude;

    private BulletManager bulletManager;

    private Vector3 startPosition;

    [SerializeField] private GameObject pickupPrefab;

    private float pickupChance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = BulletManager.Instance;
        startPosition = transform.position;
        StartCoroutine(FireBullets());
        startY = Random.Range(0.5f, 3.5f);
        frequency = Random.Range(frequencyMin, frequencyMax);
        amplitude = Random.Range(amplitudeMin, amplitudeMax);
        pickupChance = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        float sinX = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x + sinX, startY, startPosition.z);
    }

    void FixedUpdate()
    {

    }

    IEnumerator FireBullets()
    {
        while (true)
        {

            yield return new WaitForSeconds(bulletFireRate);

            bulletManager.GetBullet(
                bulletSpawn.position,
                BulletType.Enemy
                );

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Projectile"))
        {
            if(pickupChance > 0.7f)
            {
                Instantiate(pickupPrefab, transform.position, Quaternion.identity );
            }
            Destroy(gameObject);
        }
    }
}
