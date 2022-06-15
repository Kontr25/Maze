using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] private Transform _image;
    [SerializeField] private Transform _button;
    [SerializeField] private Transform _imagePoint;
    [SerializeField] private Transform _buttonPoint;
    [SerializeField] private bool _victory;
    [SerializeField] private CinemachineVirtualCamera _victoryCamera;
    [SerializeField] private CinemachineVirtualCamera _defeatCamera;
    [SerializeField] private GameObject[] _UIElements;

    private void Start()
    {
        if (_victory) GlobalEvent.Victory += Victory;
        else GlobalEvent.Defeat += Defeat;
    }

    private void OnDestroy()
    {
        if (_victory) GlobalEvent.Victory -= Victory;
        else GlobalEvent.Defeat -= Defeat;
    }

    private void Victory()
    {
        _victoryCamera.Priority = 100;
        MoveUI();
    }

    private void Defeat()
    {
        _defeatCamera.Priority = 100;
        MoveUI();
    }

    private void MoveUI()
    {
        for (int i = 0; i < _UIElements.Length; i++)
        {
            _UIElements[i].SetActive(false);
        }
        _image.DOMove(_imagePoint.position, .3f, false);
        _button.DOMove(_buttonPoint.position, .3f, false);
    }
}
