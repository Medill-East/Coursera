using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject prefabBall;

    GameObject ballObject;

    //bool retrySpawn = false;
    //Vector2 spawnLocationMin;
    //Vector2 spawnLocationMax;

    // Use this for initialization
    void Start()
    {
        SpawnBall(new Vector3(0, -1.5f, 0));
        ballObject = GameObject.FindGameObjectWithTag("Ball");

        //GameObject tempBall = Instantiate<GameObject>(prefabBall);
        //BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        //float ballColliderHalfWidth = collider.size.x / 2;
        //float ballColliderHalfHeight = collider.size.y / 2;
        //spawnLocationMin = new Vector2(
        //    tempBall.transform.position.x - ballColliderHalfWidth,
        //    tempBall.transform.position.y - ballColliderHalfHeight);
        //spawnLocationMax = new Vector2(
        //    tempBall.transform.position.x + ballColliderHalfWidth,
        //    tempBall.transform.position.y + ballColliderHalfHeight);
        //Destroy(tempBall);
    }

    // Update is called once per frame
    void Update()
    {
        //if (retrySpawn)
        //{
        //    SpawnBall(new Vector3(spawnLocationMax.x,spawnLocationMax.y,0));
        //}
    }

    public GameObject SpawnBall(Vector3 newPosition)
    {
        Debug.Log("Spawn done");

        //// make sure we don't spawn into a collision
        //if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        //{
        //    retrySpawn = false;
        //    Instantiate(prefabBall);
        //}
        //else
        //{
        //    retrySpawn = true;
        //}

        return Instantiate(prefabBall);

    }




}
