using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start3 : MonoBehaviour
{
    public GameObject UFSCAR;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Segundos());   
    }

    IEnumerator Segundos()
    {
        yield return new WaitForSeconds(10f);
        UFSCAR.SetActive(true);
        StartCoroutine(NNextScene());
    }
    IEnumerator NNextScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(1);

    }
}
