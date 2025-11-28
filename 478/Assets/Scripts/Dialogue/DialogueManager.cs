using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button[] choiceButtons;
    public UnityEvent onGoodChoice;
    public UnityEvent onBadChoice;

    private DialogueNode currentNode;
    private List<DialogueNode> nodes = new List<DialogueNode>();

    void Start()
    {
        SetupDialogue();
        ShowNode(0);
    }

    void SetupDialogue()
    {
        var node0 = new DialogueNode { text = "Чё надо?" };
        node0.choices.Add(new DialogueChoice { text = "Все норм, прохожу мимо", isBadChoice = false });
        node0.choices.Add(new DialogueChoice { text = "Пошёл ты", isBadChoice = true });
        nodes.Add(node0);
    }

    public void ShowNode(int nodeId)
    {
        currentNode = nodes[nodeId];
        dialogueText.text = currentNode.text;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < currentNode.choices.Count)
            {
                int index = i;
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentNode.choices[i].text;
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnChoiceSelected(int choiceId)
    {
        DialogueChoice choice = currentNode.choices[choiceId];
        if (choice.isBadChoice)
        {
            onBadChoice.Invoke();
        }
        else
        {
            onGoodChoice.Invoke();
        }
    }
}
