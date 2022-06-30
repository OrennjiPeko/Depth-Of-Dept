using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveBinaryInventoryRelic : MonoBehaviour
{
  public static void SaveRelicInventory(SaveInventoryRelic saveInventoryRelic)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerRelicInventory.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveSystem data = new SaveSystem(saveInventoryRelic);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static SaveSystem LoadRelicInventory()
    {
        string path = Application.persistentDataPath + "/PlayerRelicInventory.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveSystem data = formatter.Deserialize(stream) as SaveSystem;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save Relic Inventory not found in" + path);
            return null;
        }

    }
}
