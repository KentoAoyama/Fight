using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    [SerializeField] float _stepInterval = 0.3f;
    [SerializeField] float _stepTime = 0.29f;
    [SerializeField] float _backStepTime = 0.34f;
    [SerializeField] float _stepSpeed = 10;
    bool _fStep1 = false;
    bool _fStep2 = false;
    bool _bStep1 = false;
    bool _bStep2 = false;
    bool _isStep;

    public bool IsStep => _isStep;

    float _fTimer;
    float _bTimer2;

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
        if (!_isStep)
        {
            StepFront();

            StepBack();
        }
    }


    void StepFront()
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

        if (_fStep2 && _pm.InputX == 1)
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
            _bTimer2 += Time.deltaTime;

            if (_bTimer2 > _stepInterval)
            {
                _bStep1 = false;
                _bStep2 = false;
                _bTimer2 = 0;
            }
        }

        if (_bStep2 && _pm.InputX == -1)
        {
            _bStep2 = false;
            _bStep1 = false;
            _bTimer2 = 0;
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

