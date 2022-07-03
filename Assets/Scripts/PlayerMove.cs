using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    
    /// <summary> �v���C���[�̈ړ����x�@</summary>
    [SerializeField] float _moveSpeedX = 1f;
    
    
    /// <summary> �X�e�b�v���s�����ԁ@</summary>
    [SerializeField] float _stepSpeed = 1f;
    /// <summary>�@�X�e�b�v�̑��x </summary>
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

    
    void PlayerMoveHorizontal(float x, float y)//�v���C���[�̒ʏ�ړ��̏���
    {
        if (y >= -0.1 && _stepCount < 1)//���Ⴊ��ł��鎞���X�e�b�v���Ă��Ȃ���
        {
                PlayerManager._rb.velocity = new Vector2(_moveSpeedX * x, PlayerManager._rb.velocity.y);
        }

        PlayerManager._playerAnimator.SetFloat("XMove", x);//�ړ��̃A�j���[�V�����̊Ǘ�
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
