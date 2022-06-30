using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EL.Dungeon
{
    [System.Serializable]
    public class Volume : MonoBehaviour
    {
        // Vector 3 used for Generator Size
        public Vector3 generatorSize = new Vector3(1f, 1f, 1f);
        // pulls infromation about the voxels 
        public List<GameObject> voxels = new List<GameObject>();
        // bool used to draw Volume
        public static bool drawVolume = false;
         
        public GameObject gameObjectContainer;
        // create Bounds for all the prefabs 
        public Bounds bounds;
        // scale for Voxels set as 10
        public float voxelScale = 10f;


        public void OnDrawGizmos()
        {
            //draws the Volume that creates a cube that used bounds for the prefabs informaion is key to stop overlapping of objects later on
            if (!drawVolume)
            {
                if (bounds == null) return;
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(bounds.center, bounds.size);
            }
            else
            {
                if (gameObjectContainer == null) return;
                for (int i = 0; i < gameObjectContainer.transform.childCount; i++)
                {
                    Gizmos.color = Color.white;
                    Gizmos.DrawWireCube(gameObjectContainer.transform.GetChild(i).transform.position, Vector3.one * voxelScale);
                }
            }
        }


        [ContextMenu("Generate Voxel Grid")]
        public void GenerateVoxelGrid()
        {
            if (voxels.Count != 0)
            {
                for (int i = 0; i < voxels.Count; i++)
                {
                    DestroyImmediate(voxels[i]);
                }
            }

            if (gameObjectContainer == null)
            {
                //Container is used to store the Voxels as whole into a container
                gameObjectContainer = new GameObject("Voxels");
                gameObjectContainer.transform.parent = this.transform;
            }

            voxels = new List<GameObject>();
            for (int i = 0; i < generatorSize.x; i++)
            {
                for (int j = 0; j < generatorSize.y; j++)
                {
                    for (int k = 0; k < generatorSize.z; k++)
                    {
                        CreateVoxel(i * (int)voxelScale,
                                    j * (int)voxelScale,
                                    k * (int)voxelScale);
                    }
                }
            }
        }

        private void CreateVoxel(int i, int j, int k)
        {
            GameObject voxel = new GameObject(string.Format("Voxel - ({0}, {1}, {2})", i, j, k));
            voxel.transform.position = new Vector3(i, j, k);
            voxel.transform.parent = gameObjectContainer.transform;
        }

        [ContextMenu("Assign Voxels")]
        public void AssignVoxelsToList()
        {

            // Creating new Vector that pulls information of childs X,Y,Z positions min amount 
            Vector3 min = new Vector3(gameObjectContainer.transform.GetChild(0).transform.position.x,
                                            gameObjectContainer.transform.GetChild(0).transform.position.y,
                                            gameObjectContainer.transform.GetChild(0).transform.position.z);
            // creating new Vector that pulls information of the child X,Y,Z postions max amount
            Vector3 max = new Vector3(gameObjectContainer.transform.GetChild(0).transform.position.x,
                                            gameObjectContainer.transform.GetChild(0).transform.position.y,
                                            gameObjectContainer.transform.GetChild(0).transform.position.z);

            for (int i = 0; i < gameObjectContainer.transform.childCount; i++)
            {
                // turns all the voxels as child of the container that is used and uses vector3 for the postions of each voxels
                voxels.Add(gameObjectContainer.transform.GetChild(i).gameObject);
                Vector3 pos = gameObjectContainer.transform.GetChild(i).transform.position;
                // if statements for curent postion less than min and displays the min as the postion of voxel
                if (pos.x < min.x) min.x = pos.x;
                if (pos.y < min.y) min.y = pos.y;
                if (pos.z < min.z) min.z = pos.z;
                // if statement checking pos X,Y,Z more than Max and display Max to the postion 
                if (pos.x > max.x) max.x = pos.x;
                if (pos.y > max.y) max.y = pos.y;
                if (pos.z > max.z) max.z = pos.z;
            }

            Debug.Log("Voxel::AssignVoxelsToList() | " + min + " : " + max);
            // size of the vector is 0.5 times it by the VoxelScale on all three axises
            Vector3 size = new Vector3(0.5f * voxelScale, 0.5f * voxelScale, 0.5f * voxelScale);
            // creating the Bounds around the prefab plus the size it needs to be as well
            bounds = new Bounds((min + max) / 2f, ((max + size) - (min - size)));
        }

        // Void that recalculate the bounds of the prefab 
        public void RecalculateBounds()
        {
            // gets the min vector for X,Y,Z axises 
            Vector3 min = new Vector3(voxels[0].transform.position.x,
                                      voxels[0].transform.position.y,
                                      voxels[0].transform.position.z);
            // gets the max vector from X,y,z
            Vector3 max = new Vector3(voxels[0].transform.position.x,
                                      voxels[0].transform.position.y,
                                      voxels[0].transform.position.z);

            for (int i = 0; i < voxels.Count; i++)
            {
                Vector3 pos = voxels[i].transform.position;
                // checks the postion and turns min into the position on each axies 
                if (pos.x < min.x) min.x = pos.x;
                if (pos.y < min.y) min.y = pos.y;
                if (pos.z < min.z) min.z = pos.z;
                // checks the postion more than max and changes max into the position on each axies 
                if (pos.x > max.x) max.x = pos.x;
                if (pos.y > max.y) max.y = pos.y;
                if (pos.z > max.z) max.z = pos.z;
            }

            
            // creates the bounds again after recalculate the bounds 
            Vector3 size = new Vector3(0.5f * voxelScale, 0.5f * voxelScale, 0.5f * voxelScale);
            bounds = new Bounds((min + max) / 2f, ((max + size) - (min - size)));
        }

        [ContextMenu("Toggle Gizmo Mode")]
        public void ToggleGizmoToDraw()
        {
            Volume.drawVolume = !Volume.drawVolume;
        }
    }
}
