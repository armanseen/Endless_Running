using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetCones : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (animator.GetBool("Run") == true)
        {
            transform.Translate(0f, 0f, -0.3f);
        }
    }
}
