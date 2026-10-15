using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField]
    private float horizontalForce;

    [Range(0.0f, 1.0f)]
    public float decay;
    private Rigidbody2D rigidBody;

    [SerializeField]
    Boundary bounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        rigidBody.linearVelocity *= (1.0f * decay);
        CheckBounds();
    }

    private float GetTouchDirection()
    {

        if (Touchscreen.current == null)
        {
            return 0.0f;
        }

        var touch = Touchscreen.current.primaryTouch;

        if (!touch.press.isPressed)
        {
            return 0.0f;
        }

        Vector2 pos = touch.position.ReadValue();

        if(pos.x < Screen.width / 2)
        {
            return -1.0f;
        }

        return 1.0f;
        
    }

    private void Move() {
        float x = GetTouchDirection();
        rigidBody.AddForce(new Vector2(x * horizontalForce, 0.0f));
    }

    private void CheckBounds() { 
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(
                bounds.min,
                transform.position.y
                );
        }
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(
                bounds.max,
                transform.position.y
                );
        }
    }
}
