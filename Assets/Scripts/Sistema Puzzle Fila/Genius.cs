using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genius : MonoBehaviour
{
    //Player de referencia
    public PlayerController player;
    //Botoes de referencia
    public ButtonFire button1;
    public ButtonFire button2;
    public ButtonFire button3;
    public ButtonFire button4;
    //Variaveis de Controle
    public bool PB1 = false;
    public bool PB2 = false;
    public bool PB3 = false;
    public bool PB4 = false;
    public bool FPB1 = true;
    public bool FPB2 = true;
    public bool FPB3 = true;
    public bool FPB4 = true;
    public bool inicio = false;
    public bool firstTime = true;
    public bool inTeste = false;
    public bool isCorrect = true;
    public int numeroRandom;

    public AudioSource bt1;
    public AudioSource bt2;
    public AudioSource bt3;
    public AudioSource bt4;
    public AudioSource Wrong;
    public AudioSource Right;
    //Criação de Filas e Lista
    public FilaEncadeadaCircular<ButtonFire> FilaButtons;
    public FilaEncadeadaCircular<ButtonFire> FilaButtonsPlayer;

    [SerializeField]
    public List<Queue<ButtonFire>> ListaDeFila = new List<Queue<ButtonFire>>();

    //BauRecompensa
    public Chest chest;
    public void Start()
    {
        FilaButtons = new FilaEncadeadaCircular<ButtonFire>();
        FilaButtonsPlayer = new FilaEncadeadaCircular<ButtonFire>();
    }

    public void Update()
    {
        if(inicio && firstTime) // Quando pisar no tapete
        {
            player.Question();
            player.LockMovement();
            player.anim.SetBool("isMoving", false);
            StartCoroutine(InicioTapete());
            firstTime = false;
        }
        //verificação se encostou no botao selecionado
        if(PB1 && FPB1 && !firstTime)//Ir colocando na fila do player na sequencia que ele pisar nos botoes
        {
            FPB1 = false;
            bt1.Play();
            FilaButtonsPlayer.Inserir(ref button1);
        }
        else if(PB2 && FPB2 && !firstTime)
        {
            FPB2 = false;
            bt2.Play();
            FilaButtonsPlayer.Inserir(ref button2);
        }
        else if (PB3 && FPB3 && !firstTime)
        {
            FPB3 = false;
            bt3.Play();
            FilaButtonsPlayer.Inserir(ref button3);
        }
        else if (PB4 && FPB4 && !firstTime)
        {
            FPB4 = false;
            bt4.Play();
            FilaButtonsPlayer.Inserir(ref button4);
        }
        if (player.contadorFogo >=4)//Ao ativar 4, o jogo fará uma verificação se a sequencia está correta
        {
            FilaButtons.TransformarPilhaFila();
            FilaButtonsPlayer.TransformarPilhaFila();
            while (!FilaButtons.Vazia() && isCorrect) //Enquanto a fila do sistema nao estiver vazia
            {
                if (FilaButtons.Retirar() != FilaButtonsPlayer.Retirar()) //Comparar os elementos retirados das duas filas
                {
                    FilaButtons.Esvaziar();
                    FilaButtonsPlayer.Esvaziar();
                    isCorrect = false;
                    Wrong.Play();
                    Debug.Log("Errou, tente novamente");

                    StartCoroutine(Errou());


                    firstTime = true;
                    StartCoroutine(InicioTapete());
                    firstTime = false;
                }
            }
            if(isCorrect)//Tem uma mini explosão se der tudo certo em cada botão
            {
                Right.Play();   
                Instantiate(chest);
                button1.GetComponent<Animator>().SetTrigger("correct");
                button2.GetComponent<Animator>().SetTrigger("correct");
                button3.GetComponent<Animator>().SetTrigger("correct");
                button4.GetComponent<Animator>().SetTrigger("correct");
            }
            //Reset caso dê errado para poder tentar novamente
            resetContagem();
        }    
    }
    public void shutdownButtons()//Função para apagar os fogos
    {
        button1.GetComponent<SpriteRenderer>().enabled = false;
        button2.GetComponent<SpriteRenderer>().enabled = false;
        button3.GetComponent<SpriteRenderer>().enabled = false;
        button4.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void resetContagem()
    {
        isCorrect = true;
        FPB1 = true;
        FPB2 = true;
        FPB3 = true;
        FPB4 = true;
        PB1 = false;
        PB2 = false;
        PB3 = false;
        PB4 = false;
        player.contadorFogo = 0;
    }

    IEnumerator InicioTapete() //Ao pisar no tapete acrescentar os botoes nessa ordem
    {

        yield return new WaitForSeconds(1.1f);
        bt1.Play();
        button1.GetComponent<SpriteRenderer>().enabled = true;
        FilaButtons.Inserir(ref button1);

        yield return new WaitForSeconds(0.8f);
        bt2.Play();
        button2.GetComponent<SpriteRenderer>().enabled = true;
        FilaButtons.Inserir(ref button2);

        //Debug.Log(FilaMostrada.headNode.next.block);
        yield return new WaitForSeconds(0.8f);
        bt3.Play();
        button3.GetComponent<SpriteRenderer>().enabled = true;
        FilaButtons.Inserir(ref button3);
 
        yield return new WaitForSeconds(0.8f);
        bt4.Play();
        button4.GetComponent<SpriteRenderer>().enabled = true;
        FilaButtons.Inserir(ref button4);

        yield return new WaitForSeconds(0.8f);
        shutdownButtons();
        player.UnlockMovement();


    }

    IEnumerator Errou()
    {
        button1.GetComponent<Animator>().SetTrigger("incorrect");
        button2.GetComponent<Animator>().SetTrigger("incorrect");
        button3.GetComponent<Animator>().SetTrigger("incorrect");
        button4.GetComponent<Animator>().SetTrigger("incorrect");
        yield return new WaitForSeconds(0.69f);
        shutdownButtons();
    }
}


