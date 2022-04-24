using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinScript : MonoBehaviour
{
    public PlayerController player;

    public TMP_Text coin;
    public TMP_Text coin2;
    public TMP_Text coin3;
    public TMP_Text coin4;

    public Transform spot1;
    public Transform spot2;
    public Transform spot3;
    public Transform spot4;

    public bool p1 = false;
    public bool p2 = false;
    public bool p3 = false;
    public bool p4 = false;
    private void Update()
    {
        if(p1)
        {
            transform.position = spot1.position;
        }
        else if (p2)
        {
            transform.position = spot2.position;
        }
        else if (p3)
        {
            transform.position = spot3.position;
        }
        else if (p4)
        {
            transform.position = spot4.position;
        }
        coin.text = player.RuppiQtd.ToString();

        if (player.RuppiQtd == 0)
            coin.text = null;
    }
    public void Resetao()
    {
        p1 = false;
        p2 = false;
        p3 = false;
        p4 = false;
    }
}
