using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;
    public BoxCollider bx;
    private bool menu;
    int jumptime = 0;
    int lefttime = 0;
    int righttime = 0;
    int extrajumptime = 0;
    float bxy;
    float w;
    static float jumpingFunc(float x, float s)
    {
        float y;
        float a = 14f;
        x *= a / (2 * s);
        y = (-1)*(x * (x - a) * (1f / 40f));
        return y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        menu = animator.GetBool("Menu");
        if (Input.GetKeyDown(KeyCode.A) && lefttime == 0 && menu == false)
        {
            lefttime = 30 - righttime;
            righttime = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) && righttime == 0 && menu == false)
        {
            righttime = 30 - lefttime;
            lefttime = 0;
        }
        if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && menu == false)
            && animator.GetBool("Run") == false)
        {
            animator.SetBool("Run", true);
            extrajumptime = 22 + ((int)(Mathf.Sqrt(Time.deltaTime) * 25));
        }
        if (Input.GetKey(KeyCode.W) && extrajumptime == 0 && animator.GetBool("Run") == true && menu == false)
        {
            bxy = bx.center.y;
            jumptime = 19;
            extrajumptime = 47 + (int)(Mathf.Sqrt(Time.deltaTime) * 50);
            animator.SetBool("Jump", true);
        }
        else if (menu == false)
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu == false)
            {
                animator.SetBool("Run", false);
                animator.SetBool("Menu", true);
            }
            else
            {
                animator.SetBool("Run", true);
                animator.SetBool("Menu", false);
            }
        }
    }
    void FixedUpdate()
    {
        if (menu == false)
        {
            if (jumptime <= 15 && jumptime > 0)
            {
                w = jumpingFunc(15 - jumptime, 15);
                bx.center = new Vector3(bx.center.x, (bxy + w), bx.center.z);
            }
            if (jumptime > 0)
            {
                transform.Translate(0f, 0.1f * (20f / 19) * (10f / 13f), 0f);
                jumptime--;
                if (jumptime == 0)
                {
                    jumptime = -19;
                }
            }
            if (jumptime < 0)
            {
                transform.Translate(0f, -0.1f * (20f / 19) * (10f / 13f), 0f);
                jumptime++;
                if (jumptime == 0)
                {
                    w = jumpingFunc(-jumptime, 19);
                    bx.center = new Vector3(bx.center.x, (bxy + w), bx.center.z);
                }
            }
            if (jumptime >= -19 && jumptime < 0)
            {
                w = jumpingFunc(-jumptime, 19);
                bx.center = new Vector3(bx.center.x, (bxy + w), bx.center.z);
            }
            if (extrajumptime > 0)
            {
                extrajumptime--;
            }
            if (lefttime > 0)
            {
                transform.Translate(-0.10233f, 0, 0);
                lefttime--;
            }
            if (righttime > 0)
            {
                transform.Translate(0.10233f, 0, 0);
                righttime--;
            }
        }
    }
}
