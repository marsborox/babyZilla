using UnityEngine;
using UnityEngine.UI;

public class Credits_UI : UI
{
    public Button closeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitiateButton(closeButton,ButtonGUIMethod,this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
