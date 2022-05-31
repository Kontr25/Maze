using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class DamageZone : Obstacle
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Character player))
        {
            StartPeriodicDamage(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character player))
        {
            StopPeriodicDamage();
        }
    }
}
