using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField]
    private int index = 0;
    [SerializeField]
    private int earnPerSeconds = 0;
    [SerializeField]
    private int price = 0;
    [SerializeField]
    private int priceAdd = 0;
    [SerializeField]
    private Text priceText = null;
    [SerializeField]
    private Text earnText = null;
    [SerializeField]
    private Text itemAmount = null;

    private void Start()
    {
        earnText.text = string.Format("{0}", earnPerSeconds);
        priceText.text = string.Format("Price : {0}", price);
        itemAmount.text = string.Format("Have {0}", GameManager.Instance.playerData.itemAmount);
        StartCoroutine(EarnPerSeconds());
        price = GameManager.Instance.playerData.itemPrice;
    }
    public void OnPurchase()
    {
        if (GameManager.Instance.playerData.watermelonAmount < price) return;
        GameManager.Instance.playerData.watermelonAmount -= price;
        GameManager.Instance.playerData.itemAmount++;
        price += priceAdd;
        priceText.text = string.Format("Price : {0}", price);
        itemAmount.text = string.Format("Have {0}", GameManager.Instance.playerData.itemAmount);
        GameManager.Instance.playerData.itemPrice = price;
        GameManager.Instance.UpdateUI();
    }

    private IEnumerator EarnPerSeconds()
    {
        while (true)
        {
            GameManager.Instance.playerData.watermelonAmount += earnPerSeconds * 
                GameManager.Instance.playerData.itemAmount;
            GameManager.Instance.UpdateUI();
            yield return new WaitForSeconds(1f);
        }
    }
}
