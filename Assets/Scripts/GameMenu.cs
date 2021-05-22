using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PL;

public class GameMenu : MonoBehaviour
{
    //public GameObject T;
    public GameObject I;
    public GameObject[] B;
    public GameObject BackgroundOp;
    public GameObject KeyboardOp;
    public GameObject ExitOp;
    public Animator animator;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Menu") == true && BackgroundOp.activeSelf == false)
        {
            //T.SetActive(true);
            I.SetActive(true);
            B[0].SetActive(true);
            B[1].SetActive(true);
            B[2].SetActive(true);
            B[3].SetActive(true);
            count = 1;
        }
        else if(animator.GetBool("Menu") == false)
        {
            //T.SetActive(false);
            I.SetActive(false);
            B[0].SetActive(false);
            B[1].SetActive(false);
            B[2].SetActive(false);
            B[3].SetActive(false);
            BackgroundOp.SetActive(false);
            KeyboardOp.SetActive(false);
            ExitOp.SetActive(false);
            count = 0;
        }
    }
    void FixedUpdate()
    {

    }
    public void Reset()
    {
        PL.Player.BS = false;
        Destroy(PL.Player.Aus.gameObject);
        SceneManager.LoadScene("Game");
    }
    public void EnterOption()
    {
        I.SetActive(false);
        B[0].SetActive(false);
        B[1].SetActive(false);
        B[2].SetActive(false);
        B[3].SetActive(false);
        BackgroundOp.SetActive(true);
        KeyboardOp.SetActive(true);
        ExitOp.SetActive(true);
    }
    public void ExitOption()
    {
        I.SetActive(true);
        B[0].SetActive(true);
        B[1].SetActive(true);
        B[2].SetActive(true);
        B[3].SetActive(true);
        BackgroundOp.SetActive(false);
        KeyboardOp.SetActive(false);
        ExitOp.SetActive(false);
    }
    public void ExitGame()
    {
        PL.Player.BS = false;
        Destroy(PL.Player.Aus.gameObject);
        SceneManager.LoadScene("Menu");
    }
}
