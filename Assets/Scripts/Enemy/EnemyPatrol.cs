using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private bool facingRight = true;

    private Animator anim;

    private Transform targetPoint;

    void Start()
    {
        // Start by moving towards point A
        targetPoint = pointA;
        anim = GetComponent<Animator>();
        anim.SetBool("Moving", true);
    }

    void Update()
    {
        // Calculate the distance to the target point
        float distance = Vector3.Distance(transform.position, targetPoint.position);

        // If we're close enough to the target point, switch to the other point
        if (distance < 0.1f)
        {
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
            }
            else
            {
                targetPoint = pointA;
            }

            Flip();
        }

        // Move towards the target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
    }

    void Flip()
    {
        // Flip the GameObject by reversing its scale on the X axis
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
