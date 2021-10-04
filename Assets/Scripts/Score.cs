using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text score;
    Animator animator;
    void Start()
    {
        score = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    private float tempBananaScore = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (tempBananaScore != GameManager.instance.banana_Score) // if local score doesnt match gm score.
        {
            animator.Play("Show_Hud", 0, 0.0f); // show the hud
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Show_Hud")) // if the hud is already being shown.
                animator.Play("Show_Hud",0,0.2f); // show the hud from the middle.
        }
        score.text = ":" + GameManager.instance.banana_Score.ToString() + "/20"; // write score to ui.
        tempBananaScore = GameManager.instance.banana_Score; // set local score to gm score. 
    }
}
