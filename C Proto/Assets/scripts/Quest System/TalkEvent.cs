using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkEvent : MonoBehaviour
{
    public delegate void TalkEventHandler(ITalk state);
    public static event TalkEventHandler OnStateChanged;

    public static void StateChanged(ITalk state)
    {
        print("Ивент затыкнулся");
        OnStateChanged?.Invoke(state);
    }
}
