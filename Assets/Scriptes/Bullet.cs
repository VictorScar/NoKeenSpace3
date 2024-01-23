using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Rigidbody _rb;

    IEnumerator Start()
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
        Destroy(gameObject);
    }


}
