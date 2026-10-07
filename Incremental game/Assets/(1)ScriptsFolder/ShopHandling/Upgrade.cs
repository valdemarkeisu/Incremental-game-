using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] int upgradeCost;
    [SerializeField] float baseValueModfier;
    [SerializeField] int multiplierModifier;

    GameObject mainButton;
    private void Awake()
    {
        mainButton = GameObject.Find("MainButton");
    }
    public void UpgradeMainButon()
    {
        if (mainButton != null)
        {
            mainButton.GetComponent<MainButtonScirpt>().UpgradeBaseValue(baseValueModfier);
            mainButton.GetComponent<MainButtonScirpt>().UpgradeMultiplier(multiplierModifier);
        }
    }
}
