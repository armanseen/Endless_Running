using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 v3;
    public Animator animator;
    public BoxCollider bx;
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
        if (Input.GetKeyDown(KeyCode.A) && lefttime == 0)
        {
            lefttime = 30 - righttime;
            righttime = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) && righttime == 0)
        {
            righttime = 30 - lefttime;
            lefttime = 0;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.W) && extrajumptime == 0)
        {
            bxy = bx.center.y;
            jumptime = 19;
            extrajumptime = 50;
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            animator.SetBool("Run", false);
        }
    }
    void FixedUpdate()
    {
        if (jumptime <= 15 && jumptime > 0)
        {
            w = jumpingFunc(15 - jumptime, 15);
            bx.center = new Vector3(bx.center.x, (bxy + w), bx.center.z);
        }
        if (jumptime > 0)
        {
            transform.Translate(0f, 0.1f * (20f/19) * (40f / 52f), 0f);
            jumptime--;
            if (jumptime == 0)
            {
                jumptime = -19;
            }
        }
        if (jumptime < 0)
        {
            transform.Translate(0f, -0.1f * (20f / 19) * (40f / 52f), 0f);
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
