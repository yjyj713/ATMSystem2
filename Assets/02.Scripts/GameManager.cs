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
            Debug.LogWarning("�ټ��� ���ӸŴ��� ����");
            Destroy(gameObject);
        }

        userData = new UserData(userData.playername, userData.cashmoney, userData.passbookmoney);
    }
       
}
