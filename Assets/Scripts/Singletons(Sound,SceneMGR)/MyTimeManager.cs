using UnityEngine;

public class MyTimeManager : Singleton<MyTimeManager>
{
    public static new MyTimeManager instance=>Singleton<MyTimeManager>.instance;
    public float timeScale = 1f;
    public float timeElapsed = 0f;
    private void Start()
    {
        SetTimeScaleX1();
    }
    private void Update()
    {
        TimeCounting();
    }
    public void SetTimeScaleX0() 
    { 
        timeScale = Time.timeScale;
        Time.timeScale = 0f; 
    }
    public void SetTimeScaleX1() 
    {
        timeScale = Time.timeScale;
        Time.timeScale = 1f;
    }
    public void SetTimeScaleX2() 
    {
        timeScale = Time.timeScale;
        Time.timeScale = 2f;
    }
    public void SetTimeScaleX5() 
    { 
        timeScale = Time.timeScale;
        Time.timeScale = 5f;
    }
    public void SetTimeScaleX10() 
    {
        timeScale = Time.timeScale;
        Time.timeScale = 10f;
    }

    public void SetOriginalTimeScale()
    {
        Time.timeScale = timeScale;
    }
    private void TimeCounting()
    { 
        timeElapsed += Time.deltaTime;
    }
}
