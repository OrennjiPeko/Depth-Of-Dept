using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Namespace is used through out the scripts used for Dungeon generator
namespace EL.Dungeon
{
    public class Room : MonoBehaviour
    {
        // Publis ist to generator of Door/doors.
        public List<EL.Dungeon.GeneratorDoor> doors;

     

        void Start()
        {
            //pulls information for Dungeon Generator called rooms called start 
            DungeonGenerator.roomsCalledStart++;
            // pass information back to us show the generator has started 
            Debug.Log("START");


        }

        // OnDrawGizmos is used to draw the edges for prefabs and uses rays to displays information in the scene to show us the different section for the prefabs and how the rooms are built viewing the prefabs and the scene after they are built. 
        private void OnDrawGizmos()
        {
            for (int i = 0; i < doors.Count; i++)
            {
                // The Red colour is used to draw the all sides of the prefab from the top to the bottom and sides
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(doors[i].transform.position, 0.1f);

                Gizmos.DrawRay(new Ray(doors[i].transform.position, doors[i].transform.right));
                // green Colour is used to draw above the floor and the bottom sections of the prefab of the room temeplate
                Gizmos.color = Color.green;
                Gizmos.DrawRay(new Ray(doors[i].transform.position, doors[i].transform.up));
                // blue is used for the sides of the floor around the same height as the green colour overlapping
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(new Ray(doors[i].transform.position, doors[i].transform.forward));
            }
        }

        // Generator Door gets a random door from (DRandom random)
        public GeneratorDoor GetRandomDoor(DRandom random)
        {
            // Door shuffle is to get a random location from the prefab and gets open door open and returns doors 
            doors.Shuffle(random.random);
            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].open) return doors[i];
            }
            // catchs an Errpr log if it can't find no open doors
            Debug.LogError("Room::GetRandomDoor() - No open doors...");
            return null;
        }

        // Public bool to check if there has an open doors
        public bool hasOpenDoors()
        {
            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].open) return true;
            }
            return false;
        }

        // GetFirstOpenDoor is another check for the room that uses the doors locations in the prefabs for door
        public GeneratorDoor GetFirstOpenDoor()
        {
            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].open) return doors[i];
            }
            Debug.LogError("Room::GetFirstOpenDoor() - No open doors...");
            return null;
        }
    }
}

