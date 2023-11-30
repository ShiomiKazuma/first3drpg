using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform _camera;
    [SerializeField, Header("動くスピード")]
    float _moveSpeed = 0.5f;
    [SerializeField, Header("マウス感度")]
    float _mouseMove = 0.5f;
    Vector3 move = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    [SerializeField] Animator _playerAnimator;
    bool _isRun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        Rotation();
        _camera.transform.position = transform.position;
    }

    void Move()
    {
        move = Vector3.zero;
        rotation = Vector3.zero;
        _isRun = false;

        if (Input.GetKey(KeyCode.W))
        {
            rotation.y = 0;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotation.y = 180;
            MoveSet();
        }
        if(Input.GetKey(KeyCode.A))
        {
            rotation.y = -90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation.y = 90;
            MoveSet();
        }
        
        transform.Translate(move);
        _playerAnimator.SetBool("IsRun", _isRun);
    }

    void MoveSet()
    {
        move.z = _moveSpeed;
        transform.eulerAngles = _camera.transform.eulerAngles + rotation;
        _isRun = true;
    }
    void Rotation()
    {
        var speed = Vector3.zero;
        //マウスの入力
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -_mouseMove;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = _mouseMove;
        }
        _camera.transform.eulerAngles += speed;
    }
}
