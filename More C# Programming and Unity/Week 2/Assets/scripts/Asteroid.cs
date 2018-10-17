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
	}

    public void Initialize(Direction dir,Vector3 location)
    {
        if (dir == Direction.Up)
        {
            transform.position = location;
            // apply impulse force to get game object moving
            const float MinImpulseForce = 3f;
            const float MaxImpulseForce = 5f;
            float angle = Random.Range(75 * Mathf.Deg2Rad, 75 * Mathf.Deg2Rad + 30 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
                Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
            
        }

        if (dir == Direction.Left)
        {
            transform.position = location;

            // apply impulse force to get game object moving
            const float MinImpulseForce = 3f;
            const float MaxImpulseForce = 5f;
            float angle = Random.Range(165 * Mathf.Deg2Rad, 165 * Mathf.Deg2Rad + 30 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
                Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }

        if (dir == Direction.Down)
        {
            transform.position = location;

            // apply impulse force to get game object moving
            const float MinImpulseForce = 3f;
            const float MaxImpulseForce = 5f;
            float angle = Random.Range(255 * Mathf.Deg2Rad, 255 * Mathf.Deg2Rad + 30 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
                Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }

        if (dir == Direction.Right)
        {
            transform.position = location;

            // apply impulse force to get game object moving
            const float MinImpulseForce = 3f;
            const float MaxImpulseForce = 5f;
            float angle = Random.Range(-15 * Mathf.Deg2Rad, -15 * Mathf.Deg2Rad + 30 * Mathf.Deg2Rad);
            Vector2 moveDirection = new Vector2(
                Mathf.Cos(angle), Mathf.Sin(angle));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(
                moveDirection * magnitude,
                ForceMode2D.Impulse);
        }

    }
}
