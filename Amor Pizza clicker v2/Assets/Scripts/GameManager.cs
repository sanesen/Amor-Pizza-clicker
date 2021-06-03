using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float money = 0f;
    public int clickUpgrade = 1;
    public int moneyPerSecond = 0;
    public TextMeshProUGUI[] moneyText;
    public float currentPowerFill;
    public float maxPowerFill = 10;
    public Image powerProgress;

    public static GameManager instance;

    private void Start()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        changeMoney(moneyPerSecond * Time.deltaTime);
        powerProgress.fillAmount = currentPowerFill / maxPowerFill;
    }

    public void changeMoney(float amount)
    {
        money += amount;

        decimal moneyConverted = (decimal)money;
        string formatedMoney = decimal.Round(moneyConverted, 0).ToString() + "$";
        if (money>=1000)
        {
            formatedMoney = decimal.Round(moneyConverted / 1000, 2).ToString() + "K$";
        }

        if (money >= 1000000)
        {
            formatedMoney = decimal.Round(moneyConverted / 1000000, 2).ToString() + "M$";
        }

        if (money >= 1000000000)
        {
            formatedMoney = decimal.Round(moneyConverted / 1000000000, 2).ToString() + "B$";
        }

        foreach (TextMeshProUGUI text in moneyText)
        {
            text.text = formatedMoney;
        }
    }
}
