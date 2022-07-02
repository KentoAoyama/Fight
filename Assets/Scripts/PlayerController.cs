using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeedX = 1f;
    Rigidbody2D _rb;
    float _x;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PlayerMove();
    }



    void PlayerMove()
    {
        _x = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(_moveSpeedX * _x, _rb.velocity.y);

    }
}
