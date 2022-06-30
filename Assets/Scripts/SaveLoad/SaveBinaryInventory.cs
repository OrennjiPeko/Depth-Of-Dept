using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveBinaryInventory 
{
    public static void SaveInvenotry(SaveplayerInventory saveplayerInventory)
    {
        //Creates new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //Creates a string to locate where the information will be saved
        string path = Application.persistentDataPath + "/PlayerInventory.data";
        //Finds the file where the information will be stored
        FileStream stream = new FileStream(path, FileMode.Create);
        //Gains the save system data that will be stored on the disk
        SaveSystem data = new SaveSystem(saveplayerInventory);

        //Formats the information into binary
        formatter.Serialize(stream, data);
        //Closes the stream to where the files are stored
        stream.Close();
    }

    public static SaveSystem LoadInventory()
    {
        //Locates the inventory binary
        string path = Application.persistentDataPath + "/PlayerInventory.data";
        //Checks if the file exists
        if (File.Exists(path)){
            //Creates binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //Finds the file where the information is stored
            FileStream stream = new FileStream(path, FileMode.Open);
            //Deserializes the information to make it readable
            SaveSystem data = formatter.Deserialize(stream) as SaveSystem;
            //closes stream to where the files where stored
            stream.Close();

            //Returns the information to the project
            return data;
        }
        else
        {
            //Displays error if file not located
            Debug.LogError("Save Inventory file not found in " + path);
            //Returns nothing
            return null;
        }
    }
    public static void DeleteInventory()
    {
        File.Delete(Application.persistentDataPath + "/PlayerInventory.data");
        new FileStream(Application.persistentDataPath + "/PlayerInventory.data", FileMode.Create);
    }
}
