using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] utkozesek = Physics.OverlapSphere(transform.position, 0.01f);

        foreach (Collider utkozes in utkozesek)
        {
            if (utkozes.tag == "Player")
            {
                GetComponent<MeshRenderer>().enabled = false;
                return;
            }
        }
        //GetComponent<Collider>().enabled = true;
    }
}
