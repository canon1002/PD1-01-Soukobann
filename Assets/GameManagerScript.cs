using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    /// ctrl + . �Ń��\�b�h�𒊏o���Ă����

    // �z��̐��l��\�� 
    void PrintArray()
    {
        //�ǉ��B������̐錾�Ə�����
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            // �ύX�B������Ɍ������Ă���
            debugText += map.ToString() + ",";
        }
        // ����������������o��
        Debug.Log(debugText);
    }
    
    // 1�̒l���i�[����Ă���C���f�b�N�X���擾���鏈��
    int GetPlayerIndex()
    {
        // �v�f����map.Length�Ŏ擾
        for (int i = 0; i < map.GetLength(1); i++)
        {
            if (map[i, 0] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    // �ړ��̉s�𔻒f���Ĉړ����s������
    bool MoveNumber(int number, int moveFrom,int moveTo)
    {
        // �����Ȃ��������ɏ����A���^�[������A�������^�[��
        // �ړ��悪�͈͊O�ł���Έړ��ł��Ȃ�
        if (moveTo < 0 || moveTo >= map.Length){ return false;}
        //�ړ���ɔ�(2)��������
        if (map[moveTo,0] == 2)
        {
            // �ǂ̕����Ɉړ����邩���Z�o
            int velocity = moveTo - moveFrom;
            // �v���C���[�̈ړ��悩��A����ɐ�֔�(2)���ړ�������
            // ���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h���Ăяo��
            // �ړ��s��bool�ŋL�^
            bool succes = MoveNumber(2, moveTo, moveTo + velocity);
            // �������̈ړ����ł��Ȃ���΃v���C���[���ړ����Ȃ�
            if (!succes) { return false; }
        }

        // �v���C���[
        map[moveTo,0] = number;
        map[moveFrom, 0] = 0;
        return true;
    }

    // �z��̐錾
    int[,] map;

    // Start is called before the first frame update
    void Start()
    {
        // �z��̎��Ԃ̍쐬�Ə�����
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

        // �E�����ւ̈ړ�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }

        // �������ւ̈ړ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }
}
