using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]private LayerMask groundLayer;
    private Rigidbody2D rB;
    private float horInput;
    private bool IsGrounded;
    private Animator anim;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Controls();
        AnimParams();
    }

    public void Controls()
    {
        horInput = Input.GetAxis("Horizontal");

        rB.velocity = new Vector2(horInput * speed, rB.velocity.y);

        if (horInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }
    }

    public void AnimParams()
    {
        anim.SetBool("Run", horInput != 0);
        anim.SetBool("Grounded", IsGrounded);
    }

    public void Jump()
    {
        rB.velocity = new Vector2(rB.velocity.x, speed);
        IsGrounded = false;
        anim.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    public bool Attack()
    {
        return horInput == 0 && IsGrounded;
    }
}
