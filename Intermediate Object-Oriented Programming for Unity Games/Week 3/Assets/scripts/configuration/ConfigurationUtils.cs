using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;

    #region Properties
        
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }    
    }

    /// <summary>
    /// Gets the ball lifetime
    /// </summary>
    public static float BallLifeTime
    {
        get { return configurationData.BallLifeTime; }
    }

    /// <summary>
    /// Gets min spawn seconds
    /// </summary>
    public static float MinSpawnSeconds
    {
        get { return configurationData.MinSpawnSeconds; }
    }

    /// <summary>
    /// Gets max spawn seconds
    /// </summary>
    public static float MaxSpawnSeconds
    {
        get { return configurationData.MaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets standard block points
    /// </summary>
    public static float StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    /// <summary>
    /// Gets bonus block points
    /// </summary>
    public static float BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    /// <summary>
    /// Gets pickup block points
    /// </summary>
    public static float PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    /// <summary>
    /// Gets standard BlockProbabilities
    /// </summary>
    public static float StandardBlockProbabilities
    {
        get { return configurationData.StandardBlockProbabilities; }
    }

    /// <summary>
    /// Gets bonus BlockProbabilities
    /// </summary>
    public static float BonusBlockProbabilities
    {
        get { return configurationData.BonusBlockProbabilities; }
    }

    /// <summary>
    /// Gets Pickup BlockProbabilities
    /// </summary>
    public static float PickupBlockProbabilities
    {
        get { return configurationData.PickupBlockProbabilities; }
    }

    /// <summary>
    /// Gets Number of balls
    /// </summary>
    public static int NumberOfBalls
    {
        get { return configurationData.NumberOfBalls; }
    }

    /// <summary>
    /// Gets freezer effect duration
    /// </summary>
    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }

    /// <summary>
    /// Gets speedup effect duration
    /// </summary>
    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }

    /// <summary>
    /// Gets speedup factor
    /// </summary>
    public static float SpeedupFactor
    {
        get { return configurationData.SpeedupFactor; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }

}
