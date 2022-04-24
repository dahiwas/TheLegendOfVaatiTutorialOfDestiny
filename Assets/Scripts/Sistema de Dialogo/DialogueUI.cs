using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] public DialogueObject testDialogue;

    public GameObject WallSpirit;
    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    public PlayerController player;
    private TypeWritterEffect typewritterEffect;
    //Method for draw the text
    private void Start()
    {
        responseHandler = GetComponent<ResponseHandler>();  
        typewritterEffect = GetComponent<TypeWritterEffect>();
        CloseDialogueBox();
    }
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        player.LockMovement();
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        player.inChat = true;
        player.textOpen.Play();
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewritterEffect.Run(dialogue, textLabel); 
            if((i == dialogueObject.Dialogue.Length - 1) && dialogueObject.hasResponses)
                break;
            yield return new WaitUntil(() => player.passarChat);
            player.textContinue.Play();
            player.passarChat = false;
        }
        if(dialogueObject.hasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            player.textClose.Play();
            CloseDialogueBox();
        }
    }

    private void CloseDialogueBox()
    {
        player.UnlockMovement();
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        player.inChat = false;
    }

}
