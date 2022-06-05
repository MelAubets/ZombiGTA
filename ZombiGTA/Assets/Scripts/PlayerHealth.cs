using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Range(0f,100f)]
    public float health = 100f;
    public ProgressBar healthBar;
    public Animator animator;

    private void Start()
    {
        SetHealth();
    }

    private void Update()
    {
        SetHealth();
    }

    private void FixedUpdate()
    {
        animator.SetBool("Hurted", false);
    }

    public void TakeDamage(float damage)
    {
        animator.SetBool("Hurted", true);

        health -= damage;

        if(health <= 0)
            Dead();

    }

    public void Dead()
    {
        SceneManager.LoadScene(2);
    }

    public void SetHealth()
    {
        healthBar.BarValue = health;
    }

}
