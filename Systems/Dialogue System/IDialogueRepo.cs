public interface IDialogueRepo
{
    Dialogue GetConversation(string id);
    void setupDictionary();
}