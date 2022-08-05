using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    [SerializeField, Tooltip("�X�e�b�v���͂��󂯕t���鎞��")] float _stepInterval = 0.3f;
    [SerializeField, Tooltip("�O�X�e�b�v���s������")] float _stepTime = 0.29f;
    [SerializeField, Tooltip("�o�b�N�X�e�b�v���s������")] float _backStepTime = 0.34f;
    [SerializeField, Tooltip("�X�e�b�v�̑��x�E����")] float _stepSpeed = 10;
    [Tooltip("�O�X�e�b�v�̓��͔���P")] bool _fStep1 = false;
    [Tooltip("�O�X�e�b�v�̓��͔���Q")] bool _fStep2 = false;
    [Tooltip("�o�b�N�X�e�b�v�̓��͔���P")] bool _bStep1 = false;
    [Tooltip("�o�b�N�X�e�b�v�̓��͔���Q")] bool _bStep2 = false;
    [Tooltip("�X�e�b�v�����Ă��邩")] bool _isStep;
    public bool IsStep => _isStep;

    [Tooltip("�O�ɓ��͂������Ă���̎��Ԍv��")] float _fTimer;
    [Tooltip("���ɓ��͂������Ă���̎��Ԍv��")] float _bTimer;

    
    PlayerMove _pm;
    Animator _ani;
    Rigidbody2D _rb;


    void Start()
    {
        _pm = GetComponent<PlayerMove>();
        _rb = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_isStep && _pm.InputY > -0.2)�@//�X�e�b�v���łȂ������Ⴊ��ł��Ȃ��Ȃ�
        {
            StepFront();

            StepBack();
        }
    }


    /// <summary>�O�X�e�b�v�̏���</summary>
    void StepFront(/*float vec, float timer, bool step1, bool step2, bool step3, Coroutine coroutine*/)
    {     
        if (_pm.InputX == 1 && !_fStep1)
        {
            _fStep1 = true;
            _fStep2 = false;
            _bStep1 = false;
        }

        if (_pm.InputX == 0 && _fStep1)
        {
            _fStep2 = true;
        }

        if (_fStep1)
        {
            _fTimer += Time.deltaTime;

            if (_fTimer > _stepInterval)
            {
                _fStep1 = false;
                _fStep2 = false;
                _fTimer = 0;
            }
        }

        if (_pm.InputX == 1 &&�@_fStep2)
        {
            _fStep2 = false;
            _fStep1 = false;
            _fTimer = 0;
            _isStep = true;
            StartCoroutine(FrontStepRoutine());
        }
    }


    void StepBack()
    {
        if (_pm.InputX == -1 && !_bStep1)
        {
            _bStep1 = true;
            _bStep2 = false;
            _fStep1 = false;
        }

        if (_pm.InputX == 0 && _bStep1)
        {
            _bStep2 = true;
        }

        if (_bStep1)
        {
            _bTimer += Time.deltaTime;

            if (_bTimer > _stepInterval)
            {
                _bStep1 = false;
                _bStep2 = false;
                _bTimer = 0;
            }
        }

        if (_pm.InputX == -1 && _bStep2)
        {
            _bStep2 = false;
            _bStep1 = false;
            _bTimer = 0;
            _isStep = true;
            StartCoroutine(BackStepRoutine());
        }
    }


    IEnumerator FrontStepRoutine()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(transform.right * _stepSpeed, ForceMode2D.Impulse);
        _ani.SetBool("IsStep", true);
        yield return new WaitForSeconds(_stepTime);
        _ani.SetBool("IsStep", false);
        _isStep = false;
    }


    IEnumerator BackStepRoutine()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(transform.right * _stepSpeed * -1, ForceMode2D.Impulse);
        _ani.SetBool("IsBackStep", true);
        yield return new WaitForSeconds(_backStepTime);
        _ani.SetBool("IsBackStep", false);
        _isStep = false;
    }

}

