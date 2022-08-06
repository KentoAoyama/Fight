using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("移動の速度")] float _moveSpeedX = 1f;
    [Tooltip("横移動の入力")] float _x;
    [Tooltip("縦移動の入力")] float _y;
    public float InputX => _x;
    public float InputY => _y;

    readonly Vector3 _player2Scale = new(-1, 1, 1);

    Rigidbody2D _rb;
    Animator _playerAnimator;

    PlayerStep _ps;
    PlayerStateManager _psm;

   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        
        _ps = GetComponent<PlayerStep>();
        _psm = GetComponent<PlayerStateManager>();

        if (transform.position.x < 0)
        {
            _psm.PlayerNum = PlayerStateManager.PlayerNumber.Player1;
        }
        else
        {
            _psm.PlayerNum = PlayerStateManager.PlayerNumber.Player2;
        }
    }


    void Update()
    {
        if (_psm.PlayerNum == PlayerStateManager.PlayerNumber.Player2)
        {
            transform.localScale = _player2Scale;
            
            PlayerMoveHorizontal(-1);
        }
        else
        {
            PlayerMoveHorizontal(1);
        }

        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");
    }


    /// <summary>プレイヤーの横移動の処理</summary>
    void PlayerMoveHorizontal(float playerDir)
    {
        //if (_x > 0)　//移動速度を一定にする
        //{
        //    _x = 1;
        //}


        if (_y >= -0.2 && !_ps.IsStep)　//しゃがんでいない時かつステップしていない時
        {
            _rb.velocity = new Vector2(_moveSpeedX * _x, _rb.velocity.y);
        }
        else if (_y < -0.2)
        {
            _rb.velocity = Vector2.zero;
        }

        _playerAnimator.SetFloat("XMove", _x * playerDir);　//移動のアニメーションの管理
        _playerAnimator.SetFloat("YMove", _y);
    }
}
