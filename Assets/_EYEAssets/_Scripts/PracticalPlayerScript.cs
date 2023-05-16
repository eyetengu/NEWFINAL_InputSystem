using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticalPlayerScript : MonoBehaviour
{
    [SerializeField]
    private PracticalPlayerPlayer _player;
    private PracticalPlayerInput _playerInput;
    public float speedVar = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PracticalPlayerPlayer>();

        _playerInput = new PracticalPlayerInput();
        _playerInput.Enable();
        _playerInput.Player.PlayerMovement.performed += PlayerMovement_performed;
        _playerInput.Player.PlayerFire.performed += PlayerFire_performed;
    }

    private void PlayerFire_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _player.FireOnMyCommand();
    }

    private void PlayerMovement_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Debug.Log("Player is moving");
    }

    // Update is called once per frame
    void Update()
    {
        var move = _playerInput.Player.PlayerMovement.ReadValue<Vector2>();
        _player.MoveTheDarnPlayer(move);
    }
}
