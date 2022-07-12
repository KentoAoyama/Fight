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
    public bool _isStep;
    public float _stepInterval = 0.25f;



    void Update()
    {
        PlayerMoveHorizontal(PlayerManager._x, PlayerManager._y);
    }

    
    void PlayerMoveHorizontal(float x, float y)//�v���C���[�̒ʏ�ړ��̏���
    {
        if (x > 0)//�ړ����x�����ɂ���
        {
            x = 1;
        }
        else if (x < 0)
        {
            x = -1;
        }

        if (y >= -0.1 && _stepCount < 1)//���Ⴊ��ł��鎞���X�e�b�v���Ă��Ȃ���
        {
                PlayerManager._rb.velocity = new Vector2(_moveSpeedX * x, PlayerManager._rb.velocity.y);
        }

        PlayerManager._playerAnimator.SetFloat("XMove", x);//�ړ��̃A�j���[�V�����̊Ǘ�
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
    //}//1����O�ɂȂ����������ʂ��悤

    
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
