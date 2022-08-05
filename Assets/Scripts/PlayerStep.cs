using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    [SerializeField, Tooltip("ステップ入力を受け付ける時間")] float _stepInterval = 0.3f;
    [SerializeField, Tooltip("前ステップを行う時間")] float _stepTime = 0.29f;
    [SerializeField, Tooltip("バックステップを行う時間")] float _backStepTime = 0.34f;
    [SerializeField, Tooltip("ステップの速度・距離")] float _stepSpeed = 10;
    [Tooltip("前ステップの入力判定１")] bool _fStep1 = false;
    [Tooltip("前ステップの入力判定２")] bool _fStep2 = false;
    [Tooltip("バックステップの入力判定１")] bool _bStep1 = false;
    [Tooltip("バックステップの入力判定２")] bool _bStep2 = false;
    [Tooltip("ステップをしているか")] bool _isStep;
    public bool IsStep => _isStep;

    [Tooltip("前に入力が入ってからの時間計測")] float _fTimer;
    [Tooltip("後ろに入力が入ってからの時間計測")] float _bTimer;

    
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
        if (!_isStep && _pm.InputY > -0.2)　//ステップ中でないかつしゃがんでいないなら
        {
            StepFront();

            StepBack();
        }
    }


    /// <summary>前ステップの処理</summary>
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

        if (_pm.InputX == 1 &&　_fStep2)
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

