using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarScript : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;

    public Animator anim;
    public Collider2D col;
    public Collider2D thisColide;

    public AudioSource shattering;

    private void Start()
    {
        anim = GetComponent<Animator>();    
        thisColide = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon")
        {
            shattering.Play();
            thisColide.enabled = false;
            anim.SetTrigger("Quebrou");

            
        }
            

    }

    public void DeleteThis()
    {
        Destroy(this);
    }
    public void SairItem()
    {
        col.enabled = false;
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
        obj4.SetActive(true);
        obj5.SetActive(true);

    }
}
