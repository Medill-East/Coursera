using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{

    #region fields

    [SerializeField]
    Sprite spriteOfFreezerBlock;

    [SerializeField]
    Sprite spriteOfSpeedupBlock;

    PickupEffect effect;

    // freezer effect related
    float freezerEffectDuration;
    protected FreezerEffectActivatedEvent freezerEffectActivatedEvent;

    // speedup effect related
    float speedupEffectDuration;
    float speedupFactor;
    protected SpeedupEffectActivatedEvent speedupEffectActivatedEvent;


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

            speedupEffectDuration = ConfigurationUtils.SpeedupEffectDuration;
            speedupFactor = ConfigurationUtils.SpeedupFactor;
            speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
            EventManager.AddSpeedupEffectInvoker(this);
            if (value == PickupEffect.Speedup)
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

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivatedEvent.AddListener(listener);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.AddListener(listener);
    }

    #endregion

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if (effect == PickupEffect.Freezer)
            {
                freezerEffectActivatedEvent.Invoke(freezerEffectDuration);
            }
            if (effect == PickupEffect.Speedup)
            {
                speedupEffectActivatedEvent.Invoke(speedupEffectDuration, speedupFactor);
            }
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddScore(pointsOfBlock);
            Destroy(gameObject);
        }
    }
}
