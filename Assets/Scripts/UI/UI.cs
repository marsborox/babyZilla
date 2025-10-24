using UnityEngine;
using UnityEngine.UI;
using System;

public class UI : MonoBehaviour
{

    public Button logButton;
    public Button openUI_Button;
    public GameObject testObject;

    public Color32 pressedColor;
    public Color32 unpressedColor;

    private void Start()
    {
        pressedColor = new Color32(200, 200, 200, 255);
        unpressedColor = new Color32(255, 255, 255, 255);
        InitiateButton(logButton, TestMethod);
        InitiateButton(openUI_Button, ButtonGUIMethod,testObject);
        
    }
    public void ButtonGUIMethod( Button button, GameObject gUIPanel)
    {//turn off/on uiMenuPanel
        if (!gUIPanel.activeSelf)
        {
            //tempBoolean = true;
            MySoundManager.instance.ButtonClick();
            //button.GetComponent<Image>().color = pressedColor;
            gUIPanel.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            MySoundManager.instance.ButtonClick();
            //button.GetComponent<Image>().color = unpressedColor;
            gUIPanel.SetActive(false);
        }
    }

    void TestMethod()
    { 
    
    }

    public void InitiateButton(Button button, Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
            MySoundManager.instance.ButtonClick();
        });
        //boolUI = false;
    }
    /*
    public void InitiateButton<T>(Button button, Action<T> method, T value)
    {
        button.onClick.AddListener(delegate
        {
            method(value);
            //SoundManager.instance.Click();
        });
        //boolUI = false;
    }*/

    public void InitiateButton<T>(Button button, Action<Button, T> method, Button button1, T value)
    {//should be way to make this better
        button.onClick.AddListener(delegate
        {
            method(button1, value);
            //SoundManager.instance.Click();
        });
        //boolUI = false;
    }
    public void InitiateButton<T>(Button button, Action<Button, T> method, T value)
    {//should be way to make this better
        button.onClick.AddListener(delegate
        {
            method(button, value);
            //SoundManager.instance.Click();
        });
        //boolUI = false;
    }
    public void InitiateButton<T>(Button button, Action<T, T> method, T value, T value2)
    {
        button.onClick.AddListener(delegate
        {
            method(value, value2);
            //SoundManager.instance.Click();
        });
        //boolUI = false;
    }
}
