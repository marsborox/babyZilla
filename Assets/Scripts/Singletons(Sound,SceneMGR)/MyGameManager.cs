using UnityEngine;

public class MyGameManager : Singleton<MyGameManager>
{
    public static new MyGameManager instance => Singleton<MyGameManager>.instance;
    public UI pauseMenu;
    protected override void Awake()
    {
        base.Awake();
    }
    public void PauseMenu()
    {
        if (!pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(true);
            MyTimeManager.instance.SetTimeScaleX0();
            //pauseTime
        }
        else
        { 
            ((GamePause_UI)pauseMenu).options_UI.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(false);
            MyTimeManager.instance.SetOriginalTimeScale();
            //unpause Time
        }
    }

}
