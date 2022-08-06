using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandScript : MonoBehaviour
{
    [Tooltip("入力を受けるキュー")] Queue<int> _commandInput = new();

    [Tooltip("波動拳の入力")] readonly int[] _hadoken = { 2, 3, 6 };
    [Tooltip("昇龍拳の入力")] readonly int[] _shoryuken = { 6, 2, 3 };
    [Tooltip("昇龍拳の入力別パターン")] readonly int[] _shoryuken2 = { 3, 2, 3 };


    [Tooltip("レバー入力の判定")] int _lever = 5;
    [Tooltip("前回の入力を保存する変数")] int _beforeLever;


    [Header("Command")]
    [SerializeField, Tooltip("入力を保存しておく最大量")] int _inputLimit = 6;

    [Tooltip("入力時間を測るためのタイマー")] float _timer;
    [Tooltip("コマンドをリセットする時間")]readonly float _comandInterval = 1f;


    [Header("Check")]
    [SerializeField, Tooltip("チェックに使う用のリスト")] List<int> _checkCommands = new();
    [SerializeField, Tooltip("チェックを行うかの確認")] bool _commandCheck = false;

    PlayerMove _pm;


    void Start()
    {
        _pm = GetComponent<PlayerMove>();
    }

    void Update()
    {
        _timer += Time.deltaTime;


        if (_timer > _comandInterval)  //コマンドのリセットを時間で行う
        {
            _commandInput.Clear();
            _checkCommands.Clear();
        }


        CommandInput();　//入力判定


        if (_commandInput.Count > _inputLimit)　//キューの長さを固定
        {
            _commandInput.Dequeue();
        }


        if (_beforeLever != _lever && _lever != 5)　//入力が入った場合キューに追加
        {
            _timer = 0;

            _commandInput.Enqueue(_lever);

            if (_commandCheck)  //コマンドのチェックを実行するか
            {
                _checkCommands.Add(_lever);
            }

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CommandSuccess(_hadoken))　//コマンドの成立判定
            {
                Debug.Log("波動拳");
            }

            if (CommandSuccess(_shoryuken) || CommandSuccess(_shoryuken2))
            {
                Debug.Log("昇龍拳");
            }
        }


        ListCheck();　//デバッグのためキューと同じ処理をリストでも実行


        _beforeLever = _lever;　//レバーの入力を保存
    }


    /// <summary>テンキー形式でのレバー入力の判定</summary>
    void CommandInput()
    {
        float x = _pm.InputX;
        float y = _pm.InputY;

        Vector2 currentLever = new (x, y);

        if (currentLever == new Vector2(-1, -1))
        {
            _lever = 1;  //レバー入力１
        }

        if (currentLever == new Vector2(0, -1))
        {
            _lever = 2;　//レバー入力２
        }

        if (currentLever == new Vector2(1, -1))
        {
            _lever = 3;　//レバー入力３
        }

        if (currentLever == new Vector2(-1, 0))
        {
            _lever = 4;　//レバー入力４
        }

        if (currentLever == new Vector2(0, 0))
        {
            _lever = 5;　//レバー入力５
        }

        if (currentLever == new Vector2(1, 0))
        {
            _lever = 6;　//レバー入力６
        }

        if (currentLever == new Vector2(-1, 1))
        {
            _lever = 7;　//レバー入力７
        }

        if (currentLever == new Vector2(0, 1))
        {
            _lever = 8;　//レバー入力８
        }

        if (currentLever == new Vector2(1, 1))
        {
            _lever = 9;　//レバー入力９
        }
    }


    /// <summary>コマンドの成立判定</summary>
    bool CommandSuccess(int[] specialmove)
    {
        int success = 0;
        Queue<int> commands = new(_commandInput);　//現在の入力をコピー

        while (commands.Count >= 3)
        {
            foreach (var co in specialmove) //コマンドの配列をひとつずつ取り出す
            {
                if (commands.Peek() == co) //キューの先頭とコマンドの要素を比較
                {
                    success++;
                    commands.Dequeue(); //successにプラスし先頭を削除
                }
                else
                {
                    success = 0;
                    commands.Dequeue();　//successをリセットし先頭を削除、ループを抜ける
                    break;       　　　　
                }
            }
        }

        return success >= 3;　//successの数を見て値を返す
    }


    /// <summary>リストにキューと同じような処理を実行させる</summary>
    void ListCheck()
    {
        if (_commandCheck)
        {
            if (_checkCommands.Count > _inputLimit)　//Listがリミット以上の要素数になったら
            {
                for (int co = 0; co < _inputLimit; co++)
                {
                    _checkCommands[co] = _checkCommands[co + 1];　//要素をすべてひとつ前にずらす
                }

                _checkCommands.RemoveAt(_inputLimit);　//最後の要素を削除する
            }
        }
    }
}