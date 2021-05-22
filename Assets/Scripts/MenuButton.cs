using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public RawImage rimg;
    public CanvasScaler cs;
    public Button bt;
    public AudioSource aus;
    private bool flag = false;
    private float SCL;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SCL = cs.transform.position.x * 2 / 800;
        if (Input.mousePosition.x >= bt.transform.position.x - (100 * SCL) &&
            Input.mousePosition.x <= bt.transform.position.x + (100 * SCL) &&
            Input.mousePosition.y >= bt.transform.position.y - (20 * SCL) &&
            Input.mousePosition.y <= bt.transform.position.y + (20 * SCL) 
            )
        {
            if (Input.GetMouseButton(0))
            {
                rimg.color = new Color32(255, 255, 255, 255);
            }
            else
            {
                rimg.color = new Color32(240, 240, 240, 255);
            }
            if (flag == false)
            {
                aus.Play();
                flag = true;
            }
        }
        else
        {
            flag = false;
            rimg.color = new Color32(200, 200, 200, 255);
        }
    }
}
