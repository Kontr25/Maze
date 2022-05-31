using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected float _damageInterval;
    [SerializeField] protected float _damage;
    private bool _canDamage = false;

    protected void StartPeriodicDamage(Character player)
    {
        _canDamage = true;
        StartCoroutine(Damager(_damageInterval, player));
    }

    protected void StopPeriodicDamage()
    {
        _canDamage = false;
        StopAllCoroutines();
    }

    private IEnumerator Damager(float interval, Character player)
    {
        WaitForSeconds _wait = new WaitForSeconds(interval);
        while (_canDamage && player != null)
        {
            player.OnDamaged(_damage);
            yield return _wait;
        }
    }
}
