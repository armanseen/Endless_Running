using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FMen
{
    public class FirstMenu : MonoBehaviour
    {
        public AudioSource As;
        public static AudioSource Aus;
        public static bool BS = false;
        public GameObject Buttons;
        public GameObject BackgroundOp;
        public GameObject ExitOp;
        public GameObject KeyboardOp;
        // Start is called before the first frame update
        void Start()
        {
            if (BS == false)
            {
                Aus = As;
                Aus.Play();
                BS = true;
            }
            else
            {
                Destroy(As.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (BackgroundOp.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
            {
                Buttons.SetActive(true);
                BackgroundOp.SetActive(false);
                ExitOp.SetActive(false);
                KeyboardOp.SetActive(false);
            }
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        public void ExitOption()
        {
            Buttons.SetActive(true);
            BackgroundOp.SetActive(false);
            ExitOp.SetActive(false);
            KeyboardOp.SetActive(false);
        }
        public void EnterOption()
        {
            Buttons.SetActive(false);
            BackgroundOp.SetActive(true);
            ExitOp.SetActive(true);
            KeyboardOp.SetActive(true);
        }
        public void StartGame()
        {
            SceneManager.LoadScene("MapMenu");
        }
    }
}
