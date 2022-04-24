using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("ItemSplash")]
    public Transform objTransf;
    public GameObject objPrefab;
    private float delay = 0;
    private float pastTime = 0;
    public float when ;
    private Vector3 off;

    public GameObject player;
    public bool magnetize = false;


    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public AudioSource audioD;

    public int ID;

    public GameObject Sumir;

    Animator anim;
    Rigidbody2D rig;

    public Transform target;

    public bool needMagnetize;
    public void Start()
    {
        transform.position = target.position;
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        //Random for x axis
        off = new Vector3(Random.Range(minX, maxX), off.y, off.z);
        //Random for y axis
        off = new Vector3(off.x, Random.Range(minY, maxY), off.z);
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();  

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Magnet());

    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        //Quuando parar
        if(when >= delay)
        {
            pastTime = Time.deltaTime;
            //Posição dp ote,
            objTransf.position += off * Time.deltaTime;
            delay += pastTime;
            
        }
        if(when < delay)
        {
            anim.SetBool("Saiu", true);
        }

        if(magnetize)
        {
            Vector3 playerPoint = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, -0.01f, 0),1 * Time.deltaTime);
            rig.MovePosition(playerPoint); 
        }
    }

    private IEnumerator Magnet()
    {
        yield return new WaitForSeconds(2f);
        if(needMagnetize)
            magnetize = true;
    }

    public void DeleteThis()
    {
        Destroy(objPrefab);
    }

    public void Setar()
    {
        anim.SetBool("end", true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Porta2")
        {
            anim.SetBool("end", true);
        }
    }

    public void isEnde()
    {
        Sumir.SetActive(false);
    }
    
    public void isSounded()
    {
        audioD.Play();
    }

}
