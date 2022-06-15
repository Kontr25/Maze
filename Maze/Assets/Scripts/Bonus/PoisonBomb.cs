using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PoisonBomb : NegativeBonus, IDamager, ISpeedChanging
{
    private int _damageCount;

    [SerializeField] protected float _damageInterval;

    public void TakeDamage(float damage)
    {
        Explosion();
        _canDamage = true;
        StartCoroutine(Damager(_damageInterval, _character));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Character character))
        {
            _character = character;
            TakeDamage(_bonusDamage);
        }
    }

    private IEnumerator Damager(float interval, Character player)
    {
        WaitForSeconds _wait = new WaitForSeconds(interval);

        ChangeSpeed(2);

        while (_canDamage && player != null && _damageCount < 3)
        {
            player.OnDamaged(_bonusDamage);
            _damageCount++;
            yield return _wait;
        }

        ChangeSpeed(5);
    }

    public void ChangeSpeed(float speed)
    {
        _character.Speed(speed);
    }
}
