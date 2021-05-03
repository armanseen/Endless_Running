using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject T;
    public GameObject I;
    public GameObject B;
    public Animator animator;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Menu") == true)
        {
            T.SetActive(true);
            I.SetActive(true);
            B.SetActive(true);
            count = 1;
        }
        else if(count == 1)
        {
            T.SetActive(false);
            I.SetActive(false);
            B.SetActive(false);
            count = 0;
        }
    }
    void FixedUpdate()
    {

    }
    public void exitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
