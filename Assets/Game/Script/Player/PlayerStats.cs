using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class PlayerStats : MonoBehaviour, IDamagable
    {
        [SerializeField]private int hp;
        [SerializeField]private int stamina;
        [SerializeField] private Slider HpSlider;
        [SerializeField] private Slider StaminaSlider;

        private void Start()
        {
            HpSlider.value = hp;
            StaminaSlider.value = stamina;
        }

        public void ApplyDamage(int dmg)
        {
            if ((hp-dmg) <= 0)
            {
            }
            hp -= dmg;
            HpSlider.value = hp;
        }
    }
}