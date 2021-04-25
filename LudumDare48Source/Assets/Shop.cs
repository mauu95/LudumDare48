using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public int money;
    public int price;

    private GameObject player;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public void OpenShop(){
        shopUI.SetActive(true);
    }

    public void HealPlayer(){
        player.GetComponent<PlayerLifeManager>().FillLife();
        spendMoney(price);
    }

    public void IncreaseLightRadius(){
        player.GetComponent<PlayerStats>().IncreaseLightRadius();
        spendMoney(price);
    }

    public void addMoney(){
        addMoney(1);
    }

    public void addMoney(int amount){
        money += amount;

        if(money >= price){
            OpenShop();
        }
    }

    public void spendMoney(int amount){
        if(money - amount >= 0)
            money -= amount;
    }

    public void spendMoney(){
        spendMoney(price);
    }
}
