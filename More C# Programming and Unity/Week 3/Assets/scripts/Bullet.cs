using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for bullet
/// </summary>
public class Bullet : MonoBehaviour {

    const float liveTime = 2.0f;
    Timer deathTimer;

    /// <summary>
    /// add force to the bullet
    /// </summary>
    /// <param name="dir"></param>
    public void ApplyForce(Vector2 dir)
    {
        const float magnitude = 2.0f;
        GetComponent<Rigidbody2D>().AddForce(dir * magnitude,
            ForceMode2D.Impulse);
    }

	// Use this for initialization
	void Start () {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = 3.0f;
        deathTimer.Run();
	}
	
	// Update is called once per frame
	void Update () {
		if(deathTimer.Finished)
        {
            Destroy(gameObject);
        }
	}
}
