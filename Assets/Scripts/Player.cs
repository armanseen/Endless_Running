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
    int loc = 0;
    float bxy;
    float w;
    int fallLR = 0;
    bool menuflag = false;
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
        if (loc > 1 || loc < -1)
        {
            animator.SetBool("Fall", true);
        }
        menu = animator.GetBool("Menu");
        if (Input.GetKeyDown(KeyCode.A) && lefttime == 0 && menu == false && animator.GetBool("Fall") == false)
        {
            loc++;
            lefttime = 30 - righttime;
            righttime = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) && righttime == 0 && menu == false && animator.GetBool("Fall") == false)
        {
            loc--;
            righttime = 30 - lefttime;
            lefttime = 0;
        }
        if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && menu == false && animator.GetBool("Fall") == false)
            && animator.GetBool("Run") == false)
        {
            animator.SetBool("Run", true);
            menuflag = true;
            extrajumptime = 22 + ((int)(Mathf.Sqrt(Time.deltaTime) * 25));
        }
        if (Input.GetKey(KeyCode.W) && extrajumptime == 0 && animator.GetBool("Run") == true && menu == false && animator.GetBool("Fall") == false)
        {
            bxy = bx.center.y;
            jumptime = 19;
            extrajumptime = 47 + (int)(Mathf.Sqrt(Time.deltaTime) * 50);
            animator.SetBool("Jump", true);
        }
        else if (menu == false && animator.GetBool("Fall") == false && extrajumptime < 30)
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
            else if(menuflag == false)
            {
                animator.SetBool("Menu", false);
            }
            else
            {
                if(animator.GetBool("Fall") == false)
                {
                    animator.SetBool("Run", true);
                }
                animator.SetBool("Menu", false);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "BART1")
            Debug.Log("Barkhord1");
        if (collider.gameObject.tag == "BART2")
            Debug.Log("Barkhord2");
        if (collider.gameObject.tag == "BART3" || collider.gameObject.tag == "BART4")
            Debug.Log("Barkhord3");
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
            if (lefttime > 0 && fallLR == 0 || fallLR == 1)
            {
                if (animator.GetBool("Fall") == true && lefttime > 20)
                {
                    transform.Translate(-0.10233f, 0, 0);
                    lefttime--;
                }
                else if(animator.GetBool("Fall") == true)
                {
                    fallLR += 2;
                    animator.SetBool("Run", false);
                    righttime = 30;
                }
                else
                {
                    transform.Translate(-0.10233f, 0, 0);
                    lefttime--;
                }
            }
            if (righttime > 0 && fallLR == 0 || fallLR == 2)
            {
                if (animator.GetBool("Fall") == true && righttime > 20)
                {
                    transform.Translate(0.10233f, 0, 0);
                    righttime--;
                }
                else if (animator.GetBool("Fall") == true)
                {
                    fallLR += 1;
                    animator.SetBool("Run", false);
                    lefttime = 30;
                }
                else
                {
                    transform.Translate(0.10233f, 0, 0);
                    righttime--;
                }
            }
        }
    }
}
