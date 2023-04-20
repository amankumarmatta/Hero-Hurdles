using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    public int coinsCollected = 0;
    public TextMeshProUGUI coinText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            Destroy(collision.gameObject);
            UpdateCoinText();
        }
    }

    void UpdateCoinText()
    {
        coinText.text = coinsCollected.ToString();
    }
}
