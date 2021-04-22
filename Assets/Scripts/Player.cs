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
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Run", true);
        }
        if (/*Input.GetKey(KeyCode.Space) && */extrajumptime == 0)
        {
            bxy = bx.center.y;
            jumptime = 400;
            extrajumptime = 2500;
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        if (jumptime <= 250 && jumptime > 0)
        {
            w = jumpingFunc(250 - jumptime, 250);
            bx.center = new Vector3(bx.center.x, bxy + w, bx.center.z);
        }
        if (jumptime > 0)
        {
            transform.Translate(0f, 0.004f, 0f);
            jumptime--;
            if (jumptime == 0)
            {
                jumptime = -800;
            }
        }
        if (jumptime < 0)
        {
            transform.Translate(0f, -0.002f, 0f);
            jumptime++;
            if (jumptime == 0)
            {
                w = jumpingFunc(-jumptime, 400);
                bx.center = new Vector3(bx.center.x, bxy + w, bx.center.z);
            }
        }
        if (jumptime >= -400 && jumptime < 0)
        {
            w = jumpingFunc(-jumptime, 400);
            bx.center = new Vector3(bx.center.x, bxy + w, bx.center.z);
        }
        if (extrajumptime > 0)
        {
            extrajumptime--;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lefttime = 30;
        }
        if (lefttime > 0)
        {
            transform.Translate(-0.10233f, 0, 0);
            lefttime--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            righttime = 30;
        }
        if (righttime > 0)
        {
            transform.Translate(0.10233f, 0, 0);
            righttime--;
        }
    }
}
