using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Asteroid script attach to asteroid gameobject
/// </summary>
public class Asteroid : MonoBehaviour {

    [SerializeField]
    Sprite asteroid1;
    [SerializeField]
    Sprite asteroid2;
    [SerializeField]
    Sprite asteroid3;

    SpriteRenderer renderer;

	// Use this for initialization
	void Start () {

        renderer = GetComponent<SpriteRenderer>();
        int RandomNum = Random.Range(1, 3);
        if(RandomNum ==1)
        {
            renderer.sprite = asteroid1;
        }
        else if(RandomNum ==2)
        {
            renderer.sprite = asteroid2;
        }
        else
        {
            renderer.sprite = asteroid3;
        }

        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce( direction * magnitude, ForceMode2D.Impulse);
	}
	
}
