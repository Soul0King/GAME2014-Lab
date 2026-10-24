using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    [SerializeField]
    private Boundary pickupBounds;

    [SerializeField]
    private float rotationSpeed = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += (velocity * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void CheckBounds()
    {
        if (transform.position.y < pickupBounds.min)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
