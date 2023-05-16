using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIChargeBarScript : MonoBehaviour
{
    private UIChargeBarInputs _uiInputs;
    private Slider _slider;
    private bool _isCharging = false;

    void Start()
    {
        _slider = GetComponent<Slider>();

        _uiInputs = new UIChargeBarInputs();
        _uiInputs.Enable();
        _uiInputs.UIChargeBar.Charge.started += Charge_started;
        _uiInputs.UIChargeBar.Charge.canceled += Charge_canceled;
    }

    private void Charge_canceled(InputAction.CallbackContext context)
    {
        _isCharging = false;
        Debug.Log("Charging Complete");
    }

    private void Charge_started(InputAction.CallbackContext context)
    {
        _isCharging = true;
        StartCoroutine(ChargeBarRoutine());
    }

    IEnumerator ChargeBarRoutine()
    {
        while(_isCharging == true)
        {
            _slider.value += (1.0f * Time.deltaTime)/5;
            yield return null;
        }
        while (_slider.value > 0)
        {
            _slider.value -= 1.0f * Time.deltaTime;
            yield return null;
        }
    }
}
