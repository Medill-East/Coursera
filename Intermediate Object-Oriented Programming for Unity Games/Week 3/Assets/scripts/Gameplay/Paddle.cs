﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    // saved for efficiency
    Rigidbody2D rb2d;
    float halfColliderWidth;
    float halfColliderHeight;

    // aiming support
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    // freezer related
    bool isFrozen = false;
    bool frozenFinished = true;

    // speedup related
    bool isSpeedup = false;
    bool speedupFinished = true;
    float speedupFactor;
    float paddleMoveUnitsPerSecond;
    float maxPaddleMoveUnitsPerSecond;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // save for efficiency
        rb2d = GetComponent<Rigidbody2D>();
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        halfColliderWidth = bc2d.size.x / 2;
        halfColliderHeight = bc2d.size.y / 2;

        speedupFactor = ConfigurationUtils.SpeedupFactor;
        paddleMoveUnitsPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;
        maxPaddleMoveUnitsPerSecond = speedupFactor * paddleMoveUnitsPerSecond;

        EventManager.AddFreezerEffectLisener(HandleFreezerEffectActivatedEvent);
        EventManager.AddSpeedupEffectLisener(HandleSpeedupEffectActivatedEvent);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Debug.Log(rb2d.velocity);
        Debug.Log(paddleMoveUnitsPerSecond);
    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // move for horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        if (frozenFinished == true)
        {
            isFrozen = false;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if(speedupFinished == true)
        {
            isSpeedup = false;
            paddleMoveUnitsPerSecond = ConfigurationUtils.PaddleMoveUnitsPerSecond;
        }

        if (horizontalInput != 0 && isFrozen == false)
        {
            Vector2 position = rb2d.position;
            position.x += horizontalInput * paddleMoveUnitsPerSecond *
                Time.deltaTime;
            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }

    /// <summary>
    /// Calculates an x position to clamp the paddle in the screen
    /// </summary>
    /// <param name="x">the x position to clamp</param>
    /// <returns>the clamped x position</returns>
    float CalculateClampedX(float x)
    {
        // clamp left and right edges
        if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        }
        return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") &&
            TopCollision(coll))
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

    /// <summary>
    /// Checks for a collision on the top of the paddle
    /// </summary>
    /// <returns><c>true</c>, if collision was on the top of the paddle, <c>false</c> otherwise.</returns>
    /// <param name="coll">collision info</param>
    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandleFreezerEffectActivatedEvent(float frozenTime)
    {
        isFrozen = true;
        frozenFinished = false;
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        StartCoroutine(FrozenFinished(frozenTime));
    }

    IEnumerator FrozenFinished(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isFrozen = false;
        frozenFinished = true;
    }

    void HandleSpeedupEffectActivatedEvent(float speedupTime,float speedupFactor)
    {
        isSpeedup = true;
        speedupFinished = false;
        if(paddleMoveUnitsPerSecond != maxPaddleMoveUnitsPerSecond)
        {
            paddleMoveUnitsPerSecond *= speedupFactor;
        }
        StartCoroutine(SpeedupFinished(speedupTime));
    }

    IEnumerator SpeedupFinished(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isSpeedup = false;
        speedupFinished = true;
    }
}