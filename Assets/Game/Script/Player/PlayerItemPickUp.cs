using System;
using UnityEngine;

namespace Script
{
    public class PlayerItemPickUp : MonoBehaviour
    {
        [SerializeField] private PlayerBehavior _playerBehavior;

        // public void PickUp(ItemDrop itemDrop)
        // {
        //     bool wasAdded = _playerInventory.Add(itemDrop.itemData);
        //     if (wasAdded) { 
        //         Destroy(itemDrop.gameObject);
        //     }
        // }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ItemDrop itemDrop))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    itemDrop.Use(_playerBehavior);
                }
            }
        }

        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.TryGetComponent(out ItemDrop itemDrop))
        //     {
        //         bool wasAdded = _playerInventory.Add(itemDrop.itemData);
        //          if (wasAdded) 
        //          { 
        //              Destroy(itemDrop.gameObject);
        //          }
        //     }
        // }
    }
}