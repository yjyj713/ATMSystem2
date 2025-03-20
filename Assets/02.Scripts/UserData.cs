using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string playername;
    public int cashmoney;
    public int passbookmoney;

    //�⺻������
    public UserData(string name, int cash, int passbook)
    {
        playername = name;
        cashmoney = cash;
        passbookmoney = passbook;
    }

    //�⺻�� ����
    public void InitializeData(string name = "������", int cash = 100000, int passbook = 50000)
    {
        playername = name;
        cashmoney = cash;
        passbookmoney = passbook;
    }
}