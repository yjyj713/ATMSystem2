using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text cashmoneyText;
    [SerializeField] Text passbookmoneyText;

    private UserData userData;

    //���������� Ŭ������ ����鼭 ���� ���� �ߺ����� �ʿ����.
    public string playername = "������";
    public int cashmoney = 100000;
    public int passbookmoney = 50000;

    void Start()
    {
        userData = new UserData(playername, cashmoney, passbookmoney);
        UpdateUI(); //UI �ʱ� ����

    }

    public void UpdateUI()
    {
        nameText.text = userData.playername;
        cashmoneyText.text = string.Format("{0:#,###}", userData.cashmoney);
        passbookmoneyText.text = string.Format("{0:#,###}", userData.passbookmoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
