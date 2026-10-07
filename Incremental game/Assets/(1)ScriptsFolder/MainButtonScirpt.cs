using UnityEngine;

public class MainButtonScirpt : MonoBehaviour
{
    [SerializeField] float baseValue = 1f;
    [SerializeField] float multiplier = 1f;

    BuffActivePlayer buffActivePlayer;
    private void Awake()
    {
        buffActivePlayer = GameObject.Find("GameManager").GetComponent<BuffActivePlayer>();
    }

    public void EarnFromClick()
    {
        CurrencyManager.currencyManagerInstance.GainCoin(baseValue * multiplier);
        buffActivePlayer.ActivateBuff();
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
