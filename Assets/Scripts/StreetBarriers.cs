using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetBarriers : MonoBehaviour
{
    public Animator animator;
    public GameObject objgame;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objgame,new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z-200),this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (animator.GetBool("Run") == true)
        {
            this.transform.Translate(0.3f, 0f, 0f);
            objgame.transform.Translate(0.3f, 0f, 0f);
        }
    }
}
