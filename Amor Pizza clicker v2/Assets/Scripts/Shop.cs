using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<ShopItemModel> items;
    public GameObject shopPrefab;
    public GameObject content;

    public void onPurchase(int index)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject shopItem = Instantiate(shopPrefab, content.transform);
            shopItem.GetComponent<ShopItem>().init(items[i]);
        }
    }
}
