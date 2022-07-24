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
    //float _beforeInput;
    public float InputY { get => _y; set => _y = value; }
    public float InputX { get => _x; set => _x = value; }
    //public float BeforeInput => _beforeInput;
    
    Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");

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

        if (_y >= -0.1)//しゃがんでいる時かつステップしていない時
        {
                _rb.velocity = new Vector2(_moveSpeedX * _x, _rb.velocity.y);
        }

        _playerAnimator.SetFloat("XMove", _x);//移動のアニメーションの管理
        _playerAnimator.SetFloat("YMove", _y);
    }
}
