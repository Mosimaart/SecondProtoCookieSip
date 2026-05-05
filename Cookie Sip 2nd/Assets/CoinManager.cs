using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int coins = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}