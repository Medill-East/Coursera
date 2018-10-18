using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for paddle
/// </summary>
public class Paddle : MonoBehaviour {

    Rigidbody2D rigidbody2D;

    float halfColliderWidth;
    float halfColliderHeight;
    const float BounceAngleHalfRange = Mathf.Deg2Rad * 60;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;

    }

    // Update is called once per frame
    void Update () {
		//Debug.Log(ScreenUtils.ScreenLeft);
	}

    private void FixedUpdate()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {

            if (transform.position.x - halfColliderWidth < ScreenUtils.ScreenLeft)
            {
                rigidbody2D.MovePosition(new Vector2(CalculateClampedX(transform.position.x - halfColliderWidth),rigidbody2D.position.y) 
                    + 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));
            }
            else
            {
                rigidbody2D.MovePosition(rigidbody2D.position - 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));

            }


        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.position.x + halfColliderWidth > ScreenUtils.ScreenRight)
            {
                rigidbody2D.MovePosition(new Vector2(CalculateClampedX(transform.position.x + halfColliderWidth), rigidbody2D.position.y)
                    - 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));
            }
            else
            {
                rigidbody2D.MovePosition(rigidbody2D.position + 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));
            }

            //CalculateClampedX(transform.position.x + halfColliderWidth);
            //rigidbody2D.MovePosition(rigidbody2D.position + 0.0001f * new Vector2(ConfigurationUtils.PaddleMoveUnitsPerSecond / Time.fixedDeltaTime, 0));
        }
    }

    float CalculateClampedX(float possibleNewX)
    {
        //Vector2 location = transform.position;
        //Vector2 possibleNewLocation = new Vector2(transform.position.x + possibleNewX, transform.position.y);

        if(possibleNewX < ScreenUtils.ScreenLeft)
        {
            possibleNewX += halfColliderWidth;
        }
        if(possibleNewX > ScreenUtils.ScreenRight)
        {
            possibleNewX -= halfColliderWidth;
        }

        return possibleNewX;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && CheckforTopCollision(coll) == true)
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool CheckforTopCollision(Collision2D coll)
    {
        if(coll.transform.position.y - coll.gameObject.GetComponent<BoxCollider2D>().size.y/2 - halfColliderHeight - transform.position.y < 0.05f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
