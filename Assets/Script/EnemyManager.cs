using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    [SerializeField, Header("登録したエネミーそれぞれの沸く位置")] Transform[] _enemyPlace;
    [SerializeField, Header("敵の沸く間隔")] float _enemySponInterval = 3.0f;
    float _timeCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeCount += Time.deltaTime;
        if(_timeCount > _enemySponInterval)
        {
            for (int i = 0; i < _enemy.Length; i++)
            {
                Instantiate(_enemy[i], _enemyPlace[i].position, Quaternion.identity);
                _timeCount = 0;
            }
        }
    }
}
