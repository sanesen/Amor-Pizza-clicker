using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ShopItemModel
{
    public string navn;
    public float pris;
    public Sprite ikon;
    public int clickPowerIncrease, moneyPerSecondIncrease;
    public int level = 1;
    public float prisStigning = 1.5f;
}
