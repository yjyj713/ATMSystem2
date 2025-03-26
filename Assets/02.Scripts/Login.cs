using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.VersionControl;

public class LogIn : MonoBehaviour
{
    GameManager gameManager;
    UserData userData;
    UserInfo userInfo;

    private string currentErrorMessage = ""; //���� �޽��� ����

    public GameObject UserInfo, Cash, ATM, Login, PopupSignUp, PopupError, PopupBank, PopupLoginError;

    public Button LoginBtn, SignUpBtn, CancelBtn, SignUPUPBtn, OKBtn, LoginErrorOkBtn;
    public InputField IDInputField, PWInputField;
    public InputField SignIDInputField, SignNameInputField, SignPWInputField, SignPWCofirmInputField;
    public Text ErrorText;

    public void Awake()
    {
        LoginBtn = transform.Find("LoginBtn").GetComponent<Button>();
        SignUpBtn = transform.Find("SignUpBtn").GetComponent<Button>(); //�α���â������ ȸ�����Թ�ư
        CancelBtn = transform.Find("PopupSignUp/Panel/CancelBtn").GetComponent<Button>();
        SignUPUPBtn = transform.Find("PopupSignUp/Panel/SignUpBtn").GetComponent<Button>(); //ȸ������â������ ȸ�����Թ�ư
        OKBtn = transform.Find("PopupSignUp/Panel/Panel/PopupError/Panel/OKBtn").GetComponent<Button>();
        LoginErrorOkBtn = transform.Find("PopupLoginError/Panel/OKBtn").GetComponent<Button>();

        IDInputField = transform.Find("ID/IDInputField").GetComponent<InputField>();
        PWInputField = transform.Find("PW/PWInputField").GetComponent<InputField>();

        LoginBtn.onClick.AddListener(LoginBtnClick);
        SignUpBtn.onClick.AddListener(SighUpBtnClick);
        LoginErrorOkBtn.onClick.AddListener(LoginErrorOkBtnClick);

        CancelBtn.onClick.AddListener(ClosePopupSignUp);
        OKBtn.onClick.AddListener(ClosePopupError);

        SignUpBtn.onClick.AddListener(() => PopupSignUp.SetActive(true));
        SignUPUPBtn.onClick.AddListener(SignUp);
        CancelBtn.onClick.AddListener(() => PopupSignUp.SetActive(false));

        SignIDInputField = transform.Find("PopupSignUp/Panel/ID/InputField").GetComponent<InputField>();
        SignNameInputField = transform.Find("PopupSignUp/Panel/Name/InputField").GetComponent<InputField>();
        SignPWInputField = transform.Find("PopupSignUp/Panel/PW/InputField").GetComponent<InputField>();
        SignPWCofirmInputField = transform.Find("PopupSignUp/Panel/PWConfirm/InputField").GetComponent<InputField>();
        
    }
    
    private void SignUp()
    {
        string id = SignIDInputField.text.Trim();
        string name = SignNameInputField.text.Trim();
        string pw = SignPWInputField.text;
        string pwConfirm = SignPWCofirmInputField.text;

        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pw) || string.IsNullOrEmpty(pwConfirm))
        {
            ShowError("��� �ʵ带 �Է����ּ���.");
            return;
        }
        if(pw != pwConfirm)
        {
            ShowError("��й�ȣ�� ��ġ���� �ʽ��ϴ�.");     
            return;
        }

        string filePath = GetUserFilePath(id); //filePath����

        if (File.Exists(filePath))
        {
            ShowError("�̹� �����ϴ� ID�Դϴ�.");
            return;
        }

        //���ο� ���� ������ ����
        UserData newUser = new UserData(name, 100000, 50000, id, pw);
        string json = JsonUtility.ToJson(newUser, true);

        //json ���Ϸ� ����
        File.WriteAllText(filePath, json);
        Debug.Log("ȸ������ ����");
        Debug.Log("����� ���: " + Application.persistentDataPath);
        ClosePopupSignUp();
    }

    //filePath������ ���� ����.
    private string GetUserFilePath(string id)
    {
        return Path.Combine(Application.persistentDataPath, $"{id}.json");
    }

    private void ShowError(string message)
    {
        currentErrorMessage = message;
        PopupError.SetActive(true);
    }
    private void ClosePopupSignUp()
    {
        PopupSignUp.gameObject.SetActive(false);
    }

    private void ClosePopupError()
    {
        PopupError.gameObject.SetActive(false);
        ErrorText.text = currentErrorMessage;
    }

    private void LoginBtnClick()
    {
        string id = IDInputField.text.Trim();
        string pw = PWInputField.text.Trim();

        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            PopupLoginError.gameObject.SetActive(true);
            return;
        }

        string filePath = GetUserFilePath(id);
        
        if(!File.Exists(filePath))
        {
            PopupLoginError.gameObject.SetActive(true);
            return;
        }

        string json = File.ReadAllText(filePath);
        UserData userData = JsonUtility.FromJson<UserData>(json);

        if (userData.PW != pw)
        {
            PopupLoginError.gameObject.SetActive(true);
            return;
        }

        LoadPopupBank(userData);
    }

    private void LoadPopupBank(UserData userData)
    {
        Login.gameObject.SetActive(false);
        PopupBank.gameObject.SetActive(true);
        UserInfo.gameObject.SetActive(true);
        Cash.gameObject.SetActive(true);
        ATM.gameObject.SetActive(true);
    }


    private void LoginErrorOkBtnClick()
    {
        PopupLoginError.gameObject.SetActive(false);
    }

    private void SighUpBtnClick()
    {
        PopupSignUp.gameObject.SetActive(true);
    }

}
