using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class SpeedBoostBonus : PositiveBonus, ISpeedChanging
{
    public void ChangeSpeed(float speed)
    {
        _character.Speed(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Character character))
        {
            _character = character;
            Explosion();
            StartCoroutine(Boost());
        }
    }

    private IEnumerator Boost()
    {
        ChangeSpeed(20);
        yield return new WaitForSeconds(4f);
        ChangeSpeed(10);
    }
}
