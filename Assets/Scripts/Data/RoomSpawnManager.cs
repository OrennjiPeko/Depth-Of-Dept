using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class RoomSpawnManager : ScriptableObject
{
    // Room spawn Manager
    public List<RoomSpawnData> EnemySpawnLocations = new List<RoomSpawnData>();
}
