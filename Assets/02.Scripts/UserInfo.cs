using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text cashmoneyText;
    [SerializeField] Text passbookmoneyText;

    void Start()
    {
        UpdateUI(); //UI 초기 갱신
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
