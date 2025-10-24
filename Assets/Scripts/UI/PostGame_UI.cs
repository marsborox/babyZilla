using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class PostGame_UI : UI
{
    public Button newGameButton;
    public Button quitToMenuButton;
    public Button qitToWindowsButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI description;

    void Start()
    {
        SetScoreText();
        InitiateButton(newGameButton, MySceneManager.instance.OpenGameScene);
        InitiateButton(quitToMenuButton, MySceneManager.instance.OpenMainMenu);
        InitiateButton(qitToWindowsButton, MySceneManager.instance.QuitToWindows);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetScoreText()
    {
        string scoreValue = "ScoreValue";
        scoreText.text = ScoreKeeper.instance.score.ToString();
    }
}
