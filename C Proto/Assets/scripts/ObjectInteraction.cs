using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public int ID;
    public Sprite image;
    private bool toActivate = false;

    [SerializeField] public GameObject UIlayer;
    [SerializeField] GameObject drawFolder;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
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
        if(toActivate)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                drawFolder.SetActive(true);
                FindObjectOfType<Controller>().enabled = false;
                FindObjectOfType<Draw>().currentObject = this;
                FindObjectOfType<Draw>().SetImage(ID, image);
            }
        }
        
    }
}
