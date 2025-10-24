using UnityEngine;
using UnityEngine.UI;

public class GamePause_UI : UI
{
    [SerializeField] public Button resumeButton;
    [SerializeField] public Button optionsButton;
    [SerializeField] public Button restartButton;
    [SerializeField] public Button quitToMenuButton;
    [SerializeField] public Button quitToWindowsButton;

    public UI options_UI;

    private void Start()
    {
        InitiateButton(resumeButton, ResumeGame);
        InitiateButton(optionsButton,ButtonGUIMethod, options_UI.gameObject);
        InitiateButton(quitToMenuButton, QuitToMenu);
        InitiateButton(quitToWindowsButton, QuitToWindows);
    }
    public void ResumeGame()
    { 
        MyGameManager.instance.PauseMenu();
    }

    public void RestartGame()
    {
        MySceneManager.instance.OpenGameScene();
    }
    public void QuitToMenu()
    {
         MySceneManager.instance.OpenMainMenu();
    }
    public void QuitToWindows()
    {
        MySceneManager.instance.QuitToWindows();
    }
}
