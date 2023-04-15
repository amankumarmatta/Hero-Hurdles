using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallax;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallax;
        float temp = cam.transform.position.x * 1 - parallax;

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }

        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }

}
