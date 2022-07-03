using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    /// <summary> �X�e�b�v���s�����ԁ@</summary>
    [SerializeField] float _stepSpeed = 1f;
    /// <summary>/// �X�e�b�v�̑��x�@/// </summary>
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
            if (PlayerManager._x > 0)//�O�ɓ��͂���������^�C�}�[�𓮂���
            {
                _stepTrueF = true;
            }

            if (_stepTrueF)//�^�C�}�[��i�߂�
            {
                _stepTimerF += Time.deltaTime;
            }

            if (_stepTimerF > _stepInterval)//��莞�ԓ��ɘA���œ��͂�����Ȃ����
            {
                _stepTrueF = false;
                _stepTimerF = 0;//�^�C�}�[�����Z�b�g
            }

            if (PlayerManager._x > 0 && _stepTrueF)//��莞�ԓ��ɘA���œ��͂�������
            {
                StartCoroutine(StepMove());//�X�e�b�v�̏���
                _stepTimerF = 0;�@�@�@�@�@//�^�C�}�[�����Z�b�g
            }

        }

        IEnumerator StepMove()
        {
            Debug.Log("���Ă��Ղ��I");
            //PlayerManager._rb.AddForce(Vector2.right * _stepPower, ForceMode2D.Impulse);
            PlayerManager._rb.velocity = new Vector2(PlayerManager._x * _stepPower, PlayerManager._rb.velocity.y);
            yield return new WaitForSeconds(_stepSpeed);
            PlayerManager._rb.velocity = Vector2.zero;

            _stepTrueF = false;
            _stepTrueB = false;
        }
}

