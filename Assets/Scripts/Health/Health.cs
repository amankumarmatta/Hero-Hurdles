using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool isDead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            anim.SetTrigger("Dead");
            GetComponent<Movement>().enabled = false;
            isDead = true;
        }
    }
}
