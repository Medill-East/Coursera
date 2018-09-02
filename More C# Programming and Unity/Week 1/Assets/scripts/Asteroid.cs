using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Asteroid script attach to asteroid gameobject
/// </summary>
public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
