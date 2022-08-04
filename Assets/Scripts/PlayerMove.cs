using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ��̑��x")] float _moveSpeedX = 1f;
    [Tooltip("���ړ��̓���")] float _x;
    [Tooltip("�c�ړ��̓���")] float _y;
    public float InputX => _x;
    public float InputY => _y;

    Rigidbody2D _rb;
    Animator _playerAnimator;

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

        PlayerMoveHorizontal();
    }


    /// <summary>�v���C���[�̉��ړ��̏���</summary>
    void PlayerMoveHorizontal()
    {
        if (_x > 0)�@//�ړ����x�����ɂ���
        {
            _x = 1;
        }
        else if (_x < 0)
        {
            _x = -1;
        }

        if (_y >= -0.2 && !_ps.IsStep)�@//���Ⴊ��ł��Ȃ������X�e�b�v���Ă��Ȃ���
        {
            _rb.velocity = new Vector2(_moveSpeedX * _x, _rb.velocity.y);
        }
        else if (_y < -0.2)
        {
            _rb.velocity = Vector2.zero;
        }

        _playerAnimator.SetFloat("XMove", _x);�@//�ړ��̃A�j���[�V�����̊Ǘ�
        _playerAnimator.SetFloat("YMove", _y);
    }
}
