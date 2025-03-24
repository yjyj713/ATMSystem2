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
            Debug.LogWarning("다수의 게임매니저 존재");
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
        Debug.Log("저장 성공");
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("불러오기 성공");
        }
        else
        {
            userData = new UserData("이유진", 100000, 50000, null,null);
            Debug.Log("불러오기 실패. 저장된 데이터 없음. 기본값 적용");
        }

        if (UserInfo.Instance != null) //불러온 데이터로 UI 갱신
        {
            UserInfo.Instance.UpdateUI();
        }
    }

}
