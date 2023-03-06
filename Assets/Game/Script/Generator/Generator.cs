using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    [SerializeField] private Room[] _roomPrefabs;
    [SerializeField] private Room[] rewardRooms;
    [SerializeField] private Room startRoom;
    private Room[,] spawnedRooms;

    [SerializeField] private Vector2Int dungeonSize;
    [SerializeField] private Vector2Int startRoomPos;
    [SerializeField] private float roomSpacesSize;

    [SerializeField] private NavMeshSurface _navMeshSurface;


    private void Awake()
    {
        spawnedRooms = new Room[dungeonSize.x,dungeonSize.y];
        spawnedRooms[startRoomPos.x, startRoomPos.y] = startRoom;
        Generate();
        _navMeshSurface.BuildNavMesh();
    }

    private void Generate()
    {
            for (int i = 0; i < 12; i++)
            {
                PlaceOneRoom();
            }
    }

    void PlaceOneRoom()
    {
        var maxX = spawnedRooms.GetLength(0) - 1;
        var maxY = spawnedRooms.GetLength(1) - 1;
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x,y] == null) continue;
                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        var randomRoomI = Random.Range(0, _roomPrefabs.Length);
        var newRoom = Instantiate(_roomPrefabs[randomRoomI]);
        var randomRoomPos = Random.Range(0, vacantPlaces.Count);
        var pos = vacantPlaces.ElementAt(randomRoomPos);
        newRoom.transform.position = new Vector3((pos.x - 5)* roomSpacesSize, transform.position.y, (pos.y - 5)* roomSpacesSize) ;
        spawnedRooms[pos.x, pos.y] = newRoom;
        newRoom.transform.SetParent(transform);
        ConnectToOther(newRoom,pos);

    }

    private void ConnectToOther(Room room,Vector2Int pos)
    {
        var maxX = spawnedRooms.GetLength(0) - 1;
        var maxY = spawnedRooms.GetLength(1) - 1;
        List<Vector2Int> neighbors = new List<Vector2Int>();
        if (room.canalUp != null && pos.y + 1 < maxY && spawnedRooms[pos.x,pos.y + 1]?.canalDown != null) neighbors.Add(Vector2Int.up);
        if (room.canalDown != null && pos.y - 1 > 0 && spawnedRooms[pos.x,pos.y - 1]?.canalUp != null) neighbors.Add(Vector2Int.down);
        if (room.canalRight != null && pos.x + 1 < maxX && spawnedRooms[pos.x + 1,pos.y]?.canalLeft != null) neighbors.Add(Vector2Int.right);
        if (room.canalLeft != null && pos.x - 1 > 0 && spawnedRooms[pos.x - 1,pos.y]?.canalRight != null) neighbors.Add(Vector2Int.left);

        foreach (var neighbor in neighbors)
        {
            if (neighbor == Vector2Int.up)
            {
                room.canalUp.SetActive(false);
                spawnedRooms[pos.x,pos.y + 1].canalDown.SetActive(false);
                continue;
            }
            if (neighbor == Vector2Int.down)
            {
                room.canalDown.SetActive(false);
                spawnedRooms[pos.x,pos.y - 1].canalUp.SetActive(false);
                continue;
            }
            if (neighbor == Vector2Int.right)
            {
                room.canalRight.SetActive(false);
                spawnedRooms[pos.x + 1,pos.y].canalLeft.SetActive(false);
                continue;
            }
            if (neighbor == Vector2Int.left)
            {
                room.canalLeft.SetActive(false);
                spawnedRooms[pos.x - 1,pos.y].canalRight.SetActive(false);
                continue;
            }
        }
    }
}
