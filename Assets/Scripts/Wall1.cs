using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    private int counter = 0;
    int flag = 3040;
    float flagak = 689.6f;
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
        if (counter == flag)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, flagak);
            flagak = 689.35f;
            flag = 6080;
            counter = 0;
        }
    }
}
