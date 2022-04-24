using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MyWeapon")
        {
            explosion.SetActive(true);
        }
    }

}
