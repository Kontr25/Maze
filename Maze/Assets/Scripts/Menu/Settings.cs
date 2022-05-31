using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Settings : MonoBehaviour
{
    [SerializeField] private JoystickMover _joystickMover;
    [SerializeField] private KeyboardMover _keyboardMover;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _startMenu;

    public void JoystickEnable()
    {
        _joystick.SetActive(true);
        _joystickMover.enabled = true;
        _keyboardMover.enabled = false;
        CloseWindow();
    }

    public void KeyboardEnable()
    {
        _joystick.SetActive(false);
        _keyboardMover.enabled = true;
        _joystickMover.enabled = false;
        CloseWindow();
    }

    public void CloseWindow()
    {
        _startMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        _startMenu.SetActive(true);
    }
}
