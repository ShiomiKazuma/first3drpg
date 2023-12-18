using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float _timer = 0;
    [SerializeField] float _changeTime = 10.0f;
    [SerializeField] float _enemySpeed = 0.5f;
    GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = _enemySpeed;
        var rot = transform.eulerAngles;
        if (_target)
        {
            //ターゲットの方に向く
            transform.LookAt(_target.transform);
            rot = transform.eulerAngles;
        }
        else
        {
            _timer += Time.deltaTime;
            if( _timer >= _changeTime)
            {
                //ランダムでうろつく
                var rand = Random.Range(0, 360);
                rot.y = rand;
                _timer = 0;
            }
        }
        rot.x = 0;
        rot.z = 0;
        transform.eulerAngles = rot;
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
