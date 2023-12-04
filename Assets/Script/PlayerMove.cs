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
    [SerializeField] Collider _weaponCollider;
    bool _canMove = true;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _attackSE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        Attack();
        _camera.transform.position = transform.position;
    }

    void Move()
    {
        if(!_canMove)
        {
            return;
        }

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

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _playerAnimator.SetBool("Attack", true);
            _canMove = false;
            _audioSource.PlayOneShot(_attackSE);
        }
    }

    void WeaponON()
    {
        _weaponCollider.enabled = true;
    }

    void WeaponOFF()
    {
        _weaponCollider.enabled = false;
        _playerAnimator.SetBool("Attack", false);
    }

    void CanMove()
    {
        _canMove = true;
    }
}
