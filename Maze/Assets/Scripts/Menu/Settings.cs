using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _startMenu;

    public void JoystickEnable()
    {
        _joystick.SetActive(true);
        _mover.EnableKeyboard(false);
        CloseWindow();
    }

    public void KeyboardEnable()
    {
        _joystick.SetActive(false);
        _mover.EnableKeyboard(true);
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

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
