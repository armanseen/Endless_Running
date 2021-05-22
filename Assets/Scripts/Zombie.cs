using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BG;
using LS;
using SO;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Dis;
    private Animator animator;
    private BoxCollider boxcollider;
    private int forceflag = 0;
    private bool biteflag = false;
    private bool soundflagzom = false;
    private int rand1 = 0;
    private int rand2 = 0;
    private bool swt = false;
    private System.Random random = new System.Random();
    void Start()
    {
        
        animator = this.GetComponent<Animator>();
        boxcollider = this.GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (LS.Laser.anim.GetBool("Menu") == false)
        {
            if (this.transform.position.z - BG.BarrierGenerator.ply.transform.position.z < 40)
            {
                if (soundflagzom == false)
                {
                    if (swt == false)
                    {
                        swt = true;
                        rand1 = random.Next(0, 10);
                        if (rand1 == rand2) rand1++;
                        SO.Sounds.Zom[rand1].Play();
                    }
                    else
                    {
                        swt = false;
                        rand2 = random.Next(0, 10);
                        if (rand1 == rand2) rand2++;
                        SO.Sounds.Zom[rand2].Play();
                    }
                    soundflagzom = true;
                }
                Dis = this.transform.position - new Vector3(GameObject.Find("Breathing Idle").transform.position.x, this.transform.position.y, BG.BarrierGenerator.ply.transform.position.z);
                
                Dis = Dis / (Mathf.Sqrt(Dis.x * Dis.x + Dis.y * Dis.y + Dis.z * Dis.z));
            }
            else
                Dis = new Vector3(0f, 0f, 1f);
        }
    }
    void FixedUpdate()
    {
        if (LS.Laser.anim.GetBool("Menu") == false && biteflag == false)
        {
            if (LS.Laser.anim.GetBool("Run") == true)
            {
                this.transform.Translate(3 * new Vector3(0f, 0f, 1f) / 10);
                if (Dis.x > 0)
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180 + Mathf.Acos(Dis.z)*180/Mathf.PI, this.transform.eulerAngles.z);
                else
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180 - Mathf.Acos(Dis.z) * 180 / Mathf.PI, this.transform.eulerAngles.z);
                if (forceflag > 0)
                    this.transform.Translate(-3 * new Vector3(0f, 0f, 1f) / 10);
            }
            else
            {
                if (Dis.x > 0)
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180 + Mathf.Acos(Dis.z) * 180 / Mathf.PI, this.transform.eulerAngles.z);
                else
                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180 - Mathf.Acos(Dis.z) * 180 / Mathf.PI, this.transform.eulerAngles.z);
                this.transform.Translate(new Vector3(0f, 0f, 1f) / 40);
                if (forceflag > 0)
                    this.transform.Translate(-new Vector3(0f, 0f, 1f) / 10);
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            animator.SetBool("Death", true);
            boxcollider.enabled = false;
            forceflag = 30;
            Destroy(this.gameObject,1f);
        }
        if (collider.gameObject.tag == "PLY")
        {
            boxcollider.enabled = false;
            animator.SetBool("Bite", true);
            biteflag = true;
        }
    }
}
