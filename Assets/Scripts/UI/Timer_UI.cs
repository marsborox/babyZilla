using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class Timer_UI : UI
{
    public TextMeshProUGUI timeText;

    public Button timeX1Button;
    public Button timeX2Button;
    public Button timeX5Button;
    private void Start()
    {
        InitiateButton(timeX1Button, MyTimeManager.instance.SetTimeScaleX1);
        InitiateButton(timeX2Button, MyTimeManager.instance.SetTimeScaleX2);
        InitiateButton(timeX5Button, MyTimeManager.instance.SetTimeScaleX5);
    }
    void Update()
    {
        SetTimetext();
    }
    void SetTimetext()
    {
        timeText.text = ((int)MyTimeManager.instance.timeElapsed).ToString();
    }
}
