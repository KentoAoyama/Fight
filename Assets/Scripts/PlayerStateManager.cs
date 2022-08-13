using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{    
    PlayerGuard _playerGuard;
    public PlayerGuard GuardState { get => _playerGuard; set => _playerGuard = value;}
    
    PlayerNumber _playerNumber;
    public PlayerNumber PlayerNum { get => _playerNumber; set => _playerNumber = value; }


    /// <summary>プレイヤーのガードの状態を表すenum</summary>
    public enum PlayerGuard
    {
        /// <summary>ガード可能</summary>
        IsGuard,
        /// <summary>ガード不可能</summary>
        NoGuard,
        /// <summary>無敵時間</summary>
        Invincible,
    }


    /// <summary>プレイヤーの識別をするためのenum</summary>
    public enum PlayerNumber
    {
        /// <summary>プレイヤー1を表すenum</summary>
        Player1,
        /// <summary>プレイヤー２を表すenum</summary>
        Player2,
    }
}
