using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    PizzaSpawnerEffect pizzaSpawner;
    // Start is called before the first frame update
    void Start()
    {
        pizzaSpawner = FindObjectOfType<PizzaSpawnerEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameManager.instance.changeMoney(GameManager.instance.clickUpgrade);
        if (!GameManager.instance.powerActive())
        {
            GameManager.instance.currentPowerFill++;
        }
        pizzaSpawner.spawnPizza();
    }
    
}
