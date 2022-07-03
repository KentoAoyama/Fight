using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    /// <summary> ステップを行う時間　</summary>
    [SerializeField] float _stepSpeed = 1f;
    /// <summary>/// ステップの速度　/// </summary>
    [SerializeField] float _stepPower = 10f;
    public float _stepInterval = 2f;
    public float _stepTimerF;
    public float _stepTimerB;
    public bool _stepTrueF;
    public bool _stepTrueB;


    void Update()
    {
        PlayerStepMove();
    }

    void PlayerStepMove()
    {
            if (PlayerManager._x > 0)//前に入力が入ったらタイマーを動かす
            {
                _stepTrueF = true;
            }

            if (_stepTrueF)//タイマーを進める
            {
                _stepTimerF += Time.deltaTime;
            }

            if (_stepTimerF > _stepInterval)//一定時間内に連続で入力がされなければ
            {
                _stepTrueF = false;
                _stepTimerF = 0;//タイマーをリセット
            }

            if (PlayerManager._x > 0 && _stepTrueF)//一定時間内に連続で入力がされれば
            {
                StartCoroutine(StepMove());//ステップの処理
                _stepTimerF = 0;　　　　　//タイマーをリセット
            }

        }

        IEnumerator StepMove()
        {
            Debug.Log("すてっぷっ！");
            //PlayerManager._rb.AddForce(Vector2.right * _stepPower, ForceMode2D.Impulse);
            PlayerManager._rb.velocity = new Vector2(PlayerManager._x * _stepPower, PlayerManager._rb.velocity.y);
            yield return new WaitForSeconds(_stepSpeed);
            PlayerManager._rb.velocity = Vector2.zero;

            _stepTrueF = false;
            _stepTrueB = false;
        }
}

