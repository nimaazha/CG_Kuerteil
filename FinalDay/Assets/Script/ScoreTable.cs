using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{

    /*
     * this is a simple class to count the scores for the player
     * the scores is public and can be overwritten with the short/longrange rockets as they are exploded
     */

    Text text;

    public static int scores;

    void Awake()
    {
        text = GetComponent<Text>();
        scores = 0;
    }

    void Update()
    {
        text.text = "Score: " + scores; 
    }

}
