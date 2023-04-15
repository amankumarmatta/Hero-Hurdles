using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    public Rigidbody rB;
    public BoxCollider2D boxCollider;

    void Start()
    {
        rB = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
}