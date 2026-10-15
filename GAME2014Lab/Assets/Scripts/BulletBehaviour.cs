using UnityEngine;
public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Boundary bulletBounds;

    private BulletManager bulletManager;

    private void Move()
    {
        transform.position -= new Vector3(
            0.0f,
            speed * Time.deltaTime,
            0.0f
            );
    }

    private void CheckBounds() {
        if (transform.position.y < bulletBounds.min)
        {
            //Destroy(gameObject);
            bulletManager.ReturnBullet(gameObject);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
