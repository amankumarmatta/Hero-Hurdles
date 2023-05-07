using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;

    [Header("IFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberofflashes;


    private SpriteRenderer spriteRenderer;
    public Button left, right, shoot, jump;
    

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine("Invulnerability");
        }
        else
        {
            left.GetComponent<Image>().raycastTarget = false;
            right.GetComponent<Image>().raycastTarget = false;            
            jump.GetComponent<Image>().raycastTarget = false;
            Debug.LogError("Buttons Disabled");
            GetComponent<Movement>().enabled = false;
            anim.SetTrigger("Dead");
            StartCoroutine("PlayerDied");
        }
        Debug.Log("TakeDamage");
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator PlayerDied()
    {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("GameOver");
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        for (int i = 0; i < numberofflashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberofflashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
}
