using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour, ITalk
{
    //������ �������, �������� ������� � ������ �������
    [SerializeField] DialogueState firstState;
    public DialogueState currentState;
    public bool ActiveDialogue;

    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] TextMeshProUGUI nameBox;
    [SerializeField] GameObject UIFolder;

    public TutorialQuest_1 QuestToSet;

    public string stateID { get; set; }

    void Start()
    {
        NewDialogue(firstState);
    }

    //���������� ������ �� �����
    private void UpdateText()
    {
        textBox.text = currentState.Text;
        nameBox.text = currentState.Name;
    }

    public void NewDialogue(DialogueState newState)
    {
        ActiveDialogue = true;
        currentState = newState;
        UpdateText();
        UIFolder.SetActive(true);
        FindObjectOfType<Controller>().enabled = false;
    }

    void Update()
    {
        if(ActiveDialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentState.NextState!=null) //�������� �� ��������� �������
                {
                    currentState=currentState.NextState;
                    UpdateText();
                }
                else
                {
                    stateID = currentState.name;
                    print(stateID);
                    TalkEvent.StateChanged(this);
                    UIFolder.SetActive(false);
                    ActiveDialogue = false;
                    FindObjectOfType<Controller>().enabled = true;
                    if (QuestToSet != null)
                    {
                        QuestToSet.SetQuest();
                    }
                }
            }
        }

    }
}
