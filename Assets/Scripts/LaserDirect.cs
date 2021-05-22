using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LS;
using CM;

public class LaserDirect : MonoBehaviour
{
    private System.Random random = new System.Random();
    public GameObject Dust;
    private GameObject ds;
    // Start is called before the first frame update
    void Start()
    {
        if (CM.CharMenu.Mat == 1)
            this.GetComponent<Renderer>().material.color = Color.red;
        else if (CM.CharMenu.Mat == 2)
            this.GetComponent<Renderer>().material.color = Color.yellow;
        else if (CM.CharMenu.Mat == 3)
            this.GetComponent<Renderer>().material.color = Color.blue;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "BART1" || collider.gameObject.tag == "BART2" || collider.gameObject.tag == "BART3" || collider.gameObject.tag == "BART4" || collider.gameObject.tag == "Buildings")
        {
            ds = Instantiate(Dust, this.transform.position, Dust.transform.rotation);
            LS.Laser.LaserImpactss[random.Next(0, 3)].Play();
            Destroy(this.gameObject); 
        }
        if (collider.gameObject.tag == "Zom")
        {
            LS.Laser.ZomDeaths[random.Next(0, 4)].Play();
            Destroy(this.gameObject);
        }
    }
}
