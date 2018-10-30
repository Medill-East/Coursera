using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager{

    #region Fields

    static List<PickupBlock> invokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerListeners = new List<UnityAction<float>>();
    static List<UnityAction<float, float>> speedupListeners = new List<UnityAction<float, float>>();

    #endregion

    #region public methods
    
    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        invokers.Add(invoker);
        foreach (UnityAction<float> lisener in freezerListeners)
        {
            invoker.AddFreezerEffectListener(lisener);
        }
    }

    public static void AddFreezerEffectLisener(UnityAction<float> handler)
    {
        freezerListeners.Add(handler);
        foreach (PickupBlock pickupBlock in invokers)
        {
            pickupBlock.AddFreezerEffectListener(handler);
        }
    }

    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        invokers.Add(invoker);
        foreach (UnityAction<float,float> lisener in speedupListeners)
        {
            invoker.AddSpeedupEffectListener(lisener);
        }
    }

    public static void AddSpeedupEffectLisener(UnityAction<float,float> handler)
    {
        speedupListeners.Add(handler);
        foreach (PickupBlock pickupBlock in invokers)
        {
            pickupBlock.AddSpeedupEffectListener(handler);
        }
    }

    #endregion
}
