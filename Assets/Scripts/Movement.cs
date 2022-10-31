using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]private LayerMask groundLayer;
    private Rigidbody2D rB;
    private float dirX;
    private bool IsGrounded;
    private Animator anim;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Controls();
        AnimParams();
    }

    public void Controls()
    {
        dirX = Input.GetAxis("Horizontal") * speed;

        rB.velocity = new Vector2(dirX, rB.velocity.y);

        if (dirX > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (dirX < -0.01f)
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
        anim.SetBool("Run", dirX != 0);
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
        return dirX == 0 && IsGrounded;
    }
}
