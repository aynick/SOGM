using System;
using System.Collections;
using System.Collections.Generic;
using Game.Script.Generator.Room;
using Script;
using UnityEngine;

public class RoomEnterTrigger : MonoBehaviour
{
    [SerializeField] private RoomEventHandler _roomEventHandler;
    private bool isPlayerEnter;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerBehavior playerBehavior))
        {
            if (isPlayerEnter) return;
            _roomEventHandler.OnPlayerEnter();
            isPlayerEnter = true;
        }
    }
}
