using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private float _maxStamina;
    [SerializeField] private float _staminaRecoveryRate;
    [SerializeField] private float _staminaRecoverCooldown;
    private float _actualStamina;
    private float _lastTimeUsed;

    internal float ActualStamina => _actualStamina;

    private void Start()
    {
        _actualStamina = _maxStamina;
    }
    private void Update()
    {
        RecoverStamina();
    }
    private void RecoverStamina()
    {
        if (Time.time > _lastTimeUsed + _staminaRecoverCooldown)
        {
            if(_actualStamina < _maxStamina)
            {
                _actualStamina += _staminaRecoveryRate;
            }
            if(_actualStamina > _maxStamina)
            {
                _actualStamina = _maxStamina;
            }
        }
    }
    internal void ConsumeStamina(float amount)
    {
        _lastTimeUsed = Time.time;
        _actualStamina -= amount;
        if(_actualStamina < 0)
        {
            Debug.LogWarning("Stamina is negative, this should not happen");
        }
    }
    internal bool IsThereEnoughStamina(float amount)
    {
        if(_actualStamina >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
