using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpirit : MonoBehaviour
{
    public GameObject linkspirit;

    public void Instanciar()
    {
        StartCoroutine(LateInstantiate());
    }

    IEnumerator LateInstantiate()
    {
        yield return new WaitForSeconds(1f);
        linkspirit.SetActive(true);
    }


}
