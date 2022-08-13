using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{    
    PlayerGuard _playerGuard;
    public PlayerGuard GuardState { get => _playerGuard; set => _playerGuard = value;}
    
    PlayerNumber _playerNumber;
    public PlayerNumber PlayerNum { get => _playerNumber; set => _playerNumber = value; }


    /// <summary>�v���C���[�̃K�[�h�̏�Ԃ�\��enum</summary>
    public enum PlayerGuard
    {
        /// <summary>�K�[�h�\</summary>
        IsGuard,
        /// <summary>�K�[�h�s�\</summary>
        NoGuard,
        /// <summary>���G����</summary>
        Invincible,
    }


    /// <summary>�v���C���[�̎��ʂ����邽�߂�enum</summary>
    public enum PlayerNumber
    {
        /// <summary>�v���C���[1��\��enum</summary>
        Player1,
        /// <summary>�v���C���[�Q��\��enum</summary>
        Player2,
    }
}
