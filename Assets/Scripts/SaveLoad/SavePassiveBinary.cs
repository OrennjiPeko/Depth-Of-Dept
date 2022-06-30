using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SavePassiveBinary
{
    public static void SavePassiveAbilities(PlayerCombat Passive)
    {
        //Creates new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //Creates a string to locate where the information will be saved
        string path = Application.persistentDataPath + "/PlayerPassiveAbilities.data";
        //Finds the file where the information will be stored
        FileStream stream = new FileStream(path, FileMode.Create);
        //Gains the save system data that will be stored on the disk
        SaveSystem data = new SaveSystem(Passive);

        //Formats the information into binary
        formatter.Serialize(stream, data);
        //Closes the stream to where the files are stored
        stream.Close();
    }

    public static SaveSystem LoadPassiveAbility()
    {
        //Locates the passive ability binary
        string path = Application.persistentDataPath + "/PlayerPassiveAbilities.data";
        //Checks if the file exists
        if (File.Exists(path))
        {
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
            Debug.LogError("Save Passive file not found in " + path);
            //Returns nothing
            return null;
        }
    }

    public static void DeleteAbilities()
    {
        File.Delete(Application.persistentDataPath + "/PlayerPassiveAbilites.data");
        new FileStream(Application.persistentDataPath + "/PlayerPassiveAbilites.data",FileMode.Create);
    }
}
