using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private PlayerControls controls;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Movement movement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();

        controls = new PlayerControls();
        controls.Enable();

        controls.Move.Shoot.performed += ctx => AttackMode();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void AttackMode()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        //Object Pooling
        fireballs[FindFireBall()].transform.position = firePoint.position;
        fireballs[FindFireBall()].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}