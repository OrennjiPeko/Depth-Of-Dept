using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EL.Dungeon {
    [CreateAssetMenu]
    public class DungeonSet : ScriptableObject
    {
        // public string for naming the scritptableObject
        public string name = "";
        // creates lists that will store prefabs for the player spawns and boss spawns that will be used in the game
        public List<Room> spawns = new List<Room>();
        
        // Doors that will block off locations the player can't go through 
        public List<Door> doors = new List<Door>();
        // stores all the Templates of rooms that can be used in the generator 
        public List<Room> roomTemplates = new List<Room>();

    }
}

