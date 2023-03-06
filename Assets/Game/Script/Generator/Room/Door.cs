using System;
using System.Collections;
using System.Collections.Generic;
using Game.Script.Generator.Room;
using UnityEngine;

public class Door : MonoBehaviour , IDamagable
{
    [SerializeField] private int Hp;
    [SerializeField] private Collider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject particle;
    [SerializeField] private RoomEventHandler _eventHandler;
    
    private void Start()
    {
        _eventHandler.OnPlayerEntered += Close;
        _collider.isTrigger = true;
    }

    public void ApplyDamage(int dmg)
    {
        if ((Hp - dmg) > 0)
        {
            Hp -= dmg;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Close()
    {
        _collider.isTrigger = false;
        _animator.SetBool("Close", true);
    }
    
    private void OnDestroy()
    {
        _eventHandler.OnPlayerEntered -= Close;
        if (gameObject.scene.isLoaded)
            Instantiate(particle, transform.position,Quaternion.identity);
    }
}
