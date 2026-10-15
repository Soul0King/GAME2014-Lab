using UnityEngine;
public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    [SerializeField]
    private Boundary bulletBounds;
    public BulletType type;

    public BulletManager bulletManager;

    private void Move()
    {
        transform.position += (velocity * Time.deltaTime);
    }

    private void CheckBounds() {
        if (transform.position.y < bulletBounds.min && type == BulletType.Enemy)
        {
            //Destroy(gameObject);
            bulletManager.ReturnBullet(gameObject, type);
        } else if(transform.position.y > bulletBounds.max && type == BulletType.Player)
        {
            //Destroy(gameObject);
            bulletManager.ReturnBullet(gameObject, type);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletManager = BulletManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player")) {
            bulletManager.ReturnBullet(gameObject, type);
        //}
    }
}
