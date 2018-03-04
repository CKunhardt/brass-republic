using System;

public class DialogueTrigger
{
    public DialogueTrigger dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
