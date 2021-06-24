using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public TextMeshProUGUI navn;
    public TextMeshProUGUI pris;
    public Image ikon;
    public ShopItemModel model;
    public TextMeshProUGUI level;
    
    
    public void init(ShopItemModel _model)
    {
        model = _model;
        updateUI();
    }

    void updateUI()
    {
        navn.text = model.navn;
        ikon.sprite = model.ikon;
        level.text = "Lvl. " + model.level.ToString();

        if (model.pris<1000)
        {
            pris.text = model.pris.ToString() + "$";
        }

        else if (model.pris>=1000)
        {
            decimal prisConverted = (decimal)model.pris;
            pris.text = decimal.Round(prisConverted/1000, 0).ToString()+"K$";
        }
    }

    public void onClick()
    {
        if (GameManager.instance.money>=model.pris)
        {
            GameManager.instance.changeMoney(-model.pris/(GameManager.instance.powerActive()?GameManager.instance.powerUpgrade:1));
            GameManager.instance.clickUpgrade += model.clickPowerIncrease;
            GameManager.instance.moneyPerSecond += model.moneyPerSecondIncrease;
            model.pris = Mathf.FloorToInt(model.pris*model.prisStigning);
            model.level++;
            updateUI();
        }
    }
}
