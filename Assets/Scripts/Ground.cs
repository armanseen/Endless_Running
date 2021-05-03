using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
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
        if (counter == 3040)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 912);
            counter = 0;
        }
    }
}
