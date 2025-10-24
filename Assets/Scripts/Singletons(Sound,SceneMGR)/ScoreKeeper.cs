using TMPro;
using UnityEngine;

public class ScoreKeeper : SingletonPersistent<ScoreKeeper>
{
    public static new ScoreKeeper instance => SingletonPersistent<ScoreKeeper>.instance;

    public float timeBudget;
    public float timeRemaining;
    public float score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetScore();
    }
    
    // Update is called once per frame
    void Update()
    {
        //TimeTracking();
    }
    void TimeTracking()
    { 
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0) 
        {
            
            MySceneManager.instance.OpenPostGameScene();
        }
    }
    public void ResetScore()
    { 
        //timeRemaining = timeBudget;
        score = 0;
    }
    public void AddScore(int inputScore)
    {
        score += inputScore;
    }
}
