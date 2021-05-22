using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PL
{
    public class Player : MonoBehaviour
    {
        public GameObject Blood1, Blood2; 
        public AudioSource As;
        public AudioSource Deaht;
        public AudioSource Bite;
        public static bool BS = false;
        public static AudioSource Aus;
        public AudioSource[] ImpactS;
        public AudioSource[] MoveS;
        public Animator animator;
        public BoxCollider bx;
        private int counter = 0;
        private bool menu;
        int jumptime = 0;
        int lefttime = 0;
        int righttime = 0;
        int extrajumptime = 0;
        int loc = 0;
        float bxy;
        float w;
        int fallLR = 0;
        int forceflag = 0;
        int camforce1 = 0;
        int camforce2 = 0;
        int resetcounter = 0;
        float jumpflag = -1;
        private float xrcam, yrcam, zrcam;
        bool flagwall = false;
        bool menuflag = false;
        public static bool ext = false, rest = false;
        static float jumpingFunc(float x, float s)
        {
            float y;
            float a = 14f;
            x *= a / (2 * s);
            y = (-1) * (x * (x - a) * (1f / 40f));
            return y;
        }
        public void Resume()
        {
            if (menu == false)
            {
                Aus.Pause();
                animator.SetBool("Run", false);
                animator.SetBool("Menu", true);
            }
            else if (menuflag == false)
            {
                Aus.Play();
                animator.SetBool("Menu", false);
            }
            else
            {
                if (animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
                {
                    animator.SetBool("Run", true);
                }
                Aus.Play();
                animator.SetBool("Menu", false);
            }
        }
        static void Reset()
        {
            SceneManager.LoadScene("Game");
        }
        // Start is called before the first frame update
        void Start()
        {
            if (BS == false)
            {
                Aus = As;
                Aus.Play();
                BS = true;
            }
            else
            {
                Destroy(As.gameObject);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if ((loc > 1 || loc < -1) && flagwall == false)
            {
                flagwall = true;
                camforce2 = 25;
                ImpactS[4].Play();
                ImpactS[1].Play();
                animator.SetBool("Fall3", true);
            }
            menu = animator.GetBool("Menu");
            if (Input.GetKeyDown(KeyCode.A) && lefttime == 0 && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                loc++;
                lefttime = 15 - righttime;
                righttime = 0;
            }
            if (Input.GetKeyDown(KeyCode.D) && righttime == 0 && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                loc--;
                righttime = 15 - lefttime;
                lefttime = 0;
            }
            if (((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
                && animator.GetBool("Run") == false)
            {
                animator.SetBool("Run", true);
                menuflag = true;
                extrajumptime = 22 + ((int)(Mathf.Sqrt(Time.deltaTime) * 25));
            }
            if (Input.GetKey(KeyCode.W) && extrajumptime == 0 && animator.GetBool("Run") == true && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                MoveS[0].Play();
                bxy = bx.center.y;
                jumptime = 19;
                extrajumptime = 47 + (int)(Mathf.Sqrt(Time.deltaTime) * 50);
                animator.SetBool("Jump", true);
            }
            else if (menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false && extrajumptime < 30)
            {
                animator.SetBool("Jump", false);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menu == false)
                {
                    Aus.Pause();
                    animator.SetBool("Run", false);
                    animator.SetBool("Menu", true);
                }
                else if (menuflag == false)
                {
                    Aus.Play();
                    animator.SetBool("Menu", false);
                }
                else
                {
                    if (animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
                    {
                        animator.SetBool("Run", true);
                    }
                    Aus.Play();
                    animator.SetBool("Menu", false);
                }
            }
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "BART1" && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                ImpactS[0].Play();
                ImpactS[1].Play();
                forceflag = 15;
                if (extrajumptime > 0)
                {
                    jumpflag = 0.6f;
                }
                else
                {
                    jumpflag = -1;
                }
                animator.SetBool("Fall1", true);
                animator.SetBool("Run", false);
            }
            if (collider.gameObject.tag == "BART2" && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                ImpactS[2].Play();
                ImpactS[3].Play();
                camforce1 = 20;
                animator.SetBool("Fall2", true);
                animator.SetBool("Run", false);

            }
            if (((collider.gameObject.tag == "BART3") || (collider.gameObject.tag == "BART4")) && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                ImpactS[4].Play();
                ImpactS[5].Play();
                camforce2 = 25;
                animator.SetBool("Fall3", true);
                animator.SetBool("Run", false);
            }
            if (collider.gameObject.tag == "Zom" && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                Deaht.Play();
                Bite.Play();
                Instantiate(Blood1, new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z), this.transform.rotation);
                Instantiate(Blood2, new Vector3(this.transform.position.x, this.transform.position.y + 3f, this.transform.position.z), this.transform.rotation);
                xrcam = GameObject.Find("Main Camera").transform.eulerAngles.x;
                yrcam = GameObject.Find("Main Camera").transform.eulerAngles.y;
                zrcam = GameObject.Find("Main Camera").transform.eulerAngles.z;
                animator.SetBool("Fall4", true);
                animator.SetBool("Run", false);
            }
        }
        void FixedUpdate()
        {
            if (menu == false)
            {
                if (animator.GetBool("Fall1") == true || animator.GetBool("Fall2") == true || animator.GetBool("Fall3") == true || animator.GetBool("Fall4") == true)
                {
                    resetcounter++;
                }
                if (resetcounter == 150)
                {
                    Reset();
                }
                counter++;
                if (forceflag > 0)
                {
                    forceflag--;
                    this.transform.Translate(0f, 0f, 0.3f * jumpflag);
                }
                if (camforce1 > 0)
                {
                    camforce1--;
                    GameObject.Find("Main Camera").transform.Translate(0.0025f, -0.06375f, -0.25f);
                }
                if (camforce2 > 0)
                {
                    camforce2--;
                    GameObject.Find("Main Camera").transform.Translate(0.002f, 0.051f, 0.2f);
                }
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
                if (lefttime > 0 && (fallLR == 0 || fallLR == 1))
                {
                    if (animator.GetBool("Fall3") == true && lefttime > 10)
                    {
                        transform.Translate(-0.20466f, 0, 0);
                        lefttime--;
                    }
                    else if (animator.GetBool("Fall3") == true)
                    {
                        fallLR += 2;
                        animator.SetBool("Run", false);
                        righttime = 15;
                    }
                    else if (animator.GetBool("Run") == true)
                    {
                        transform.Translate(-0.20466f, 0, 0);
                        lefttime--;
                    }
                }
                if (righttime > 0 && (fallLR == 0 || fallLR == 2))
                {
                    if (animator.GetBool("Fall3") == true && righttime > 10)
                    {
                        transform.Translate(0.20466f, 0, 0);
                        righttime--;
                    }
                    else if (animator.GetBool("Fall3") == true)
                    {
                        fallLR += 1;
                        animator.SetBool("Run", false);
                        lefttime = 15;
                    }
                    else if (animator.GetBool("Run") == true)
                    {
                        transform.Translate(0.20466f, 0, 0);
                        righttime--;
                    }
                }
            }
        }
    }
}
