using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Collider[] utkozesek = Physics.OverlapSphere(transform.position, 0.01f);

        foreach (Collider utkozes in utkozesek)
        {
            if (utkozes.tag == "Wall")
            {
                Destroy(gameObject);
                return;
            }
        }
        GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
