using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class KeyboardMover : Character
{
    private float _horizontal;
    private float _vertical;

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Move(_horizontal, _vertical);
    }
}
