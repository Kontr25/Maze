using System;
using UnityEngine;

public class GlobalEvent : MonoBehaviour
{
    public static Action Victory;
    public static Action Defeat;
    public static Action DisableCharacter;

    public static void SendVictory()
    {
        if (Victory != null)
        {
            Victory.Invoke();
            SendDisableCharacter();
        }
    }

    public static void SendDefeat()
    {
        if (Defeat != null)
        { Defeat.Invoke();
            SendDisableCharacter();
        }
    }

    public static void SendDisableCharacter()
    {
        if (DisableCharacter != null) DisableCharacter.Invoke();
    }
}
