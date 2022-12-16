using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public int ID;
    public int uiID;
    public bool toActivate = false;

    [SerializeField] public GameObject[] UIlayer;
    [SerializeField] GameObject drawFolder;

    //Инфа о настройках рисовальщика
    public int btnsNumber;
    public Vector3[] positions;

    public JournalItemData imageData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            UIlayer[uiID].SetActive(true);
            toActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIlayer[uiID].SetActive(false);
            toActivate = false;
        }
    }

    private void Update()
    {
        if(toActivate)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                drawFolder.SetActive(true);
                FindObjectOfType<Controller>().enabled = false;
                FindObjectOfType<Draw>().SetImage(imageData.ID, imageData.image);
                FindObjectOfType<Draw>().SetDrawer(btnsNumber, positions, this);
                toActivate = false;
            }
        }
        
    }
}
