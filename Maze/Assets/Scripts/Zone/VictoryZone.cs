using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class VictoryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Character character))
        {
            GlobalEvent.SendVictory();
        }
        
    }
}
