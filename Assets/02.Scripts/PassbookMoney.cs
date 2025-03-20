using UnityEngine;
using UnityEngine.UI;

public class PassbookMoney : MonoBehaviour
{
    [SerializeField] Text passbook;

    public void Passbook(int money)
    {
        if (money <= 0)
        {
            passbook.text = "0";
            return;
        }
        passbook.text = string.Format("{0:#,###}", money);
    }

    void Start()
    {
        Passbook(50000);
    }
}