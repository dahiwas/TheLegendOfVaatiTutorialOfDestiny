using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public float damage = 2;
    public bool rightAttack;
    public Genius genius;

    public PlayerController playerController;


    public void StartAttack()
    {
        swordCollider.enabled = true;
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }



}
