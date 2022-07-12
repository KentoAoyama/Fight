using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static Rigidbody2D _rb;
    public static Animator _playerAnimator;
    public static float _x;
    public static float _y;
    public static float _beforeInput;
    GameObject _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = _player.GetComponent<Rigidbody2D>();
        _playerAnimator = _player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_x);
        
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetAxisRaw("Vertical");

        _beforeInput = _x;
    }
}
