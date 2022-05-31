using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class JoystickMover : Character
{
    [SerializeField] private DynamicJoystick _joystick;

    private void FixedUpdate()
    {
        Move(_joystick.Horizontal, _joystick.Vertical);
    }
}
