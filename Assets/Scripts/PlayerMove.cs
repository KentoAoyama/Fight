using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    
    /// <summary> プレイヤーの移動速度　</summary>
    [SerializeField] float _moveSpeedX = 1f;
    Animator _playerAnimator;
    
    float _x;
    float _y;
    public float InputY { get => _y; set => _y = value; }
    public float InputX { get => _x; set => _x = value; }
    
    Rigidbody2D _rb;

    PlayerStep _ps;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _ps = GetComponent<PlayerStep>();
    }


    void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");
        //_x = Input.GetAxisRaw("CrossH");
        //_y = Input.GetAxisRaw("CrossV");


        PlayerMoveHorizontal();
    }

    
    void PlayerMoveHorizontal()//プレイヤーの通常移動の処理
    {
        if (_x > 0)//移動速度を一定にする
        {
            _x = 1;
        }
        else if (_x < 0)
        {
            _x = -1;
        }

        if (_y >= -0.2 && !_ps.IsStep)//しゃがんでいない時かつステップしていない時
        {
            _rb.velocity = new Vector2(_moveSpeedX * _x, _rb.velocity.y);
        }
        else if (_y < -0.2)
        {
            _rb.velocity = Vector2.zero;
        }


        _playerAnimator.SetFloat("XMove", _x);//移動のアニメーションの管理
        _playerAnimator.SetFloat("YMove", _y);
    }
}
