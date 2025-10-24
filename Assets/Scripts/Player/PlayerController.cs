using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    //public MyGameManager gameManager;
    public Pacicka pacicka; 
    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void OnJump(InputValue value)
    { 
        Debug.Log("jumped");
    }

    void OnPause()
    {
        MyGameManager.instance.PauseMenu();
    }
    void OnAttack(InputValue inputValue)
    { 
        //pacicka.Stomp(inputValue.isPressed);
    }
}
