using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
    [Tooltip("���͂��󂯂�L���[")] Queue<int> _commandInput = new();

    [Tooltip("�g�����̓���")] readonly int[] _hadoken = { 2, 3, 6 };
    [Tooltip("�������̓���")] readonly int[] _shoryuken = { 6, 2, 3 };
    [Tooltip("�������̓��͕ʃp�^�[��")] readonly int[] _shoryuken2 = { 3, 2, 3 };


    [Tooltip("���o�[���͂̔���")] int _lever = 5;
    [Tooltip("�O��̓��͂�ۑ�����ϐ�")] int _beforeLever;


    [Header("Command")]
    [SerializeField, Tooltip("���͂�ۑ����Ă����ő��")] int _inputLimit = 6;

    [Tooltip("���͎��Ԃ𑪂邽�߂̃^�C�}�[")] float _timer;
    [Tooltip("�R�}���h�����Z�b�g���鎞��")]readonly float _comandInterval = 1f;


    [Header("Check")]
    [SerializeField, Tooltip("�`�F�b�N�Ɏg���p�̃��X�g")] List<int> _checkCommands = new();
    [SerializeField, Tooltip("�`�F�b�N���s�����̊m�F")] bool _commandCheck = false;

    PlayerMove _pm;


    void Start()
    {
        _pm = GetComponent<PlayerMove>();
    }

    void Update()
    {
        _timer += Time.deltaTime;


        if (_timer > _comandInterval)  //�R�}���h�̃��Z�b�g�����Ԃōs��
        {
            _commandInput.Clear();
            _checkCommands.Clear();
        }


        CommandInput();�@//���͔���


        if (_commandInput.Count > _inputLimit)�@//�L���[�̒������Œ�
        {
            _commandInput.Dequeue();
        }


        if (_beforeLever != _lever && _lever != 5)�@//���͂��������ꍇ�L���[�ɒǉ�
        {
            _timer = 0;

            _commandInput.Enqueue(_lever);

            if (_commandCheck)  //�R�}���h�̃`�F�b�N�����s���邩
            {
                _checkCommands.Add(_lever);
            }

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CommandSuccess(_hadoken))�@//�R�}���h�̐�������
            {
                Debug.Log("�g����");
            }

            if (CommandSuccess(_shoryuken) || CommandSuccess(_shoryuken2))
            {
                Debug.Log("������");
            }
        }


        ListCheck();�@//�f�o�b�O�̂��߃L���[�Ɠ������������X�g�ł����s


        _beforeLever = _lever;�@//���o�[�̓��͂�ۑ�
    }


    /// <summary>�e���L�[�`���ł̃��o�[���͂̔���</summary>
    void CommandInput()
    {
        float x = _pm.InputX;
        float y = _pm.InputY;

        Vector2 currentLever = new (x, y);

        if (currentLever == new Vector2(-1, -1))
        {
            _lever = 1;  //���o�[���͂P
        }

        if (currentLever == new Vector2(0, -1))
        {
            _lever = 2;�@//���o�[���͂Q
        }

        if (currentLever == new Vector2(1, -1))
        {
            _lever = 3;�@//���o�[���͂R
        }

        if (currentLever == new Vector2(-1, 0))
        {
            _lever = 4;�@//���o�[���͂S
        }

        if (currentLever == new Vector2(0, 0))
        {
            _lever = 5;�@//���o�[���͂T
        }

        if (currentLever == new Vector2(1, 0))
        {
            _lever = 6;�@//���o�[���͂U
        }

        if (currentLever == new Vector2(-1, 1))
        {
            _lever = 7;�@//���o�[���͂V
        }

        if (currentLever == new Vector2(0, 1))
        {
            _lever = 8;�@//���o�[���͂W
        }

        if (currentLever == new Vector2(1, 1))
        {
            _lever = 9;�@//���o�[���͂X
        }
    }


    /// <summary>�R�}���h�̐�������</summary>
    bool CommandSuccess(int[] specialmove)
    {
        int success = 0;
        Queue<int> commands = new(_commandInput);�@//���݂̓��͂��R�s�[

        while (commands.Count >= 3)
        {
            foreach (var co in specialmove) //�R�}���h�̔z����ЂƂ����o��
            {
                if (commands.Peek() == co) //�L���[�̐擪�ƃR�}���h�̗v�f���r
                {
                    success++;
                    commands.Dequeue(); //success�Ƀv���X���擪���폜
                }
                else
                {
                    success = 0;
                    commands.Dequeue();�@//success�����Z�b�g���擪���폜�A���[�v�𔲂���
                    break;       �@�@�@�@
                }
            }
        }

        return success >= 3;�@//success�̐������Ēl��Ԃ�
    }


    /// <summary>���X�g�ɃL���[�Ɠ����悤�ȏ��������s������</summary>
    void ListCheck()
    {
        if (_commandCheck)
        {
            if (_checkCommands.Count > _inputLimit)�@//List�����~�b�g�ȏ�̗v�f���ɂȂ�����
            {
                for (int co = 0; co < _inputLimit; co++)
                {
                    _checkCommands[co] = _checkCommands[co + 1];�@//�v�f�����ׂĂЂƂO�ɂ��炷
                }

                _checkCommands.RemoveAt(_inputLimit);�@//�Ō�̗v�f���폜����
            }
        }
    }
}