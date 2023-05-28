using Game.Scripts.LiveObjects;
using Game.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrameworkInputManager : MonoBehaviour
{
    private FrameworkInputs _inputs;
    private Player _player;
    private Drone _drone;
    private Forklift _forklift;
    private Crate _crate;

    void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        _drone = GameObject.FindObjectOfType<Drone>();
        _forklift = GameObject.FindObjectOfType<Forklift>();
        /*
        _player = GameObject.Find("Player").GetComponent<Player>();
        _drone = GameObject.Find("Drone").GetComponent<Drone>();
        _forklift = GameObject.Find("Fork_Lift").GetComponent<Forklift>();
        */

        _inputs = new FrameworkInputs();

        if(_inputs != null)
        {
            Debug.Log("_inputs != null");
            _inputs.Player.Enable();
            _inputs.Drone.Disable();
            _inputs.Forklift.Disable();
            _inputs.Hacking.Disable();
        }

        _inputs.Player.Movement.started += PlayerMovement_started;
        _inputs.Player.Movement.canceled += PlayerMovement_canceled;
        _inputs.Player.Rotation.started += PlayerRotation_started;
        _inputs.Player.Rotation.canceled += PlayerRotation_canceled;

        _inputs.Drone.MoveForwardBack.performed += DroneMoveForwardBack_performed;
        _inputs.Drone.MoveForwardBack.canceled += DroneMoveForwardBack_canceled;
        _inputs.Drone.Rotate.performed += DroneRotate_performed;
        _inputs.Drone.Rotate.canceled += DroneRotate_canceled;
        _inputs.Drone.Elevation.performed += DroneElevation_performed;
        _inputs.Drone.Elevation.canceled += DroneElevation_canceled;

        _inputs.Forklift.Movement.performed += ForkliftMovement_performed1;
        _inputs.Forklift.Movement.canceled += ForkliftMovement_canceled;
        _inputs.Forklift.Rotation.performed += ForkliftRotation_performed;
        _inputs.Forklift.ForksRaiseLower.performed += ForksRaiseLower_performed;

        
    }

    private void Punch_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Punch Cancelled");
        _crate.SetPunchCondition(false);
    }

    private void Punch_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Punch Started");
        _crate.SetPunchCondition(true);
    }

    //Punch
    private void Punch_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Punch Performed");
        _crate.SuperPunch();
    }

    //Forklift
    private void ForkliftMovement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var movementValues = _inputs.Forklift.Movement.ReadValue<float>();
        _forklift.ForkliftMoveValues(movementValues);
    }
    
    private void ForksRaiseLower_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var forkLiftLiftValues = _inputs.Forklift.ForksRaiseLower.ReadValue<float>();
        _forklift.LiftValues(forkLiftLiftValues);
    }

    private void ForkliftRotation_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var forkliftRotation = _inputs.Forklift.Rotation.ReadValue<float>();
        _forklift.ForkliftRotation(forkliftRotation);
    }

    private void ForkliftMovement_performed1(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var movementValues = _inputs.Forklift.Movement.ReadValue<float>();
        _forklift.ForkliftMoveValues(movementValues);
    }

    //Drone
    private void DroneElevation_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var droneLiftValue = _inputs.Drone.Elevation.ReadValue<float>();
        _drone.LiftDrone(droneLiftValue);
    }
    
    private void DroneElevation_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var droneLiftValue = _inputs.Drone.Elevation.ReadValue<float>();
        _drone.LiftDrone(droneLiftValue);
    }
    
    private void DroneRotate_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var droneRotation = _inputs.Drone.Rotate.ReadValue<float>();
        _drone.RotateDrone(droneRotation);
    }

    private void DroneRotate_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var droneRotation = _inputs.Drone.Rotate.ReadValue<float>();
        _drone.RotateDrone(droneRotation);
    }
    
    private void DroneMoveForwardBack_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //var droneMovementValue = _inputs.Drone.MoveForwardBack.ReadValue<float>();
        //_drone.MoveDrone(droneMovementValue);
    }

    private void DroneMoveForwardBack_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var droneMovementValue = _inputs.Drone.MoveForwardBack.ReadValue<float>();
        _drone.MoveDrone(droneMovementValue);
    }

    //Player
    private void PlayerMovement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var playerMovement = _inputs.Player.Movement.ReadValue<float>();
        _player.MoveOurPlayer(0f);
    }

    private void PlayerMovement_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var playerMovement = _inputs.Player.Movement.ReadValue<float>();
        _player.MoveOurPlayer(playerMovement);
        //Debug.Log(playerMovement);        
    }
    
    private void PlayerRotation_canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _player.RotateOurPlayer(0f);
    }

    private void PlayerRotation_started(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        var playerRotation = _inputs.Player.Rotation.ReadValue<float>();
        _player.RotateOurPlayer(playerRotation);
        //Debug.Log(playerRotation);
    }


    //Action Maps
    public void EnablePlayerActionMap()
    {
        _inputs.Player.Enable();
        _inputs.Drone.Disable();
        _inputs.Forklift.Disable();
        _inputs.Hacking.Disable();
    }

    public void EnableDroneActionMap()
    {
        _inputs.Player.Disable();
        _inputs.Drone.Enable();
        _inputs.Forklift.Disable();
        _inputs.Hacking.Disable();
    }

    public void EnableForkliftActionMap()
    {
        _inputs.Forklift.Enable();
        _inputs.Player.Disable();
        _inputs.Drone.Disable();
        _inputs.Hacking.Disable();
    }

    public void EnableLaptopActionMap()
    {
        _inputs.Hacking.Enable();
        _inputs.Player.Disable();
        _inputs.Drone.Disable();
        _inputs.Forklift.Disable();
    }    
}
