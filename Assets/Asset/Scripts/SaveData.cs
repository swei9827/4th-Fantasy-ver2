using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveData : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    [ContextMenu("Save Stats")]
    public void SaveStats()
    {
        //PlayerStats p1Stats = new PlayerStats();
        //PlayerStats p2Stats = new PlayerStats();

        PlayerStats p1Stats = player1.GetComponent<PlayerStats>();
        PlayerStats p2Stats = player2.GetComponent<PlayerStats>();

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
        loadedData.players.Add(p2Stats);

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
