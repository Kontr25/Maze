using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class NegativeBonus : MonoBehaviour
{
    [SerializeField] protected float _bonusDamage;
    [SerializeField] protected ParticleSystem _explosion;
    [SerializeField] protected GameObject _bombModel;
    [SerializeField] protected Collider _bombCollider;
    protected Character _character;
    protected bool _canDamage = false;

    protected void Explosion()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        _bombModel.SetActive(false);
        _bombCollider.enabled = false;
        Destroy(gameObject, 10f);
    }
}
