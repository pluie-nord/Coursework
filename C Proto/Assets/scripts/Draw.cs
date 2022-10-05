using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    [SerializeField] List<GameObject> btnsOrder;
    public List<GameObject> currentOrder;
    [SerializeField] GameObject image;
    public ObjectInteraction currentObject;
    private void Start()
    {
        currentOrder = new List<GameObject>();
        foreach(var i in btnsOrder)
        {
            currentOrder.Add(i);
        }
        
        for (int i = 1; i<btnsOrder.Count; i++)
        {
            btnsOrder[i].GetComponent<Button>().interactable = false;
        }
    }

    public void SetLine()
    {
        print("right btn");
        if (currentOrder[0] == btnsOrder[0])
        {
            for (int i = 1; i < btnsOrder.Count; i++)
            {
                btnsOrder[i].GetComponent<Button>().interactable = true;
            }
        }
        currentOrder.Remove(currentOrder[0]);
        if (currentOrder.Count == 0)
        {
            
            foreach(var i in btnsOrder)
            {
                Destroy(i);
            }
            btnsOrder.Clear();
            DrawImage();
        }
    }    

    public void ResetLine()
    {
        print("wrong btn");
        currentOrder.Clear();
        foreach (var i in btnsOrder)
        {
            currentOrder.Add(i);
        }

        for (int i = 1; i < btnsOrder.Count; i++)
        {
            btnsOrder[i].GetComponent<Button>().interactable = false;
        }
    }

    private void DrawImage()
    {
        Destroy(currentObject.UIlayer);
        Destroy(currentObject);
        image.SetActive(true);
    }

    [SerializeField] GameObject drawFolder;
    public void Close()
    {
        if (btnsOrder.Count!=0)
        {
            ResetLine();
        }
        drawFolder.SetActive(false);
        FindObjectOfType<ShipController>().enabled = true;
        
    }    

}
