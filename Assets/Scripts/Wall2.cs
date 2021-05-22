using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2 : MonoBehaviour
{
    private int counter = 0;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (animator.GetBool("Run") == true)
        {
            counter++;
            transform.Translate(0f, 0f, -0.3f);
        }
        if (counter == 6080)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.4f);
            counter = 0;
        }
    }
}
