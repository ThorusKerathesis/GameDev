using System;
using System.Collections.Generic;
using System.Linq;
[Serializable]
public class Dialogue
{
    private string _ConversationId;
    private string[] sentences;

    private List<string> activeSentences;

    internal char[] NextSentence()
    {
        activeSentences = sentences.ToList<string>();
        char[] sentence = activeSentences[0].ToCharArray();
        activeSentences.Remove(activeSentences[0]);
        return sentence;
    }

    internal bool SentencesRemaining()
    {
        return sentences.Length != 0;
    }
    internal string ConversationID => _ConversationId;
}


