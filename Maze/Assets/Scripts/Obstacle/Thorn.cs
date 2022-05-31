using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Thorn : Obstacle
{
    [SerializeField] private Rigidbody[] _thornElement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character player))
        {
            ExplosionThorn();
            StartPeriodicDamage(player);
            DestroyThorn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character player))
        {
            StopPeriodicDamage();
        }
    }

    private void ExplosionThorn()
    {
        for (int i = 0; i < _thornElement.Length; i++)
        {
            _thornElement[i].isKinematic = false;
            _thornElement[i].AddExplosionForce(400, new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z), 50f);
            _thornElement[i].angularVelocity = new Vector3(1, 1, 1);
        }
    }
    private void DestroyThorn()
    {
        Destroy(gameObject, 4f);
    }
}
