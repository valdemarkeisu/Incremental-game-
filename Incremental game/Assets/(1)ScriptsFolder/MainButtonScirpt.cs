using UnityEngine;

public class MainButtonScirpt : MonoBehaviour
{
    [SerializeField] float baseValue = 1f;
    [SerializeField] float multiplier = 1f;

    public void EarnFromClick()
    {
        CurrencyManager.currencyManagerInstance.GainCoin(baseValue * multiplier);
    }

    public void UpgradeBaseValue(float amount)
    {
        baseValue += amount;
    }

    public void UpgradeMultiplier(float amount)
    {
        multiplier += amount;
    }

}
