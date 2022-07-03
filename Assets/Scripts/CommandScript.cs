using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
    public List<int> _commandInput = new List<int>();
    int[] _hadoken = { 2, 3, 6 };
    int[] _shoryuken = { 6, 2, 3 };
    int[] _shoryuken2 = { 3, 2, 3 };

    int _lever = 5;
    int _beforeLever;

    [SerializeField] int _inputLimit = 3;

    float _commandTimer;
    float _comandInterval = 1f;


    void Update()
    {
        _commandTimer += Time.deltaTime;

        if (_commandTimer > _comandInterval && _commandInput.Count != 0 )
        {
            _commandInput.RemoveRange(0, _commandInput.Count);
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
            for (int co = 0; co < _inputLimit; co++)
            {
                _commandInput[co] = _commandInput[co + 1];
            }

            _commandInput.RemoveAt(_inputLimit);
        }


        if (_beforeLever != _lever)
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

        _beforeLever = _lever;
    }

    bool CommandSuccess(int[] specialmove)
    {
        int count = 0;
        int success = 0;

        foreach (var co in specialmove)
        {
            if (count < _commandInput.Count)
            {
                if (_commandInput[count] == co)
                {
                    success++;

                    if (success == 3)
                    {
                        return true;
                    }
                }
            }
            count++;
        }
        return false;
    }

    IEnumerator InputInterval()
    {
        yield return new WaitForSeconds(0.025f);
        _commandInput.Add(_lever);
        _commandInput.Remove(5);
        Debug.Log(_lever);
    }
}
