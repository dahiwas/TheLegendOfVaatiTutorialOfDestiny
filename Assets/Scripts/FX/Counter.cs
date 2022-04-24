using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public PlayerController player;
    public bool isGone = false;
    public Animator anim;
    public GameObject Exclamation;
    public AudioSource audio1;
    public AudioSource audio2;
    public bool Dead;
    public CameraMovement cameras;
    public RoomMove ZeldaCamera;
    public RoomMove VaatiCamera;
    public RoomMove cameraDefault;
    public AudioSource audioVaati;
    public GameObject playerExcl;
    public AudioSource audioZelda;
    public GameObject Video;



    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(player.FinalScene && !isGone)
        {
            player.LockMovement();
            player.anim.SetBool("isMoving", false);
            isGone = true;
            StartCoroutine(Comecou());
            
        }
    }
    IEnumerator Comecou()
    {
        yield return new WaitForSeconds(2f);
        Exclamation.SetActive(true);
        yield return new WaitForSeconds(5f);
        Exclamation.SetActive(false);
        anim.SetBool("Begin", true);
        yield return new WaitForSeconds(5f);
        anim.SetBool("Begin", false);
        if(!Dead)
        {
            Exclamation.SetActive(true);
            yield return new WaitForSeconds(2f);
            Exclamation.SetActive(false);
            anim.SetBool("Begin", true);
            yield return new WaitForSeconds(1f);
            cameras.minPosition = VaatiCamera.cameraChangeMin;
            cameras.maxPosition = VaatiCamera.cameraChangeMax;
            yield return new WaitForSeconds(1f);
            playerExcl.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            audioVaati.Play();
            yield return new WaitForSeconds(1.5f);
            playerExcl.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            cameras.minPosition = ZeldaCamera.cameraChangeMin;
            cameras.maxPosition = ZeldaCamera.cameraChangeMax;
            yield return new WaitForSeconds(1f);
            Exclamation.SetActive(true);
            audio2.Play();
            yield return new WaitForSeconds(2f);
            Exclamation.SetActive(false);
            anim.SetBool("Begin", false);
            yield return new WaitForSeconds(0.1f);
            anim.SetBool("Begin", true);
            yield return new WaitForSeconds(3.2f);
            Video.SetActive(true);
            cameras.minPosition = cameraDefault.cameraChangeMin;
            cameras.maxPosition = cameraDefault.cameraChangeMax;
            StartCoroutine(Reset());

        }
        
    }

    public void PlayAudio()
    {
        audio1.Play();
    }

    public void Deads()
    {
        Dead = true;
    }

    public void Stone()
    {
        audioZelda.Play();
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(17f);
        SceneManager.LoadScene(0);

    }
}
