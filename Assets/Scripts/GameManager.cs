using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _frame = 0;
    uint _frameCount=0;
    void FixedUpdate()
    {
        _frameCount++;
        _frame++;
    }

    public int FrameTimer()
    {
        _frame++;
        return _frame;
    }
}
