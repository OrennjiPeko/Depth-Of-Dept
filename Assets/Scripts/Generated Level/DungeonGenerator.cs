using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EL.Dungeon;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
#if Unity_Editor
using UnityEditor;
#endif

public class DungeonGenerator : MonoBehaviour
{
    // pulls information form Dungeon Data script
    public EL.Dungeon.DungeonData data;
    // dungeon set
    public int dungeonSet = 0;
    // displays the seed in the script inspector 
    public int seed = 0;
    //check if they have been ticked in the Inspector 
    public bool randomizeSeedOnStart = true;
    public bool randomizeRoomSize = true;
    // creates DRandom
    public DRandom random;
    // bool that set false at the start used later on in the script
    public bool generationComplete = false;
    // the target Room we want the generator to create and the room count that displayed during testing
    public int targetRooms = 30;
    public int roomsCount;
    // create List string parts used later on in the script
    private List<string> parts = new List<string>();
    // gets Room and Door list in the script
    public List<Room> rooms = new List<Room>();
    public List<Door> doors = new List<Door>();

    public float voxelPixelSize = 10f;
    //creates openset in Room
    public List<EL.Dungeon.Room> openSet = new List<EL.Dungeon.Room>();
    //Dictinary used to get information 
    public Dictionary<Vector3, GameObject> globalVoxels = new Dictionary<Vector3, GameObject>();
    // create a new gameobject called doorVoxelsTest
    public List<GameObject> doorVoxelsTest = new List<GameObject>();
    // gets the start room and static int called roomCalledStart as 0.
    public GameObject startRoom;
    public static int roomsCalledStart = 0;
    // public bool to display generated with timer in the console 
    public bool generateWithTimer = true;

    
    public bool Exit = true;
    

    //NavMesh 
    public NavMeshSurface Surface;

    void Start()
    {

        if (randomizeSeedOnStart)
        {
            // gets seed and create value from 0 to any random number it can choose
            seed = Random.Range(0, int.MaxValue);
        }
        // random is DRandom
        random = new DRandom();
        //uses init to get the seed after creating the number 
        random.Init(seed);

        if (randomizeRoomSize)
        {
            // uses randomize room size tick to get a targeted room add the random value 
            targetRooms = 30 + (int)(random.value() * 30f);
        }

        roomsCount = 0;
        globalVoxels = new Dictionary<Vector3, GameObject>();
        dungeonSet = random.range(0, data.sets.Count - 1);
        

        // starts to generation of the level
        StartGeneration();


    }
    private void StartGeneration()
    {
        //starts the DeBug Timer
        DDebugTimer.Start();
        //set the generation complete as false
        generationComplete = false;
        //goes to room list and doors list
        rooms = new List<Room>();
        doors = new List<Door>();
        //spawwns the dungoen from getting temeplates from dungeon sets
        int spawn = random.range(0, data.sets[dungeonSet].spawns.Count - 1);
        // gets the game objects and spawning objects from the temeplate from data 
        GameObject room = (GameObject)Instantiate(data.sets[dungeonSet].spawns[spawn].gameObject);
        
        //gets the start room for the player
        startRoom = room;
        
        
        // starts to add rooms to the start room
        rooms.Add(room.GetComponent<Room>());
        room.transform.parent = this.gameObject.transform;
        //pulls Open set from Dungeon room
        openSet.Add(room.GetComponent<EL.Dungeon.Room>());
        //gets the Volume from Room script and recalculate bounds
        room.GetComponent<Volume>().RecalculateBounds();
        // gets Volume voxels that are set in the script to add global voxels
        AddGlobalVoxels(room.GetComponent<Volume>().voxels);
        //adds to the room
        roomsCount++;

        // Magic of a while loop 
        while (openSet.Count > 0)
        {
            // starts Generate Next Room code
            GenerateNextRoom();
        }

        //process doors
        for (int i = 0; i < rooms.Count; i++)
        {
            for (int j = 0; j < rooms[i].doors.Count; j++)
            {
                if (rooms[i].doors[j].door == null)
                {
                    // creates the door and spawn them in the correct location
                    Door d = ((GameObject)Instantiate(data.sets[dungeonSet].doors[0].gameObject)).GetComponent<Door>();
                    doors.Add(d);
                    rooms[i].doors[j].door = d;
                    rooms[i].doors[j].sharedDoor.door = d;
                    // gets the door and set it's position and rotation
                    d.gameObject.transform.position = rooms[i].doors[j].transform.position;
                    d.gameObject.transform.rotation = rooms[i].doors[j].transform.rotation;
                    d.gameObject.transform.parent = this.gameObject.transform;
                }
            }
        }
        if (roomsCount <= 10)
        {
            SceneManager.LoadScene("RandomLevelBuild");
        }
        // chances the if statement to true
        generationComplete = true;
        Surface.BuildNavMesh(); //bakes our little room of magic 
        //displays the timer in ms 
        Debug.Log("DungeonGenerator::Generation completed : " + DDebugTimer.Lap() + "ms");

    }

    private void GenerateNextRoom()
    {
        // gets the last room that equals to start room and getting the Room Script
        Room lastRoom = startRoom.GetComponent<Room>();
        
        
        // if statment that gets the open count and checking more than 0 and getting the open set
        if (openSet.Count > 0) lastRoom = openSet[0];
        

        //create a mutiable list of all possible rooms
        List<Room> possibleRooms = new List<Room>();
        for (int i = 0; i < data.sets[dungeonSet].roomTemplates.Count; i++)
        {
            // starts adding the room in the generator object
            possibleRooms.Add(data.sets[dungeonSet].roomTemplates[i]);
        }
        // shuffles the rooms to be random
        possibleRooms.Shuffle(random.random);
        // gets the new room and Generator of door script
        GameObject newRoom;
        GeneratorDoor door;
        // bool to check if the room is good
        bool roomIsGood = false;
        // magic of Do Loop
        do
        {
            for (int i = 0; i < doorVoxelsTest.Count; i++)
            {
                // ends the door Voxels Test gameobject
                GameObject.DestroyImmediate(doorVoxelsTest[i]);
            }
            // clans the door Voxels Test
            doorVoxelsTest.Clear();

           
            if (roomsCount >= targetRooms)
            {
                // Adds the end rooms for target reached
                possibleRooms = GetAllRoomsWithOneDoor(possibleRooms);

            }
        



            //If we picked a room with with one door, try again UNLESS we've have no other rooms to try
            int doors = 0;
            bool tryAgain = false;
            // use RoomToTry as possible rooms
            GameObject roomToTry;
            //creates a int variable and setting up with random range and the possible room taking 1 away 
            int r = random.range(0, possibleRooms.Count - 1);
            roomToTry = possibleRooms[r].gameObject;
            doors = roomToTry.GetComponent<Room>().doors.Count;

            if (doors == 1 && possibleRooms.Count > 1)
            {
                //we're adding a room with one door when we have other's we could try first.
                float chance = 1f - Mathf.Sqrt(((float)roomsCount / (float)targetRooms)); //the closer we are to target the less of a chance of changing rooms
                float randomValue = random.value();
                // checking the ranomd value is less than chance
                if (randomValue < chance)
                {
                    r = random.range(0, possibleRooms.Count - 1);
                    roomToTry = possibleRooms[r].gameObject;

                    doors = roomToTry.GetComponent<Room>().doors.Count;
                    if (doors == 1 && possibleRooms.Count > 1)
                    {
                        // second around for randomValue and chance 
                        float chance2 = 1f - Mathf.Sqrt(((float)roomsCount / (float)targetRooms)); //the closer we are to target the less of a chance of changing rooms
                        float randomValue2 = random.value();
                        if (randomValue2 < chance2)
                        {
                            r = random.range(0, possibleRooms.Count - 1);
                            roomToTry = possibleRooms[r].gameObject;
                        }
                        else
                        {
                            // oh well time to try again
                        }

                    }
                }
                else
                {
                    // oh well part 99
                }
            }
            // removes r objects 
            possibleRooms.RemoveAt(r);
            // creates the room with room to try
            newRoom = (GameObject)Instantiate(roomToTry);
            newRoom.transform.parent = this.gameObject.transform;
            // connect rooms with door
            door = ConnectRooms(lastRoom, newRoom.GetComponent<Room>());
            

            //room is now generated and in position. now we need to test overlapping!
            Volume v = newRoom.GetComponent<Volume>();
            Room ro = newRoom.GetComponent<Room>();
            // bool set to false for overlapping
            bool overlap = false;
            for (int i = 0; i < v.voxels.Count; i++)
            {
                if (globalVoxels.ContainsKey(RoundVec3ToInt(v.voxels[i].gameObject.transform.position)))
                {
                    
                    // overlap has been found... NOOOOOOOOOONOOOOOO
                    overlap = true;
                    continue;
                }

                for (int j = 0; j < openSet.Count; j++)
                {
                    for (int k = 0; k < openSet[j].doors.Count; k++)
                    {
                        //check if door is in the globalVoxelList
                        if (!openSet[j].doors[k].open) continue;
                        //we also want to ignore the Door we're connecting with
                        if (openSet[j].doors[k] == door) continue;
                        float rot = NormalizeAngle(Mathf.RoundToInt(openSet[j].doors[k].transform.rotation.eulerAngles.y));
                        Vector3 direction = new Vector3();
                        if (rot == 0)
                        {
                            direction = new Vector3(1f, 0f, 0f);
                        }
                        else if (rot == 180)
                        {
                            direction = new Vector3(-1f, 0f, 0f);
                        }
                        else if (rot == 90)
                        {
                            direction = new Vector3(0f, 0f, -1f);
                        }
                        else if (rot == 270)
                        {
                            direction = new Vector3(0f, 0f, 1f);
                        }
                        // create g as primitive type sphere
                        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        g.transform.position = openSet[j].doors[k].voxelOwner.transform.position + (direction * v.voxelScale);
                        g.GetComponent<Renderer>().material.color = Color.red;
                        doorVoxelsTest.Add(g);
                        if (RoundVec3ToInt(v.voxels[i].gameObject.transform.position) == RoundVec3ToInt(openSet[j].doors[k].voxelOwner.transform.position + (direction * v.voxelScale)))
                        {
                            overlap = true;
                            //Room has overlap with a door voxel neighbour 
                        }
                        else
                        {
                            //Room isn't overlapping with a door voxel neighbour
                            
                        }
                    }
                }
            }

            // bool hasspace benn set to true
            bool hasSpace = true;

            if (!overlap)
            {
                //NO overlap with the room and checking doors
                //check all the doors, and make sure there's at least a 1x1x1 voxel of air out of it
                //this will ensure we have room for a treasure room at least, and no doors will lead right into a wall!
                for (int i = 0; i < ro.doors.Count; i++)
                {
                    // find the direction the door is pointing in the world space of the scene
                    
                   
                    if (!ro.doors[i].open) continue; //check all open doors BUT the one we're connecting with..
                    if (ro.doors[i] == newRoom.GetComponent<Room>().GetFirstOpenDoor()) continue;
                    //Actually checking door
                    float rot = NormalizeAngle(Mathf.RoundToInt(ro.doors[i].transform.rotation.eulerAngles.y));
                    Vector3 direction = new Vector3();
                    if (rot == 0)
                    {
                        //checking +X facing axis 
                        direction = new Vector3(1f, 0f, 0f);
                    }
                    else if (rot == 180)
                    {
                        //checking -X facing axis
                        direction = new Vector3(-1f, 0f, 0f);
                    }
                    else if (rot == 90)
                    {
                        //checking -Z facing axis 
                        direction = new Vector3(0f, 0f, -1f);
                    }
                    else if (rot == 270)
                    {
                        //checking +Z facing axis 
                        direction = new Vector3(0f, 0f, 1f);
                    }
                    //Drawing spheres
                    GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    g.transform.position = ro.doors[i].voxelOwner.transform.position + (direction * v.voxelScale); 
                    doorVoxelsTest.Add(g);

                    if (globalVoxels.ContainsKey(RoundVec3ToInt(ro.doors[i].voxelOwner.transform.position + (direction * v.voxelScale))))
                    {
                        /*
                        The code is checking if we have collision on the door neighbours
                        */
                        hasSpace = false;
                        break;
                    }
                    else
                    {
                        /*
                         We are good time to move to the next step
                         checking doors aginst all other doors so that no door voxels overlpas with the other door voxel
                        */
                        for (int j = 0; j < openSet.Count; j++)
                        {
                            for (int k = 0; k < openSet[j].doors.Count; k++)
                            {
                                if (!openSet[j].doors[k].open) continue;
                                float rot2 = NormalizeAngle(Mathf.RoundToInt(openSet[j].doors[k].transform.rotation.eulerAngles.y));
                                Vector3 direction2 = new Vector3();
                                // rot2 is used as the good  side for the doors 
                                if (rot2 == 0)
                                {
                                    
                                    direction2 = new Vector3(1f, 0f, 0f);
                                }
                                else if (rot2 == 180)
                                {
                                    direction2 = new Vector3(-1f, 0f, 0f);
                                }
                                else if (rot2 == 90)
                                {
                                    direction2 = new Vector3(0f, 0f, -1f);
                                }
                                else if (rot2 == 270)
                                {
                                    direction2 = new Vector3(0f, 0f, 1f);
                                }

                                if (RoundVec3ToInt(ro.doors[i].voxelOwner.transform.position + (direction * v.voxelScale)) == RoundVec3ToInt(openSet[j].doors[k].voxelOwner.transform.position + (direction2 * v.voxelScale)))
                                {
                                    hasSpace = false;
                                    //TWo door voxels are overlapping!
                                    break;
                                }
                            }
                            if (!hasSpace) break;
                        }
                    }
                }
            }

            if (!overlap && hasSpace)
            {
                // all the prefabs fit perfectly 
                roomIsGood = true;
            }
            else
            {
                //Destroy the room Imdediate 
                GameObject.DestroyImmediate(newRoom);
                // Try another room, the current one doesn't fit/ work
                //destroy the room we just tried to place
            }
        } while (possibleRooms.Count > 0 && !roomIsGood);
        if (!roomIsGood)
        {
            //Mission Faild we get them next time 
            // shoudln't have this issue, just catch box just in case
            
        }
        else
        {
            // Generators other doors and gets FirstOpenDoor from room script 
            GeneratorDoor otherDoor = newRoom.GetComponent<Room>().GetFirstOpenDoor();
            door.sharedDoor = otherDoor;
            otherDoor.sharedDoor = door;

            door.open = false;
            newRoom.GetComponent<Room>().GetFirstOpenDoor().open = false;

            rooms.Add(newRoom.GetComponent<Room>());

            AddGlobalVoxels(newRoom.GetComponent<Volume>().voxels);
            if (!lastRoom.hasOpenDoors()) openSet.Remove(lastRoom);
            
            if (newRoom.GetComponent<Room>().hasOpenDoors()) openSet.Add(newRoom.GetComponent<Room>());
            roomsCount++;
        }
    }

    private float NormalizeAngle(int rotation)
    {
        while (rotation < 0)
        {
            rotation += 360;
        }
        while (rotation > 360)
        {
            rotation -= 360;
        }
        return rotation;
    }

    private Vector3 RoundVec3ToInt(Vector3 v)
    {
        return new Vector3(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
    }

    private void AddGlobalVoxels(List<GameObject> voxels)
    {
        for (int i = 0; i < voxels.Count; i++)
        {
            
            Vector3 position = RoundVec3ToInt(voxels[i].gameObject.transform.position);
            if (globalVoxels.ContainsKey(position))
            {
                //The Voxel we're trying to add to globalVoxels is already defined 
            }
            else
            {
                globalVoxels.Add(position, voxels[i]);
            }
        }
    }


    public List<Room> GetAllRoomsWithOneDoor(List<Room> list)
    {
        
        List<Room> roomsWithOneDoor = new List<Room>();
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].doors.Count == 1)
            {
                roomsWithOneDoor.Add(list[i]);
                
            }
        }
        return roomsWithOneDoor;
    }

    public GeneratorDoor ConnectRooms(Room lastRoom, Room newRoom)
    {
        GeneratorDoor lastRoomDoor = lastRoom.GetRandomDoor(random); //this is the "EXIT" door of the last room, which we want to connect to a new room
        GeneratorDoor newRoomDoor = newRoom.GetFirstOpenDoor(); //grabs the first open door to allow rooms to have flow

        newRoom.transform.rotation = Quaternion.AngleAxis((lastRoomDoor.transform.eulerAngles.y - newRoomDoor.transform.eulerAngles.y) + 180f, Vector3.up);
        Vector3 translate = lastRoomDoor.transform.position - newRoomDoor.transform.position;
        newRoom.transform.position += translate;
        newRoom.GetComponent<Volume>().RecalculateBounds();
        //calling this now to create a worldspace bounds based on the new position/rotation after alignment.
        //using the worldspace volume-grid later when making smarter dungeons that can not overlap.

        
        return lastRoomDoor;
        
    }
   

    public float timer = 0f;
    public float delayTime = 0.01f;

}
