using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPartical : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    private void Start()
    {
    }

    private void Update()
    {

        Debug.Log(_particleSystem.isPlaying);
    }
}
