using System;
using System.Collections.Generic;

[Serializable]
public class DialogueNode
{
    public string text;
    public List<DialogueChoice> choices = new List<DialogueChoice>();
}

[Serializable]
public class DialogueChoice
{
    public string text;
    public bool isBadChoice;
}
