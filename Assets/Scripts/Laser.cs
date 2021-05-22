using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LS
{
    public class Laser : MonoBehaviour
    {
        private GameObject direct, left, right;
        public AudioSource[] LaserShoots;
        public AudioSource[] LaserImpacts;
        public AudioSource[] ZomDeath;
        public static AudioSource[] LaserImpactss;
        public static AudioSource[] ZomDeaths;
        public Animator animator;
        public static Animator anim;
        public GameObject laserdirect, laserleft, laserright;
        private System.Random random = new System.Random();
        // Start is called before the first frame update
        void Start() 
        {
            LaserImpactss = new AudioSource[LaserImpacts.Length];
            for (int i=0;i<LaserImpacts.Length; i++)
            {
                LaserImpactss[i] = LaserImpacts[i];
            }
            ZomDeaths = new AudioSource[ZomDeath.Length];
            for (int i = 0; i < ZomDeath.Length; i++)
            {
                ZomDeaths[i] = ZomDeath[i];
            }
            anim = animator;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && direct == null && animator.GetBool("Run") == true && animator.GetBool("Menu") == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false)
            {
                LaserShoots[random.Next(0, 3)].Play();
                direct = Instantiate(laserdirect, this.transform.position, laserdirect.transform.rotation);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && left == null && animator.GetBool("Run") == true && animator.GetBool("Menu") == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false)
            {
                LaserShoots[random.Next(0, 3)].Play();
                left = Instantiate(laserleft, this.transform.position, laserleft.transform.rotation);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && right == null && animator.GetBool("Run") == true && animator.GetBool("Menu") == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false)
            {
                LaserShoots[random.Next(0, 3)].Play();
                right = Instantiate(laserright, this.transform.position, laserright.transform.rotation);
            }
        }
        void FixedUpdate()
        {
            if (animator.GetBool("Menu") == false)
            {
                if (direct != null)
                {
                    direct.transform.Translate(0f, 1f, 0f);
                    if (direct.transform.position.z > -180f)
                    {
                        Destroy(direct, 0f);
                    }
                }
                if (left != null)
                {
                    left.transform.Translate(0f, 1f, 0f);
                    if (left.transform.position.z > -180f)
                    {
                        Destroy(left, 0f);
                    }
                }
                if (right != null)
                {
                    right.transform.Translate(0f, 1f, 0f);
                    if (right.transform.position.z > -180f)
                    {
                        Destroy(right, 0f);
                    }
                }
            }
        }
    }
}