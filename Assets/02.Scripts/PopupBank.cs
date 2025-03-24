using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    GameManager gameManager;
    UserInfo userInfo;
    UserData userData;

    public Button DepositBtn, WithdrawalBtn;
    public Button DepositBackBtn, WithdrawalBackBtn;

    public Button Money1, Money2, Money3, Money4, Money5, Money6;
    public Button CustomBtn1, CustomBtn2;

    public InputField InputField1, InputField2;

    public GameObject Deposit, Withdrawal, ATM, PopupError;
    public Text ErrorText;
    public Button OKBtn;

    public void Awake()
    {
        DepositBtn = transform.Find("ATM/DepositButton").GetComponent<Button>();
        WithdrawalBtn = transform.Find("ATM/WithdrawalButton").GetComponent<Button>();
        DepositBackBtn = transform.Find("Deposit/DepositBack_Btn").GetComponent<Button>();
        WithdrawalBackBtn = transform.Find("Withdrawal/WithdrawalBack_Btn").GetComponent<Button>();

        Money1 = transform.Find("Deposit/Money1").GetComponent<Button>();
        Money2 = transform.Find("Deposit/Money2").GetComponent<Button>();
        Money3 = transform.Find("Deposit/Money3").GetComponent<Button>();
        Money4 = transform.Find("Withdrawal/Money4").GetComponent<Button>();
        Money5 = transform.Find("Withdrawal/Money5").GetComponent<Button>();
        Money6 = transform.Find("Withdrawal/Money6").GetComponent<Button>();

        CustomBtn1 = transform.Find("Deposit/CustomMoney/CustomButton1").GetComponent<Button>();
        CustomBtn2 = transform.Find("Withdrawal/CustomMoney/CustomButton2").GetComponent<Button>();

        InputField1 = transform.Find("Deposit/CustomMoney").GetComponent<InputField>();
        InputField2 = transform.Find("Withdrawal/CustomMoney").GetComponent<InputField>();

        InputField1.onValueChanged.AddListener(delegate { OnlyNum(InputField1); });
        InputField2.onValueChanged.AddListener(delegate { OnlyNum(InputField2); });

        Money1.onClick.AddListener(() => Depositt(10000));
        Money2.onClick.AddListener(() => Depositt(30000));
        Money3.onClick.AddListener(() => Depositt(50000));

        Money4.onClick.AddListener(() => Withdrawall(10000));
        Money5.onClick.AddListener(() => Withdrawall(30000));
        Money6.onClick.AddListener(() => Withdrawall(50000));

        CustomBtn1.onClick.AddListener(CustomDepositt);
        CustomBtn2.onClick.AddListener(CustomWithdrawall);

        DepositBtn.onClick.AddListener(DepositBtnClick);
        WithdrawalBtn.onClick.AddListener(WithdrawalBtnClick);
        DepositBackBtn.onClick.AddListener(DepositBackBtnClick);
        WithdrawalBackBtn.onClick.AddListener(WithdrawalBackBtnClick);

        //팝업에러
        PopupError = transform.Find("PopupError").gameObject;
        ErrorText = PopupError.transform.Find("Panel/ErrorText").GetComponent<Text>();
        OKBtn = PopupError.transform.Find("Panel/OKBtn").GetComponent<Button>();
        OKBtn.onClick.AddListener(ClosePopupError);
        PopupError.SetActive(false);
    }
    private void OnlyNum(InputField input)
    {
        string newText = "";
        foreach (char c in input.text)
        {
            if (char.IsDigit(c)) //숫자인경우만추가
                newText += c;
        }
        input.text = newText;  // 숫자가 아닌 문자는 삭제
    }
    private void DepositBtnClick()
    {
        Deposit.gameObject.SetActive(true);
        ATM.gameObject.SetActive(false);
    }
    private void WithdrawalBtnClick()
    {
        Withdrawal.gameObject.SetActive(true);
        ATM.gameObject.SetActive(false);
    }

    private void DepositBackBtnClick()
    {
        Deposit.gameObject.SetActive(false);
        ATM.gameObject.SetActive(true);
    }
    private void WithdrawalBackBtnClick()
    {
        Withdrawal.gameObject.SetActive(false);
        ATM.gameObject.SetActive(true);
    }

    public void Depositt(int amount) //입금기능
    {
        if(GameManager.Instance.userData.cashmoney >= amount)
        {
            GameManager.Instance.userData.cashmoney -= amount;
            GameManager.Instance.userData.passbookmoney += amount;
            UserInfo.Instance.UpdateUI();
        }
        else
        {
            ShowError("현금이 부족합니다.");
        }
    }
    private void Withdrawall(int amount) //출금기능
    {
        if (GameManager.Instance.userData.passbookmoney >= amount)
        {
            GameManager.Instance.userData.passbookmoney -= amount;
            GameManager.Instance.userData.cashmoney += amount;
            UserInfo.Instance.UpdateUI();
        }
        else
        {
            ShowError("은행 잔고가 부족합니다");
        }
    }
    private void CustomDepositt() //커스텀입금
    {
        if (int.TryParse(InputField1.text, out int amount))
        {
            Depositt(amount);
        }
        else
        {
            ShowError("올바른 금액을 입력하세요");
        }
    }

    private void CustomWithdrawall() //커스텀 출금
    {
        if (int.TryParse(InputField2.text, out int amount))
        {
            Withdrawall(amount);
        }
        else
        {
            ShowError("올바른 금액을 입력하세요!");
        }
    }
    private void ShowError(string message)
    {
        ErrorText.text = message;
        PopupError.SetActive(true);
    }

    private void ClosePopupError()
    {
        PopupError.SetActive(false);
    }
}
