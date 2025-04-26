//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHP, currentHP;
    public float invincibleLen = 1f;
    private float invincCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        UIController.instance.healthSlider.maxValue = maxHP;
        UIController.instance.healthSlider.value = currentHP;
        UIController.instance.healthText.text = "HP: " + currentHP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
        
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0)
        {
            
            currentHP -= damageAmount;
            if(currentHP <= 0)
            {
                gameObject.SetActive(false);

                currentHP = 0;

                GameManager.Instance.PlayerDied();
            }

        invincCounter = invincibleLen;

            UIController.instance.healthSlider.value = currentHP;
            UIController.instance.healthText.text = "HP: " + currentHP;
        }
    }
}
