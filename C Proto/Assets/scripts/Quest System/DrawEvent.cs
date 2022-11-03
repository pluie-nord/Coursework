using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEvent : MonoBehaviour
{
    public delegate void EnemyEventHandler(IPicture picture);
    public static event EnemyEventHandler OnPictureDrawn;

    public static void PictureDrawn(IPicture picture)
    {
        OnPictureDrawn?.Invoke(picture);
    }
}
