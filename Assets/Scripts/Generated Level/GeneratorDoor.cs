using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EL.Dungeon
{
    // This script is used in the Generator script and placed on each door with location of VoxelOwner set in prefab manauel entered 
    public class GeneratorDoor : MonoBehaviour
    {
        // checks open as true
        public bool open = true;
        // checks the game object from doors using Voxels locations that been set in the script in prefab door,1,2,3
        public GameObject voxelOwner;
        // create shared Doors that used later in the code
        public GeneratorDoor sharedDoor;
        // pulls the Door script that isn't used yet
        public Door door;
    }
}
