using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block {

    #region fields

    [SerializeField]
    Sprite spriteOfFreezerBlock;

    [SerializeField]
    Sprite spriteOfSpeedupBlock;

    PickupEffect effect;

    float freezerEffectDuration;

    protected FreezerEffectActivatedEvent freezerEffectActivatedEvent;

    #endregion

    #region property

    public PickupEffect pickupEffect
    {
        set
        {
            effect = value;
            freezerEffectDuration = ConfigurationUtils.FreezerEffectDuration;
            freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
            EventManager.AddFreezerEffectInvoker(this);
            if (value == PickupEffect.Freezer)
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
    void Start()
    {
        pointsOfBlock = ConfigurationUtils.PickupBlockPoints;
    }

    #region public method

    public void AddFreezerEffectListener(UnityAction<float> lisener)
    {
        freezerEffectActivatedEvent.AddListener(lisener);
    }

    #endregion

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if(effect == PickupEffect.Freezer)
            {
                freezerEffectActivatedEvent.Invoke(freezerEffectDuration);
            }
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddScore(pointsOfBlock);
            Destroy(gameObject);
        }
    }
}
