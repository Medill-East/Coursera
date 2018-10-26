using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {

        StartCoroutine(StartMoving());
        StartCoroutine(SpawnNewBall());
        StartCoroutine(DestroyBall());

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

        //Debug.Log(Time.time);

    }

    /// <summary>
    /// Wait for 1s before move
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartMoving()
    {
        yield return new WaitForSecondsRealtime(1);
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Wait and destory the ball
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyBall()
    {
        yield return new WaitForSecondsRealtime(10);
        CreateNewBall(gameObject.transform.position);
        Destroy(gameObject);
        HUD.ShowLeftBall();
    }

    /// <summary>
    /// Wait and spawn new ball
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnNewBall()
    {
        yield return new WaitForSecondsRealtime(Random.Range(ConfigurationUtils.MinSpawnSeconds, ConfigurationUtils.MaxSpawnSeconds));
        CreateNewBall(gameObject.transform.position);
    }

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    /// <summary>
    /// Create a new ball
    /// </summary>
    private void CreateNewBall(Vector3 newPosition)
    {
        BallSpawner ballSpawner = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BallSpawner>();
        GameObject newBall = ballSpawner.SpawnBall(newPosition);
        newBall.transform.position = newPosition;
        Debug.Log(ballSpawner.gameObject.name);
    }

    /// <summary>
    /// When invisible, spawn a new ball
    /// </summary>
    private void OnBecameInvisible()
    {
        if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            Destroy(gameObject);
            HUD.ShowLeftBall();
            Debug.Log("Spawn because of invisible");
            CreateNewBall(new Vector3(0, -1.5f, 0));
        }

    }
}
