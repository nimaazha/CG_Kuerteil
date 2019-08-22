using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{

    int scores;

    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Scores: " + scores.ToString();
    }

    public void HitScoreboard(int scoreSent)
    {
        scores += scoreSent;
        scoreText.text = "Scores: " + scores.ToString();
    }
}
