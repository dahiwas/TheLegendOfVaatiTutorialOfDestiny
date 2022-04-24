using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomZoom : MonoBehaviour
{
    private CameraMovement cam;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool encostou = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!encostou)
            {
                cam.zoomActive = true;
                encostou = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (encostou)
            {
                cam.zoomActive = false;
                encostou = false;
            }
        }
    }
}
