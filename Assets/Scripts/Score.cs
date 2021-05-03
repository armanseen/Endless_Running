using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Animator animator;
    public Text T;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        T.text = "Score : " + score;
    }
    void FixedUpdate()
    {
        if (animator.GetBool("Run") == true)
        {
            score++;
        }
    }
}
