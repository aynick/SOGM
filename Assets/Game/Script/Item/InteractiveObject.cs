using UnityEngine;

namespace Script
{
    public abstract class InteractiveObject : MonoBehaviour
    {
        public abstract void Use(PlayerBehavior playerBehavior);
    }
}