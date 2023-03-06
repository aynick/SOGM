using UnityEngine;

namespace Script
{
    public abstract class ItemData : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public GameObject prefab;

    }
}