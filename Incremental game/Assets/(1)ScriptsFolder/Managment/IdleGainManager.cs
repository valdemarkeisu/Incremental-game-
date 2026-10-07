using UnityEngine;
using TMPro;

public class IdleGainManager : MonoBehaviour
{
    [SerializeField] public float globalMultiplier;


    [SerializeField] public  int idleGainAmount = 0;
    [SerializeField] float timeBetwenIdleGain = 1f;

    float nextIdleCheck = 0f;

    TMP_Text cpsText;


    private void Awake()
    {
        SetCpsText();
        UpdateCpsText();
    }

    private void Update()
    {
        IdleGain();      
    }

    void IdleGain()
    {   
        if (Time.time >= nextIdleCheck)
        {
            CurrencyManager.currencyManagerInstance.GainCoin(idleGainAmount * globalMultiplier);
            nextIdleCheck = Time.time + timeBetwenIdleGain;           
        }        
    }

    public void UpdateCpsText()
    {
        if (cpsText != null)
        {
            cpsText.text = ("CPS:" + (idleGainAmount * globalMultiplier).ToString());
        }
    }
    void SetCpsText()
    {
        GameObject cpsTextObj = GameObject.Find("CpsText");
        if (cpsTextObj != null)
        {
            cpsText = cpsTextObj.GetComponent<TMP_Text>();
        }
        else { Debug.LogError("CpsText object not found"); }
    }
}
