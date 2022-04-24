using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Item item;
    public Animator anim;
    public bool jaFoi = false;
    public AudioSource open;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Abrir()
    {
        anim.SetTrigger("Abrir");
    }

    public void SairItem()
    {
        Instantiate(item);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player") && !jaFoi)
        {

            Abrir();
            jaFoi = true;
        }
    }

    public void TocarAbertura()
    {
        open.Play();
    }

}
