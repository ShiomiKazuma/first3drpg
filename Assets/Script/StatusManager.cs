using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] GameObject _main;
    [SerializeField] int _currentHp;
    [SerializeField] int _maxHp;
    [SerializeField] GameObject _effect;
    [SerializeField] float _effectTime = 3.0f;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _hitSE;
    [SerializeField] string _tagName;
    [SerializeField] Slider _hpSlider;
    [SerializeField] float _damageInterval = 2.0f;
    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }
    private void Update()
    {
        if(_currentHp <= 0)
        {
            _currentHp = 0;
            var effect = Instantiate(_effect);
            effect.transform.position = transform.position;
            Destroy(effect, _effectTime);
            this.enabled = false;
            Destroy(_main.gameObject);
        }

        float percent = (float)_currentHp / (float)_maxHp;
        _hpSlider.value = percent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _tagName)
        {
            Damage();
            _collider.enabled = false;
            Invoke("ColliderReset", _damageInterval);
        }
    }

    void Damage()
    {
        _audioSource.PlayOneShot(_hitSE);
        _currentHp--;
    }

    void ColliderReset()
    {
        _collider.enabled = true;
    }
}
