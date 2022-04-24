using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //CaixaDeConversa
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;

    public GameObject sepultura;
    public DialogueObject dO1;
    public DialogueObject dO2;
    public DialogueObject dO3;
    public Interactable Interactable { get; set; }
    //Instanciação das variaveis
    public float moveSpeed = 1f;
    public float collisionOffSet = 0.05f;
    public ContactFilter2D movementFilter;
    public bool canMove = true;
    public SwordAttack swordAttack;
    //Mana
    public bool emProcesso = false; //Processo de recarga para deixar o auemnto mais smooth
    public Stakes mana;
    public int topo;
    public bool inDash = false;
    public bool inSpin = false;
    //Vetores de movimento
    Vector2 movementInput; //valores 2D
    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer; //Renderização
    public Animator anim;
    //Checar colisões nas paredes
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();//Criação de uma lista vazia
    //Genius - Puzzle 2
    public Genius genius;
    public int contadorFogo = 0;

    public bool inChat = false;
    public bool passarChat = false;

    public GameObject interrog;
    public GameObject actionBallon;
    public bool spaceAction = false;

    //Inventario
    bool possuiBackpack = false;
    public GameObject backpack;
    public List<GameObject> inv;
    public GameObject inventory;
    public bool inventoryOn = false;
    public bool RuppiGot = false;
    public int RuppiQtd = 0;
    public int RuppiYellowQtd = 0;
    public int RuppiRedQtd = 0;

    public GameObject GreenRupee;
    public GameObject YellowRupee;
    public GameObject RedRupee;
    public GameObject LinksHead;
    public GameObject Key;

    public bool linkSpirit = false;
    public BoxCollider2D actionCollider;

    public int SlotsInventory = 0;

    public CoinScript gR;
    public CoinScript2 rR;
    public CoinScript3 yR;

    //Puzzle3
    public bool triforceSecret = false;
    public GameObject wallSpirit;
    public GameObject RupeesSecret;
    public GameObject RupeesSecret2;
    public GameObject Hole;

    //HUD
    public Animator BDash;
    public Animator BAction;
    public Animator BB;
    public GameObject switch1;
    public GameObject switch2;

    //KeyMakerRoom
    public GameObject KeyMakerScript;
    public GameObject KeyMakerObject;
    public bool keyMakerAccess = false;
    public bool hasKey = false;
    public GameObject RupeeForMaker;
    public GameObject RupeeForMaker2;
    public GameObject RupeeForMaker3;
    public GameObject RupeeForMaker4;
    public GameObject RupeeForMaker5;
    public GameObject RupeeForMaker6;
    public GameObject RupeeForMaker7;
    public GameObject RupeeForMaker8;
    public GameObject RupeeForMaker9;
    public GameObject RupeeForMaker10;

    public bool canOpen2Door = false;
    public PortaScript2 ps2;

    //CenaDeInicio
    public GameObject BG;

    //Audios
    public AudioSource RupeeG;
    public AudioSource RupeeR;
    public AudioSource RupeeY;
    public AudioSource LinksCabeca;
    public AudioSource Chave;
    public AudioSource backpackAudio;
    public AudioSource questionWall;
    public AudioSource backpackOpen;
    public AudioSource backpackClose;
    public AudioSource textOpen;
    public AudioSource textContinue;
    public AudioSource textClose;
    public AudioSource SpinAttacks;
    public AudioSource Dashes;
    public AudioSource walking;

    //FinalScene
    public bool FinalScene = false;
    public GameObject final;
    //Player HUD
    public GameObject _HUD;
    public GameObject _Mana;
    void Start()
    {
        BG.GetComponent<scriptFade>().FadeIn();
        //Instanciação para poder modificar no código
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mana = new Stakes();
        inv = new List<GameObject>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            //Constante carregamento de Mana quando o player estiver livre
            recarregarMana();
            //se o movimento não for 0, então tentar se mover
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (movementInput.x != 0)
                    movementInput.y = 0;
                else if (movementInput.y != 0)
                    movementInput.x = 0;

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
                //Animação de se movimentar
                anim.SetBool("isMoving", success);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
            //Flipar o sprite quando muda direção
            if (movementInput.y > 0)
            {
                anim.SetBool("isFront", false);
                anim.SetBool("Horizontal", false);
            }
            else if (movementInput.y < 0)
            {
                anim.SetBool("isFront", true);
                anim.SetBool("Horizontal", false);
            }
            else if(movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                anim.SetBool("isRight", true);
                anim.SetBool("Horizontal", true);
            }
            else if(movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                anim.SetBool("isRight", true);
                anim.SetBool("Horizontal", true);
            }
        }
        RuppiQtd = inv.FindAll(x => x.gameObject.name == GreenRupee.gameObject.name).Count;
        RuppiRedQtd = inv.FindAll(x => x.gameObject.name == RedRupee.gameObject.name).Count;
        RuppiYellowQtd = inv.FindAll(x => x.gameObject.name == YellowRupee.gameObject.name).Count;
    }
    private bool TryMove(Vector2 direction) // Conseguir escorregar nas paredes, deixa o jogo mais smooths
    {
        if (direction != Vector2.zero)
        {
            //Checar as possiveis colisões
            int count = rb.Cast(
                direction, // X e Y valores de -1 e 1 que representa a direção que o corpo está olhando
                movementFilter, // As configurações que determinarão onde a colisão ira ocorrer [Layers]
                castCollisions, // Lista de colisoes armazenadas depois do cast
                moveSpeed * Time.fixedDeltaTime + collisionOffSet);
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {  
            return false;
        }
    }
    void OnMove(InputValue movementValue) //Novo recurso da unity de InputSystem para movimentação ao inves de rigidbody2d
    {
        movementInput = movementValue.Get<Vector2>();
    }
   
    void recarregarMana() //Função para recarregar a mana
    {
        if (mana.getTopo() < 15 && !emProcesso && !inDash) //Recarregar apenas se a fila estiver com menos de 15
        {
            StartCoroutine(EncherMana());
        }
    }
    IEnumerator EncherMana() // Cronometro para que o preenchimento seja mais suave
    {
        emProcesso = true;
        mana.insere();
        yield return new WaitForSeconds(0.3f);
        emProcesso = false;
    }

    void OnFire() //Ao apertar o botao esquerdo do mouse, função do inputsystem
    {
        if(!inChat)
        {
            if (mana.getTopo() > 8 && !inDash && anim.GetBool("isMoving"))
            {
                Dashes.Play();
                BDash.SetBool("pressed", true);
                for (int i = 0; i < 8; i++) //Gasta 8 de mana por dash
                {
                    mana.remove();
                }
                StartCoroutine(SpeedUP());
            }
        }
        else
        {
            if(dialogueUI.IsOpen)
            {
                passarChat = true;
            }
                
        }

    }

    void OnTest()
    {
        if(RuppiQtd >= 1)
        {
            for(int i = 0; i < 1; i++)
                inv.Remove(GreenRupee);
        }
    }
    void OnInventory()
    {
        if (possuiBackpack && !dialogueUI.IsOpen)
        {
            
            VerificacaoDeSlots();
            BB.SetBool("pressed", true);
            Debug.Log("Apertou Inventario");
            if (!inventoryOn)
            {
                backpackOpen.Play();
                anim.SetBool("isMoving", false);
                LockMovement();
                inventory.SetActive(true);
                inventoryOn = true;
            }
            else
            {
                backpackClose.Play();

                BB.SetBool("pressed", false);
                UnlockMovement();
                inventory.GetComponent<InventorySystem>().Desativar();
                inventory.SetActive(false);
                inventoryOn = false;
                gR.Resetao();
                rR.Resetao();
                yR.Resetao();   
            }
        }
            
    }

    void VerificacaoDeSlots()
    {
        if(RuppiRedQtd !=0)
        {
            SlotsInventory++;
        }
        if (RuppiQtd != 0)
        {
            SlotsInventory++;
        }
        if (RuppiYellowQtd != 0)
        {
            SlotsInventory++;
        }
        if (linkSpirit)
        {
            SlotsInventory++;
        }
        if(hasKey)
        {
            SlotsInventory++;
        }
    }
    void OnSpin()
    {
        BAction.SetBool("pressed", true);

        if(Interactable != null && !dialogueUI.IsOpen && !triforceSecret && !keyMakerAccess)
        {
            Interactable.Interact(this);
        }
        else if (Interactable != null && !dialogueUI.IsOpen && triforceSecret && !keyMakerAccess)
        {
            Interactable.Interact(this);
            wallSpirit.GetComponent<WallSpirit>().Instanciar();
        }
        else if(Interactable != null && !dialogueUI.IsOpen && keyMakerAccess)
        {
            Interactable.Interact(this);
            KeyMakerObject.GetComponent<KeyMaker>().FazerChave();
            RupeeForMaker.SetActive(true);
            RupeeForMaker2.SetActive(true);
            RupeeForMaker3.SetActive(true);
            RupeeForMaker4.SetActive(true);
            RupeeForMaker5.SetActive(true);
            RupeeForMaker6.SetActive(true);
            RupeeForMaker7.SetActive(true);
            RupeeForMaker8.SetActive(true);
            RupeeForMaker9.SetActive(true);
            RupeeForMaker10.SetActive(true);
            for(int i = 0; i < 100; i++)
            {
                inv.Remove(GreenRupee);
            }
            for (int i = 0; i < 20; i++)
            {
                inv.Remove(RedRupee);
            }
        }

        if (mana.getTopo() > 3 && !inSpin && Interactable == null && linkSpirit)
        {
            SpinAttacks.Play();
            for(int i = 0; i <3; i++)
            {
                mana.remove();
            }

            StartCoroutine(SpinAttack());
        }else
        {
            StartCoroutine(Action());
        }
    }

    IEnumerator Action()
    { 
        actionCollider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        actionCollider.enabled = false;
        BAction.SetBool("pressed", false);
    }

    IEnumerator SpeedUP()
    {
        inDash = true;
        anim.SetBool("isRun", true);
        moveSpeed = 1.89f;
        yield return new WaitForSeconds(0.5f);
        inDash = false;
        anim.SetBool("isRun", false);
        BDash.SetBool("pressed", false);
        moveSpeed = 0.8f;
    }
    IEnumerator SpinAttack()
    {
        swordAttack.StartAttack();
        inSpin = true;
        LockMovement();
        anim.SetBool("Spin", true);
        yield return new WaitForSeconds(0.67f);
        anim.SetBool("Spin", false);
        BAction.SetBool("pressed", false);
        swordAttack.StopAttack();
        UnlockMovement();
        inSpin = false;
    }
    //Para executar alguams funções paradas
    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }
    


    //Detecção de colisão com outros objetos
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se o player colidir com a parede puzzle 2
        if (other.tag == "GeniusStart")
        {
            if(!genius.inicio)
                questionWall.Play();
            genius.inicio = true;
        }
        //Se o player colidir com o cemiterio
        if(other.tag == "Action")
        {
            if(!spaceAction)
            {
                actionBallon.SetActive(true);
                spaceAction = true;
            }
        }
        //Quando o player enconsta nas moedas do jogo
        if(other.tag == "Ruppy1")
        {
            RupeeG.Play();
            inv.Add(GreenRupee);
            other.GetComponent<Item>().Setar();

        }
        if (other.tag == "Ruppy2")
        {
            RupeeR.Play();
            inv.Add(RedRupee);
            other.GetComponent<Item>().Setar();

        }
        if (other.tag == "Ruppy3")
        {
            RupeeY.Play();
            inv.Add(YellowRupee);
            other.GetComponent<Item>().Setar();

        }
        if (other.tag == "Key")
        {
            if(!hasKey)
            {
                LinksCabeca.Play();
                inv.Add(Key);
                hasKey = true;
                other.GetComponent<Item>().Setar();
            }
        }
        if (other.tag == "Backpack")
        {
            if(!possuiBackpack)
            {
                backpackAudio.Play();
                sepultura.GetComponent<DialogueActivator>().dialogueObject = dO1;
                backpack.SetActive(true);
                possuiBackpack = true;
                wallSpirit.SetActive(true);
                RupeesSecret.SetActive(true);
                other.GetComponent<Item>().Setar();

            }


        }
        if (other.tag == "LinkHead")
        {
            if(!linkSpirit)
            {
                other.GetComponent<Item>().Setar();
                LinksCabeca.Play();
                inv.Add(LinksHead);
                linkSpirit = true;
                switch1.SetActive(false);
                switch2.SetActive(true);
                sepultura.GetComponent<DialogueActivator>().dialogueObject = dO2;
                RupeesSecret2.SetActive(true);
            }

        }
        if(other.tag == "TriforceSecret")
        {
            if (!spaceAction)
            {
                actionBallon.SetActive(true);
                spaceAction = true;
                triforceSecret = true;
                Hole.SetActive(true);
            }
        }
        if(other.tag == "KeyMaker")
        {
            if(RuppiQtd >= 25 && RuppiRedQtd > 20)
            {
                KeyMakerScript.GetComponent<DialogueActivator>().dialogueObject = dO3;
                keyMakerAccess = true;
            }
        }
        if(other.tag == "Porta2")
        {
            if(hasKey)
            {
                canOpen2Door = true;
            }
        }
        if(other.tag == "FinalDoor")
        {
            FinalScene = true;
            final.SetActive(true);
            _HUD.SetActive(false);
            _Mana.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Action")
        {
            if (spaceAction)
            {
                actionBallon.SetActive(false);
                spaceAction = false;
            }
        }
        if (other.tag == "TriforceSecret")
        {
            if (spaceAction)
            {
                actionBallon.SetActive(false);
                spaceAction = false;
                triforceSecret = false;
            }
        }
    }

    public void Walk()
    {
        walking.Play();
    }
    public void Question()
    {
        //Para mudar a rotação do objeto
        Transform logo = interrog.transform;
        Vector3 newRotation = new Vector3(0, 0, -20);        
        logo.eulerAngles = newRotation;
        Instantiate(interrog, transform.position + new Vector3(0,0.13f,0), transform.rotation) ;
        Instantiate(interrog, transform.position + new Vector3(0.13f, 0.08f, 0), logo.rotation);
        newRotation = new Vector3(0, 0, 20);
        logo.eulerAngles = newRotation;
        Instantiate(interrog, transform.position + new Vector3(-0.13f, 0.08f, 0), logo.rotation);
    }

}
