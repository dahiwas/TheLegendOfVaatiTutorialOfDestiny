using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript2 : MonoBehaviour
{
    public GameObject porta;
    public PlayerController player;
    public GameObject ob1;
    public GameObject ob2;
    public bool fTime = true;
    public AudioSource audio1;
    public AudioSource audio2;

    public AudioSource p1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(ChecarChave() && fTime)//(ChecarChave() && fTime)
            {
                player.hasKey = false;
                player.linkSpirit = false;
                player.inv.Remove(player.LinksHead);
                player.inv.Remove(player.Key);
                StartCoroutine(Final());

            }
        }
    }
    IEnumerator Final()
    {
        fTime = false;
        ob1.SetActive(true);
        ob2.SetActive(true);
        p1.Play();
        player.LockMovement();
        player.anim.SetBool("isMoving", false);
        yield return new WaitForSeconds(2.25f);
        player.UnlockMovement();
        float targetVolume = 0.01f;
        
        while (targetVolume > 0)
        {
            yield return new WaitForSeconds(0.01f);
            audio1.volume = targetVolume;
            targetVolume -= 0.09f * Time.deltaTime;
        }
    }

    public bool ChecarChave()
    {
        if (player.hasKey)
            return true;
        return false;
    }

    public void ApagarTudo()
    {
        porta.SetActive(false);
        ob1.SetActive(false);
        ob2.SetActive(false);
    }
}
