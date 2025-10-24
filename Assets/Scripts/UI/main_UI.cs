using UnityEngine;
using UnityEngine.UI;

public class Main_UI : UI
{
    public Button uiButton;
    public Button printToLogButton;
    public Button postGame;
    public GameObject testUi;
    
    private void Start()
    {
        InitiateButton(printToLogButton, PrintLog);
        InitiateButton(uiButton,ButtonGUIMethod, testUi);
        InitiateButton(postGame,MySceneManager.instance.OpenPostGameScene);
    }
    void PrintLog()
    {
        Debug.Log("Logging");
    }
    
}
