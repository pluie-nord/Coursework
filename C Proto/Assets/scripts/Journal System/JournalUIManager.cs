using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalUIManager : MonoBehaviour
{
    public List<JournalItemData> imagesInStack;
    [SerializeField] Image[] images = new Image[2];
    public int pageNumber = 0;
    [SerializeField] GameObject UIFolder;
    [SerializeField] TextMeshProUGUI page;
    public void SetStartImages(int startPage)
    {
        for(int i=startPage; i<startPage+2; i++)
        {
            if (imagesInStack.Count>i)
            {
                images[(i%2)].color = new Color32(255, 255, 255, 255);
                images[(i % 2)].sprite = imagesInStack[i].image;
            }
            else
            {
                images[(i % 2)].color = new Color32(255,255,255,0);
            }
        }

    }

    public void NextPage()
    {
        pageNumber+=2;
        SetStartImages(pageNumber);
        page.text = (pageNumber / 2).ToString();
    }

    public void LastPage()
    {
        if(pageNumber-2>=0)
        {
            pageNumber -= 2;
            SetStartImages(pageNumber);
            page.text = (pageNumber / 2).ToString();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UIFolder.SetActive(true);
            SetStartImages(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIFolder.SetActive(false);
            pageNumber = 0;
        }
    }

}
