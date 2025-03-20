using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("다수의 게임매니저 존재");
            Destroy(gameObject);
        }

        userData = new UserData(userData.playername, userData.cashmoney, userData.passbookmoney);
    }
       
}
