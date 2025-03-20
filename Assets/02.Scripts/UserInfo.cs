using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text cashmoneyText;
    [SerializeField] Text passbookmoneyText;

    public Button descriptionButton; //입금버튼
    public Button withdrawalButton; //출금버튼

    public string playername = "이유진";
    public int cashmoney = 100000;
    public int passbookmoney = 50000;

    void Start()
    {
        UpdateUI(); //UI 초기 갱신

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
