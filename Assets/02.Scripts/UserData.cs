using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string playername = "이유진";
    public int cashmoney = 100000;
    public int passbookmoney= 50000;

    // 생성자
    public UserData(string name, int cash, int passbook)
    {
        playername = name;
        cashmoney = cash;
        passbookmoney = passbook;
    }
}