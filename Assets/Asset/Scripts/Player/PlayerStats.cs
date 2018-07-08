﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class PlayerStats : GeneralStats {

    public int aggro;

    public PlayerStats()
    {
        this.health = 400;
        this.aggro = 0;
    }

    [ContextMenu("Save Stats")]
    public void SaveStats()
    {
        //PlayerStats p1Stats = new PlayerStats();
        //PlayerStats p2Stats = new PlayerStats();

        PlayerStats p1Stats = new PlayerStats();

        PlayerList loadedData = this.LoadStats();

        /*if(loadedData.players[0] == null)
        {
            loadedData.players.Add(p1Stats);
        }
        else if(loadedData.players[0] != null)
        {
            loadedData.players[0] = p1Stats;
        }

        if(loadedData.players[1] == null)
        {
            loadedData.players.Add(p2Stats);
        }
        else if(loadedData.players[1] != null)
        {
            loadedData.players[1] = p2Stats;
        }*/

        loadedData.players.Add(p1Stats);

        // Convert our Stats class into a JSON string format
        string data = JsonUtility.ToJson(loadedData, true);

        Debug.Log(data);

        // Write and save our JSON string to a text file in a specific folder

        string path = Path.Combine(Application.streamingAssetsPath, "Stats");

        File.WriteAllText(path, data);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    [ContextMenu("Load Stats")]
    public PlayerList LoadStats()
    {
        Debug.Log("Loading Stats");
        PlayerList newList = new PlayerList();
        newList.players = new List<PlayerStats>();

        // get path to stats file
        string path = Path.Combine(Application.streamingAssetsPath, "Stats");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            newList = JsonUtility.FromJson<PlayerList>(json);
        }
        return newList;
    }
}

[Serializable]
public class PlayerList
{
    public List<PlayerStats> players;
}

