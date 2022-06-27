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

        if (_input.Count > 3)
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
                Debug.Log("îgìÆåù");
            }

            if (CommandSuccess(_shoryuken) || CommandSuccess(_shoryuken2))
            {
                Debug.Log("è∏ó¥åù");
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
    //public List<int> _input = new List<int>();
    //List<int> _hadoken = new List<int>() { 2, 3, 6 };
    //List<int> _shoryuken = new List<int>() { 6, 2, 3 };

    //int _lever = 5;
    //int _beforeLever;

    //bool _plessW;
    //bool _plessA;
    //bool _plessS;
    //bool _plessD;
    //bool _upW;
    //bool _upA;
    //bool _upS;
    //bool _upD;

    //float _timer;
    //float _commandInterval = 1;

    //void Start()
    //{
    //    _plessW = Input.GetKeyDown(KeyCode.W);
    //    _plessA = Input.GetKeyDown(KeyCode.A);
    //    _plessS = Input.GetKeyDown(KeyCode.S);
    //    _plessD = Input.GetKeyDown(KeyCode.D);
    //    _upW = Input.GetKeyUp(KeyCode.W);
    //    _upA = Input.GetKeyUp(KeyCode.A);
    //    _upS = Input.GetKeyUp(KeyCode.S);
    //    _upD = Input.GetKeyUp(KeyCode.D);
    //}


    //void Update()
    //{
    //    _timer += Time.deltaTime;

    //    if  (_timer > _commandInterval)

    //    if (_plessW)
    //    {
    //        _lever += 3;
    //    }

    //    if (_upW)
    //    {
    //        _lever -= 3;
    //    }


    //    if (_plessA)
    //    {
    //        _lever -= 1;
    //    }

    //    if (_upA)
    //    {
    //        _lever += 1;
    //    }


    //    if (_plessS)
    //    {
    //        _lever -= 3;
    //    }

    //    if (_upS)
    //    {
    //        _lever += 3;
    //    }


    //    if (_plessD)
    //    {
    //        _lever += 1;
    //    }

    //    if (_upD)
    //    {
    //        _lever -= 1;
    //    }

    //    if (_input.Count > 3)
    //    {
    //        _input[0] = _input[1];
    //        _input[1] = _input[2];
    //        _input[2] = _input[3];
    //        _input.RemoveAt(3);
    //    }


    //    if (_beforeLever != _lever)
    //    {
    //        StartCoroutine(InputInterval());
    //    }


    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (CommandSuccess(_hadoken))
    //        {
    //            Debug.Log("îgìÆåù");
    //        }

    //        if (CommandSuccess(_shoryuken))
    //        {
    //            Debug.Log("è∏ó¥åù");
    //        }
    //    }

    //    _input.Remove(5);

    //    _beforeLever = _lever;
    //}

    //bool CommandSuccess(List<int> specialmove)
    //{
    //    int count = 0;
    //    int success = 0;

    //    foreach (var co in specialmove)
    //    {
    //        if (count < _input.Count)
    //        {
    //            if (_input[count] == co)
    //            {
    //                success++;

    //                if (success == 3)
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        count++;
    //    }
    //    return false;
    //}

    //IEnumerator InputInterval()
    //{
    //    yield return new WaitForSeconds(0.025f);
    //    _input.Add(_lever);
    //    _input.Remove(5);
    //    Debug.Log(_lever);
    //}
}
