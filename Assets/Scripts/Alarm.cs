using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _bottomLimit = 0.01f;
    private bool _isThiefInside;

    private void Update()
    {
        if (_isThiefInside)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 1, Time.deltaTime);

        }
        else if (_audioSource.isPlaying)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0, Time.deltaTime);

            if (_audioSource.volume <= _bottomLimit)
            {
                _audioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInside = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _isThiefInside = false;
        }
    }
}
