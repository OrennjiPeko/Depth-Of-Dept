using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EL.Dungeon
{
    [CreateAssetMenu]
    public class DungeonData : ScriptableObject
    {
        // create a public List called Dungoen set that uses scriptableObejct as template. 
        public List<DungeonSet> sets = new List<DungeonSet>();

    }
}

