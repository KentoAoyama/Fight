using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _moveSpeedX = 1f;
    
    
    void Update()
    {
        PlayerMoveHorizontal(PlayerManager._x, PlayerManager._y);
    }



    void PlayerMoveHorizontal(float x, float y)//プレイヤーの通常移動の処理
    {
        if (y >= -0.1)
        {
            if (x > 0)
            {
                PlayerManager._rb.velocity = new Vector2(_moveSpeedX * x, PlayerManager._rb.velocity.y);
            }
            else if (x < 0)
            {
                PlayerManager._rb.velocity = new Vector2(_moveSpeedX * x, PlayerManager._rb.velocity.y);
            }
        }
        PlayerManager._playerAnimator.SetFloat("XMove", x);//移動のアニメーションの管理
        PlayerManager._playerAnimator.SetFloat("YMove", y);
    }
}
