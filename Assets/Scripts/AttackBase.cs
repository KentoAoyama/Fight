using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [Header("CommandStatus")]
    [SerializeField, Tooltip("����ɗ^����_���[�W")] float _damage = 0;
    [SerializeField, Tooltip("����̃K�[�h���̍d���t���[��")] float _guardFrame = 0;
    [SerializeField, Tooltip("����̃q�b�g���̍d���t���[��")] float _hitFrame = 0;
    [SerializeField, Tooltip("�����Ă���Z�̔����t���[��")] float _startUpFrame = 0;
    [SerializeField, Tooltip("�����Ă���Z�̑S�̃t���[��")] float _attackFrame = 0;

    [Tooltip("�������_���[�W���󂯂�R���C�_�[")] PolygonCollider2D _hitBox;
    [Tooltip("����Ƀ_���[�W��^����Boxcast")] BoxcastCommand _damageBoxCast;
    [Tooltip("�U���������郌�C���[")] LayerMask _hitLayer;

    [Tooltip("����̃v���C���[")] GameObject _rival;
    
    [Header("Animation")]
    [SerializeField, Tooltip("���s����U���̖��O")] string _animationName;
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
