using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarrierGenerator : MonoBehaviour
{
    public Animator animator;
    public GameObject L1, L2, L3, L4, L5, L6;
    public GameObject[] BarsT1, BarsT2, BarsT3, BarsT4;
    private List<GameObject> InsBars = new List<GameObject>();
    private int Timer = 0;
    private int RemoveTime = 0;
    private int rand;
    private int onebarbug = 0;
    private System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 17; j++)
        {
            RemoveTime++;
            for (int i = 0; i < InsBars.Count; i++)
            {
                float r;
                r = InsBars[i].transform.rotation.y;
                if (r > 0.9f)
                {
                    InsBars[i].transform.Translate(0f, 0f, 15.9f);
                }
                else if (r > 0.5f)
                {
                    InsBars[i].transform.Translate(15.9f, 0f, 0f);
                }
                else if (r > -0.2f)
                {
                    InsBars[i].transform.Translate(0f, 0f, -15.9f);
                }
                else if (r > -0.9f)
                {
                    InsBars[i].transform.Translate(-15.9f, 0f, 0f);
                }
            }
            rand = random.Next(0, 19);
            if (rand < 15)
            {
                rand = random.Next(0, 3);
                if (rand == 0)
                {
                    rand = random.Next(0, 15);
                    if (rand < 10)
                    {
                        if (rand == 5)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x - 1f, L2.transform.position.y, L2.transform.position.z), BarsT1[rand].transform.rotation));
                        else if (rand == 6)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x, L2.transform.position.y + 0.8f, L2.transform.position.z), BarsT1[rand].transform.rotation));
                        else
                            InsBars.Add(Instantiate(BarsT1[rand], L2.transform.position, BarsT1[rand].transform.rotation));
                    }
                    else
                        InsBars.Add(Instantiate(BarsT2[rand - 10], L2.transform.position, BarsT2[rand - 10].transform.rotation));
                    rand = random.Next(0, 15);
                    if (rand < 10)
                    {
                        if (rand == 5)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x - 1f, L3.transform.position.y, L3.transform.position.z), BarsT1[rand].transform.rotation));
                        else if (rand == 6)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x, L3.transform.position.y + 0.8f, L3.transform.position.z), BarsT1[rand].transform.rotation));
                        else
                            InsBars.Add(Instantiate(BarsT1[rand], L3.transform.position, BarsT1[rand].transform.rotation));
                    }
                    else
                        InsBars.Add(Instantiate(BarsT2[rand - 10], L3.transform.position, BarsT2[rand - 10].transform.rotation));
                }
                else if (rand == 1)
                {
                    rand = random.Next(0, 15);
                    if (rand < 10)
                    {
                        if (rand == 5)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x - 1f, L1.transform.position.y, L1.transform.position.z), BarsT1[rand].transform.rotation));
                        else if (rand == 6)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x, L1.transform.position.y + 0.8f, L1.transform.position.z), BarsT1[rand].transform.rotation));
                        else
                            InsBars.Add(Instantiate(BarsT1[rand], L1.transform.position, BarsT1[rand].transform.rotation));
                    }
                    else
                        InsBars.Add(Instantiate(BarsT2[rand - 10], L1.transform.position, BarsT2[rand - 10].transform.rotation));
                    rand = random.Next(0, 15);
                    if (rand < 10)
                    {
                        if (rand == 5)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x - 1f, L3.transform.position.y, L3.transform.position.z), BarsT1[rand].transform.rotation));
                        else if (rand == 6)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x, L3.transform.position.y + 0.8f, L3.transform.position.z), BarsT1[rand].transform.rotation));
                        else
                            InsBars.Add(Instantiate(BarsT1[rand], L3.transform.position, BarsT1[rand].transform.rotation));
                    }
                    else
                        InsBars.Add(Instantiate(BarsT2[rand - 10], L3.transform.position, BarsT2[rand - 10].transform.rotation));
                }
                else
                {
                    rand = random.Next(0, 15);
                    if (rand < 10)
                    {
                        if (rand == 5)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x - 1f, L2.transform.position.y, L2.transform.position.z), BarsT1[rand].transform.rotation));
                        else if (rand == 6)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x, L2.transform.position.y + 0.8f, L2.transform.position.z), BarsT1[rand].transform.rotation));
                        else
                            InsBars.Add(Instantiate(BarsT1[rand], L2.transform.position, BarsT1[rand].transform.rotation));
                    }
                    else
                        InsBars.Add(Instantiate(BarsT2[rand - 10], L2.transform.position, BarsT2[rand - 10].transform.rotation));
                    rand = random.Next(0, 15);
                    if (rand < 10)
                    {
                        if (rand == 5)
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x - 1f, L1.transform.position.y, L1.transform.position.z), BarsT1[rand].transform.rotation));
                        else if (rand == 6)
                        {
                            InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x, L1.transform.position.y + 0.8f, L1.transform.position.z), BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT1[rand], L1.transform.position, BarsT1[rand].transform.rotation));
                    }
                    else
                        InsBars.Add(Instantiate(BarsT2[rand - 10], L1.transform.position, BarsT2[rand - 10].transform.rotation));
                }
            }
            else if (rand < 18)
            {
                rand = random.Next(0, 2);
                if (rand == 0)
                {
                    rand = random.Next(0, 3);
                    InsBars.Add(Instantiate(BarsT3[rand], L4.transform.position, BarsT3[rand].transform.rotation));
                    rand = random.Next(0, 3);
                    InsBars.Add(Instantiate(BarsT3[rand], L5.transform.position, BarsT3[rand].transform.rotation));
                }
                else if (rand == 1)
                {
                    rand = random.Next(0, 3);
                    InsBars.Add(Instantiate(BarsT3[rand], L4.transform.position, BarsT3[rand].transform.rotation));
                    rand = random.Next(0, 3);
                    InsBars.Add(Instantiate(BarsT3[rand], L6.transform.position, BarsT3[rand].transform.rotation));
                }
            }
            else
                InsBars.Add(Instantiate(BarsT4[0], L1.transform.position, BarsT4[0].transform.rotation));
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (animator.GetBool("Run") == true)
        {
            if (RemoveTime > 30)
            {
                Destroy(InsBars[0],0f);
                InsBars.RemoveAt(0);
                if (onebarbug <= 0)
                {
                    Destroy(InsBars[0], 0f);
                    InsBars.RemoveAt(0);
                }
                else
                {
                    onebarbug--;
                }
                RemoveTime--;
            }
            Timer++;
            for (int i = 0; i < InsBars.Count; i++)
            {
                float r;
                r = InsBars[i].transform.rotation.y;
                if (r > 0.9f)
                {
                    InsBars[i].transform.Translate(0f, 0f, 0.3f);
                }
                else if (r > 0.5f)
                {
                    InsBars[i].transform.Translate(0.3f, 0f, 0f);
                }
                else if (r > -0.2f)
                {
                    InsBars[i].transform.Translate(0f, 0f, -0.3f);
                }
                else if (r > -0.9f)
                {
                    InsBars[i].transform.Translate(-0.3f, 0f, 0f);
                }
            }
            if (Timer == 53)
            {
                RemoveTime++;
                Timer = 0;
                rand = random.Next(0, 19);
                if (rand < 15)
                {
                    rand = random.Next(0, 3);
                    if (rand == 0)
                    {
                        rand = random.Next(0, 15);
                        if (rand < 10)
                        {
                            if (rand == 5)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x - 1f, L2.transform.position.y, L2.transform.position.z), BarsT1[rand].transform.rotation));
                            else if (rand == 6)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x, L2.transform.position.y + 0.8f, L2.transform.position.z), BarsT1[rand].transform.rotation));
                            else
                                InsBars.Add(Instantiate(BarsT1[rand], L2.transform.position, BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT2[rand - 10], L2.transform.position, BarsT2[rand - 10].transform.rotation));
                        rand = random.Next(0, 15);
                        if (rand < 10)
                        {
                            if (rand == 5)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x - 1f, L3.transform.position.y, L3.transform.position.z), BarsT1[rand].transform.rotation));
                            else if (rand == 6)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x, L3.transform.position.y + 0.8f, L3.transform.position.z), BarsT1[rand].transform.rotation));
                            else
                                InsBars.Add(Instantiate(BarsT1[rand], L3.transform.position, BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT2[rand - 10], L3.transform.position, BarsT2[rand - 10].transform.rotation));
                    }
                    else if (rand == 1)
                    {
                        rand = random.Next(0, 15);
                        if (rand < 10)
                        {
                            if (rand == 5)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x - 1f, L1.transform.position.y, L1.transform.position.z), BarsT1[rand].transform.rotation));
                            else if (rand == 6)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x, L1.transform.position.y + 0.8f, L1.transform.position.z), BarsT1[rand].transform.rotation));
                            else
                                InsBars.Add(Instantiate(BarsT1[rand], L1.transform.position, BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT2[rand - 10], L1.transform.position, BarsT2[rand - 10].transform.rotation));
                        rand = random.Next(0, 15);
                        if (rand < 10)
                        {
                            if (rand == 5)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x - 1f, L3.transform.position.y, L3.transform.position.z), BarsT1[rand].transform.rotation));
                            else if (rand == 6)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L3.transform.position.x, L3.transform.position.y + 0.8f, L3.transform.position.z), BarsT1[rand].transform.rotation));
                            else
                                InsBars.Add(Instantiate(BarsT1[rand], L3.transform.position, BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT2[rand - 10], L3.transform.position, BarsT2[rand - 10].transform.rotation));
                    }
                    else
                    {
                        rand = random.Next(0, 15);
                        if (rand < 10)
                        {
                            if (rand == 5)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x - 1f, L2.transform.position.y, L2.transform.position.z), BarsT1[rand].transform.rotation));
                            else if (rand == 6)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L2.transform.position.x, L2.transform.position.y + 0.8f, L2.transform.position.z), BarsT1[rand].transform.rotation));
                            else
                                InsBars.Add(Instantiate(BarsT1[rand], L2.transform.position, BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT2[rand - 10], L2.transform.position, BarsT2[rand - 10].transform.rotation));
                        rand = random.Next(0, 15);
                        if (rand < 10)
                        {
                            if (rand == 5)
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x - 1f, L1.transform.position.y, L1.transform.position.z), BarsT1[rand].transform.rotation));
                            else if (rand == 6)
                            {
                                InsBars.Add(Instantiate(BarsT1[rand], new Vector3(L1.transform.position.x, L1.transform.position.y + 0.8f, L1.transform.position.z), BarsT1[rand].transform.rotation));
                            }
                            else
                                InsBars.Add(Instantiate(BarsT1[rand], L1.transform.position, BarsT1[rand].transform.rotation));
                        }
                        else
                            InsBars.Add(Instantiate(BarsT2[rand - 10], L1.transform.position, BarsT2[rand - 10].transform.rotation));
                    }
                }
                else if (rand < 18)
                {
                    rand = random.Next(0, 2);
                    if (rand == 0)
                    {
                        rand = random.Next(0, 3);
                        InsBars.Add(Instantiate(BarsT3[rand], L4.transform.position, BarsT3[rand].transform.rotation));
                        rand = random.Next(0, 3);
                        InsBars.Add(Instantiate(BarsT3[rand], L5.transform.position, BarsT3[rand].transform.rotation));
                    }
                    else if (rand == 1)
                    {
                        rand = random.Next(0, 3);
                        InsBars.Add(Instantiate(BarsT3[rand], L4.transform.position, BarsT3[rand].transform.rotation));
                        rand = random.Next(0, 3);
                        InsBars.Add(Instantiate(BarsT3[rand], L6.transform.position, BarsT3[rand].transform.rotation));
                    }
                }
                else
                {
                    onebarbug++;
                    InsBars.Add(Instantiate(BarsT4[0], L1.transform.position, BarsT4[0].transform.rotation));
                }
            }
        }
    }
}
