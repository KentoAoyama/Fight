using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
    Queue<int> _commandInput = new();
    int[] _hadoken = { 2, 3, 6 };
    int[] _shoryuken = { 6, 2, 3 };
    int[] _shoryuken2 = { 3, 2, 3 };

    int _lever = 5;
    int _beforeLever;

    [Header("Command")]
    [SerializeField] int _inputLimit = 3;

    float _commandTimer;
    float _comandInterval = 1f;

    [Header("Check")]
    [SerializeField] List<int> _checkCommands = new();
    [SerializeField] bool _commandCheck = false;


    void Update()
    {
        _commandTimer += Time.deltaTime;

        if (_commandTimer > _comandInterval)
        {
            _commandInput.Clear();
            _checkCommands.Clear();
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            _lever += 3;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _lever -= 3;
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            _lever -= 1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _lever += 1;
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            _lever -= 3;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _lever += 3;
        }



        if (Input.GetKeyDown(KeyCode.D))
        {
            _lever += 1;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _lever -= 1;
        }


        if (_commandInput.Count > _inputLimit)
        {
            _commandInput.Dequeue();
        }


        if (_beforeLever != _lever && _lever != 5)
        {
            _commandTimer = 0;
            StartCoroutine(InputInterval());
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CommandSuccess(_hadoken))
            {
                Debug.Log("”g“®Œ");
            }
            
            if (CommandSuccess(_shoryuken) || CommandSuccess(_shoryuken2))
            {
                Debug.Log("¸—´Œ");
            }
        }


        if (_commandCheck)
        {
            if (_checkCommands.Count > _inputLimit)
            {
                for (int co = 0; co < _inputLimit; co++)
                {
                    _checkCommands[co] = _checkCommands[co + 1];
                }

                _checkCommands.RemoveAt(_inputLimit);
            }
        }

        _beforeLever = _lever;
    }


    bool CommandSuccess(int[] specialmove)
    {
        int success = 0;
        Queue<int> commands = new (_commandInput);

        if (commands.Count >= 3)
        {
            while (true)
            {
                foreach (var co in specialmove)
                {
                    if (commands.Peek() == co)
                    {
                        success++;
                        commands.Dequeue();
                    }
                    else
                    {
                        success = 0;
                        commands.Dequeue();
                        break;
                    }                  
                }               

                if (commands.Count < 3)
                {
                    break;
                }
            }
        }

        return success >= 3;
    }


    IEnumerator InputInterval()
    {
        yield return new WaitForSeconds(0.016f);
        _commandInput.Enqueue(_lever);

        if (_commandCheck)
        {
            _checkCommands.Add(_lever);
        }
    }
}