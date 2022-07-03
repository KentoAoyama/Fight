using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    /// <summary> �X�e�b�v���s�����ԁ@</summary>
    [SerializeField] float _stepSpeed = 1f;
    /// <summary>/// �X�e�b�v�̑��x�@/// </summary>
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

        if (_stepTrueR)//�^�C�}�[��i�߂�
        {
            _stepTimerR += Time.deltaTime;
        }
        
        if (_stepTimerR > _stepInterval)//��莞�ԓ��ɘA���œ��͂�����Ȃ����
        {
            _stepTrueR = false;
            _stepTimerR = 0;//�^�C�}�[�����Z�b�g
        }

        if (PlayerManager._x > 0)//�O�ɓ��͂���������^�C�}�[�𓮂���
        {
            _stepTrueR = true;
        }
        
        if (PlayerManager._x > 0 && _stepTimerR < _stepInterval)//��莞�ԓ��ɘA���œ��͂�������
        {
            StartCoroutine(StepMove(_stepPower));//�X�e�b�v�̏���
            _stepTimerR = 0;�@�@�@�@�@�@�@�@�@�@//�^�C�}�[�����Z�b�g
        }

    }

    IEnumerator StepMove(float step)
    {
        Debug.Log("���Ă��Ղ��I");
        PlayerManager._rb.AddForce(Vector2.right * step, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_stepSpeed);
        PlayerManager._rb.velocity = Vector2.zero;

        _stepTrueR = false;
        _stepTrueL = false;
    }
}
