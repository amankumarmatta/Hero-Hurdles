using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    private PlayerControls controls;
    private Animator anim;
    private bool isGrounded;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        controls = new PlayerControls();
        controls.Enable();

        controls.Move.Shoot.performed += ctx => AttackMode();     
    }

    private void AttackMode()
    {
        if (isGrounded == true)
        {
            anim.SetTrigger("Attack");               
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}