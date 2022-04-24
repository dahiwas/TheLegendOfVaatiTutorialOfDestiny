using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : MonoBehaviour
{
    public ButtonScript button1;
    public ButtonScript button2;
    public Animator anim;
    public BoxCollider2D box;
    public AudioSource porta;
    public bool caiu = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(button1.clicou == true && button2.clicou == true && !caiu)
        {

            caiu = true;
            anim.SetBool("Complete", true);
            box.enabled = false;
        }
    }

    public void Caiu()
    {
        porta.Play();
    }
}
