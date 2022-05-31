using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected Rigidbody _playerRigidbody;
        [SerializeField] protected float _speed;
        [SerializeField] protected float _health;
        [SerializeField] protected GameObject _explosion;
        [SerializeField] protected ParticleSystem _damageEffect;
        [SerializeField] protected GameObject[] _blobPrefab;

        protected void Move(float horizontal, float vertical)
        {
            _playerRigidbody.velocity = new Vector3(horizontal * _speed, _playerRigidbody.velocity.y, vertical * _speed);

            Vector3 _direction = new Vector3(horizontal, 0f, vertical);
            if (_direction != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), Time.deltaTime * 10);
        }

        protected void Speed(int speed)
        {
            _speed = speed;
        }

        public virtual void OnDamaged(float damage)
        {
            _health -= damage;

            StartCoroutine(PunchScale());

            if(_health <= 0)
            {
                Die();
            }
        }

        private IEnumerator PunchScale()
        {
            _playerRigidbody.transform.DOPunchScale(new Vector3(0.3f, -0.6f, 0.3f), 0.5f, 1, 1);
            _damageEffect.Play();

            yield return new WaitForSeconds(0.5f);
            _playerRigidbody.transform.localScale = new Vector3(1, 1, 1);
        }

        protected void Die()
        {
            Instantiate(_explosion, _playerRigidbody.transform.position, Quaternion.identity);
            Instantiate(_blobPrefab[Random.Range(0, 3)], new Vector3(_playerRigidbody.transform.position.x, _playerRigidbody.transform.position.y - 0.49f, _playerRigidbody.transform.position.z), Quaternion.identity);
            Destroy(_playerRigidbody.gameObject);
        }
    }
}


