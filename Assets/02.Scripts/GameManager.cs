using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UserData userData;

    private string savePath;

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
            return;
        }
        savePath = Path.Combine(Application.persistentDataPath, "SaveData.json");
        LoadUserData();
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("���� ����");
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("�ҷ����� ����");
        }
        else
        {
            userData = new UserData("������", 100000, 50000, null,null);
            Debug.Log("�ҷ����� ����. ����� ������ ����. �⺻�� ����");
        }

        if (UserInfo.Instance != null) //�ҷ��� �����ͷ� UI ����
        {
            UserInfo.Instance.UpdateUI();
        }
    }

}
