using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private Movement movement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }
}
