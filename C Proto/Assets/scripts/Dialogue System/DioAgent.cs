using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioAgent : MonoBehaviour
{
    private bool toActivate = false;

    [SerializeField] public GameObject UIlayer;
    [SerializeField] public DialogueState State;

    [SerializeField] public TutorialQuest_1 thisQuest;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIlayer.SetActive(true);
            toActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIlayer.SetActive(false);
            toActivate = false;
        }
    }

    private void Update()
    {
        if (toActivate)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<DialogueSystem>().NewDialogue(State);
                FindObjectOfType<DialogueSystem>().QuestToSet = thisQuest;
                toActivate = false;
            }
        }

    }
}
