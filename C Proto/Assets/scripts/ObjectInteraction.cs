using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] public GameObject UIlayer;
    [SerializeField] GameObject drawFolder;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            UIlayer.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIlayer.SetActive(false);
        }
    }

    private void Update()
    {
        if(UIlayer.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                drawFolder.SetActive(true);
                FindObjectOfType<ShipController>().enabled = false;
                FindObjectOfType<Draw>().currentObject = this;
            }

        }
    }
}
