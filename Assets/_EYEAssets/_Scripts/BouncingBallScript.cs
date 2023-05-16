using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BouncingBallScript : MonoBehaviour
{
    private BouncingBallInputs _ballInput;
    private float bounceStart;   
    public float forceAdded = 200;

    private Rigidbody _rb;
    private bool isBallBouncing;
    private bool isGrounded;

    void Start()
    {
        _ballInput = new BouncingBallInputs();
        _ballInput.Ball.Enable();
        _ballInput.Ball.Bounce.performed += Bounce_performed;
        _ballInput.Ball.Bounce.canceled += Bounce_canceled;
        _ballInput.Ball.Bounce.started += Bounce_started;

        _rb = GetComponent<Rigidbody>();
    }

    private void Bounce_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        bounceStart = _ballInput.Ball.Bounce.ReadValue<float>();
        isBallBouncing = false;
    }

    private void Bounce_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(isBallBouncing == false && isGrounded == true)
        {
            isBallBouncing = true;
            isGrounded = false;

            float bounceDuration = (float)context.duration;
            Debug.Log(bounceDuration);
            forceAdded = 800f * bounceDuration;
            if(bounceDuration> 800)
            {
                bounceDuration = 800;
            }
            _rb.AddForce(transform.up * forceAdded);
            forceAdded = 200;
        }
    }

    private void Bounce_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isBallBouncing == false && isGrounded == true)
        {
            isBallBouncing = true;
            isGrounded= false;

            forceAdded = 800;
            Debug.Log("SuperBounce" + context);
            _rb.AddForce(transform.up * forceAdded);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < .6)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
