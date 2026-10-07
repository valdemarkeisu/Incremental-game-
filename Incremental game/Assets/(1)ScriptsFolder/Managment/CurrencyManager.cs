using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager currencyManagerInstance;

    TMP_Text coinText;

    [SerializeField] public static int currencyAmount = 0;

    private void Awake()
    {
        if (currencyManagerInstance == null) {currencyManagerInstance = this; }
        else { Destroy(gameObject);}

        SetTexts();
        UpdateCoinText();
    }
    public void GainCoin(float amountGained)
    {
        currencyAmount += (int)amountGained;
        UpdateCoinText();
    }

    public void LoseCoin(float amountSpent)
    {
        if (currencyAmount >= 0 + amountSpent)
        {
            currencyAmount -= (int)amountSpent;
            UpdateCoinText();
        }
    }

    public void ResetCoins()
    {
        currencyAmount = 0;
        UpdateCoinText();
    }


    void SetTexts()
    {
        GameObject coinTextObj = GameObject.Find("CoinText");

        if(coinTextObj != null)
        {
            coinText = coinTextObj.GetComponent<TMP_Text>();
        }
        else {Debug.LogError("CoinText object not found"); 
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = ("Coin:" + currencyAmount.ToString());
        }
    }
}
