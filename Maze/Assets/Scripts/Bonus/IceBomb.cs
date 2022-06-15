using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using static UnityEngine.Debug;

public class IceBomb : NegativeBonus, ISpeedChanging, IDamager
{
    public void ChangeSpeed(float speed)
    {
        _character.Speed(speed);
    }

    public void TakeDamage(float damage)
    {
        Explosion();
        _character.OnDamaged(damage);
        StartCoroutine(Freezing());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Character character))
        {
            _character = character;
            TakeDamage(_bonusDamage);
        }
    }

    private IEnumerator Freezing()
    {
        Log("Freezing");
        ChangeSpeed(1);
        yield return new WaitForSeconds(2f);
        ChangeSpeed(5);
    }
}
