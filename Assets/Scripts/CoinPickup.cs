using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip coinSound; // the audio clip to play when the player picks up a coin

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position); // play the coin sound
            Destroy(gameObject); // destroy the coin object
        }
    }
}
