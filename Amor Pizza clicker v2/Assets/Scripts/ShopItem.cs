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
    int superPowerChanceMaxStart = GameManager.instance.superPowerChanceMax;


    public void init(ShopItemModel _model)
    {
        model = _model;
        updateUI();
    }

    void updateUI()
    {
        navn.text = model.navn;
        ikon.sprite = model.ikon;
        if (model.level == superPowerChanceMaxStart)
        {
            level.text = "Max level";
        }
        else
        {
            level.text = "Lvl. " + model.level.ToString();
        }

        if (model.pris < 1000)
        {
            pris.text = model.pris.ToString() + "$";
        }

        else if (model.pris >= 1000)
        {
            decimal prisConverted = (decimal)model.pris;
            pris.text = decimal.Round(prisConverted / 1000, 0).ToString() + "K$";
        }
    }

    public void onClick()
    {
        if (model.level < superPowerChanceMaxStart)
        {
            if (GameManager.instance.superPowerChanceMax > model.superPowerChanceIncrease)
            {
                if (GameManager.instance.money >= model.pris)
                {
                    if (GameManager.instance.powerActive())
                    {
                        if (GameManager.instance.superPower == 1)
                        {
                            GameManager.instance.changeMoney(-model.pris / GameManager.instance.superPowerUpgrade);
                        }
                        else
                        {
                            GameManager.instance.changeMoney(-model.pris / GameManager.instance.powerUpgrade);
                        }
                    }
                    else
                    {
                        GameManager.instance.changeMoney(-model.pris);
                    }

                    GameManager.instance.clickUpgrade += model.clickPowerIncrease;
                    GameManager.instance.moneyPerSecond += model.moneyPerSecondIncrease;
                    if (GameManager.instance.superPowerChanceMax > model.superPowerChanceIncrease)
                    {
                        GameManager.instance.superPowerChanceMax -= model.superPowerChanceIncrease;
                    }

                    model.pris = Mathf.FloorToInt(model.pris * model.prisStigning);
                    if (model.level < superPowerChanceMaxStart)
                    {
                        model.level++;
                    }

                    updateUI();
                }
            }

        }

    }
}
