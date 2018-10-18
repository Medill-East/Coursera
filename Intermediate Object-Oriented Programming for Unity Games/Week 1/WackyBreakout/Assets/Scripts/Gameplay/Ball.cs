using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for ball
/// </summary>
public class Ball : MonoBehaviour {

    Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(Vector3.down * ConfigurationUtils.BallImpulseForce);



        //rb2D.AddForce(new Vector2(Mathf.Cos(20), Mathf.Sin(20)) * ConfigurationUtils.BallImpulseForce);
    }

    // Update is called once per frame
    void Update () {

    }

    public void SetDirection(Vector2 direction)
    {
        rb2D.velocity = rb2D.velocity.magnitude * direction;
    }

    /// <summary>
    /// 旋转向量，使其方向改变，大小不变
    /// </summary>
    /// <param name="v">需要旋转的向量</param>
    /// <param name="angle">旋转的角度</param>
    /// <returns>旋转后的向量</returns>
    private Vector2 RotationMatrix(Vector2 v, float angle)
    {
        var x = v.x;
        var y = v.y;
        var sin = Mathf.Sin(Mathf.PI * angle / 180);
        var cos = Mathf.Cos(Mathf.PI * angle / 180);
        var newX = x * cos + y * sin;
        var newY = x * -sin + y * cos;
        return new Vector2((float)newX, (float)newY);
    }
}
