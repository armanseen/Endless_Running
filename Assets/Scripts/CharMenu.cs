using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using FMen;
namespace CM
{
    public class CharMenu : MonoBehaviour
    {
        public static int Mat = 1;
        public GameObject S2, S3;
        // Start is called before the first frame update
        void Start()
        {
            if (int.Parse(File.ReadAllText(@"HighScore.json")) >= 100000)
            {
                GameObject.Find("Start 2(Off)").SetActive(false);
                GameObject.Find("Start 3(Off)").SetActive(false);
                S2.SetActive(true);
                S3.SetActive(true);
            }
            else if (int.Parse(File.ReadAllText(@"HighScore.json")) >= 50000)
            {
                GameObject.Find("Start 2(Off)").SetActive(false);
                S2.SetActive(true);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MapMenu");
            }
        }
        public void StartGame1()
        {
            Mat = 1;
            SceneManager.LoadScene("Game");
            FirstMenu.Aus.Stop();
            FirstMenu.BS = false;
            Destroy(FirstMenu.Aus.gameObject);
        }
        public void StartGame2()
        {
            Mat = 2;
            SceneManager.LoadScene("Game");
            FirstMenu.Aus.Stop();
            FirstMenu.BS = false;
            Destroy(FirstMenu.Aus.gameObject);
        }
        public void StartGame3()
        {
            Mat = 3;
            SceneManager.LoadScene("Game");
            FirstMenu.Aus.Stop();
            FirstMenu.BS = false;
            Destroy(FirstMenu.Aus.gameObject);
        }
    }
}