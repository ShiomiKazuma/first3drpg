using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _time = 3.0f;
    [SerializeField] float _enemySpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, _time);
    }

    // Update is called once per frame
    void Update()
    {
        var speed = Vector3.zero;
        speed.z = _enemySpeed;

        this.transform.Translate(speed);
    }
}
