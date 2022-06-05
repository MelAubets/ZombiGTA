using System.Collections;
using UnityEngine;

public class WanderHealth : MonoBehaviour
{
    public float health = 1f;
    public int rand;
    public Animator animator;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Dead();
        } 
    }

    private void Dead()
    {
        animator.SetBool("isDying", true);
        Destroy(gameObject, 3f);
    }


}
