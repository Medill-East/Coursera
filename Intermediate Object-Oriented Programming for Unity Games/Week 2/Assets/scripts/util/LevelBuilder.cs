using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class of LevelBuilder
/// </summary>
public class LevelBuilder : MonoBehaviour
{

    #region fields

    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;

    [SerializeField]
    GameObject prefabBonusBlock;

    [SerializeField]
    GameObject prefabPickupBlock;

    private float blockWidth;
    private float blockHeight;

    #endregion

    // Use this for initialization
    void Start()
    {
        Instantiate(prefabPaddle);
        GameObject tempBlock = Instantiate(prefabStandardBlock);
        blockWidth = tempBlock.GetComponent<BoxCollider2D>().size.x;
        blockHeight = tempBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tempBlock);
        CreateRowsOfBlocks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateRowsOfBlocks()
    {
        GameObject[,] blockLists = new GameObject[11, 3];
        

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 11; i++)
            {
                float randNum = Random.Range(0,4);
                if(randNum <= 1)
                {
                    blockLists[i, j] = Instantiate(prefabStandardBlock);
                    blockLists[i, j].transform.position = new Vector3((i - 5) * blockWidth, ScreenUtils.ScreenTop * (0.8f - (j * 0.2f)), 0);
                }
                else if(1 <randNum && randNum <= 2)
                {
                    blockLists[i, j] = Instantiate(prefabBonusBlock);
                    blockLists[i, j].transform.position = new Vector3((i - 5) * blockWidth, ScreenUtils.ScreenTop * (0.8f - (j * 0.2f)), 0);
                }
                else if(2 < randNum && randNum <= 3)
                {
                    blockLists[i, j] = Instantiate(prefabPickupBlock);
                    blockLists[i, j].GetComponent<PickupBlock>().pickupEffect = PickupEffect.Freezer;
                    blockLists[i, j].transform.position = new Vector3((i - 5) * blockWidth, ScreenUtils.ScreenTop * (0.8f - (j * 0.2f)), 0);
                }
                else if (3 < randNum && randNum <= 4)
                {
                    blockLists[i, j] = Instantiate(prefabPickupBlock);
                    blockLists[i, j].GetComponent<PickupBlock>().pickupEffect = PickupEffect.Speedup;
                    blockLists[i, j].transform.position = new Vector3((i - 5) * blockWidth, ScreenUtils.ScreenTop * (0.8f - (j * 0.2f)), 0);
                }


            }
        }


    }

}
