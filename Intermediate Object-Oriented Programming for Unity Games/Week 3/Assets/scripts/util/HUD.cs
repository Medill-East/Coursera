using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// class for hud
/// </summary>
public class HUD : MonoBehaviour {

    #region fields

    static Text scoreText;
    static float score = 0;

    static Text ballsLeftText;
    static int ballsLeft = 10;

    #endregion


    // Use this for initialization
    void Start() {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = scoreText.text + score.ToString();
        Debug.Log(score.ToString());

        ballsLeft = ConfigurationUtils.NumberOfBalls;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
        ballsLeftText.text = ballsLeftText.text + ballsLeft.ToString();
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddScore(float inputPointsOfBlock)
    {
        score += inputPointsOfBlock;
        scoreText.text = "Score:";
        scoreText.text = scoreText.text + score.ToString();
    }

    public static void ShowLeftBall()
    {
        ballsLeft -= 1;
        ballsLeftText.text = "Balls Left:";
        ballsLeftText.text = ballsLeftText.text + ballsLeft.ToString();
        Debug.Log(ballsLeft.ToString());
    }
}
