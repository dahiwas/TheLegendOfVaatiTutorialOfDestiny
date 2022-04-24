using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Genius genius;

    public PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se o player colidir com os botoes do genius
        if (other.tag == "GeniusButton")
        {
            if (!genius.firstTime)
            {
                if (!genius.button1.GetComponent<SpriteRenderer>().enabled)
                {
                    playerController.contadorFogo++;
                    genius.PB1 = true;
                }
                genius.button1.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        if (other.tag == "GeniusButton2")
        {
            if (!genius.firstTime)
            {
                if (!genius.button2.GetComponent<SpriteRenderer>().enabled)
                {
                    playerController.contadorFogo++;
                    genius.PB2 = true;
                }
                genius.button2.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        if (other.tag == "GeniusButton3")
        {
            if (!genius.firstTime)
            {
                if (!genius.button3.GetComponent<SpriteRenderer>().enabled)
                {
                    playerController.contadorFogo++;
                    genius.PB3 = true;
                }
                genius.button3.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        if (other.tag == "GeniusButton4")
        {
            if (!genius.firstTime)
            {
                if (!genius.button4.GetComponent<SpriteRenderer>().enabled)
                {
                    playerController.contadorFogo++;
                    genius.PB4 = true;
                }
                genius.button4.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
