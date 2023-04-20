using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int numCoins;

    void Start()
    {
        for (int i = 0; i < numCoins; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Instantiate(coinPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
        }
    }
}
