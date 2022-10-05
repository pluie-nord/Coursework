using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    Draw drawManager;
    private void Start()
    {
        drawManager = FindObjectOfType<Draw>();
    }
    public void CheckOrder()
    {
        if (drawManager.currentOrder[0]==gameObject)
        {
            drawManager.SetLine();
        }
        else
        {
            drawManager.ResetLine();
        }
    }
}
