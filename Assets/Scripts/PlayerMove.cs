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


    void Update()
    {
        if (PlayerManager._x > 0)
        {
            PlayerManager._x = 1;
        }
        else if (PlayerManager._x < 0)
        {
            PlayerManager._x = -1;
        }


        PlayerMoveHorizontal(PlayerManager._x, PlayerManager._y);
        PlayerStep(PlayerManager._x);
    }

    
    void PlayerMoveHorizontal(float x, float y)//プレイヤーの通常移動の処理
    {
        if (y >= -0.1 && _stepCount < 1)//しゃがんでいる時かつステップしていない時
        {
                PlayerManager._rb.velocity = new Vector2(_moveSpeedX * x, PlayerManager._rb.velocity.y);
        }

        PlayerManager._playerAnimator.SetFloat("XMove", x);//移動のアニメーションの管理
        PlayerManager._playerAnimator.SetFloat("YMove", y);
    }


    void PlayerStep(float x)
    {
        if (x == 1 && _stepCount == 0)
        {
            StartCoroutine(StepCount());
        }

        if (x == 1 && x != PlayerManager._beforeInput && _stepCount == 1)
        {
            StartCoroutine(Step(1));
            _stepCount = 0;
        }
    }

    
    IEnumerator StepCount()
    {
        _stepCount = 0;
        yield return new WaitForSeconds(1f);
        _stepCount++;
    }


    IEnumerator Step(int direction)
    {
        PlayerManager._rb.AddForce(Vector2.right * _stepPower * direction, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_stepSpeed);
        PlayerManager._rb.velocity = Vector2.zero;
    }
}
