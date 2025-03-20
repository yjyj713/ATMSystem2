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

    //유저데이터 클래스를 만들면서 변수 정의 중복으로 필요없음.
    public string playername = "이유진";
    public int cashmoney = 100000;
    public int passbookmoney = 50000;

    void Start()
    {
        userData = new UserData(playername, cashmoney, passbookmoney);
        UpdateUI(); //UI 초기 갱신

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
