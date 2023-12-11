using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehavior : MonoBehaviour
{
    //0-felso, 1-also, 2-jobb, 3-bal
    public GameObject[] falak;
    public GameObject[] ajtok;

    //public bool[] testStat;
    // Start is called before the first frame update
    /* void Start()
     {
         UpdateRoom(testStat);
     }*/

    // Update is called once per frame
    /*void Update()
    {
        

    }*/

    public void UpdateRoom(bool[] stat)
    {
        for (int i = 0; i < stat.Length; i++)
        {
            ajtok[i].SetActive(stat[i]);
            falak[i].SetActive(!stat[i]);
        }

    }
}
