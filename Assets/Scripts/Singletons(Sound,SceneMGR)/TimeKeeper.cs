using UnityEngine;

public class TimeKeeper : Singleton<TimeKeeper>

{

    public static new TimeKeeper instance => SingletonPersistent<TimeKeeper>.instance;

    public float timeBudget;
    public float timeRemaining;

    void Start()
    {
        timeRemaining = timeBudget;
    }
    void Update()
    {
        TimeTracking();
    }
    void TimeTracking()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {

            MySceneManager.instance.OpenPostGameScene();
        }
    }
}
