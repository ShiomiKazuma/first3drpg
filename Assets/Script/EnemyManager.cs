using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] _enemy;
    [SerializeField, Header("ìoò^ÇµÇΩÉGÉlÉ~Å[ÇªÇÍÇºÇÍÇÃï¶Ç≠à íu")] Transform[] _enemyPlace;
    [SerializeField, Header("ìGÇÃï¶Ç≠ä‘äu")] float _enemySponInterval = 3.0f;
    float _timeCount;
    [SerializeField] int _maxCount;
    int _currentCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_maxCount <= _currentCount)
            return;

        _timeCount += Time.deltaTime;
        if(_timeCount > _enemySponInterval)
        {
            for (int i = 0; i < _enemy.Length; i++)
            {
                Instantiate(_enemy[i], _enemyPlace[i].position, Quaternion.identity);
                _currentCount++;
            }
            _timeCount = 0;
        }
    }
}
