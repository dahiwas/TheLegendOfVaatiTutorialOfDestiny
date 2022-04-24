using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralRegion : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("Esta dentro");
        }
    }

}
