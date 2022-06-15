using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using DG.Tweening;

public class PositiveBonus : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _explosion;
    [SerializeField] protected GameObject _bonusModel;
    [SerializeField] protected Collider _bonusCollider;
    protected Character _character;

    private void Start()
    {
        StartCoroutine(Levitation());
    }

    private IEnumerator Levitation()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            transform.DOMoveY(2, 1f, false);
            yield return wait;
            transform.DOMoveY(1, 1f, false);
            yield return wait;
        }
    }

    protected void Explosion()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        _bonusModel.SetActive(false);
        _bonusCollider.enabled = false;
        Destroy(gameObject, 10f);
    }
}
