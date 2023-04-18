using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    /// ctrl + . でメソッドを抽出してくれる

    // 配列の数値を表示 
    void PrintArray()
    {
        //追加。文字列の宣言と初期化
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            // 変更。文字列に結合していく
            debugText += map.ToString() + ",";
        }
        // 結合した文字列を出力
        Debug.Log(debugText);
    }
    
    // 1の値が格納されているインデックスを取得する処理
    int GetPlayerIndex()
    {
        // 要素数はmap.Lengthで取得
        for (int i = 0; i < map.GetLength(1); i++)
        {
            if (map[i, 0] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    // 移動の可不可を判断して移動を行う処理
    bool MoveNumber(int number, int moveFrom,int moveTo)
    {
        // 動けない条件を先に書き、リターンする、早期リターン
        // 移動先が範囲外であれば移動できない
        if (moveTo < 0 || moveTo >= map.Length){ return false;}
        //移動先に箱(2)が居たら
        if (map[moveTo,0] == 2)
        {
            // どの方向に移動するかを算出
            int velocity = moveTo - moveFrom;
            // プレイヤーの移動先から、さらに先へ箱(2)を移動させる
            // 箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを呼び出す
            // 移動可不可をboolで記録
            bool succes = MoveNumber(2, moveTo, moveTo + velocity);
            // もし箱の移動ができなければプレイヤーも移動しない
            if (!succes) { return false; }
        }

        // プレイヤー
        map[moveTo,0] = number;
        map[moveFrom, 0] = 0;
        return true;
    }

    // 配列の宣言
    int[,] map;

    // Start is called before the first frame update
    void Start()
    {
        // 配列の実態の作成と初期化
        map = new int[,] {
            { 0, 0, 0, 1, 0, 2, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        int playerIndex= GetPlayerIndex();

        // 右方向への移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }

        // 左方向への移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }
}
