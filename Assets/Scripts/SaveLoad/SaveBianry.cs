using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public static class SaveBianry 
{
    public static void SavePlayer(PlayerData Player)
    {
        //Creates a formatter to convert information to binary
        BinaryFormatter formatter = new BinaryFormatter();
        //Creates a path to the file location
        string path = Application.persistentDataPath + "/Player.data";
        //Creates the filestream to where the information will be stored
        FileStream stream = new FileStream(path, FileMode.Create);
        //Saves the player's information to the file
        SaveSystem data = new SaveSystem(Player);

        //Sends the information to the file location
        formatter.Serialize(stream, data);
        //Closes the filestream
        stream.Close();
    }

    public static SaveSystem LoadPlayer()
    {
        //Creates a path to the file location
        string path = Application.persistentDataPath + "/Player.data";
        //checks if the path exists
        if (File.Exists(path))
        {
            //Creates a formatter to load information
            BinaryFormatter formatter = new BinaryFormatter();
            //Opens the path to the file where the information stored
            FileStream stream = new FileStream(path, FileMode.Open);

            //pulls the information from the file
            SaveSystem data = formatter.Deserialize(stream) as SaveSystem;

            //Closes the filestream
            stream.Close();

            //Returns the information
            return data;
        }
        else
        {
            //Doesn't return any information if the file isn't there
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteData()
    {
        File.Delete(Application.persistentDataPath + "/Player.data");
        new FileStream(Application.persistentDataPath + "/Player.data", FileMode.Create);
    }
}
