using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Player;

public class Key : MonoBehaviour
{
    [SerializeField] private Transform _key;

    private void Start()
    {
        StartCoroutine(Ripple());
    }

    private IEnumerator Ripple()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while (true)
        {
            _key.DOMoveY(1.1f, 0.9f, false);
            yield return wait;
            _key.DOMoveY(0.8f, 0.9f, false);
            yield return wait;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Character character))
        {
            character.GetKey();
            transform.DOScale(Vector3.zero, 0.5f);
            Destroy(gameObject, 0.5f);
        }
    }
}
