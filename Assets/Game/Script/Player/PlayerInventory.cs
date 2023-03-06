using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{

    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private List<ItemData> items = new List<ItemData>();
        private int space = 3;
        [SerializeField] private ItemDrop itemDropPrefab;
        [SerializeField] private Transform handTransform;
        private ItemData _currentItemData;
        private int _currentSlot;

        public bool Add(ItemData itemData)
        {
            if (items.Count >= space)
            {
                Drop();
            }
            items.Add(itemData);
            SelectItem(_currentSlot);
            return true;
        }

        public void Drop()
        {
            if (_currentItemData != null)
            {
                items.Remove(_currentItemData);
                Instantiate(itemDropPrefab, transform.position + transform.forward * 3, Quaternion.identity).GetComponent<ItemDrop>()
                    .SetItem(_currentItemData);
                _currentItemData = null;
                if (handTransform.childCount > 0)
                {
                    for (int i = 0; i < handTransform.childCount; i++)
                    {
                        Destroy(handTransform.GetChild(i).gameObject);
                    }
                }
                SelectItem(_currentSlot);
            }
        }

        public void SelectItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                _currentSlot = index;
                _currentItemData = items[_currentSlot];
                if (handTransform.childCount > 0)
                {
                    Destroy(handTransform.GetChild(0).gameObject);
                }
                var item = Instantiate(_currentItemData.prefab, handTransform);
                item.TryGetComponent(out SwordObject swordObject);
                swordObject.SetSwordData((SwordData)_currentItemData);
            }
            else
            {
                _currentItemData = null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();
            }
        }
    }
}

