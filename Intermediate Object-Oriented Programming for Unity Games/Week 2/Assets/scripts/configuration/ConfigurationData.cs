using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;
    float ballLifeTime = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    float standardBlockPoints = 1;
    float bonusBlockPoints = 2;
    float pickupBlockPoints = 3;
    float standardBlockProbabilities = 1;
    float bonusBlockProbabilities = 2;
    float pickupBlockProbabilities = 3;
    int numberOfBalls = 10;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    /// <summary>
    /// get the ball lifetime 
    /// </summary>
    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    /// <summary>
    /// get min spawn seconds
    /// </summary>
    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    /// <summary>
    /// get max spawn seconds
    /// </summary>
    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    /// <summary>
    /// get standard block points
    /// </summary>
    public float StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    /// <summary>
    /// get bonus block points
    /// </summary>
    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    /// <summary>
    /// get pickup block points
    /// </summary>
    public float PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    /// <summary>
    /// get standard BlockProbabilities
    /// </summary>
    public float StandardBlockProbabilities
    {
        get { return standardBlockProbabilities; }
    }

    /// <summary>
    /// get bonus BlockProbabilities
    /// </summary>
    public float BonusBlockProbabilities
    {
        get { return bonusBlockProbabilities; }
    }

    /// <summary>
    /// get pickup BlockProbabilities
    /// </summary>
    public float PickupBlockProbabilities
    {
        get { return pickupBlockProbabilities; }
    }

    /// <summary>
    /// get number of balls
    /// </summary>
    public int NumberOfBalls
    {
        get { return numberOfBalls; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {               
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }


    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(','); 
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        standardBlockPoints = float.Parse(values[5]);
        bonusBlockPoints = float.Parse(values[6]);
        pickupBlockPoints = float.Parse(values[7]);
        standardBlockProbabilities = float.Parse(values[8]);
        bonusBlockProbabilities = float.Parse(values[9]);
        pickupBlockProbabilities = float.Parse(values[10]);
        numberOfBalls = int.Parse(values[11]);

    }

    #endregion
}
