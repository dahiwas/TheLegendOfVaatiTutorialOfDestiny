using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Start2Script : MonoBehaviour
{
    public GameObject StartGame;
    public scriptFade fade;
    public VideoPlayer clip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGO());
        clip.Play();
    }
    IEnumerator StartGO()
    {

        yield return new WaitForSeconds(31f);//31
        StartGame.SetActive(true);
    }
}

