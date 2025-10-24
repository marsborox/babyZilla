using UnityEngine;
using UnityEngine.InputSystem;

public class Pressed : MonoBehaviour
{
    public bool isPressed = false;

    public PlayerInput playerInput;
    public InputAction action;
    public Pacicka pacicka;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();//can be left public field and drag and dropped
        //instead of this
        action = playerInput.actions["Attack"];
    }
    private void Update()
    {
        DoStuff();
    }
    private void OnEnable()
    {
        action.started += ctx => StartPressed();
        action.canceled += ctx => StopPressed();
    }
    private void OnDisable()
    {
        action.started -= ctx => StartPressed();
        action.canceled -= ctx => StopPressed();
    }
    private void StartPressed()
    {
        isPressed=true;
    }
    private void StopPressed()
    {
        isPressed=false;
    }
    private void DoStuff()
    {
        pacicka.Stomp(isPressed);

    }
}
