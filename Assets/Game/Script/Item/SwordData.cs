using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "Sword", menuName = "ItemData/Items/Sword", order = 1)]
    public class SwordData : ItemData
    {
        public int dmg;
        public float attackRate;
    }
}