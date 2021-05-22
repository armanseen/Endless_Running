using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LS;

public class Dust : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if(LS.Laser.anim.GetBool("Run") == true)
            this.transform.Translate(0f, 0f, -0.3f);
    }
}
