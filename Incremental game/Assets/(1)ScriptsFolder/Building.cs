using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] int amountOwned;
    [SerializeField] int basePrice;

    [SerializeField] int price;

    [SerializeField] int baseProduction;
    [SerializeField] int extraProduction;
    [SerializeField] float productionMultiplier;

    [SerializeField] float priceFactor = 1.1f;

    int realProduction;
    int totalProduction;
    int lastaddedProduction;

    [SerializeField] TMP_Text amountText;
    [SerializeField] TMP_Text priceText;

    IdleGainManager idleManager;
    private void Awake()
    {
        idleManager = GameObject.Find("GameManager").GetComponent<IdleGainManager>();
        UpdatePriceText();

    }

    public void BuyThisBuilding()
    {
        
        if (CurrencyManager.currencyAmount >= price)
        {
            CurrencyManager.currencyManagerInstance.LoseCoin(price);
            amountOwned++;            
            ProductionUpdate();
            amountText.text = amountOwned.ToString();
            UpdatePriceText();
        }
    }

    public void ModifyBuilding(int extra, float multiplier)
    {
        extraProduction += extra;
        productionMultiplier += multiplier;
        ProductionUpdate();
    }

    void ProductionUpdate()
    {
        realProduction = (int) ((baseProduction + extraProduction) * productionMultiplier);
        totalProduction = realProduction * amountOwned;
        idleManager.idleGainAmount += totalProduction - lastaddedProduction;
        lastaddedProduction = totalProduction;
        idleManager.UpdateCpsText();    
    }

    void UpdatePriceText()
    {
        if (priceText != null)
        {
            if (amountOwned == 0)
            {
                price = basePrice;
            }
            else
            {
                price = (int)(basePrice * Mathf.Pow(priceFactor, amountOwned));
            }
            priceText.text = ("Price:" + price.ToString());
        }
    }



}
