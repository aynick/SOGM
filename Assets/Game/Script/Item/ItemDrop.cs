using System;
using UnityEngine;

namespace Script
{
    public class ItemDrop : InteractiveObject
    {
        [SerializeField] private Transform meshPos;
        public ItemData itemData;
        public void SetItem(ItemData itemData)
        {
            if (itemData == null) return;
            this.itemData = itemData;
            Instantiate(itemData.prefab, meshPos);
        }
        
        private void OnEnable()
        {
            SetItem(itemData);
        }

        public override void Use(PlayerBehavior playerBehavior)
        {
            playerBehavior.PlayerInventory.Add(itemData);
            Destroy(gameObject);
        }
    }
}