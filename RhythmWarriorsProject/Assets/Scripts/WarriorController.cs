using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    private Transform m_Transform;
    private float bulletPlayerDistanceScale;

    [SerializeField]
    private Transform bullet;

    [SerializeField]
    private int maxHealth;

    public int health;

    [SerializeField]
    private HealthBar HealthBar;

    [SerializeField]
    private ParticleSystem deathParticles;


    // Start is called before the first frame update
    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        bulletPlayerDistanceScale = 1.21f;
        health = maxHealth;
        HealthBar.SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKey(KeyCode.W) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 0.1f, Space.World);
        }

        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKey(KeyCode.S) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * 0.1f, Space.World);
        }

        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKey(KeyCode.A) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 0.1f, Space.World);
        }

        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKey(KeyCode.D) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 0.1f, Space.World);
        }

        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKey(KeyCode.Q) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKey(KeyCode.Keypad1))
        {
            transform.Rotate(Vector3.up, -1.0f);
        }

        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKey(KeyCode.E) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKey(KeyCode.Keypad2))
        {
            transform.Rotate(Vector3.up, 1.0f);
        }
    }

    void Fire()
    {
        if (gameObject.tag == Tags.PLAYER1_TAG && Input.GetKeyDown(KeyCode.F) ||
            gameObject.tag == Tags.PLAYER2_TAG && Input.GetKeyDown(KeyCode.Keypad3))
        {
            Vector3 barrelPos = transform.GetChild(0).position;
            Vector3 shotDirection = (barrelPos - transform.position).normalized;
            Vector3 bulletPos = transform.position + bulletPlayerDistanceScale * shotDirection;

            Transform newBullet = (Transform)Instantiate(bullet, bulletPos, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(shotDirection * 10f);
        }
    }

    public void TakeDamage(int damage)
    {
        if(health >= damage)
        {
            health -= damage;
        }

        else
        {
            health = 0;
        }

        HealthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }
}
