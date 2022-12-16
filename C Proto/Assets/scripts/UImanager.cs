using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject questUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!questUI.activeSelf)
            {
                questUI.SetActive(true);
                FindObjectOfType<QuestsUIManager>().SetActiveQuest();
            }
            else { questUI.SetActive(false); }
        }
    }
}
