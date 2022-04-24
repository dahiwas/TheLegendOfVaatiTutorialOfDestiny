using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator anim;
    public bool clicou = false;
    public AudioSource bt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(1.8f);
        clicou = false;
        anim.SetBool("Complete", false);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag == "Player")
        {
            if(!clicou)
            {
                bt.Play();
                clicou = true;
                anim.SetBool("Complete", true);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Tempo());
        }
    }


}
