using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //get a reference and start an instance of our input actions
    //enable input action map for dog
    //register perform functions

    private PlayerInputActions _input;

    private void Start()
    {
        _input = new PlayerInputActions();
        _input.Dog.Enable();
        _input.Dog.Bark.performed += Bark_performed;
        _input.Dog.Bark.canceled += Bark_canceled;
        _input.Dog.Walk.performed += Walk_performed;
        _input.Dog.Run.performed += Run_performed;
        _input.Dog.Die.performed += Die_performed;
    }

    private void Die_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Dog has died..." + context);
    }

    private void Run_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Running..." + context);
    }

    private void Walk_performed(InputAction.CallbackContext context)
    {
        var move = _input.Dog.Walk.ReadValue<Vector2>();
        Debug.Log("Walking...Dog..." + move);
    }

    private void Bark_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Done Barking... " + context);    
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Barking..." + context);
    }
}
