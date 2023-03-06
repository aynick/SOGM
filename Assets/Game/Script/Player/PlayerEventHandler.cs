using System;
using UnityEngine;

namespace Script
{
    public class PlayerEventHandler : MonoBehaviour
    {
        public event Action<PlayerStats> OnStatsChanged;

        public void OnStatsChange(PlayerStats playerStats)
        {
            OnStatsChanged?.Invoke(playerStats);
        }
    }
}