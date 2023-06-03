using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomgenerator : MonoBehaviour
{
    public GameObject room;
    public Vector3 origin = Vector3.zero;
    public ArrayList rooms = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        var rnd = new System.Random();
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = new Vector3(rnd.Next(-30, 40), rnd.Next(-30, 40), rnd.Next(-10, 10));
            rooms.Add(Instantiate(room, randomPosition, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

}
