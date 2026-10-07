using TMPro;
using UnityEngine;

public class BuffActivePlayer : MonoBehaviour
{
    [SerializeField] float buffDuration = 15f;
    [SerializeField] float buffStrength = 2f;

    float buffEndTime = 0f;

    [SerializeField] int clicksNeeded = 20;
    int currentClicks = 0;

    bool buffActive = false;

    IdleGainManager idleGainManager;
    [SerializeField] TMP_Text buffText;

    private void Awake()
    {
        idleGainManager = GameObject.Find("GameManager").GetComponent<IdleGainManager>();
        UpdateBuffText();
    }
    private void Update()
    {
        DeactivateBuff();
    }

    public void ActivateBuff()
    {
        if (!buffActive)
        {
            currentClicks++;
            if(currentClicks >= clicksNeeded)
            {
                buffActive = true;
                buffEndTime = Time.time + buffDuration;
                Buff();
            }
            UpdateBuffText();
        }
    }
    public void DeactivateBuff()
    {
        if (buffActive && Time.time >= buffEndTime)
        {
            buffActive = false;
            idleGainManager.globalMultiplier -= buffStrength;
            idleGainManager.UpdateCpsText();
            UpdateBuffText();
        }
    }

    void Buff()
    {       
        currentClicks = 0;
        idleGainManager.globalMultiplier += buffStrength; 
        idleGainManager.UpdateCpsText();
    }
    void UpdateBuffText()
    {
        if (buffActive)
        {
            buffText.text = "Buff Active!";
        }
        else
        {
            buffText.text = (currentClicks.ToString() + "/" + clicksNeeded.ToString());
        }
    }

}
