using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = transform.position;
        
        cameraPosition.x = player.position.x;

        if (player.position.y > transform.position.y)
        {
            cameraPosition.y = player.position.y;
        }
        cameraPosition.z = transform.position.z;

        transform.position = cameraPosition;
    }
}
