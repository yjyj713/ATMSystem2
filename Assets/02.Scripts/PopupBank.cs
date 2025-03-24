using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    GameManager gameManager;
    UserInfo userInfo;
    UserData userData;

    public Button DepositBtn, WithdrawalBtn;
    public Button DepositBackBtn, WithdrawalBackBtn;

    public GameObject Deposit, Withdrawal, ATM;

    public void Awake()
    {
        DepositBtn = transform.Find("ATM/DepositButton").GetComponent<Button>();
        WithdrawalBtn = transform.Find("ATM/WithdrawalButton").GetComponent<Button>();
        DepositBackBtn = transform.Find("Deposit/DepositBack_Btn").GetComponent<Button>();
        WithdrawalBackBtn = transform.Find("Withdrawal/WithdrawalBack_Btn").GetComponent<Button>();

        DepositBtn.onClick.AddListener(DepositBtnClick);
        WithdrawalBtn.onClick.AddListener(WithdrawalBtnClick);
        DepositBackBtn.onClick.AddListener(DepositBackBtnClick);
        WithdrawalBackBtn.onClick.AddListener(WithdrawalBackBtnClick);
    }

    public void DepositBtnClick()
    {
        Deposit.gameObject.SetActive(true);
        ATM.gameObject.SetActive(false);
    }
    public void WithdrawalBtnClick()
    {
        Withdrawal.gameObject.SetActive(true);
        ATM.gameObject.SetActive(false);
    }

    public void DepositBackBtnClick()
    {
        Deposit.gameObject.SetActive(false);
        ATM.gameObject.SetActive(true);
    }
    public void WithdrawalBackBtnClick()
    {
        Withdrawal.gameObject.SetActive(false);
        ATM.gameObject.SetActive(true);
    }


}
