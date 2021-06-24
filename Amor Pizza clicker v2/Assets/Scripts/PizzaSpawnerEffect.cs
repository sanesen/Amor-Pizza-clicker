using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSpawnerEffect : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 forceMin, forceMax;
    public float multiplier = 10;
    public void spawnPizza()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 1;

        GameObject pizza = Instantiate(prefab, mousePosition, Quaternion.identity);
        Vector3 force = new Vector3(Random.Range(forceMin.x, forceMax.x), Random.Range(forceMin.y, forceMax.y),0);
        pizza.GetComponent<Rigidbody2D>().AddForce(force*multiplier);
        Destroy(pizza, 3);
    }
}
