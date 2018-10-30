using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager{

    #region Fields

    static List<PickupBlock> invokers = new List<PickupBlock>();
    static List<UnityAction<float>> liseners = new List<UnityAction<float>>();

    #endregion

    #region public methods
    
    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        invokers.Add(invoker);
        foreach (UnityAction<float> lisener in liseners)
        {
            invoker.AddFreezerEffectListener(lisener);
        }
    }

    public static void AddFreezerEffectLisener(UnityAction<float> handler)
    {
        liseners.Add(handler);
        foreach (PickupBlock pickupBlock in invokers)
        {
            pickupBlock.AddFreezerEffectListener(handler);
        }
    }

    #endregion
}
