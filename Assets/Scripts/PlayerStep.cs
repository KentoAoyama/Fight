using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    /// <summary> ステップを行う時間　</summary>
    [SerializeField] float _stepSpeed = 1f;
    /// <summary>/// ステップの速度　/// </summary>
    [SerializeField] float _stepPower = 3f;
    float _stepInterval = 2f;
    public float _stepTimerR;
    public float _stepTimerL;
    public bool _stepTrueR;
    public bool _stepTrueL;


    void Update()
    {
        PlayerStepMove();
    }

    void PlayerStepMove()
    {
        Debug.Log(_stepTrueR);

        if (_stepTrueR)//タイマーを進める
        {
            _stepTimerR += Time.deltaTime;
        }
        
        if (_stepTimerR > _stepInterval)//一定時間内に連続で入力がされなければ
        {
            _stepTrueR = false;
            _stepTimerR = 0;//タイマーをリセット
        }

        if (PlayerManager._x > 0)//前に入力が入ったらタイマーを動かす
        {
            _stepTrueR = true;
        }
        
        if (PlayerManager._x > 0 && _stepTimerR < _stepInterval)//一定時間内に連続で入力がされれば
        {
            StartCoroutine(StepMove(_stepPower));//ステップの処理
            _stepTimerR = 0;　　　　　　　　　　//タイマーをリセット
        }

    }

    IEnumerator StepMove(float step)
    {
        Debug.Log("すてっぷっ！");
        PlayerManager._rb.AddForce(Vector2.right * step, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_stepSpeed);
        PlayerManager._rb.velocity = Vector2.zero;

        _stepTrueR = false;
        _stepTrueL = false;
    }
}
