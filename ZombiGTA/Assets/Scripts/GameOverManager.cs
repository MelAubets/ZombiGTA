using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    public Text state;
    public Animator animator;
    void Start()
    {
        state.text = "Game Over!";
        animator.SetBool("isLose", true);
    }

}
