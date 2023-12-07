using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _time = 3.0f;
    [SerializeField] float _enemySpeed = 0.5f;
    GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, _time);
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = _enemySpeed;

        if(_target)
        {
            transform.LookAt(_target.transform);
        }
        this.transform.Translate(speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _target = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _target = null;
        }
    }
}
