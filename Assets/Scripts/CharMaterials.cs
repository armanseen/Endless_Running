using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM;
public class CharMaterials : MonoBehaviour
{
    public Material M1;
    public Material M2;
    public Material M3;
    // Start is called before the first frame update
    void Start()
    {
        if (CM.CharMenu.Mat == 1)
            this.GetComponent<Renderer>().material = M1;
        else if(CM.CharMenu.Mat == 2)
            this.GetComponent<Renderer>().material = M2;
        else if(CM.CharMenu.Mat == 3)
            this.GetComponent<Renderer>().material = M3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
