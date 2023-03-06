using System;
using UnityEngine;

namespace Game.Script.Generator.Room
{
    public class RoomEventHandler : MonoBehaviour
    {
        public event Action OnPlayerEntered;

        public void OnPlayerEnter()
        {
            OnPlayerEntered?.Invoke();
        }
    }
}