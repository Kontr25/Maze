using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class HillBonus : PositiveBonus, IHealler
{
    [SerializeField] protected float _bonusHP;

    public void Hill(float HealtPoint)
    {
        _character.Hill(HealtPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Character character))
        {
            _character = character;
            Hill(_bonusHP);
            Explosion();
        }
    }
}
