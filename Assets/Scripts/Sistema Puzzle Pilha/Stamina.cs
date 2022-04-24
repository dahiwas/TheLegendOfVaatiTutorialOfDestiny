using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Stamina : MonoBehaviour
{
    public Image staminaBar;
    public PlayerController player;
    public bool cheio;
    float stamina, maxStamina = 15;
    float lerpSpeed; //Deixar o preenchimento suave
    //Perseguição do player
    public Camera cam;    // Camera que contem o canvas
    public Transform target; // objeto para perseguir
    public RectTransform icon;   // qual imagem no canvas
    public Canvas canvas; // qual canvas
    private void Start()
    {
        stamina = maxStamina;
    }
    void FixedUpdate()
    {
        stamina = player.mana.getTopo();
        staminaBarFiller();
        lerpSpeed = 9f * Time.deltaTime;
        colorChanger();
        //Perseguir o player, necessario dos dados de onde está
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        float h = Screen.height;
        float w = Screen.width;
        float x = screenPos.x - (w / 2);
        float y = screenPos.y - (h / 2);
        float s = canvas.scaleFactor;
        icon.anchoredPosition = new Vector2(x, y) / s;
        //Retirar da HUD para o não atrapalhar o player quando a stamina estiver cheia
        estaCheio();
        if(cheio)
        {
            staminaBar.enabled = false;
        }
        else
        {
            staminaBar.enabled = true;
        }
    }
    void estaCheio()
    {
        if(stamina >= maxStamina)
        {
            StartCoroutine(Tempo());
        }
        else
        {
            cheio = false;
        }
    }
    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(0.5f);
        cheio = true;
    }
    void staminaBarFiller()//Preenchimento da stamina
    {
        staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, stamina/maxStamina, lerpSpeed);
    }
    void colorChanger()//A cor da stamina muda dependendo de quão cheio está
    {
        Color staminaColor = Color.Lerp(Color.red, Color.blue, (stamina / maxStamina));
        staminaBar.color = staminaColor;
    }
}
