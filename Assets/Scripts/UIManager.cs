using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject clickerWatermelon = null;

    [SerializeField]
    private GameObject shopPanel = null;

    public void OnClickWatermelon()
    {
        clickerWatermelon.GetComponent<Animator>().Play("Clicker", -1, 0f);
        GameManager.Instance.playerData.watermelonAmount += GameManager.Instance.playerData.wmPerClick;
        GameManager.Instance.UpdateUI();
    }

    public void OnCloseShop()
    {
        shopPanel.transform.Translate(Vector3.left * 10);
    }

    public void OnActiveShop()
    {
        shopPanel.transform.Translate(Vector3.right * 10);
    }
}
