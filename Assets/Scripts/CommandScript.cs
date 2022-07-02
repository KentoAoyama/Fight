using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
    public List<int> _input = new List<int>();
    List<int> _hadoken = new List<int>() { 2, 3, 6 };
    List<int> _shoryuken = new List<int>() { 6, 2, 3 };
    List<int> _shoryuken2 = new List<int>() { 3, 2, 3 };

    int _lever = 5;
    int _beforeLever;

    int _inputLimit = 3;

    float _commandTimer;
    float _comandInterval = 1f;


    void Update()
    {
        _commandTimer += Time.deltaTime;

        if (_commandTimer > _comandInterval && _input.Count != 0 )
        {
            _input.RemoveRange(0, _input.Count);
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

        
        if (_input.Count > _inputLimit)
        {
            _input[0] = _input[1];
            _input[1] = _input[2];
            _input[2] = _input[3];
            _input.RemoveAt(3);
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
                Debug.Log("�g����");
            }

            if (CommandSuccess(_shoryuken) || CommandSuccess(_shoryuken2))
            {
                Debug.Log("������");
            }
        }

        _beforeLever = _lever;
    }

    bool CommandSuccess(List<int> specialmove)
    {
        int count = 0;
        int success = 0;

        foreach (var co in specialmove)
        {
            if (count < _input.Count)
            {
                if (_input[count] == co)
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
        _input.Add(_lever);
        _input.Remove(5);
        Debug.Log(_lever);
    }
}