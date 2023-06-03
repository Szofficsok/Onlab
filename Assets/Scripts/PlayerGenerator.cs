using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    public GameObject jatekos;
    public static GameObject ujJatekos = null;
    // Start is called before the first frame update
    void Start()
    {

        Quaternion q = Quaternion.identity;
        ujJatekos = Instantiate(jatekos, new Vector3(0, -2, 0), q, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
