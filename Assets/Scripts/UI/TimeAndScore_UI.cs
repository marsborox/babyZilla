using System;
using TMPro;
//using UnityEngine;

public class TimeAndScore_UI : UI
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    private void Start()
    {
        
    }
    private void Update()
    {

        scoreText.text = "Score: " + ScoreKeeper.instance.score.ToString();
        DisplayTime();
    }
    void DisplayTime()
    {
        int displayTime = (int)TimeKeeper.instance.timeRemaining;
        TimeSpan time = TimeSpan.FromSeconds(displayTime);
        timeText.text = time.ToString().Substring(3);
    }
}
