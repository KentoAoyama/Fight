using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [Header("CommandStatus")]
    [SerializeField, Tooltip("相手に与えるダメージ")] float _damage = 0;
    [SerializeField, Tooltip("相手のガード時の硬直フレーム")] float _guardFrame = 0;
    [SerializeField, Tooltip("相手のヒット時の硬直フレーム")] float _hitFrame = 0;
    [SerializeField, Tooltip("撃っている技の発生フレーム")] float _startUpFrame = 0;
    [SerializeField, Tooltip("撃っている技の全体フレーム")] float _attackFrame = 0;

    [Tooltip("自分がダメージを受けるコライダー")] PolygonCollider2D _hitBox;
    [Tooltip("相手にダメージを与えるBoxcast")] BoxcastCommand _damageBoxCast;
    [Tooltip("攻撃が当たるレイヤー")] LayerMask _hitLayer;

    [Tooltip("相手のプレイヤー")] GameObject _rival;
    
    [Header("Animation")]
    [SerializeField, Tooltip("実行する攻撃の名前")] string _animationName;
    Animator _animator;

    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _hitBox = GetComponent<PolygonCollider2D>();

        _hitLayer = LayerMask.NameToLayer("Player");
    }


    void FixedUpdate()
    {
        
    }

    protected void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool(_animationName, true);

            Debug.Log("YES!!!!!!!!!");
        }
    }
}
