using Game.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameworkInputManager : MonoBehaviour
{
    private FrameworkInputs _inputs;
    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _inputs = new FrameworkInputs();
        _inputs.Player.Enable();

        _inputs.Player.Movement.performed += PlayerMovement_performed;
        _inputs.Player.Movement.started += PlayerMovement_started;
        _inputs.Player.Movement.canceled += PlayerMovement_canceled;
        _inputs.Player.Rotation.started += PlayerRotation_started;
        _inputs.Player.Rotation.canceled += PlayerRotation_canceled;

        _inputs.Drone.MoveForwardBack.performed += MoveForwardBack_performed;
        _inputs.Drone.Rotate.performed += Rotate_performed;
        _inputs.Drone.Elevation.performed += Elevation_performed;

        _inputs.Forklift.Movement.performed += Movement_performed1;
        _inputs.Forklift.ForksRaiseLower.performed += ForksRaiseLower_performed;

        _inputs.Melee.Punch.performed += Punch_performed;
    }

    private void Punch_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }

    private void ForksRaiseLower_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }

    private void Movement_performed1(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }

    private void Elevation_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }

    private void Rotate_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }

    private void MoveForwardBack_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }

    private void PlayerMovement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var playerMovement = _inputs.Player.Movement.ReadValue<float>();
        _player.MoveOurPlayer(0f);
    }

    private void PlayerMovement_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var playerMovement = _inputs.Player.Movement.ReadValue<float>();
        _player.MoveOurPlayer(playerMovement);
        Debug.Log(playerMovement);
        
    }

    private void PlayerMovement_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
    }
    private void PlayerRotation_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _player.RotateOurPlayer(0f);
    }

    private void PlayerRotation_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var playerRotation = _inputs.Player.Rotation.ReadValue<float>();
        _player.RotateOurPlayer(playerRotation);
        Debug.Log(playerRotation);
    }


}
