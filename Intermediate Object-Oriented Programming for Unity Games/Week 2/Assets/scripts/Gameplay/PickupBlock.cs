using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : Block {

    #region fields

    [SerializeField]
    Sprite spriteOfFreezerBlock;

    [SerializeField]
    Sprite spriteOfSpeedupBlock;

    PickupEffect effect;

    #endregion

    #region property

    public PickupEffect pickupEffect
    {
        set
        {
            effect = value;
            if(value == PickupEffect.Freezer)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteOfFreezerBlock;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteOfSpeedupBlock;
            }
            
        }
        

    }

    #endregion

    // Use this for initialization
    void Start () {
        pointsOfBlock = ConfigurationUtils.PickupBlockPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
