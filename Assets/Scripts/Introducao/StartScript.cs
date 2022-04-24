using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;


public class StartScript : MonoBehaviour
{
    public AudioSource Start1;
    public bool Foi = false;
    public scriptFade fade;
    public TextMeshPro text;
    public Animator anim;
    public VideoPlayer clip;

    public void Start()
    {
        clip.SetDirectAudioVolume(0, 0.2f);
        StartCoroutine(Repeat());
    }
    void OnStart()
    {
        if (!Foi)
        {
            Foi = true;

            StartCoroutine(NNextScene());            
        }

    }


    IEnumerator NNextScene()
    {

        
        anim.SetBool("pressed", true);
        Debug.Log("Foi");
        Start1.Play();
        //Volume do Jogo
        float targetVolume = 1;
        clip.SetDirectAudioVolume(0, targetVolume);
        while (targetVolume > 0)
        {
            yield return new WaitForSeconds(0.01f);
            clip.SetDirectAudioVolume(0, targetVolume);
            targetVolume -= 0.9f * Time.deltaTime;
        }
        fade.FadeOut();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

    IEnumerator Repeat()
    {
        yield return new WaitForSeconds(25f);
        fade.FadeOut();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }


}
