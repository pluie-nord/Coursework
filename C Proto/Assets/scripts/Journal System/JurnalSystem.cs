using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurnalSystem : MonoBehaviour
{
    public static JurnalSystem Instance { get; set; }

    private Dictionary<JournalItemData, JournalItem> m_itemDictionary;
    public List<JournalItem> inventory { get; private set; }
    private JournalUIManager journalUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        //DontDestroyOnLoad(this);
        inventory = new List<JournalItem>();
        m_itemDictionary = new Dictionary<JournalItemData, JournalItem>();
        journalUI = FindObjectOfType<JournalUIManager>();
    }

    public void Add(JournalItemData referenceData)
    {
        if (!m_itemDictionary.TryGetValue(referenceData, out JournalItem value))
        {
            JournalItem newItem = new JournalItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
            journalUI.imagesInStack.Add(referenceData);
        }
    }

    public void Remove(JournalItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out JournalItem value))
        {
            inventory.Remove(value);
            m_itemDictionary.Remove(referenceData);
            journalUI.imagesInStack.Remove(referenceData);
        }
    }
}

public class JournalItem
{
    public JournalItemData data { get; private set; }
    public int stackSize { get; private set; }

    public JournalItem(JournalItemData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }
}
