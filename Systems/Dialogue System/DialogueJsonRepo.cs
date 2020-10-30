using System.Collections.Generic;
using UnityEngine;

public class DialogueJsonRepo : IDialogueRepo
{
    Dictionary<string, Dialogue> _conversions;
    private string DialogueFile;
    public DialogueJsonRepo(string DialogueFile)
    {
        this.DialogueFile = DialogueFile;
    }

    public void setupDictionary()
    {
        Dialogue[] d = JsonUtility.FromJson<Dialogue[]>(DialogueFile);
        //add to Dictionary
        foreach (Dialogue dia in d)
        {
            _conversions.Add(dia.ConversationID, dia);
        }
    }


    public Dialogue GetConversation(string id) => _conversions[id];
}