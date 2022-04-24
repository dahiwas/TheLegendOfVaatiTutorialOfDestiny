using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public bool zoomActive;
    public RoomMove zoom;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    private void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x); 
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);  
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);  

        }
        if(zoomActive)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 0.88f, 0.05f);
        }
        else
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 1.090197f, 0.05f); 
        }

    }

}
