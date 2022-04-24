using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMaker : MonoBehaviour
{
    public Animator anim;
    public GameObject key;
    public AudioSource som;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FazerChave()
    {
        StartCoroutine(Faca());
    }

    public void SairChave()
    {
        key.SetActive(true);
    }

    IEnumerator Faca()
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("doIt");
    }

    public void PlaySom()
    {
        som.Play();
    }
}
