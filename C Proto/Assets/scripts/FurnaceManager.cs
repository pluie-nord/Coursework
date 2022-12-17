using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceManager : MonoBehaviour
{
    public bool toActivate = false;

    [SerializeField] public GameObject UIlayer;

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
                FindObjectOfType<CraftManager>().OpenCraft();
                toActivate = false;
            }
        }

    }
}
