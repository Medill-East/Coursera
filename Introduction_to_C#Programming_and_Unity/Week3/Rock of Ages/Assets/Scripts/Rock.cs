using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    //SpriteRenderer spriteRenderer;
    //Object[] rocks;

	// Use this for initialization
	void Start () {
        //spriteRenderer = this.transform.GetComponent<SpriteRenderer>();

        //rocks = Resources.LoadAll("Sprites",typeof(Sprite));

        //Sprite sprite = (Sprite)rocks[Random.Range(0, rocks.Length)];
        //spriteRenderer.sprite = sprite;

        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 2f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
