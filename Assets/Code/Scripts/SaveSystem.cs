﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.data";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        binary.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        var path = Application.persistentDataPath + "/level.data";
        if (!File.Exists(path)) return new PlayerData(1, new List<int>(), 50, DateTime.Now);
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);
        PlayerData data = binary.Deserialize(fileStream) as PlayerData;
        fileStream.Close();
        return data;
    }

    public static void Clear()
    {
        var path = Application.persistentDataPath + "/level.data";
        File.Delete(path);
    }
}