using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class FireBomb : NegativeBonus, IDamager
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            _character = character;
            TakeDamage(_bonusDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        Explosion();

        _character.OnDamaged(_bonusDamage);
    }
}
