using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Draw : MonoBehaviour, IPicture
{
    public int ID { get; set; }

    [SerializeField] List<GameObject> btnsOrder;
    public List<GameObject> currentOrder;
    [SerializeField] GameObject imageObj;
    public ObjectInteraction currentObject;

    [SerializeField] GameObject BtnPrefab;

    public void SetImage(int pictureID, Sprite image)
    {
        ID = pictureID;
        imageObj.GetComponent<Image>().sprite = image;
    }

    public void SetLine()
    {
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

    public void SetDrawer(int btnNumber, Vector3[] positions, ObjectInteraction newObject)
    {
        for (var i = 0; i < btnNumber; i++)
        {
            GameObject newBtn = Instantiate(BtnPrefab);
            newBtn.transform.SetParent(gameObject.transform);
            newBtn.transform.localPosition = positions[i];
            newBtn.transform.localScale = new Vector3(1, 1, 1);
            newBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            btnsOrder.Add(newBtn);
        }
        currentObject = newObject;
        foreach (var i in btnsOrder)
        {
            currentOrder.Add(i);
        }
    }

    public void ResetLine()
    {
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
        currentObject.UIlayer[currentObject.uiID].SetActive(false);
        if (currentObject.uiID==0)
        {
            Destroy(currentObject);
        }
        else
        {
            currentObject.uiID = 1;
        }
        imageObj.SetActive(true);
        DrawEvent.PictureDrawn(this);
        FindObjectOfType<JurnalSystem>().Add(currentObject.imageData);
    }

    [SerializeField] GameObject drawFolder;
    public void Close()
    {
        if (btnsOrder.Count!=0)
        {
            ResetLine();
        }
        drawFolder.SetActive(false);
        FindObjectOfType<Controller>().enabled = true;
        imageObj.SetActive(false);

    }    

}
