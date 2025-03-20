using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text cashmoneyText;
    [SerializeField] Text passbookmoneyText;

    public Button descriptionButton; //�Աݹ�ư
    public Button withdrawalButton; //��ݹ�ư

    public string playername = "������";
    public int cashmoney = 100000;
    public int passbookmoney = 50000;

    void Start()
    {
        UpdateUI(); //UI �ʱ� ����

    }

    public void UpdateUI()
    {
        nameText.text = playername;
        cashmoneyText.text = string.Format("{0:#,###}", cashmoney);
        passbookmoneyText.text = string.Format("{0:#,###}", passbookmoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
