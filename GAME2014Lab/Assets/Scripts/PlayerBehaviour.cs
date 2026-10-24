using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField]
    private float horizontalForce;

    [Range(0.0f, 1.0f)]
    public float decay;
    private Rigidbody2D rigidBody;

    [SerializeField]
    Boundary bounds;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    float bulletFireRate = 1;

    [SerializeField]
    TMP_Text livesText;

    private int lives = 3;

    private BulletManager bulletManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        bulletManager = BulletManager.Instance;
        StartCoroutine(FireBullets());
        livesText.text = "Lives: " + lives;
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

    IEnumerator FireBullets()
    {
        while (true)
        {

            yield return new WaitForSeconds(bulletFireRate);

            bulletManager.GetBullet(
                    bulletSpawn.position,
                    BulletType.Player
                    );

            yield return null;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Projectile"))
        {
            lives -= 1;
            livesText.text = "Lives: " + lives;
            if( lives < 0)
            {
                PlayerDie();
            }
        }
        if (collision.CompareTag("Pickup"))
        {
            lives += 1;
            livesText.text = "Lives: " + lives;
        }
    }

    private void PlayerDie()
    {
        SceneManager.LoadScene("End");
    }
}
