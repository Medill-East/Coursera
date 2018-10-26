using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class of standard block
/// </summary>
public class StandardBlock : Block {

    #region fields

    [SerializeField]
    Sprite spriteOfSDB0;

    [SerializeField]
    Sprite spriteOfSDB1;

    [SerializeField]
    Sprite spriteOfSDB2;

    #endregion

    // Use this for initialization
    void Start () {
        pointsOfBlock = ConfigurationUtils.StandardBlockPoints;
        float randomNumber = Random.Range(0, 3f);
        if(randomNumber <= 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteOfSDB0;
        }
        else if (1 < randomNumber && randomNumber <= 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteOfSDB1;
        }
        else if (2 < randomNumber && randomNumber <= 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteOfSDB2;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
