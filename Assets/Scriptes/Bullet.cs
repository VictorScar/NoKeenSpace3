using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private Rigidbody _rb;

    private Character _owner;


    public void Init(Character owner)
    {
        _owner = owner;
        StartCoroutine(ProjectileFly());
    }

    private IEnumerator ProjectileFly()
    {
        var remainingTime = 0f;

        while (remainingTime < _lifeTime)
        {
            _rb.velocity = transform.forward * _speed * Time.fixedDeltaTime;
            remainingTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            return;
        }

        var character = other.GetComponent<Character>();

        if (character != null)
        {
            character.GetDamage(_damage, _owner);
        }

        Destroy(gameObject);
    }


}
