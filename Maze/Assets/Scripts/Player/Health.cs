using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _bar;

    public void UpdateHealthBar(float health)
    {
        _bar.fillAmount = health / 10;
    }
}
