using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class MetallicBall : Character
{
    [SerializeField] private float _armor;

    public override void OnDamaged(float damage)
    {
        damage /= _armor;

        base.OnDamaged(damage);
    }
}
