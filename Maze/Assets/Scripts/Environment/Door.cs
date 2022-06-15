using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _padlock;
    [SerializeField] private GameObject _padlockFragmentsParent;
    [SerializeField] private Rigidbody[] _doorRigidbodies;
    [SerializeField] private Rigidbody[] _padlockFragments;
    [SerializeField] private Renderer[] _fragmentColor;
    [SerializeField] private Collider _thisDoorCollider;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent (out Character character))
        {
            if (character.HasKey()) OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Destroy(_padlock);
        _padlockFragmentsParent.SetActive(true);
        for (int i = 0; i < _padlockFragments.Length; i++)
        {
            _padlockFragments[i].isKinematic = false;
            _padlockFragments[i].AddExplosionForce(300, transform.position, 100);
            _fragmentColor[i].material.DOFade(0, 6f);
            Destroy(_padlockFragments[i].gameObject, 6f);
        }
        for (int i = 0; i < _doorRigidbodies.Length; i++)
        {
            _doorRigidbodies[i].isKinematic = false;
        }
        _thisDoorCollider.enabled = false;
    }
}
