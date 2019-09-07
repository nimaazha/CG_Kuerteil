using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{

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
