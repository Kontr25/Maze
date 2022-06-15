using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Mover : Character
{
    private bool _keybord;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private DynamicJoystick _joystick;

    private void FixedUpdate()
    {
        if (!_keybord)
        {
            Move(_joystick.Horizontal, _joystick.Vertical);
        }
        else
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            Move(_horizontal, _vertical);
        }
    }

    public void EnableKeyboard(bool value)
    {
        _keybord = value;
    }
}
