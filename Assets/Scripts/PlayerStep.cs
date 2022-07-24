using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    [SerializeField] float _stepInterval = 0.3f;
    [SerializeField] float _stepTime = 0.5f;
    public bool _isStep1 = false;
    public bool _isStep2 = false;
    public bool _isStep3 = false;
    public bool _isStep4 = false;
    public bool _isStep;

    public float _timer1;
    public float _timer2;

    PlayerMove _pm;


    void Start()
    {
        _pm = GetComponent<PlayerMove>();
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
        if (_pm.InputX == 1 && !_isStep1)
        {
            _isStep1 = true;
            _isStep2 = false;
            _isStep3 = false;
        }

        if (_pm.InputX == 0 && _isStep1)
        {
            _isStep2 = true;
        }

        if (_isStep1)
        {
            _timer1 += Time.deltaTime;

            if (_timer1 > _stepInterval)
            {
                _isStep1 = false;
                _isStep2 = false;
                _timer1 = 0;
            }
        }

        if (_isStep2 && _pm.InputX == 1)
        {
            _isStep1 = false;
            _isStep2 = false;
            _timer1 = 0;
            _isStep = true;
            StartCoroutine(StepRoutine());
        }
    }


    void StepBack()
    {
        if (_pm.InputX == -1 && !_isStep3)
        {
            _isStep3 = true;
            _isStep4 = false;
            _isStep1 = false;
        }

        if (_pm.InputX == 0 && _isStep3)
        {
            _isStep4 = true;
        }

        if (_isStep3)
        {
            _timer2 += Time.deltaTime;

            if (_timer2 > _stepInterval)
            {
                _isStep3 = false;
                _isStep4 = false;
                _timer2 = 0;
            }
        }

        if (_isStep4 && _pm.InputX == -1)
        {
            _isStep3 = false;
            _isStep4 = false;
            _timer2 = 0;
            _isStep = true;
            StartCoroutine(StepRoutine());
        }
    }


    IEnumerator StepRoutine()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(_stepTime);
        Debug.Log("Finish");
        _isStep = false;
    }
}

