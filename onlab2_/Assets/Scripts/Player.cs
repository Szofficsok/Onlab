using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject character;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A)) {
            //rb.AddForce(Vector3.left * speed);
            character.transform.Rotate(-Vector3.up * speed * speed);
        }
        if (Input.GetKey(KeyCode.D)) {
            //rb.AddForce(Vector3.right * speed);
            character.transform.Rotate(Vector3.up * speed * speed);
        }
        if (Input.GetKey(KeyCode.W)) {
            //rb.AddForce(Vector3.forward * speed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.AddForce(Vector3.back * speed);
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        Collider[] utkozesek = Physics.OverlapSphere(transform.position, 0.01f);

        foreach (Collider utkozes in utkozesek)
        {
            if (utkozes.tag == "Wall")
            {
                Destroy(utkozes);
                break;
            }
        }
    }

}
