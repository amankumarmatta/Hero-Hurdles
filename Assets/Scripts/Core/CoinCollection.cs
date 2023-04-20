using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI coinsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coin++;
            coinsText.text = coin.ToString();
            Destroy(this.gameObject);
        }
    }
}
