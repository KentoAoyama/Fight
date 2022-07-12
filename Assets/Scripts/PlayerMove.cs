using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    
    /// <summary> プレイヤーの移動速度　</summary>
    [SerializeField] float _moveSpeedX = 1f;
    
    
    /// <summary> ステップを行う時間　</summary>
    [SerializeField] float _stepSpeed = 1f;
    /// <summary>　ステップの速度 </summary>
    [SerializeField] float _stepPower = 10f;
    public int _stepCount;
    public bool _isStep;
    public float _stepInterval = 0.25f;



    void Update()
    {
        PlayerMoveHorizontal(PlayerManager._x, PlayerManager._y);
    }

    
    void PlayerMoveHorizontal(float x, float y)//プレイヤーの通常移動の処理
    {
        if (x > 0)//移動速度を一定にする
        {
            x = 1;
        }
        else if (x < 0)
        {
            x = -1;
        }

        if (y >= -0.1 && _stepCount < 1)//しゃがんでいる時かつステップしていない時
        {
                PlayerManager._rb.velocity = new Vector2(_moveSpeedX * x, PlayerManager._rb.velocity.y);
        }

        PlayerManager._playerAnimator.SetFloat("XMove", x);//移動のアニメーションの管理
        PlayerManager._playerAnimator.SetFloat("YMove", y);
    }


    //void PlayerStep(float x)
    //{
    //    if (x == 1 && _stepCount == 0 && !_isStep)
    //    {
    //        _isStep = true;
    //        StartCoroutine(StepCount());
    //    }

    //    if (x == 1 && _stepCount == 1 && _isStep)
    //    {
    //        StartCoroutine(Step(1));
    //    }
    //}//1から０になった時を識別しよう

    
    //IEnumerator StepCount()
    //{
    //    _stepCount++;
    //    yield return new WaitForSeconds(_stepInterval);
    //    _stepCount = 0;
    //    _isStep = false;
    //}


    //IEnumerator Step(int direction)
    //{
    //    PlayerManager._rb.AddForce(Vector2.right * _stepPower * direction, ForceMode2D.Impulse);
    //    yield return new WaitForSeconds(_stepSpeed);
    //    PlayerManager._rb.velocity = Vector2.zero;

    //    _isStep = false;
    //    _stepCount = 0;
    //}
}
