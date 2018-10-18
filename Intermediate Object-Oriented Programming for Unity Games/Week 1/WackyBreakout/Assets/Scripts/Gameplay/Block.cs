using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for block
/// </summary>
public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
        }
    }
}
