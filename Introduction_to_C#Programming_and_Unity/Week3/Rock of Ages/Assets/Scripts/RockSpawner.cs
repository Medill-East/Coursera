using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    [SerializeField]
    GameObject prefabRock;

    Object[] rocks;
    public int rockNumber = 0;

    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    //const int SpawnBorderSize = 100;
    //int minSpawnX;
    //int maxSpawnX;
    //int minSpawnY;
    //int maxSpawnY;

    private void Start()
    {
        //minSpawnX = SpawnBorderSize;
        //maxSpawnX = Screen.width - SpawnBorderSize;
        //minSpawnY = SpawnBorderSize;
        //maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    private void Update()
    {
        if(spawnTimer.Finished)
        {
            SpawnRock();

            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnRock()
    {
        //Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
                                      //Random.Range(minSpawnY, maxSpawnY),
                                       //-Camera.main.transform.position.z);
        Vector3 location = new Vector3(Screen.width/2,
                              Screen.height/2,
                               -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        if(GameObject.FindGameObjectsWithTag("Rock").Length < rockNumber)
        {
            GameObject rock = Instantiate(prefabRock) as GameObject;
            rock.transform.position = worldLocation;

            SpriteRenderer spriteRenderer = rock.GetComponent<SpriteRenderer>();

            rocks = Resources.LoadAll("Sprites", typeof(Sprite));

            Sprite sprite = (Sprite)rocks[Random.Range(0, rocks.Length)];
            spriteRenderer.sprite = sprite;
        }

    }

}
