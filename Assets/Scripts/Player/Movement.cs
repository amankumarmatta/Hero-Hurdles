using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;

    PlayerControls controls;
    private float direction = 0f;
    public float speed;
    public float JumpForce;

    private bool isGrounded = false;
    private bool isFacingRight = true;

    public Rigidbody2D rB;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Move.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Move.Jump.performed += ctx => Jump();
    }

    private void FixedUpdate()
    {
        rB.velocity = new Vector2(direction * speed, rB.velocity.y);

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }

        AnimParams();
    }

    private void AnimParams()
    {
        anim.SetFloat("Speed", Mathf.Abs(direction));
        anim.SetBool("Grounded", isGrounded);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    public void Jump()
    {
        if (isGrounded == true)
        {
            rB.velocity = new Vector2(rB.velocity.x, JumpForce);
        }
        isGrounded = false;
        anim.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
