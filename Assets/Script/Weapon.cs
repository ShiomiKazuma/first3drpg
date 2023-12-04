using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject _effect;
    [SerializeField] float _effectTime = 3.0f;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _hitSE;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            var effect = Instantiate(_effect);
            _audioSource.PlayOneShot(_hitSE);
            effect.transform.position = other.transform.position;
            //Instantiate(_effect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(effect, _effectTime);
        }
    }
}
