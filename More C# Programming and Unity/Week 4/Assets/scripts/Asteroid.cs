using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;

    CircleCollider2D cc2d;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // set random sprite for asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
        }

        cc2d = GetComponent<CircleCollider2D>();
    }

    /// <summary>
    /// Starts the asteroid moving in the given direction
    /// </summary>
    /// <param name="direction">direction for the asteroid to move</param>
    /// <param name="position">position for the asteroid</param>
    public void Initialize(Direction direction, Vector3 position)
    {
        // set asteroid position
        transform.position = position;

        // set random angle based on direction
        float angle;
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;
        if (direction == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }

        StartMoving(angle);
    }

    /// <summary>
    /// Destroys the asteroid on collision with a bullet
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(coll.gameObject);   //destroy the bullet
          //Destroy(gameObject);      //destroy the asteroid

            Vector3 localScale = gameObject.transform.localScale;
            if (localScale.x > 0.4)
            {
                localScale.x = localScale.x / 2;
                localScale.y = localScale.y / 2;
                gameObject.transform.localScale = localScale;
                cc2d.radius = cc2d.radius / 2;

                GameObject smallerAsteroid1 = Instantiate(gameObject);
                smallerAsteroid1.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                GameObject smallerAsteroid2 = Instantiate(gameObject);
                smallerAsteroid2.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
            }
            else
            {
                Destroy(gameObject);
            }


        }
    }

    public void StartMoving(float angle)
    {
        // apply impulse force to get asteroid moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 3f;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }
}
