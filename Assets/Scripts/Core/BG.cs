using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public float tileSize = 1.0f;
    private Vector2 spriteSize;

    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().sprite.bounds.size;
        transform.position = new Vector2(transform.position.x + spriteSize.x * transform.localScale.x, transform.position.y);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - scrollSpeed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -spriteSize.x * transform.localScale.x)
        {
            transform.position = new Vector2(transform.position.x + 2 * spriteSize.x * transform.localScale.x, transform.position.y);
        }
    }
}
