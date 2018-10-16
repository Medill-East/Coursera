using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for paddle
/// </summary>
public class Paddle : MonoBehaviour {

    Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2D.MovePosition(rigidbody2D.position - 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));
        }
    }
}
