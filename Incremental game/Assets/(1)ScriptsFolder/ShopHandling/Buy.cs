using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] GameObject itemBaught;

    public void BuyItem()
    {
        if(itemBaught != isActiveAndEnabled)
        {
            itemBaught.SetActive(true);
            itemBaught.GetComponent<Building>().BuyThisBuilding();
        }
        else
        {
            itemBaught.GetComponent<Building>().BuyThisBuilding();
        }
    }



}
