using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// spawner for asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabAsteroid;
    Asteroid scriptAsteroid;
    float colliderRadius;

	// Use this for initialization
	void Start () {
        //GameObject cloneAsteroid = Instantiate(prefabAsteroid, Vector3.zero, Quaternion.identity);
        //cloneAsteroid.GetComponent<Asteroid>().Initialize(Direction.Up,Vector3.zero);
        //colliderRadius = cloneAsteroid.GetComponent<CircleCollider2D>().radius;
        //Destroy(cloneAsteroid);
        colliderRadius = prefabAsteroid.GetComponent<CircleCollider2D>().radius;
        Debug.Log(colliderRadius);


        Vector3 rightPosition = new Vector3(ScreenUtils.ScreenRight + 2 * colliderRadius, 0, 0);
        GameObject moveLeftAsteroid = Instantiate(prefabAsteroid,rightPosition, Quaternion.identity);
        moveLeftAsteroid.GetComponent<Asteroid>().Initialize(Direction.Left, rightPosition);

        Vector3 topPosition = new Vector3(0, ScreenUtils.ScreenTop + 2 * colliderRadius, 0);
        GameObject moveDownAsteroid = Instantiate(prefabAsteroid, topPosition, Quaternion.identity);
        moveDownAsteroid.GetComponent<Asteroid>().Initialize(Direction.Down, topPosition);

        Vector3 leftPosition = new Vector3(ScreenUtils.ScreenLeft - 2 * colliderRadius, 0, 0);
        GameObject moveRightAsteroid = Instantiate(prefabAsteroid, leftPosition, Quaternion.identity);
        moveRightAsteroid.GetComponent<Asteroid>().Initialize(Direction.Right, leftPosition);

        Vector3 bottomPosition = new Vector3(0, ScreenUtils.ScreenBottom - 2 * colliderRadius, 0);
        GameObject moveUpAsteroid = Instantiate(prefabAsteroid, bottomPosition, Quaternion.identity);
        moveUpAsteroid.GetComponent<Asteroid>().Initialize(Direction.Up, bottomPosition);

    }
	
}
