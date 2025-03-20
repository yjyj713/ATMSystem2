using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    public static UserInfo Instance { get; private set; }

    [SerializeField] Text nameText;
    [SerializeField] Text cashmoneyText;
    [SerializeField] Text passbookmoneyText;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("�ټ��� �������� ����");
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        UpdateUI(); //UI �ʱ� ����
    }

    public void UpdateUI()
    {
        if (GameManager.Instance != null && GameManager.Instance.userData != null)
        {
            nameText.text = GameManager.Instance.userData.playername;
            cashmoneyText.text = string.Format("{0:#,###}", GameManager.Instance.userData.cashmoney);
            passbookmoneyText.text = string.Format("{0:#,###}", GameManager.Instance.userData.passbookmoney);
        }
    }
}
