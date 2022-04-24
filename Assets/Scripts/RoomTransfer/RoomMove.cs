using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChangeMax;
    public Vector2 cameraChangeMin;
    public Vector3 playerChange;
    public float size;
    private CameraMovement cam;
    public AudioSource move;

    bool encostou = false;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            move.Play();
            cam.minPosition = cameraChangeMin;
            cam.maxPosition = cameraChangeMax;
            other.transform.position += playerChange;
                
        }
    }
}
