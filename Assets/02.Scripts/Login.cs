using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    GameManager gameManager;
    UserData userData;

    public GameObject UserInfo, Cash, ATM, Login;

    public Button LoginBtn, SighUpBtn;
    public InputField IDInputField, PWInputField;

    public void Awake()
    {
        LoginBtn = transform.Find("Login/LoginButton").GetComponent<Button>();
        SighUpBtn = transform.Find("Login/SignUpButton").GetComponent<Button>();

        IDInputField = transform.Find("Login/ID/IDInputField").GetComponent<InputField>();
        PWInputField = transform.Find("Login/PW/PWInputField").GetComponent<InputField>();

        LoginBtn.onClick.AddListener(LoginBtnClick);
        SighUpBtn.onClick.AddListener(SighUpBtnClick);

        //IDInputField.onValueChanged.AddListener;
        
    }

    private void LoginBtnClick()
    {
        
    }

    private void SighUpBtnClick()
    {
        
    }
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
