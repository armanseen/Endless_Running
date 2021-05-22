using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    public class Sounds : MonoBehaviour
    {
        static public AudioSource[] Zom;
        public AudioSource[] Zoms;
        // Start is called before the first frame update
        void Start()
        {
            Zom = new AudioSource[Zoms.Length];
            for (int i = 0; i < Zoms.Length; i++)
            {
                Zom[i] = Zoms[i];
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}