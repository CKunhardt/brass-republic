using System;

public class Conversation
{
    [System.Serializable]

	public class ConvNode
	{
        // pass character, day, number
        // if XYZ, then (character, 123, 123)
	}

    public Node startNode;
}


public void TriggerDialogue()
{
    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
}



public Text nameText;
public Text dialogueText;





nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
{
    if (sentences.Count == 0)
    {
        EndDialogue();
        return;
    }

    string sentence = sentences.Dequeue();
    dialogueText.text = sentence;
}

void EndDialogue()
{
    Debug.Log("End of conversation.");
}