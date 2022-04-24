using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScript : MonoBehaviour
{
    public Collider2D colid;
    void Start()
    {
        colid.enabled = false;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        colid.enabled = true;
    }

}
