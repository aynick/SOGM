using System;
using System.Collections;
using System.Collections.Generic;
using Game.Script.Generator.Room;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{
    [SerializeField] private RoomEventHandler _roomEventHandler;
    public GameObject canalLeft;
    public GameObject canalRight;
    public GameObject canalDown;
    public GameObject canalUp;

    [SerializeField] private Door[] _doors;

    [SerializeField] private EnemyBehavior[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform unitsParent;
    
    private void Start()
    {
        _roomEventHandler.OnPlayerEntered += SpawnEnemies;
    }

    private void SpawnEnemies()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            var rand = Random.Range(0, enemies.Length);
            var enemy = Instantiate(enemies[rand], spawnPoint.position, Quaternion.identity);
            enemy.transform.SetParent(unitsParent);
        }
    }

}
