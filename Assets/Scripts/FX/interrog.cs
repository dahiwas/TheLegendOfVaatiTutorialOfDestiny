using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interrog : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        Morrer();
    }

    

    void Morrer()
    {
        StartCoroutine(Time());
       
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
