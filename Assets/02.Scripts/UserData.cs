using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string playername;
    public int cashmoney;
    public int passbookmoney;

    //기본생성자
    public UserData(string name, int cash, int passbook)
    {
        playername = name;
        cashmoney = cash;
        passbookmoney = passbook;
    }

    //기본값 설정
    public void InitializeData(string name = "이유진", int cash = 100000, int passbook = 50000)
    {
        playername = name;
        cashmoney = cash;
        passbookmoney = passbook;
    }
}