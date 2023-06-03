using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float cameraDistance = 5.0f;

    // Use this for initialization
    void Start()
    {
        while(PlayerGenerator.ujJatekos == null)
        {}
        player = PlayerGenerator.ujJatekos;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        transform.Rotate(40f, 0f, 0f);
    }
}
