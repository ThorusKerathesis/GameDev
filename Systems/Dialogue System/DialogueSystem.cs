using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private float typingSpeed = 0.02f;

    private Dialogue _dialogue;
    private Coroutine cor;
    private WaitForSeconds Wait;
    private IDialogueRepo dialogueRepo;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)){
            typingSpeed = 0f;
            Wait = new WaitForSeconds(typingSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
        }
       
    }

    public void StartDialogue(string ConversionID)
    {
        _dialogue = dialogueRepo.GetConversation(ConversionID);
        TypeSentence();
    }

    private void TypeSentence()
    {
        cor = StartCoroutine(TypeSentence_Coroutine());
    }

    private void StopTyping()
    {
        StopCoroutine(cor);
    }
    private IEnumerator TypeSentence_Coroutine()
    {
        typingSpeed = 0.02f;
        Wait = new WaitForSeconds(typingSpeed);
        foreach (char letter in _dialogue.NextSentence()) {
            textDisplay.text += letter;
            yield return Wait;
        }
    }

    public void NextSentence() 
    {
        StopTyping();
        if (_dialogue.SentencesRemaining())
        {
            ClearText();
            TypeSentence();
        }
        else
        {
            ClearText();
        }

    }

    private void ClearText()
    {
        textDisplay.text = "";
    }
}
